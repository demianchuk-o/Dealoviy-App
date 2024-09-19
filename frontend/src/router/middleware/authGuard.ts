import { useAuthStore } from "@/store/auth";
import { NavigationGuardNext, RouteLocationNormalized } from "vue-router";

const AuthGuard = (protectedRoutes: string[]) => {
  return (
    to: RouteLocationNormalized,
    _: RouteLocationNormalized,
    next: NavigationGuardNext
  ) => {
    const authStore = useAuthStore();

    if (protectedRoutes.includes(to.path) && !authStore.isAuth) {
      next("/signin");
    } else {
      next();
    }
  };
};

export default AuthGuard;
