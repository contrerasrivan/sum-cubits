import primeVueCustomOptions from '@/prime'
import PrimeVue from 'primevue/config'
import ToastService from 'primevue/toastservice'
import i18n from '@/resources/i18n'
import router from '@/router'
import store from '@/store'
import auth from '@/auth'

import { createApp } from 'vue'
import App from '@/App.vue'
import '@/assets/styles/main.css'

createApp(App)
  .use(store)
  .use(router)
  .use(auth)
  .use(i18n)
  .use(PrimeVue, primeVueCustomOptions)
  .use(ToastService)
  .mount('#app')
