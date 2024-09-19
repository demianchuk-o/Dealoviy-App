import config from "@/config";
import axios from "axios";
import useAuthMiddleware from "./middleware/auth.middleware";

const httpClient = axios.create({
  baseURL: config.API_URL,
});

useAuthMiddleware(httpClient);

export default httpClient;
