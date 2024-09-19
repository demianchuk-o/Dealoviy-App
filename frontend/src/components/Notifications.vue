<script setup lang="ts">
import { useNotificationsStore } from "@/store/notifications";

const notificationsStore = useNotificationsStore();

const getNotificationColor = (type: string) => {
  switch (type) {
    case "success":
      return "success";
    case "error":
      return "error";
    case "warning":
      return "warning";
    case "info":
      return "info";
    default:
      return "info";
  }
};
</script>

<template>
  <v-snackbar
    v-for="notification in notificationsStore.notifications"
    :color="getNotificationColor(notification.type)"
    :timeout="notification.duration"
    :model-value="notification.isShow"
  >
    {{ notification.message }}
    <template v-slot:actions>
      <v-btn variant="text" @click="notification.isShow = false"> Close </v-btn>
    </template>
  </v-snackbar>
</template>

<style scoped></style>
