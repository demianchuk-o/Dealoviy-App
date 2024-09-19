<script setup lang="ts">
import parseServerErrors from "@/core/helpers/parse-server-errors";
import { password, required } from "@/core/validation-rules";
import { Session, useAuthStore } from "@/store/auth";
import { AxiosError } from "axios";
import { ref } from "vue";
import { useRouter } from "vue-router";

const router = useRouter();
const authStore = useAuthStore();

const signUpForm = ref({
  username: "",
  displayName: "",
  password: "",
});

const isSignUpFormValid = ref(false);
const signUpErrors = ref("");

const signUp = () => {
  if (!isSignUpFormValid.value) {
    return;
  }

  signUpErrors.value = "";

  authStore
    .signUp(signUpForm.value)
    .then((session?: Session) => {
      console.log("Session", session);
      router.push("/");
    })
    .catch((error: AxiosError<{ errors: object }>) => {
      signUpErrors.value = parseServerErrors(error);
      console.log("SignUp Error", error);
    });
};
</script>

<template>
  <v-row justify="center" align="center" class="h-100">
    <v-col cols="12" sm="6" md="4" lg="3" xl="3">
      <v-sheet elevation="3" class="pa-5">
        <v-form @submit.prevent="signUp" v-model="isSignUpFormValid">
          <v-row>
            <v-col cols="12">
              <h1 class="text-h6 text-center">Sign Up</h1>
            </v-col>
            <v-col cols="6">
              <v-text-field
                variant="outlined"
                density="compact"
                hide-details="auto"
                label="Username"
                :rules="[required]"
                v-model="signUpForm.username"
              ></v-text-field>
            </v-col>
            <v-col cols="6">
              <v-text-field
                variant="outlined"
                density="compact"
                hide-details="auto"
                label="Display name"
                v-model="signUpForm.displayName"
              ></v-text-field>
            </v-col>
            <v-col cols="12">
              <v-text-field
                variant="outlined"
                density="compact"
                hide-details="auto"
                label="Password"
                type="password"
                :rules="[required, password(8, 16)]"
                v-model="signUpForm.password"
              ></v-text-field>
            </v-col>
            <small
              v-show="signUpErrors.length"
              class="w-100 text-center text-error"
            >
              {{ signUpErrors }}
            </small>
            <v-col cols="12">
              <v-btn type="submit" block color="primary">Sign Up</v-btn>
            </v-col>
            <v-col cols="12" class="text-center">
              <a
                href="#"
                @click.prevent="$router.push('/signin')"
                class="text-medium-emphasis"
                >Have an account? Sign In!</a
              >
            </v-col>
          </v-row>
        </v-form>
      </v-sheet>
    </v-col>
  </v-row>
</template>

<style scoped></style>
