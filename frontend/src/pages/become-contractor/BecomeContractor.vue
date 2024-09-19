<script setup lang="ts">
import httpClient from "@/core/httpClient";
import {
  required,
  requiredIf,
  tagContact,
  uaNumber,
} from "@/core/validation-rules";
import { useAuthStore } from "@/store/auth";
import { computed, reactive, ref, watch } from "vue";
import { useRouter } from "vue-router";

const router = useRouter();
const authStore = useAuthStore();

type ContactInfo = {
  type: "phone" | "telegram" | "whatsapp" | "viber";
  value: string;
};

const becomeContractorForm = reactive<{
  additionalInfo: string;
  contactInfos: ContactInfo[];
}>({
  additionalInfo: "",
  contactInfos: [],
});

const showAddContactModal = ref(false);
const addContactModalContactTypes = computed(() =>
  ["Phone", "Telegram", "WhatsApp", "Viber"].filter(
    (type) =>
      !becomeContractorForm.contactInfos.find(
        (contactInfo) => contactInfo.type === type
      )
  )
);

const addContactModalForm = ref<{
  type?: string;
  value?: string;
}>({});

watch(
  () => addContactModalForm.value.type,
  (type) => {
    if (type === "Phone") {
      addContactModalForm.value.value = "380";
    } else if (type === "Telegram") {
      addContactModalForm.value.value = "@";
    } else if (type === "WhatsApp") {
      addContactModalForm.value.value = "380";
    } else if (type === "Viber") {
      addContactModalForm.value.value = "380";
    }
  }
);

const isAddContactFormValid = ref(false);

const handleAddContact = () => {
  if (!isAddContactFormValid.value) {
    return;
  }

  becomeContractorForm.contactInfos.push({
    type: addContactModalForm.value.type,
    value: addContactModalForm.value.value,
  } as ContactInfo);

  addContactModalForm.value = {};
  showAddContactModal.value = false;
};

const handleRemoveContact = (type: ContactInfo["type"]) => {
  becomeContractorForm.contactInfos = becomeContractorForm.contactInfos.filter(
    (contactInfo) => contactInfo.type !== type
  );
};

const isContactInfosTouched = ref(false);
const isContactInfosNotFilled = computed(
  () => isContactInfosTouched.value && !becomeContractorForm.contactInfos.length
);

const isLoading = ref(false);

const handleSubmit = () => {
  isContactInfosTouched.value = true;

  if (isContactInfosNotFilled.value) {
    return;
  }

  isLoading.value = true;

  httpClient
    .post("/contractor-profiles", becomeContractorForm)
    .then(() => {
      authStore.signOut();
      router.push("/signin");
      isLoading.value = false;
    })
    .finally(() => {
      isLoading.value = false;
    });
};
</script>

<template>
  <v-container>
    <v-form @submit.prevent="handleSubmit" :disabled="isLoading">
      <v-row>
        <v-col cols="12">
          <h1>Become a contractor</h1>
        </v-col>
        <v-col cols="12">
          <h2>Tell a bit about yourself:</h2>
          <v-textarea variant="solo" hide-details="auto" label="I love mom..." :rules="[required]"
            v-model="becomeContractorForm.additionalInfo"></v-textarea>
        </v-col>
        <v-col cols="12">
          <h2>Your contact info</h2>

          <span :class="{ 'text-error': isContactInfosNotFilled }">
            Revise and edit your contact information for users to know how to
            reach out to you {{ isContactInfosNotFilled }}
          </span>

          <v-list v-for="contact in becomeContractorForm.contactInfos">
            <v-list-item :title="contact.type" :subtitle="contact.value">
              <template v-slot:title="{ title }">
                {{ title }}
              </template>
              <template v-slot:prepend>
                <v-btn size="x-small" icon="mdi-close" class="me-2" @click="handleRemoveContact(contact.type)"
                  :disabled="isLoading"></v-btn>
              </template>
            </v-list-item>
          </v-list>
        </v-col>
        <v-col cols="12" class="d-flex">
          <v-dialog max-width="600" v-model="showAddContactModal">
            <template v-if="addContactModalContactTypes.length" v-slot:activator="{ props }">
              <v-btn v-bind="props" text="add contact" :disabled="isLoading">
              </v-btn>
            </template>

            <template v-slot:default="{ isActive }">
              <v-form @submit.prevent="handleAddContact()" v-model="isAddContactFormValid">
                <v-card title="Add contact">
                  <v-card-text>
                    <v-row>
                      <v-col cols="auto">
                        <v-select variant="solo" density="comfortable" label="Type" :items="addContactModalContactTypes"
                          style="min-width: 150px" hide-details="auto" :rules="[required]"
                          v-model="addContactModalForm.type">
                          <template v-slot:item="{ props }">
                            <v-list-item v-bind="props"> </v-list-item>
                          </template> </v-select></v-col>
                      <v-col cols="auto" class="flex-grow-1">
                        <v-text-field append-outer-icon="mdi-menu-down" variant="solo" density="comfortable"
                          hide-details="auto" :disabled="!addContactModalForm.type" :label="addContactModalForm.type
                              ? `Enter ${addContactModalForm.type} contact`
                              : 'Select contact type first'
                            " :rules="[
    required,
    requiredIf(
      () => addContactModalForm.type !== 'Telegram',
      uaNumber
    ),
    requiredIf(
      () => addContactModalForm.type === 'Telegram',
      tagContact
    ),
  ]" v-model="addContactModalForm.value">
                        </v-text-field>
                      </v-col>
                    </v-row>
                  </v-card-text>

                  <v-card-actions>
                    <v-spacer></v-spacer>

                    <v-btn text="Close" @click="isActive.value = false"></v-btn>
                    <v-btn type="submit" color="primary" text="Add contact"></v-btn>
                  </v-card-actions>
                </v-card>
              </v-form>
            </template>
          </v-dialog>
          <v-spacer></v-spacer>
          <v-btn type="submit" size="large" width="200px" color="primary">
            Submit
          </v-btn>
        </v-col>
      </v-row>
    </v-form>
  </v-container>
</template>

<style scoped></style>
