import { defineStore } from 'pinia'
import { ref } from 'vue'

export const useUserStore = defineStore('users-store', () => {
  const userPermissions = ref<string[]>([])

  const hasPermission = (requiredPermission: string): boolean => {
    return userPermissions.value.includes(requiredPermission)
  }

  const setUserPermissions = (permissions: string[]): void => {
    userPermissions.value = permissions
  }

  return { hasPermission, setUserPermissions }
})