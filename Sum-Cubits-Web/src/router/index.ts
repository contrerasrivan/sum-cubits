import { createRouter, createWebHistory } from 'vue-router'
import { authGuard } from '@auth0/auth0-vue'
import type { Router } from 'vue-router'
import { recordRouter, myRecordRouter } from '@/features/record/router'

const router: Router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      redirect: '/my-record',
      beforeEnter: authGuard,
      component: () => import('@/components/Shell-Component.vue'),
      children: [
        recordRouter,
        myRecordRouter
      ]
    },
    {path: '/:catchAll(.*)*', redirect: '/' }
  ]
})

export default router
