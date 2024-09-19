import { useNotificationsStore } from "@/store/notifications";
import { AxiosError } from "axios";
import parseServerErrors from "../helpers/parse-server-errors";

const useNotifications = () => {
  const notificationsStore = useNotificationsStore();

  const addServerErrorNotification = (
    error: AxiosError<{
      errors: object;
    }>,
    duration = 10000
  ) => {
    const message = parseServerErrors(error);
    if (!message) return;
    notificationsStore.addNotification({
      type: "error",
      message,
      duration,
    });
  };

  return {
    notifications: notificationsStore.notifications,
    addNotification: notificationsStore.addNotification,
    removeNotification: notificationsStore.removeNotification,
    addServerErrorNotification,
  };
};

export default useNotifications;
