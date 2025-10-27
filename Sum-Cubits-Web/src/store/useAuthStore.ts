import { useAuth0 } from '@auth0/auth0-vue'
import { defineStore } from 'pinia'
import { computed } from 'vue'

export const useAuthStore = defineStore('auth-store', () => {
  const auth = useAuth0()

  const accessToken = computed(async () => {
    return await auth.getAccessTokenSilently()
  })

  return { accessToken }
})