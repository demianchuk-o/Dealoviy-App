<script setup lang="ts">
import ServiceCard from "@/components/ServiceCard.vue";
import httpClient from "@/core/httpClient";
import { Service } from "@/types";
import { ref } from "vue";
import { useRoute } from "vue-router";
const route = useRoute();

const { cityId, keyword } = route.query;

type SearchServiceResponse = {
  services: Service[];
  totalCount: number;
  keyword: string;
  cityName: string;
};

const searchResponse = ref<SearchServiceResponse>();

const isLoading = ref(false);

const fetchServices = () => {
  isLoading.value = true;
  httpClient
    .get(`/services/search`, {
      params: {
        keyword,
        cityId,
      },
    })
    .then((response) => {
      searchResponse.value = response.data;
    })
    .finally(() => {
      isLoading.value = false;
    });
};
fetchServices();
</script>

<template>
  <v-container class="max-width-md">
    <v-row>
      <v-col cols="12">
        <h1 v-if="searchResponse?.services.length">
          Found {{ searchResponse?.services.length }}
          {{ searchResponse.keyword }} services in
          {{ searchResponse.cityName }}
        </h1>
        <template v-else>
          <h1>Services not found :(</h1>
          <a href="#" class="text-primary" @click.prevent="$router.push('/')"
            >Back to home page</a
          >
        </template>
      </v-col>
      <v-col v-show="isLoading" cols="12">
        <v-progress-linear indeterminate color="primary"></v-progress-linear>
      </v-col>
      <v-col
        v-for="service in searchResponse?.services"
        :key="service.serviceId"
        cols="12"
      >
        <service-card :service="service" />
      </v-col>
    </v-row>
  </v-container>
</template>

<style scoped></style>
