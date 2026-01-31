<script setup lang="ts">
//import components
import Button from "primevue/button";
import Card from "primevue/card";
import Tag from "primevue/tag";
import Panel from "primevue/panel";
import Dialog from "primevue/dialog";
import MultiSelect from "primevue/multiselect";
import DatePicker from "primevue/datepicker";

//import services
import ReservationService from "@/features/reservation/services/ReservationService";

// imprt Dtos
import type { ReservaDto } from "@/features/reservation/models/ReservaDto";

//import Request/Response
import type { GetReservationListResponse } from "@/features/reservation/interfaces/GetReservationListResponse";
import type { CreateReservationRequest } from "@/features/reservation/interfaces/CreateReservationRequest";
import type { GetAvailableTurnsResponse, AvailableTurnoDto } from "@/features/reservation/interfaces/GetAvailableTurnsResponse";

import { onMounted, ref, computed } from "vue";
import { useAuth0 } from "@auth0/auth0-vue";
import { useRouter } from "vue-router";
import { useI18n } from "vue-i18n";

// Auth, Router & i18n
const auth = useAuth0();
const { t } = useI18n();
const router = useRouter();

//const 
const showCreateModal = ref(false)
const selectedReservation = ref<Date>();
const selectedTurnos = ref<number[]>([]);
const turnosDisponibles = ref<AvailableTurnoDto[]>([]);
const selectedSalonId = ref<number>(1); // falta api para obtener salones
const minDate = ref<Date>(new Date());  

// service
const reservationService = new ReservationService();

// State Reservation
const reservations = ref<ReservaDto[]>([]);

//Methods
const getReservationList = async () => {
    const response: GetReservationListResponse =
      await reservationService.getReservationList()
    reservations.value = response.reservationDto
}

const deleteReservation = async (fechaReserva: string) => {
    await reservationService.deleteReservation({ fechaReserva })
    await getReservationList()
}

const createReservation = async (request: CreateReservationRequest) => {
    await reservationService.createReservation(request)
    await getReservationList()
};

const hasReservations = computed(() => reservations.value.length > 0);


const formatDate = (date: Date): string => {
  const year = date.getFullYear();
  const month = String(date.getMonth() + 1).padStart(2, '0');
  const day = String(date.getDate()).padStart(2, '0');
  return `${year}-${month}-${day}`;
};

const cancelEdit = () => {
  showCreateModal.value = false;
  selectedReservation.value = new Date();
  selectedTurnos.value = [];
  turnosDisponibles.value = [];
};

const onDateSelect = async () => {
  if (!selectedReservation.value) return;
  
  const fechaReserva = formatDate(selectedReservation.value);
  
  const turnos: GetAvailableTurnsResponse = await reservationService.getAvailableTurns({ 
    fechaReserva, 
    salonId: selectedSalonId.value 
  });
  
  // Filtrar solo los turnos disponibles
  turnosDisponibles.value = turnos.filter(turno => turno.disponibili);
  selectedTurnos.value = [];
};

const goToHome = () => {
  router.push({ name: 'reservation-list' })
}

//OnMounted home
onMounted(async () => {
  getReservationList()
});


</script>

<template>
  <div class="w-full">
    <div>
      <Panel toggleable class="border border-sky-900 rounded-lg shadow-sm">
        <template #header>
          <div class="flex align-items-center gap-3">
            <Button
              :label="t('Reservar Salón')"
              icon="pi pi-calendar"
              class="p-button-rounded text-lg"
              size="small"
              variant="outlined"
              rounded
              severity="info"
              @click="showCreateModal = true"
            />
          </div>
          <div class="flex justify-content-end">
            <span class="text-xl">{{ t("Mis Reservas") }}</span>
          </div>
        </template>
        <template #default>
          <!-- Empty State -->
          <div v-if="!hasReservations" class="text-center py-8">
            <p class="text-neutral-500">Aún no tienes reservas solicitadas</p>
          </div>

          <!-- Reservations List -->
          <div
            v-else
            class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4"
          >
            <Card
              v-for="(reservation, index) in reservations"
              :key="index"
              class="border-2 border-gray-300 rounded-lg shadow-md hover:shadow-lg transition-shadow"
            >
              <template #title
                ><i class="pi pi-calendar"></i>
                <span class="ml-2"> {{ reservation.fechaReserva }} </span>
              </template>
              <template #subtitle>
                <div class="flex flex-wrap gap-2 mt-2">
                  <div class="flex items-center gap-2">
                    <i class="pi pi-clock"></i>
                    <Tag 
                      v-for="turno in reservation.turnosConfirmados" 
                      :key="turno.reservaId" 
                      severity="primary"
                      class="ml-1"
                    >
                      {{ turno.nombreTurno }}
                    </Tag>
                  </div>
                </div>
              </template>
              <template #content>
                <div class="grid">
                  <div class="col-12">
                    <div class="button-row">
                      <Button
                        icon="pi pi-trash"
                        text
                        rounded
                        size="small"
                        severity="danger"
                        @click="deleteReservation(reservation.fechaReserva)"
                      />
                    </div>
                  </div>
                </div>
              </template>
            </Card>
          </div>
        </template>
      </Panel>
    </div>

    <!-- Modal de Edición -->
    <Dialog
      v-model:visible="showCreateModal"
      :header="t('Crear Reserva')"
      :modal="true"
      :style="{ width: '50vw' }"
      :breakpoints="{ '1199px': '75vw', '575px': '90vw' }"
    >
      <template #header>
        <div class="flex align-items-center gap-2">
          <i class="pi pi-calendar-create text-2xl"></i>
          <span class="text-xl font-semibold">{{ t("Crear Reserva") }}:</span>
          <DatePicker
            v-model="selectedReservation"
            input-id="reservation-date"
            dateFormat="yy-mm-dd"
            :minDate="minDate"
            :placeholder="t('Fecha Reserva')"
            class="ml-4"
            @date-select="onDateSelect"
          />
        </div>
      </template>

      <div class="flex items-center gap-4 mb-1">
        <label for="turnos" class="font-semibold">
          <i class="pi pi-clock">
            <span class="text-xl ml-2">{{ t("Turnos") }}:</span>
          </i>
        </label>
        <MultiSelect
          v-model="selectedTurnos"
          :options="turnosDisponibles"
          optionLabel="nombre"
          optionValue="turnoId"
          :placeholder="selectedReservation && turnosDisponibles.length ===0 ? t('Turnos no disponibles') : t('Turnos Disponibles')"
          class="w-min-full"
          display="chip"
          :disabled="!selectedReservation || turnosDisponibles.length === 0"
        />
      </div>

      <template #footer>
        <Button
          :label="t('Cancelar')"
          icon="pi pi-ban"
          severity="danger" 
          variant="outlined"
          rounded
          @click="cancelEdit"
        />
        <Button
          :label="t('Guardar')"
          icon="pi pi-save"
          severity="success"
          variant="outlined" 
          rounded
          :disabled="!selectedReservation || selectedTurnos.length === 0"
          @click="async () => {
            await createReservation({
              fechaReserva: (() => {
          const year = selectedReservation!.getFullYear();
          const month = String(selectedReservation!.getMonth() + 1).padStart(2, '0');
          const day = String(selectedReservation!.getDate()).padStart(2, '0');
          return `${year}-${month}-${day}`;
              })(),
              idSalon: 1,
              idTurnos: selectedTurnos,
              idEstado: 5
            });
            await goToHome();
            cancelEdit();
          }"
        />
      </template>
    </Dialog>
  </div>
</template>

<style scoped></style>
