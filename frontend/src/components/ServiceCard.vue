<script setup lang="ts">
import { Service } from "@/types";

defineProps<{
  service: Service;
}>();
</script>

<template>
  <v-card variant="elevated">
    <v-card-item>
      <v-row>
        <v-col cols="12">
          <div class="text-h6 mb-1">
            <a
              href="#"
              class="text-black"
              @click.prevent="$router.push(`/service/${service.serviceId}`)"
              >{{ service.name }}</a
            >
          </div>
          <div class="text-caption">
            {{ service.description }}
          </div>
        </v-col>
        <v-col cols="12">
          <span>
            <v-icon color="primary">mdi-map-marker</v-icon>
            {{ service.cityName }}
          </span>
        </v-col>
        <v-col cols="auto">
          <h2 class="text-primary">
            ${{ service.lowerPriceBound }}-{{ service.upperPriceBound }}
          </h2>
        </v-col>
        <v-spacer></v-spacer>
        <v-col cols="auto">
          <v-rating
            readonly
            hover
            :length="5"
            :size="32"
            :model-value="service.averageRating"
            active-color="primary"
          />
        </v-col>
      </v-row>
    </v-card-item>
  </v-card>
</template>

<style scoped></style>
