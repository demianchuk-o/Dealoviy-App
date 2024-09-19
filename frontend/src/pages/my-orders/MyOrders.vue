<script setup lang="ts">
import CreateReviewModal from "@/components/CreateReviewModal.vue";
import httpClient from "@/core/httpClient";
import { CustomerServiceOrder, CustomerServiceRequest } from "@/types";
import { ref } from "vue";

const servicesRequests = ref<CustomerServiceRequest[]>([]);
const isRequestsLoading = ref(false);

const fetchServicesRequests = () => {
  isRequestsLoading.value = true;
  return httpClient
    .get<CustomerServiceRequest[]>(`/users/requests`)
    .then((response) => {
      servicesRequests.value = response.data;
    })
    .finally(() => {
      isRequestsLoading.value = false;
    });
};

fetchServicesRequests();

const servicesOrders = ref<CustomerServiceOrder[]>();
const isServicesOrdersLoading = ref(false);

const fetchServicesOrders = () => {
  isServicesOrdersLoading.value = true;
  return httpClient
    .get<CustomerServiceOrder[]>(`/users/orders`)
    .then((response) => {
      servicesOrders.value = response.data;
    })
    .finally(() => {
      isServicesOrdersLoading.value = false;
    });
};
fetchServicesOrders();

const removeRequest = (requestId: string) => {
  httpClient.delete(`/requests/${requestId}`).then(() => {
    fetchServicesRequests();
    fetchServicesOrders();
  });
};
</script>

<template>
  <v-container class="max-width-md">
    <v-row>
      <v-col v-show="isRequestsLoading" cols="12">
        <v-progress-linear indeterminate color="primary"></v-progress-linear>
      </v-col>
      <v-col cols="12">
        <h1 class="text-h5">My tasks</h1>
      </v-col>

      <v-col v-if="servicesRequests.length" cols="12">
        <h2 class="text-h6 mb-2">Requests</h2>
      </v-col>

      <v-row>
        <v-col cols="6" v-for="request in servicesRequests">
          <v-card>
            <template v-slot:prepend>
              <v-card-title>{{ request.serviceName }}</v-card-title>
            </template>
            <template v-slot:append>
              <div>{{ request.requestStatus }}</div>
            </template>
            <v-card-text>
              <div class="d-flex justify-space-between ga-2 mb-2">
                <div>
                  {{ request.description }}
                </div>
                <div class="d-flex flex-column justify-space-between">
                  <div class="text-h5 text-primary">
                    ${{ request.paymentAmount }}
                  </div>
                  <div>{{ request.requestDate.split("T")[0] }}</div>
                </div>
              </div>
            </v-card-text>
            <v-card-actions>
              <div class="w-100">
                <v-divider class="mb-2"></v-divider>
                <div class="d-flex justify-space-between align-end">
                  <div>
                    <div class="text-h6">
                      {{ request.contractorName }}
                    </div>
                    <div class="text-h6">
                      {{ request.contractorContactInfo.type }}:
                      {{ request.contractorContactInfo.value }}
                    </div>
                  </div>
                  <div v-if="request.requestStatus === 'Declined'">
                    <v-btn color="red" @click="removeRequest(request.requestId)"
                      >Remove</v-btn
                    >
                  </div>
                </div>
              </div>
            </v-card-actions>
          </v-card>
        </v-col>
      </v-row>

      <v-col v-if="servicesOrders?.length" cols="12">
        <h2 class="text-h6 mb-2">Tasks</h2>
      </v-col>

      <v-row>
        <v-col cols="6" v-for="order in servicesOrders">
          <v-card>
            <template v-slot:prepend>
              <v-card-title>{{ order.serviceName }}</v-card-title>
            </template>
            <template v-slot:append>
              <div>{{ order.orderStatus }}</div>
            </template>
            <v-card-text>
              <div class="d-flex justify-space-between ga-2 mb-2">
                <div>
                  {{ order.description }}
                </div>
                <div class="d-flex flex-column justify-space-between">
                  <div class="text-h5 text-primary">
                    ${{ order.paymentAmount }}
                  </div>
                  <div>{{ order.requestDate.split("T")[0] }}</div>
                </div>
              </div>
            </v-card-text>
            <v-card-actions>
              <div class="w-100">
                <v-divider class="mb-2"></v-divider>
                <div class="d-flex justify-space-between align-end">
                  <div>
                    <div class="text-h6">
                      {{ order.contractorName }}
                    </div>
                    <div class="text-h6">
                      {{ order.contractorContactInfo.type }}:
                      {{ order.contractorContactInfo.value }}
                    </div>
                  </div>
                  <div v-if="order.orderStatus === 'Finished'">
                    <create-review-modal :service-id="order.serviceId" />
                  </div>
                </div>
              </div>
            </v-card-actions>
          </v-card>
        </v-col>
      </v-row>
    </v-row>
  </v-container>
</template>

<style scoped></style>
