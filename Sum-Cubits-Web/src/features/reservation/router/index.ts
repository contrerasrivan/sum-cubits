import { type RouteRecordRaw, RouterView } from "vue-router";
import { usePermissionGuard } from "@/composables/usePermissionGuard";

export const reservationRouter: RouteRecordRaw = {
    path: 'reservation',
    component: RouterView,
    meta: { permissions: 'reservation' },
    beforeEnter: usePermissionGuard,
    children: [
        
    ]
}

const ReservationList = () => import('@/features/reservation/pages/Reservation-List.vue');

export const myReservationRouter: RouteRecordRaw = {
path: 'my-reservation',
component: RouterView,
children: [
    {
        path: '',
        name: 'reservation-list',
        component: ReservationList
    }
]
}