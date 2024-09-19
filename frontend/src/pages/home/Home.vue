<script setup lang="ts">
import httpClient from "@/core/httpClient";
import { reactive, ref, watch } from "vue";
import { useRouter } from "vue-router";

const router = useRouter();

const regions = ref([]);
const cities = ref([]);

const searchServicesForm = reactive({
  regionId: null,
  cityId: null,
  serviceQuery: "",
});

const fetchRegions = async () => {
  httpClient.get("/regions").then((response) => {
    regions.value = response.data.map(
      (region: { id: string; name: string }) => ({
        title: region.name,
        value: region.id,
      })
    );
  });
};
const fetchCities = async () => {
  httpClient.get(`/cities/${searchServicesForm.regionId}`).then((response) => {
    cities.value = response.data.map(
      (region: { id: string; name: string }) => ({
        title: region.name,
        value: region.id,
      })
    );
  });
};

fetchRegions();

watch(
  () => searchServicesForm.regionId,
  () => {
    searchServicesForm.cityId = null;
    fetchCities();
  }
);

const handleSearch = () => {
  router.push({
    path: "/services",
    query: {
      keyword: searchServicesForm.serviceQuery,
      cityId: searchServicesForm.cityId,
    },
  });
};
</script>

<template>
  <v-container class="max-width-md">
    <v-form @submit.prevent="handleSearch">
      <v-row class="ga-0">
        <v-col cols="12">
          <h1 class="text-center">Start by searching for services</h1>
        </v-col>
        <v-col cols="12">
          <v-text-field
            variant="solo"
            hide-details="auto"
            label="Service name"
            v-model="searchServicesForm.serviceQuery"
          ></v-text-field>
        </v-col>
        <v-col cols="3" class="d-flex ga-5">
          <v-select
            variant="solo"
            label="Choose a region"
            v-model="searchServicesForm.regionId"
            :items="regions"
          >
            <template v-slot:item="{ props, item }">
              <v-list-item
                v-bind="props"
                :title="item.title"
                :value="item.value"
              ></v-list-item>
            </template>
          </v-select>
        </v-col>
        <v-col cols="3" class="d-flex ga-5">
          <v-select
            variant="solo"
            label="Choose a city"
            v-model="searchServicesForm.cityId"
            :items="cities"
            :disabled="!searchServicesForm.regionId"
          >
            <template v-slot:item="{ props, item }">
              <v-list-item
                v-bind="props"
                :title="item.title"
                :value="item.value"
              ></v-list-item>
            </template>
          </v-select>
        </v-col>
        <v-spacer></v-spacer>
        <v-col cols="auto">
          <v-btn type="submit" color="primary" size="x-large">Search</v-btn>
        </v-col>
      </v-row>
    </v-form>
  </v-container>
</template>

<style scoped></style>
