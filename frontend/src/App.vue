<script setup lang="ts">
import { useRouter } from "vue-router";
import Notifications from "./components/Notifications.vue";
import { useAuthStore } from "./store/auth";

const router = useRouter();
const authStore = useAuthStore();

const handleSignOut = () => {
  authStore.signOut();
  router.push("/signin");
};
</script>

<template>
  <v-app>
    <v-app-bar elevation="0" border>
      <v-app-bar-title>
        <span class="cursor-pointer" @click="$router.push('/')">Dealoviy</span>
      </v-app-bar-title>

      <template v-slot:append>
        <div class="d-flex ga-5 me-5">
          <template v-if="authStore.isContractor">
            <v-btn
              color="primary"
              @click.prevent="$router.push('/my-services')"
            >
              My services
            </v-btn>
            <v-btn color="primary" @click.prevent="$router.push('/my-tasks')">
              My Tasks
            </v-btn>
          </template>
          <template v-else-if="authStore.isCustomer">
            <v-btn color="primary" @click.prevent="$router.push('/my-orders')">
              My orders
            </v-btn>
          </template>
        </div>

        <v-btn v-if="!authStore.isAuth" @click="$router.push('/signin')">
          Sign In
        </v-btn>
        <template v-else>
          <v-menu>
            <template v-slot:activator="{ props }">
              <v-btn variant="tonal" color="primary" v-bind="props">
                {{
                  authStore.session?.displayName || authStore.session?.userName
                }}
                <template v-slot:append>
                  <v-icon v-if="authStore.isContractor" size="x-large">
                    mdi-account-cash
                  </v-icon>
                  <v-icon v-else-if="authStore.isCustomer" size="x-large">
                    mdi-account
                  </v-icon>
                </template>
              </v-btn>
            </template>
            <v-list>
              <v-list-item
                link
                :base-color="authStore.isCustomer ? 'primary' : ''"
                @click="
                  authStore.selectRole('customer');
                  $router.push('/');
                "
              >
                Customer
              </v-list-item>
              <v-list-item
                v-if="authStore.session?.contractorProfileId"
                link
                :base-color="authStore.isContractor ? 'primary' : ''"
                @click="
                  authStore.selectRole('contractor');
                  $router.push('/');
                "
              >
                Contractor
              </v-list-item>
              <v-list-item
                v-else
                link
                @click="$router.push('/become-contractor')"
              >
                Become a contractor
              </v-list-item>
              <v-divider></v-divider>
              <!-- <v-list-item link> Edit profile </v-list-item> -->
              <v-divider></v-divider>
              <v-list-item>
                <v-btn color="primary" class="w-100" @click="handleSignOut">
                  Sign Out
                  <template v-slot:append>
                    <v-icon>mdi-logout</v-icon>
                  </template>
                </v-btn>
              </v-list-item>
            </v-list>
          </v-menu>
        </template>
      </template>
    </v-app-bar>

    <v-main>
      <router-view />
      <notifications />
    </v-main>
  </v-app>
</template>

<style scoped></style>
