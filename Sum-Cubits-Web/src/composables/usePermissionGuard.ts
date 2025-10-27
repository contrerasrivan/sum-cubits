import type { NavigationGuardNext, RouteLocationNormalized } from 'vue-router'
import { useUserStore } from '@/features/users/store'

let userStore: ReturnType<typeof useUserStore> | null = null

function getUserStore() {
  if (!userStore) {
    userStore = useUserStore()
  }

  return userStore
}

export const usePermissionGuard = (
  to: RouteLocationNormalized,
  from: RouteLocationNormalized,
  next: NavigationGuardNext
) => {
  const store = getUserStore()

  if (!store.hasPermission(to.meta.permissions as string)) {
    return next({ path: '/' })
  }

  next()
}
