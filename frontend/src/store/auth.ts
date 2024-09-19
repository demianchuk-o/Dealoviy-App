import httpClient from "@/core/httpClient";
import { defineStore } from "pinia";
import { computed, onMounted, ref, watch } from "vue";

export type Session = {
  userName: string;
  displayName: string;
  contractorProfileId: string | null;
  accessToken: string;
  selectedRole: "contractor" | "customer";
};

export const extractPayloadFromToken = (accessToken: string) => {
  const base64Payload = accessToken.split(".")[0];
  const payload: {
    sub: string;
    name: string;
    exp: number;
  } = JSON.parse(atob(base64Payload));

  return payload;
};

export const useAuthStore = defineStore("auth", () => {
  const session = ref<Session>();
  const isAuth = computed(() => !!session.value);

  const restoreSession = () => {
    try {
      const restoredSession = JSON.parse(localStorage.getItem("session")!);
      session.value = restoredSession;
      console.log("Auth: session token", session.value?.accessToken);
    } catch (e) {
      console.error("Auth: Error restoring session", e);
      localStorage.removeItem("session");
    }
  };

  onMounted(() => {
    restoreSession();
  });

  const storeSession = () => {
    if (!session.value) {
      console.log("Session is`nt set, removing from localStorage");
      localStorage.removeItem("session");
      return;
    }

    localStorage.setItem("session", JSON.stringify(session.value));
  };

  watch(
    session,
    () => {
      storeSession();
    },
    { deep: true }
  );

  const setSession = (data: {
    id: string;
    username: string;
    displayName: string;
    contractorProfileId: string;
    token: string;
  }) => {
    session.value = {
      userName: data.username,
      displayName: data.displayName,
      contractorProfileId: data.contractorProfileId ?? null,
      accessToken: data.token,
      selectedRole: data.contractorProfileId ? "contractor" : "customer",
    };
  };

  const signIn = (credentials: { username: string; password: string }) => {
    const { username, password } = credentials;
    return httpClient
      .post("/auth/login", {
        username,
        password,
      })
      .then((response) => {
        setSession(response.data);
        return session.value;
      })
      .catch((e) => {
        console.error("Sign In failed!", e);
        return Promise.reject(e);
      });
  };

  const signUp = (credentials: {
    username: string;
    displayName: string;
    password: string;
  }) => {
    const { username, displayName, password } = credentials;
    return httpClient
      .post("/auth/register", {
        username,
        displayName,
        password,
      })
      .then((response) => {
        setSession(response.data);
        return session.value;
      })
      .catch((e) => {
        console.error("Sign Up failed!", e);
        return Promise.reject(e);
      });
  };

  const signOut = () => {
    session.value = undefined;
    localStorage.removeItem("session");
  };

  const selectRole = (role: "contractor" | "customer") => {
    if (!session.value) {
      return;
    }

    session.value.selectedRole = role;
  };

  const isCustomer = computed(() => session.value?.selectedRole === "customer");
  const isContractor = computed(
    () => session.value?.selectedRole === "contractor"
  );

  return {
    session,
    isAuth,
    signIn,
    signUp,
    signOut,
    selectRole,
    isCustomer,
    isContractor,
  };
});
