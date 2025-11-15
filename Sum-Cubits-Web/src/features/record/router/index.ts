import { type RouteRecordRaw, RouterView } from "vue-router";
import { usePermissionGuard } from "@/composables/usePermissionGuard";

export const recordRouter: RouteRecordRaw = {
    path: 'record',
    component: RouterView,
    meta: { permissions: 'record' },
    beforeEnter: usePermissionGuard,
    children: [

    ]
}

export const myRecordRouter: RouteRecordRaw = {
    path: 'my-record',
    name: 'record-list',
    component: () => import('@/features/record/pages/Record-List.vue')
}