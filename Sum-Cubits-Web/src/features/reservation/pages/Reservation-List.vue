<script setup lang="ts">
//import components
import Button from 'primevue/button'
import Card from 'primevue/card'
import Tag from 'primevue/tag'
import Panel from 'primevue/panel'

import ReservationService from '@/features/reservation/services/indext';

import { onMounted, ref, computed } from 'vue'
import { useAuth0 } from '@auth0/auth0-vue';
import { useRouter } from 'vue-router';
import { useI18n } from 'vue-i18n';

// Auth, Router & i18n
const auth = useAuth0()
const { t } = useI18n()
const router = useRouter()

// Computed properties
const userName = computed(() => {
  return auth.user.value?.name
})

// service
const reservationService = new ReservationService();

// Mock data for demonstration (replace with actual data later)
const reservations = ref([
  {
    id: 1,
    date: '2024-01-20',
    reserva: ['Turno Mañana', 'Turno Tarde']
  },
  {
    id: 2,
    date: '2024-01-21',
    reserva: ['Turno Mañana']
  },
  {
    id: 3,
    date: '2024-01-22',
    reserva: ['Turno Mañana', 'Turno Tarde', 'Turno Noche']
  }
])

const hasReservations = computed(() => reservations.value.length > 0)
</script>

<template>
 <div class="w-full">
    <div>
        <Panel toggleable class="border border-gray-300 rounded-lg shadow-sm">
            <template #header>
                <div class="flex align-items-center justify-content-between w-full">
                <div class="flex align-items-center gap-3">               
                    <Button :label="t('Reservar Salón')" icon="pi pi-calendar" class="p-button-rounded p-button-text p-button-plain text-lg" size="small"/>
                </div>
                </div>
            </template>
          <template #default>
          <!-- Empty State -->
          <div v-if="!hasReservations" class="text-center py-8">
            <p class="text-neutral-500">Aún no tienes reservas solicitadas</p>
          </div>

          <!-- Reservations List -->
          <div v-else class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
            <Card 
              v-for="reservation in reservations" 
              :key="reservation.id"
              class="border-2 border-gray-300 rounded-lg shadow-md hover:shadow-lg transition-shadow"
            >
              <template #title><i class="pi pi-calendar"></i>
                        <span class="ml-2"> {{ reservation.date }} </span>
              </template>
              <template #subtitle>
                <div class="grid">
                  <div class="col-1">
                    <i class="pi pi-clock"></i>
                    <Tag class= "ml-2" severity="primary">{{ Array.isArray(reservation.reserva) ? reservation.reserva.join(', ') : reservation.reserva }}</Tag>
                  </div>
                </div>
              </template>
              <template #content>
                <div class="grid">
                    <div class="col-12">
                        <div class="button-row">
                            <Button icon="pi pi-pencil" text rounded size="small" severity="secondary" />
                            <Button icon="pi pi-trash" text rounded size="small" severity="danger" />
                        </div>
                    </div>
                </div>
              </template>
            </Card>
          </div>
        </template>
        </Panel>
    </div>
 </div>
</template>

<style scoped>

</style>
