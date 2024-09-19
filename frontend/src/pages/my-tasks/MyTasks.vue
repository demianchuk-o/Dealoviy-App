<script setup lang="ts">
import httpClient from "@/core/httpClient";
import { ServiceStats } from "@/types";
import { ref } from "vue";

const myServicesStats = ref<ServiceStats[]>([]);
const isLoading = ref(false);

const fetchMyServicesStats = () => {
  isLoading.value = true;
  return httpClient
    .get<ServiceStats[]>("/serviceStats")
    .then((response) => {
      myServicesStats.value = response.data;
    })
    .finally(() => {
      isLoading.value = false;
    });
};

fetchMyServicesStats();
</script>

<template>
  <v-container class="max-width-md">
    <v-row>
      <v-col v-show="isLoading" cols="12">
        <v-progress-linear indeterminate color="primary"></v-progress-linear>
      </v-col>
      <v-col cols="12">
        <h1 class="text-h5 mb-2">Choose service:</h1>

        <v-row>
          <v-col cols="6" v-for="serviceStats in myServicesStats">
            <v-card variant="outlined">
              <v-card-title
                ><a
                  href="#"
                  class="text-primary"
                  @click.prevent="
                    $router.push(`/my-tasks/${serviceStats.serviceId}`)
                  "
                  >{{ serviceStats.serviceName }}</a
                ></v-card-title
              >
              <v-card-text>
                <p>
                  Requests to review: {{ serviceStats.pendingRequestsCount }}
                </p>
                <p>Requests to do: {{ serviceStats.notFinishedOrdersCount }}</p>
              </v-card-text>
            </v-card>
          </v-col>
        </v-row>
      </v-col>
    </v-row>
  </v-container>
</template>

<style scoped></style>
