<script setup lang="ts">
import httpClient from "@/core/httpClient";
import { Service, ServiceOrder, ServiceRequest } from "@/types";
import { ref } from "vue";
import { useRoute } from "vue-router";

const route = useRoute();
const serviceId = route.params.id;

const service = ref<Service>();
const isServiceLoading = ref(false);
const fetchService = () => {
  isServiceLoading.value = true;
  return httpClient
    .get<Service>(`/services/${serviceId}`)
    .then((response) => {
      service.value = response.data;
    })
    .finally(() => {
      isServiceLoading.value = false;
    });
};
fetchService();

const servicesRequests = ref<ServiceRequest[]>([]);
const isRequestsLoading = ref(false);

const fetchServicesRequests = () => {
  isRequestsLoading.value = true;
  return httpClient
    .get<ServiceRequest[]>(`/services/${serviceId}/requests`)
    .then((response) => {
      servicesRequests.value = response.data;
    })
    .finally(() => {
      isRequestsLoading.value = false;
    });
};

fetchServicesRequests();

const servicesOrders = ref<ServiceOrder[]>();
const isServicesOrdersLoading = ref(false);

const fetchServicesOrders = () => {
  isServicesOrdersLoading.value = true;
  return httpClient
    .get<ServiceOrder[]>(`/services/${serviceId}/orders`)
    .then((response) => {
      servicesOrders.value = response.data;
    })
    .finally(() => {
      isServicesOrdersLoading.value = false;
    });
};
fetchServicesOrders();

const answerRequest = (requestId: string, decision: "accept" | "decline") => {
  httpClient.post(`/requests/${requestId}/${decision}`).then(() => {
    fetchServicesRequests();
    fetchServicesOrders();
  });
};

const changeOrderStatus = (orderId: string, status: "start" | "finish") => {
  httpClient.post(`/orders/${orderId}/${status}`).then(() => {
    fetchServicesOrders();
  });
};
</script>

<template>
  <v-container class="max-width-md">
    <v-row>
      <v-col v-show="isRequestsLoading || isServiceLoading" cols="12">
        <v-progress-linear indeterminate color="primary"></v-progress-linear>
      </v-col>
      <v-col cols="12">
        <h1 class="text-h5">
          Tasks for service:
          <a
            href="#"
            class="text-primary"
            @click.prevent="$router.push(`/service/${serviceId}`)"
          >
            {{ service?.name }}
          </a>
        </h1>
      </v-col>

      <v-col v-if="servicesRequests.length" cols="12">
        <h2 class="text-h6 mb-2">Requests</h2>
      </v-col>

      <v-row>
        <v-col cols="6" v-for="request in servicesRequests">
          <v-card>
            <template v-slot:prepend>
              <v-card-title>{{ request.customerName }}</v-card-title>
            </template>
            <template v-slot:append>
              <div class="d-flex ga-2">
                <v-btn
                  size="small"
                  icon="mdi-check"
                  @click="answerRequest(request.requestId, 'accept')"
                ></v-btn>
                <v-btn
                  size="small"
                  icon="mdi-cancel"
                  @click="answerRequest(request.requestId, 'decline')"
                ></v-btn>
              </div>
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
                <div class="text-h6">
                  {{ request.customerContactInfo.type }}:
                  {{ request.customerContactInfo.value }}
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
              <v-card-title>{{ order.customerName }}</v-card-title>
            </template>
            <v-card-text>
              <div class="d-flex justify-space-between ga-2 mb-2">
                <div>
                  {{ order.description }}
                </div>
                <div
                  class="d-flex flex-column justify-space-between align-end text-no-wrap"
                >
                  <div class="text-h5 text-primary">
                    ${{ order.paymentAmount }}
                  </div>
                  <div>{{ order.requestDate.split("T")[0] }}</div>
                </div>
              </div>
            </v-card-text>
            <v-card-actions>
              <div class="w-100">
                <div class="mb-2">
                  {{ order.orderStatus }}
                  <v-btn
                    variant="elevated"
                    size="sm"
                    color="#5865f2"
                    @click="
                      changeOrderStatus(
                        order.orderId,
                        order.orderStatus === 'NotStarted' ? 'start' : 'finish'
                      )
                    "
                    >{{
                      order.orderStatus === "NotStarted" ? "Start" : "Finish"
                    }}</v-btn
                  >
                </div>
                <v-divider class="mb-2"></v-divider>
                <div class="text-h6">
                  {{ order.customerContactInfo.type }}:
                  {{ order.customerContactInfo.value }}
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
