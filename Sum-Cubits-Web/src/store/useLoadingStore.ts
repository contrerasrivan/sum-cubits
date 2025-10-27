import { defineStore } from 'pinia'
import { computed, ref } from 'vue'

export const useLoadingStore = defineStore('loading-store', () => {
  const loadingTimeout = ref<number | null>(null)
  const loading = ref<boolean>(false)
  const timeout = 500

  const isLoading = computed(() => loading.value)

  const start = () => {
    if (loading.value)
      return

    clearTimeout(loadingTimeout.value!)

    loadingTimeout.value = window.setTimeout(() => {
      loading.value = true
    }, timeout)
  }


  const stop = () => {
    clearTimeout(loadingTimeout.value!) 
    loadingTimeout.value = null
    loading.value = false
  }


  return {
    stop,
    start,
    isLoading
  }
})
