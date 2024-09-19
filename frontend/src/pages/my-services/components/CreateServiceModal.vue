<script setup lang="ts">
import httpClient from "@/core/httpClient";
import { required } from "@/core/validation-rules";
import { ref, watch } from "vue";

const emit = defineEmits<{
  (e: "created"): void;
}>();

const showAddServiceModal = ref(false);

const regions = ref([]);
const cities = ref([]);

type CreateServiceForm = {
  name?: string;
  description?: string;
  regionId?: string;
  cityId?: string;
  lowerPriceBound?: number;
  upperPriceBound?: number;
};

const createServiceForm = ref<CreateServiceForm>({});

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
  httpClient
    .get(`/cities/${createServiceForm.value?.regionId}`)
    .then((response) => {
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
  () => createServiceForm.value?.regionId,
  () => {
    createServiceForm.value.cityId = undefined;
    if (createServiceForm.value.regionId) fetchCities();
  }
);

const isCreateServiceFormValid = ref(false);

const isLoading = ref(false);
const handleSubmit = () => {
  if (!isCreateServiceFormValid.value) return;

  isLoading.value = true;
  httpClient
    .post("/services", {
      cityId: createServiceForm.value.cityId,
      name: createServiceForm.value.name,
      Description: createServiceForm.value.description,
      lowerPriceBound: createServiceForm.value.lowerPriceBound,
      upperPriceBound: createServiceForm.value.upperPriceBound,
    })
    .then(() => {
      console.log("Service created successfully");
      emit("created");
    })
    .finally(() => {
      showAddServiceModal.value = false;
      isLoading.value = false;
      createServiceForm.value = {};
    });
};
</script>

<template>
  <v-dialog max-width="600" v-model="showAddServiceModal">
    <template v-slot:activator="{ props }">
      <v-btn v-bind="props" text="add new service"> </v-btn>
    </template>

    <template v-slot:default="{ isActive }">
      <v-form
        @submit.prevent="handleSubmit"
        v-model="isCreateServiceFormValid"
        :disabled="isLoading"
      >
        <v-card title="Add new service" :loading="isLoading">
          <v-card-text>
            <v-row>
              <v-col cols="12">
                <v-text-field
                  variant="solo"
                  label="Service name"
                  class="mb-1"
                  :rules="[required]"
                  v-model="createServiceForm.name"
                ></v-text-field>
                <v-textarea
                  variant="solo"
                  label="Description"
                  class="mb-1"
                  :rules="[required]"
                  v-model="createServiceForm.description"
                ></v-textarea>
                <v-select
                  variant="solo"
                  label="Region"
                  :rules="[required]"
                  :items="regions"
                  v-model="(createServiceForm.regionId as undefined)"
                >
                  <template v-slot:item="{ props, item }">
                    <v-list-item
                      v-bind="props"
                      :title="item.title"
                      :value="item.value"
                    ></v-list-item>
                  </template>
                </v-select>
                <v-select
                  variant="solo"
                  label="City"
                  :rules="[required]"
                  :items="cities"
                  v-model="(createServiceForm.cityId as undefined)"
                  :disabled="!createServiceForm.regionId"
                >
                  <template v-slot:item="{ props, item }">
                    <v-list-item
                      v-bind="props"
                      :title="item.title"
                      :value="item.value"
                    ></v-list-item>
                  </template>
                </v-select>

                <div class="d-flex">
                  <v-text-field
                    type="number"
                    variant="solo"
                    hide-details="auto"
                    prefix="$"
                    label="Min price"
                    :rules="[required]"
                    v-model="createServiceForm.lowerPriceBound"
                  ></v-text-field>
                  <div
                    class="d-flex align-center pa-2"
                    style="max-height: 56px"
                  >
                    <div style="height: 5px; width: 15px" class="bg-grey"></div>
                  </div>
                  <v-text-field
                    type="number"
                    variant="solo"
                    hide-details="auto"
                    prefix="$"
                    label="Max price"
                    :rules="[required]"
                    v-model="createServiceForm.upperPriceBound"
                  ></v-text-field>
                </div>
              </v-col>
            </v-row>
          </v-card-text>

          <v-card-actions>
            <v-spacer></v-spacer>

            <v-btn text="Close" @click="isActive.value = false"></v-btn>
            <v-btn type="submit" color="primary" text="Add service"></v-btn>
          </v-card-actions>
        </v-card>
      </v-form>
    </template>
  </v-dialog>
</template>

<style scoped></style>
