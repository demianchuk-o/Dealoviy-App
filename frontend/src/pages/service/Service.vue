<script setup lang="ts">
import CreateRequestModal from "@/components/CreateRequestModal.vue";
import CreateReviewModal from "@/components/CreateReviewModal.vue";
import httpClient from "@/core/httpClient";
import { useAuthStore } from "@/store/auth";
import { Contractor, Service, ServiceReview } from "@/types";
import { ref } from "vue";
import { useRoute } from "vue-router";

const route = useRoute();
const { id } = route.params;

const authStore = useAuthStore();

const service = ref<Service>();

const isServiceLoading = ref(false);

const fetchService = () => {
  isServiceLoading.value = true;
  return httpClient
    .get<Service>(`/services/${id}`)
    .then((response) => {
      service.value = response.data;
    })
    .finally(() => {
      isServiceLoading.value = false;
    });
};

const contractor = ref<Contractor>();
const isContractorLoading = ref(false);

const fetchContractor = () => {
  isContractorLoading.value = true;
  return httpClient
    .get<Contractor>(`/contractor-profiles/${service.value?.contractorId}`)
    .then((response) => {
      contractor.value = response.data;
    })
    .finally(() => {
      isContractorLoading.value = false;
    });
};

const reviews = ref<ServiceReview[]>();
const isReviewsLoading = ref(false);

const fetchReviews = () => {
  console.log("fetching reviews");
  isReviewsLoading.value = true;
  return httpClient
    .get<ServiceReview[]>(`/services/${service.value?.serviceId}/reviews`)
    .then((response) => {
      reviews.value = response.data;
    })
    .finally(() => {
      isReviewsLoading.value = false;
    });
};

const fetchInfo = async () => {
  await fetchService();
  await fetchContractor();
  await fetchReviews();
};

fetchInfo();
</script>

<template>
  <v-container class="max-width-md">
    <v-row>
      <v-col v-show="isServiceLoading" cols="12">
        <v-progress-linear indeterminate color="primary"></v-progress-linear>
      </v-col>
      <template v-if="service">
        <v-col cols="6" class="flex-grow-1">
          <h1>{{ service?.name }}</h1>
          <div class="mb-2">{{ service?.description }}</div>

          <div class="mb-1">
            <v-icon color="primary">mdi-map-marker</v-icon>
            {{ service?.cityName }}
          </div>

          <div class="text-primary text-h4 mb-1">
            ${{ service?.lowerPriceBound }}-{{ service?.upperPriceBound }}
          </div>
          <CreateRequestModal
            v-if="
              authStore.session?.contractorProfileId !== service.contractorId
            "
            :available-contact-types="contractor?.contactTypes"
            :service-id="service?.serviceId"
          />
        </v-col>

        <v-col cols="6">
          <v-card
            variant="outlined"
            :title="contractor?.name"
            prepend-icon="mdi-account"
          >
            <v-card-text>
              About myself: <br />
              {{ contractor?.additionalInfo }}
            </v-card-text>

            <v-card-actions class="d-flex ga-2">
              <v-chip
                v-for="contactType in contractor?.contactTypes"
                :text="contactType"
              />
            </v-card-actions>
          </v-card>
        </v-col>

        <v-col cols="12">
          <div class="text-h4">Average Rating</div>
          <v-rating
            readonly
            half-increments
            hover
            :length="5"
            :size="32"
            :model-value="service?.averageRating"
            active-color="primary"
          />
          <span>{{ service?.averageRating.toFixed(1) }}/5</span>

          <v-row>
            <v-col cols="6">
              <div class="d-flex mb-2">
                <div v-if="reviews?.length" class="text-h6">
                  Based on {{ reviews?.length }} reviews:
                </div>
                <div v-else class="text-h6">No reviews yet</div>
                <v-spacer></v-spacer>
                <create-review-modal
                  v-if="
                    authStore.session?.contractorProfileId !==
                    service.contractorId
                  "
                  :service-id="service?.serviceId"
                  @created="fetchReviews()"
                />
              </div>
              <v-row v-if="reviews?.length">
                <v-col cols="12" v-for="review in reviews">
                  <v-card variant="flat" :title="review.reviewerName">
                    <template v-slot:append>
                      <v-rating
                        readonly
                        half-increments
                        hover
                        :length="5"
                        :size="32"
                        :model-value="review.rating"
                        active-color="primary"
                      />
                    </template>

                    <v-card-text>
                      <div class="d-flex justify-space-between">
                        <div>
                          {{ review.reviewText }}
                        </div>
                        <div>{{ review.reviewDate.split("T")[0] }}</div>
                      </div>
                    </v-card-text>
                  </v-card>
                </v-col>
              </v-row>
            </v-col>
          </v-row>
        </v-col>
      </template>
      <v-col v-if="!service && !isServiceLoading" cols="12">
        Error!
        <a href="#" @click.prevent="$router.go(-1)">Go back</a>
      </v-col>
    </v-row>
  </v-container>
</template>

<style scoped></style>
