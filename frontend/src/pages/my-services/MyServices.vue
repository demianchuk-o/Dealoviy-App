<script setup lang="ts">
import ServiceCard from "@/components/ServiceCard.vue";
import httpClient from "@/core/httpClient";
import { Service } from "@/types";
import { ref } from "vue";
import CreateServiceModal from "./components/CreateServiceModal.vue";

const myServices = ref<Service[]>([]);
const isLoading = ref(false);

const fetchMyServices = () => {
  isLoading.value = true;
  return httpClient
    .get<Service[]>("/services")
    .then((response) => {
      myServices.value = response.data;
    })
    .finally(() => {
      isLoading.value = false;
    });
};

fetchMyServices();
</script>

<template>
  <v-container class="max-width-md">
    <v-row>
      <v-col cols="12">
        <h1>My services</h1>
        <!-- <v-btn @click="$router.push('/create-service')"
          >create new service</v-btn
        > -->
        <create-service-modal @submit="fetchMyServices" />
      </v-col>
      <v-col v-show="isLoading" cols="12">
        <v-progress-linear indeterminate color="primary"></v-progress-linear>
      </v-col>
      <v-col v-for="service in myServices" :key="service.serviceId" cols="6">
        <service-card :service="service" />
      </v-col>
    </v-row>
  </v-container>
</template>

<style scoped></style>
