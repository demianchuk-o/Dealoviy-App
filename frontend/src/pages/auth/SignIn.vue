<script setup lang="ts">
import parseServerErrors from "@/core/helpers/parse-server-errors";
import { required } from "@/core/validation-rules";
import { Session, useAuthStore } from "@/store/auth";
import { AxiosError } from "axios";
import { ref } from "vue";
import { useRouter } from "vue-router";

const router = useRouter();
const authStore = useAuthStore();

const signInForm = ref({
  username: "",
  password: "",
});

const isSignInFormValid = ref(false);

const signInErrors = ref("");

const signIn = () => {
  if (!isSignInFormValid.value) {
    return;
  }

  signInErrors.value = "";

  authStore
    .signIn(signInForm.value)
    .then((session?: Session) => {
      console.log("Session", session);
      router.push("/");
    })
    .catch((error: AxiosError<{ errors: object }>) => {
      signInErrors.value = parseServerErrors(error);
      console.log("SignIn Error", error);
    });
};
</script>

<template>
  <v-row justify="center" align="center" class="h-100">
    <v-col cols="12" sm="6" md="4" lg="3" xl="3">
      <v-sheet elevation="3" class="pa-5">
        <v-form @submit.prevent="signIn" v-model="isSignInFormValid">
          <v-row>
            <v-col cols="12">
              <h1 class="text-h6 text-center">Sign In</h1>
            </v-col>
            <v-col cols="12">
              <v-text-field
                variant="outlined"
                density="compact"
                hide-details="auto"
                label="Login"
                :rules="[required]"
                v-model="signInForm.username"
              ></v-text-field>
            </v-col>
            <v-col cols="12">
              <v-text-field
                variant="outlined"
                density="compact"
                hide-details="auto"
                label="Password"
                type="password"
                :rules="[required]"
                v-model="signInForm.password"
              ></v-text-field>
            </v-col>
            <small
              v-show="signInErrors.length"
              class="w-100 text-center text-error"
            >
              {{ signInErrors }}
            </small>
            <v-col cols="12">
              <v-btn type="submit" block color="primary">Sign In</v-btn>
            </v-col>
            <v-col cols="12" class="text-center">
              <a
                href="#"
                @click.prevent="$router.push('/signup')"
                class="text-medium-emphasis"
                >Not have an account? Sign Up!</a
              >
            </v-col>
          </v-row>
        </v-form>
      </v-sheet>
    </v-col>
  </v-row>
</template>

<style scoped></style>
