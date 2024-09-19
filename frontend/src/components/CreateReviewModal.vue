<script setup lang="ts">
import httpClient from "@/core/httpClient";
import { required } from "@/core/validation-rules";
import { ref } from "vue";

const props = defineProps<{
  serviceId: string;
}>();

const emit = defineEmits<{
  (e: "created"): void;
}>();

const showCreateReviewModal = ref(false);

type CreateReviewForm = {
  reviewText?: string;
  rating?: number;
};

const createReviewForm = ref<CreateReviewForm>({});
const isCreateReviewFormValid = ref(false);

const isLoading = ref(false);
const handleSubmit = () => {
  if (!isCreateReviewFormValid.value) {
    return;
  }

  isLoading.value = true;
  httpClient
    .post(`/services/${props.serviceId}/reviews`, createReviewForm.value)
    .finally(() => {
      isLoading.value = false;
      createReviewForm.value = {};
      showCreateReviewModal.value = false;
      emit("created");
    });
};
</script>

<template>
  <v-dialog max-width="600" v-model="showCreateReviewModal">
    <template v-slot:activator="{ props }">
      <v-btn v-bind="props" color="primary" text="Add review"> </v-btn>
    </template>

    <template v-slot:default="{ isActive }">
      <v-form
        @submit.prevent="handleSubmit"
        v-model="isCreateReviewFormValid"
        :disabled="isLoading"
      >
        <v-card title="Add new review" :loading="isLoading">
          <v-card-text>
            <v-row>
              <v-col cols="12">
                <v-text-field
                  variant="solo"
                  label="Comment"
                  class="mb-1"
                  :rules="[required]"
                  v-model="createReviewForm.reviewText"
                ></v-text-field>
                <v-rating
                  hover
                  :length="5"
                  :size="32"
                  active-color="primary"
                  v-model="createReviewForm.rating"
                />
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
