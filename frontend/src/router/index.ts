import { RouteRecordRaw, createRouter, createWebHistory } from "vue-router";
import AuthGuard from "./middleware/authGuard";

const routes: RouteRecordRaw[] = [
  {
    path: "/",
    component: () => import("../pages/home/Home.vue"),
  },
  {
    path: "/become-contractor",
    component: () => import("../pages/become-contractor/BecomeContractor.vue"),
  },
  {
    path: "/services",
    component: () => import("../pages/services/Services.vue"),
  },
  {
    path: "/service/:id",
    component: () => import("../pages/service/Service.vue"),
  },
  {
    path: "/my-services",
    component: () => import("../pages/my-services/MyServices.vue"),
  },
  {
    path: "/my-tasks",
    component: () => import("../pages/my-tasks/MyTasks.vue"),
  },
  {
    path: "/my-tasks/:id",
    component: () => import("../pages/my-tasks/ServiceTasks.vue"),
  },

  {
    path: "/my-orders/",
    component: () => import("../pages/my-orders/MyOrders.vue"),
  },

  {
    path: "/signin",
    component: () => import("../pages/auth/SignIn.vue"),
  },
  {
    path: "/signup",
    component: () => import("../pages/auth/SignUp.vue"),
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

router.beforeEach(AuthGuard(["/"]));

export default router;
