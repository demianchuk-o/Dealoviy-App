<script setup lang="ts">
import httpClient from "@/core/httpClient";
import {
  required,
  requiredIf,
  tagContact,
  uaNumber,
} from "@/core/validation-rules";
import { ContractorContactType } from "@/types";
import { ref, watch } from "vue";

const props = withDefaults(
  defineProps<{
    availableContactTypes?: ContractorContactType[];
    serviceId: string;
  }>(),
  {
    availableContactTypes: () => ["Phone", "Telegram", "Viber", "WhatsApp"],
  }
);

const emit = defineEmits<{
  (e: "created"): void;
}>();

const showCreateRequestModal = ref(false);

type CreateRequestForm = {
  description?: string;
  customerContactInfo: {
    Type?: ContractorContactType;
    Value?: string;
  };
  paymentAmount?: number;
};

const createReviewForm = ref<CreateRequestForm>({
  customerContactInfo: {},
});

watch(
  () => createReviewForm.value.customerContactInfo.Type,
  () => {
    if (createReviewForm.value.customerContactInfo.Type === "Phone")
      createReviewForm.value.customerContactInfo.Value = "380";
    else createReviewForm.value.customerContactInfo.Value = "@";
  }
);

const isCreateRequestFormValid = ref(false);

const isLoading = ref(false);
const handleSubmit = () => {
  if (!isCreateRequestFormValid.value) {
    return;
  }

  isLoading.value = true;
  httpClient
    .post(`/services/${props.serviceId}/requests`, createReviewForm.value)
    .then(() => {
      showCreateRequestModal.value = false;
      createReviewForm.value = {
        customerContactInfo: {},
      };
      emit("created");
    })
    .finally(() => {
      isLoading.value = false;
    });
};
</script>

<template>
  <v-dialog max-width="600" v-model="showCreateRequestModal">
    <template v-slot:activator="{ props }">
      <v-btn color="primary" v-bind="props" text="Leave a request"> </v-btn>
    </template>

    <template v-slot:default="{ isActive }">
      <v-form
        @submit.prevent="handleSubmit"
        v-model="isCreateRequestFormValid"
        :disabled="isLoading"
      >
        <v-card title="Leave request" :loading="isLoading">
          <v-card-text>
            <v-row>
              <v-col cols="12">
                <v-textarea
                  variant="outlined"
                  label="Provide a short description of you situation"
                  :rules="[required]"
                  v-model="createReviewForm.description"
                ></v-textarea>
                <v-radio-group
                  :rules="[required]"
                  v-model="createReviewForm.customerContactInfo.Type"
                >
                  <template v-slot:label>
                    <div>Choose how to contact the contractor</div>
                  </template>

                  <v-radio
                    v-for="contactType in availableContactTypes"
                    :label="contactType"
                    :value="contactType"
                  ></v-radio>
                </v-radio-group>
                <v-text-field
                  v-if="createReviewForm.customerContactInfo.Type"
                  variant="solo"
                  :label="
                    createReviewForm.customerContactInfo.Type
                      ? `Enter your ${createReviewForm.customerContactInfo.Type} contact info`
                      : 'Choose contact type'
                  "
                  class="mb-1"
                  prepend-inner-icon="mdi-account-box-outline"
                  :prefix="
                    createReviewForm.customerContactInfo.Type === 'Phone'
                      ? '+'
                      : ''
                  "
                  :rules="[
                    required,
                    requiredIf(
                      () =>
                        createReviewForm.customerContactInfo.Type === 'Phone',
                      uaNumber
                    ),
                    requiredIf(
                      () =>
                        createReviewForm.customerContactInfo.Type ===
                        'Telegram',
                      tagContact
                    ),
                  ]"
                  validate-on="input lazy"
                  v-model="createReviewForm.customerContactInfo.Value"
                ></v-text-field>
                <v-text-field
                  type="number"
                  variant="solo"
                  label="How much you will pay?"
                  class="mb-1"
                  prepend-inner-icon="mdi-cash"
                  suffix="UAH"
                  :rules="[required]"
                  v-model="createReviewForm.paymentAmount"
                ></v-text-field>
              </v-col>
            </v-row>
          </v-card-text>

          <v-card-actions>
            <v-spacer></v-spacer>

            <v-btn text="Close" @click="isActive.value = false"></v-btn>
            <v-btn type="submit" color="primary" text="Leave request"></v-btn>
          </v-card-actions>
        </v-card>
      </v-form>
    </template>
  </v-dialog>
</template>

<style scoped></style>
