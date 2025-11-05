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

const RecordList =  () =>  import('@/features/record/pages/Record-List.vue');

export const myRecordRouter: RouteRecordRaw = {
    path: 'my-record',
    component: RouterView,
    children: [
      {
        path: '',
        name: 'record-list',
        component: RecordList()
      }  
    ]
}