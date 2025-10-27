import type { RouteRecordRaw } from 'vue-router'
import { RouterView } from 'vue-router'
import { usePermissionGuard } from '@/composables/usePermissionGuard'

const UserList = () => import('@/features/users/pages/User-List.vue')

const userRoute: RouteRecordRaw = {
  path: 'users',
  component: RouterView,
  meta: { permissions: 'users' },
  beforeEnter: usePermissionGuard,
  children: [{ path: '', name: 'user-list', component: UserList }]
}

export default userRoute