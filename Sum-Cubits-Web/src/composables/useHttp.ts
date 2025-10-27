import { useLoadingStore } from '@/store/useLoadingStore'
import { useErrorStore } from '@/store/useErrorStore'
import { useAuthStore } from '@/store/useAuthStore'
import { createFetch } from '@vueuse/core'

const API_URL = import.meta.env.VITE_API_URL

const loadingStore = useLoadingStore()
const errorStore = useErrorStore()
const authStore = useAuthStore()

export const useHttp = (url: string, queryParams?: unknown) => {
  if (queryParams) {
    const query = serializeQueryObject(queryParams as QueryObject)
    return customFetch(`${url}?${query}`)
  }

  return customFetch(url)
}

const customFetch = createFetch({
  baseUrl: `${API_URL}`,
  options: {
    async beforeFetch({ options }) {
      loadingStore.start()
      options.headers = {
        ...options.headers,
        Accept: 'application/json',
        'Content-Type': 'application/json',
        Authorization: `Bearer ${await authStore.accessToken}`
      }
      errorStore.clearError()
      return { options }
    },
    async afterFetch({ data, response }) {
      errorStore.setHttpResponse(response)
      loadingStore.stop()
      return { data }
    },
    async onFetchError({ data, response, error }) {
      errorStore.setError(error)
      errorStore.setErrorData(data)
      errorStore.setHttpResponse(response)
      loadingStore.stop()
      return {}
    }
  },
  fetchOptions: {
    mode: 'cors'
  }
})

type QueryValue = string | number | boolean | Date | QueryObject

interface QueryObject {
  [key: string]: QueryValue
}

const serializeQueryObject = (obj: QueryObject, prefix: string = ''): string => {
  return Object.entries(obj)
    .map(([key, value]) => {
      const fullKey = prefix ? `${prefix}[${key}]` : key

      if (value instanceof Date) {
        return `${encodeURIComponent(fullKey)}=${encodeURIComponent(value.toISOString())}`
      } else if (typeof value === 'object' && value !== null) {
        return serializeQueryObject(value as QueryObject, fullKey)
      } else {
        return `${encodeURIComponent(fullKey)}=${encodeURIComponent(String(value))}`
      }
    })
    .join('&')
}