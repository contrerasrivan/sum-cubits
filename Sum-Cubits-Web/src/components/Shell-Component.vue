<script setup lang="ts">
import ProgressSpinner from 'primevue/progressspinner';
import type { MenuItem } from 'primevue/menuitem'
import ProgressBar from 'primevue/progressbar'
import Menubar from 'primevue/menubar'
import Message from 'primevue/message'
import Button from 'primevue/button'
import UserService from '@/features/users/services/UserService'
import RoleService from '@/features/roles/services/RoleService'

import type { ViewDto } from '@/features/views/models/ViewDto'

import { useLoadingStore } from '@/store/useLoadingStore'
import { useUserStore } from '@/features/users/store'
import { useErrorStore } from '@/store/useErrorStore'
import { RouterView, useRoute } from 'vue-router'
import { computed,onMounted, ref } from 'vue'
import { useAuth0 } from '@auth0/auth0-vue'
import { useI18n } from 'vue-i18n'
import router from '@/router'

const roleService = new RoleService();
const userService = new UserService();

const loadingStore = useLoadingStore();
const userStore = useUserStore();
const errorStore = useErrorStore();
const route = useRoute();
const auth = useAuth0();
const { t } = useI18n();

const menuItemList = ref<MenuItem[]>([])

const anyMenuList = computed(() => {
    return menuItemList.value.length > 0;
})

const getViewList = async () => {
    const roleId = await userService.getRoleId();
    const viewList = await roleService.getViewList(roleId);
    if (viewList) {
        menuItemList.value = viewList.map(mapTo);
        userStore.setUserPermissions(viewList.map((view) => view.nombreVista));
    }
}

const mapTo = (view : ViewDto) => {
    return {
        label: t(`shell.titles.${view.nombreVista}`),
        command: () => goToRouteByName(view.ruta)
    } as MenuItem
}

const goToRouteByName = (name : string) => {
    router.push({ name : name });
}

const logout = () => {
    auth.logout({ logoutParams: { returnTo: window.location.origin } });
}

onMounted(async () => {
    await getViewList();
})
</script>

<template>
  <div >
    <Menubar :model="menuItemList">
        <template #end>
            <Button label="Logout" icon="pi pi-fw pi-power-off" class="p-button-danger" @click="logout" />
        </template>
    </Menubar>
    <div class="m-3">
      <ProgressBar
        v-if="loadingStore.isLoading"
        class="mb-3"
        style="height: 6px"
        mode="indeterminate"
      ></ProgressBar>
      <Message
        v-if="errorStore.isAnyError"
        class="mb-3"
        :closable="false"
        :severity="errorStore.errorSeverity"
      >
        {{ errorStore.errorMessage }}
      </Message>
      <RouterView />
    </div>

  </div>
</template>

<style scoped>

</style>
