import { createApp } from "vue";
import App from "./App.vue";
import "./style.css";

const app = createApp(App);

// Pinia
import { createPinia } from "pinia";
const pinia = createPinia();
app.use(pinia);

// Router
import router from "./router";
app.use(router);

// Vuetify
import "@mdi/font/css/materialdesignicons.css";
import { createVuetify } from "vuetify";
import * as components from "vuetify/components";
import * as directives from "vuetify/directives";
import "vuetify/styles";

const vuetify = createVuetify({
  components,
  directives,
});
app.use(vuetify);

app.mount("#app");
