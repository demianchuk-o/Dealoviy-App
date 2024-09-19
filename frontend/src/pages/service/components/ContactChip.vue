<script setup lang="ts">
import { ref } from "vue";

defineProps<{
  label?: string;
  text?: string;
}>();

const isDetailsShow = ref(false);
</script>

<template>
  <v-menu
    v-model="isDetailsShow"
    location="top start"
    origin="top start"
    transition="scale-transition"
  >
    <template v-slot:activator="{ props }">
      <v-chip pill v-bind="props" link>{{ label }}</v-chip>
    </template>

    <v-card>
      <v-list>
        <v-list-item
          :link="false"
          prepend-icon="mdi-account-box-outline"
          @click.stop
        >
          <v-list-item-subtitle>{{ text }}</v-list-item-subtitle>
        </v-list-item>
      </v-list>
    </v-card>
  </v-menu>
</template>

<style scoped></style>
