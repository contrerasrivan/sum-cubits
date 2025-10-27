import { computed, ref } from 'vue'
import { defineStore } from 'pinia'

export const useErrorStore = defineStore('error-store', () => {
  const error = ref<string | null>()
  const httpResponse = ref<Response>()
  const errorData = ref<{ message: string }>()

  const clearError = () => {
    error.value = null
  }

  const setError = (value: string) => {
    if (value) {
      error.value = value
    }
  }

  const setErrorData = (value: { message: string }) => {
    if (value) {
      errorData.value = value
    }
  }

  const setHttpResponse = (value: Response | null) => {
    if (value) {
      httpResponse.value = value
    }
  }

  const isAnyError = computed(() => {
    return (
      error.value != null ||
      isAuthenticationError.value ||
      isAuthorizationError.value ||
      isInternalServerError.value
    )
  })

  const errorMessage = computed(() => {
    return errorData.value == null
      ? isAuthenticationError.value
        ? 'Unauthenticated'
        : isAuthorizationError.value
          ? 'Unauthorized'
          : 'An error occurred, please try again.'
      : errorData.value?.message
  })

  const errorSeverity = computed<'error' | 'warn'>(() => {
    if (isAuthenticationError.value || isAuthorizationError.value) return 'warn'

    return 'error'
  })

  const isAuthenticationError = computed(() => {
    return httpResponse.value != null && httpResponse.value.status == 401
  })

  const isAuthorizationError = computed(() => {
    return httpResponse.value != null && httpResponse.value.status == 403
  })

  const isInternalServerError = computed(() => {
    return httpResponse.value != null && httpResponse.value.status == 500
  })

  return {
    isAnyError,
    errorMessage,
    errorSeverity,
    clearError,
    setError,
    setErrorData,
    setHttpResponse
  }
})
