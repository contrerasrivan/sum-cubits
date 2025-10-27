import { createRouter, createWebHistory } from 'vue-router'
import { authGuard } from '@auth0/auth0-vue'
import type { Router } from 'vue-router'

const router: Router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '',
      redirect: '/home',
      beforeEnter: authGuard,
      component: () => import('@/components/Shell-Component.vue'),
      children: []
    },
    {path: '/catch-all(.*)*', redirect: '/' }
  ]
})

export default router
