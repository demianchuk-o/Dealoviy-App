import router from "@/router";
import { useAuthStore } from "@/store/auth";
import { AxiosInstance } from "axios";

const useAuthMiddleware = async (axiosInstance: AxiosInstance) => {
  axiosInstance.interceptors.request.use(
    (config) => {
      // If the request already has an authorization header, do nothing
      if (config.headers.Authorization) {
        return config;
      }

      // If request has`nt an authorization header, add it from the auth store
      const authStore = useAuthStore();
      const accessToken = authStore.session?.accessToken;

      config.headers.Authorization = `Bearer ${accessToken}`;

      return config;
    },
    (error) => Promise.reject(error)
  );

  axiosInstance.interceptors.response.use(
    (response) => response,
    async (error) => {
      const authStore = useAuthStore();

      // If there is no response from the server (server is down or no internet connection)
      if (!error.response) {
        return Promise.reject(error);
      }

      // If the access token has expired or is invalid
      if (error.response.status === 401) {
        router.push({
          path: "/signin",
          query: {
            msg: "Session expired. Please sign in again.",
          },
        });
        authStore.signOut();
      }

      return Promise.reject(error);
    }
  );
};

export default useAuthMiddleware;
