import { nanoid } from "nanoid";
import { defineStore } from "pinia";
import { ref } from "vue";

type Notification = {
  id?: string;
  message: string;
  type: "success" | "error" | "info";
  duration?: number;
  isShow?: boolean;
};

export const useNotificationsStore = defineStore("notifications", () => {
  const notifications = ref<Notification[]>([]);

  const removeNotification = (id: string) => {
    notifications.value = notifications.value.filter(
      (notification) => notification.id !== id
    );
  };

  const addNotification = (notification: Notification) => {
    const newNotification = Object.assign(
      {
        id: nanoid(4),
        isShow: true,
        duration: notification.duration ? notification.duration : -1,
      },
      notification
    );

    console.log(newNotification.duration);

    notifications.value.push(newNotification);

    return newNotification;
  };

  return {
    notifications,
    addNotification,
    removeNotification,
  };
});
