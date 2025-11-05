<script setup lang="ts">
 import { ref, computed, onMounted } from 'vue';
import { useToast } from 'primevue/usetoast';
import { useConfirm } from 'primevue/useconfirm';
import FullCalendar from '@fullcalendar/vue3';
import dayGridPlugin from '@fullcalendar/daygrid';
import interactionPlugin from '@fullcalendar/interaction';
import esLocale from '@fullcalendar/core/locales/es';

// PrimeVue Components
import Dialog from 'primevue/dialog';
import Button from 'primevue/button';
import Card from 'primevue/card';
import Tag from 'primevue/tag';
import Divider from 'primevue/divider';
import ProgressSpinner from 'primevue/progressspinner';
import Message from 'primevue/message';

import RecordService from '@/features/record/services/RecordService';

import { useAuth0 } from '@auth0/auth0-vue';
import { useRouter } from 'vue-router';
import { useI18n } from 'vue-i18n';


// service
const recordService = new RecordService();

// Referencias
const auth = useAuth0();
const  { t } = useI18n();
const router = useRouter();
const calendarRef = ref(null);
const mostrarModal = ref(false);
const fechaSeleccionada = ref(null);
const turnosDelDia = ref([]);
const cargandoTurnos = ref(false);
const reservando = ref(false);
const eventos = ref([]);

// Computed
const tituloModal = computed(() => {
/*   return fechaSeleccionada.value 
    ? 'Seleccionar turno' 
    : 'Seleccione un día'; */
});

const fechaSeleccionadaFormato = computed(() => {
/*   if (!fechaSeleccionada.value) return '';
  return new Date(fechaSeleccionada.value).toLocaleDateString('es-AR', {
    weekday: 'long',
    year: 'numeric',
    month: 'long',
    day: 'numeric'
  }); */
});

const estadoDiaTexto = computed(() => {
/*   const turnosOcupados = turnosDelDia.value.filter(t => t.ocupado).length;
  const totalTurnos = turnosDelDia.value.length;
  
  if (turnosOcupados === 0) return 'Todos los turnos disponibles';
  if (turnosOcupados === totalTurnos) return 'Todos los turnos ocupados';
  return `${totalTurnos - turnosOcupados} de ${totalTurnos} disponibles`; */
});

const estadoDiaSeverity = computed(() => {
  /* const turnosOcupados = turnosDelDia.value.filter(t => t.ocupado).length;
  const totalTurnos = turnosDelDia.value.length;
  
  if (turnosOcupados === 0) return 'success';
  if (turnosOcupados === totalTurnos) return 'danger';
  return 'warning'; */
});

const estadoDiaIcon = computed(() => {
  /* const turnosOcupados = turnosDelDia.value.filter(t => t.ocupado).length;
  const totalTurnos = turnosDelDia.value.length;
  
  if (turnosOcupados === 0) return 'pi pi-check-circle';
  if (turnosOcupados === totalTurnos) return 'pi pi-times-circle';
  return 'pi pi-exclamation-triangle'; */
});

// Configuración de FullCalendar
const calendarOptions = ref({
/*   plugins: [dayGridPlugin, interactionPlugin],
  initialView: 'dayGridMonth',
  locale: esLocale,
  headerToolbar: {
    left: 'prev,next today',
    center: 'title',
    right: ''
  },
  buttonText: {
    today: 'Hoy'
  },
  height: 'auto',
  fixedWeekCount: false,
  dateClick: handleDateClick,
  events: eventos.value,
  eventContent: renderEventContent,
  datesSet: handleDatesSet,
  dayCellClassNames: (arg) => {
    const hoy = new Date();
    hoy.setHours(0, 0, 0, 0);
    if (arg.date < hoy) {
      return ['dia-pasado'];
    }
    return [];
  } */
});

// Métodos
const cargarDisponibilidadMes = async () => {
 /*  try {
    const anio = fecha.getFullYear();
    const mes = fecha.getMonth() + 1;

    const response = await axios.get(`${API_URL}/calendario/disponibilidad`, {
      params: {
        anio: anio,
        mes: mes,
        salonId: props.salonId
      }
    });

    // Convertir datos en eventos de FullCalendar
    eventos.value = response.data.map(dia => {
      let color, textColor, className;
      
      switch (dia.estado) {
        case 'disponible':
          color = '#27ae60';
          textColor = 'white';
          className = 'evento-disponible';
          break;
        case 'parcial':
          color = '#f39c12';
          textColor = 'white';
          className = 'evento-parcial';
          break;
        case 'completo':
          color = '#e74c3c';
          textColor = 'white';
          className = 'evento-completo';
          break;
        default:
          color = '#95a5a6';
          textColor = 'white';
          className = '';
      }

      return {
        start: dia.fecha,
        display: 'background',
        backgroundColor: color,
        textColor: textColor,
        className: className,
        extendedProps: {
          turnosOcupados: dia.turnosOcupados,
          totalTurnos: dia.totalTurnos,
          estado: dia.estado
        }
      };
    });

    // Actualizar eventos en el calendario
    if (calendarRef.value) {
      const calendarApi = calendarRef.value.getApi();
      calendarApi.removeAllEvents();
      calendarApi.addEventSource(eventos.value);
    }

  } catch (error) {
    console.error('Error cargando disponibilidad:', error);
    toast.add({
      severity: 'error',
      summary: 'Error',
      detail: 'No se pudo cargar la disponibilidad del mes',
      life: 3000
    });
  } */
};

const cargarTurnosDelDia = async () => {
  /* cargandoTurnos.value = true;
  try {
    const fechaStr = fecha.toISOString().split('T')[0];
    const response = await axios.get(
      `${API_URL}/calendario/disponibilidad/${fechaStr}`,
      { params: { salonId: props.salonId } }
    );

    turnosDelDia.value = response.data;
  } catch (error) {
    console.error('Error cargando turnos:', error);
    toast.add({
      severity: 'error',
      summary: 'Error',
      detail: 'No se pudieron cargar los turnos del día',
      life: 3000
    });
  } finally {
    cargandoTurnos.value = false;
  } */
};

const handleDateClick = async () => {
 /*  const fechaClick = new Date(info.dateStr);
  const hoy = new Date();
  hoy.setHours(0, 0, 0, 0);

  if (fechaClick < hoy) {
    toast.add({
      severity: 'warn',
      summary: 'Fecha no válida',
      detail: 'No puedes reservar en fechas pasadas',
      life: 3000
    });
    return;
  }

  fechaSeleccionada.value = info.dateStr;
  mostrarModal.value = true;
  await cargarTurnosDelDia(fechaClick); */
};

const handleDatesSet = async () => {
  /* await cargarDisponibilidadMes(dateInfo.start); */
};

const confirmarReserva = () => {
 /*  confirm.require({
    message: `¿Confirmar reserva de ${turno.nombreTurno} para el ${fechaSeleccionadaFormato.value}?`,
    header: 'Confirmar reserva',
    icon: 'pi pi-exclamation-triangle',
    accept: () => realizarReserva(turno),
    reject: () => {}
  }); */
};

const realizarReserva = async () => {
  /* reservando.value = true;
  try {
    await axios.post(`${API_URL}/reservas`, {
      usuarioID: props.usuarioId,
      salonID: props.salonId,
      turnoID: turno.turnoID,
      fechaReserva: fechaSeleccionada.value,
      cantidadPersonas: null,
      observaciones: null
    });

    toast.add({
      severity: 'success',
      summary: 'Reserva exitosa',
      detail: `Tu reserva para ${turno.nombreTurno} ha sido confirmada`,
      life: 4000
    });

    emit('reserva-creada');
    
    // Recargar datos
    const calendarApi = calendarRef.value.getApi();
    await cargarDisponibilidadMes(calendarApi.getDate());
    await cargarTurnosDelDia(new Date(fechaSeleccionada.value));
    
  } catch (error) {
    console.error('Error creando reserva:', error);
    toast.add({
      severity: 'error',
      summary: 'Error en la reserva',
      detail: error.response?.data?.error || 'No se pudo completar la reserva',
      life: 4000
    });
  } finally {
    reservando.value = false;
  } */
};

const formatearHora = () => {
  /* return timeSpan.substring(0, 5); */
};

const getIconoTurno = () => {
/*   const iconos = {
    'Mañana': 'pi pi-sun',
    'Mediodía': 'pi pi-sun',
    'Tarde': 'pi pi-cloud',
    'Noche': 'pi pi-moon'
  };
  return iconos[nombreTurno] || 'pi pi-clock'; */
};

const renderEventContent = () => {
  return {
    html: `<div class="evento-custom"></div>`
  };
};

onMounted(async () => {
  /* const calendarApi = calendarRef.value.getApi();
  await cargarDisponibilidadMes(calendarApi.getDate()); */
});
</script>
<template>
    <div class="reservas-container">
    <!-- Calendario con FullCalendar -->
    <div class="calendario-wrapper">
      <FullCalendar
        ref="calendarRef"
        :options="calendarOptions"
      />
    </div>

    <!-- Modal para seleccionar turno -->
    <Dialog 
      v-model:visible="mostrarModal" 
      :modal="true"
      :style="{ width: '500px' }"
      :dismissableMask="true"
    >
      <div class="modal-content">
        <div class="fecha-seleccionada">
          <i class="pi pi-calendar"></i>
          <span>{{ fechaSeleccionadaFormato }}</span>
        </div>

        <div class="estado-dia">
          <Tag 
            :value="estadoDiaTexto" 
          />
        </div>

        <Divider />

        <div class="turnos-disponibles">
          <h3>Turnos disponibles</h3>
          
          <div v-if="cargandoTurnos" class="loading-turnos">
            <ProgressSpinner style="width:50px;height:50px" />
          </div>

          <div v-else class="lista-turnos">
            <div 
              v-for="turno in turnosDelDia" 
              :class="['turno-card']"
            >
              <div class="turno-header">
                <div class="turno-icono">
                  <i></i>
                </div>
                <div class="turno-info">
                  <h4>Turno</h4>
                  <p class="horario">
                    <i class="pi pi-clock"></i>
                     - 
                  </p>
                  <p class="descripcion">
                    
                  </p>
                </div>
              </div>

              <div class="turno-accion">
                <div class="estado-ocupado">
                  <Tag value="Ocupado" severity="danger" />
                  <small >
                  </small>
                </div>
                <Button 
                />
              </div>
            </div>
          </div>

          <Message v-if="!cargandoTurnos && turnosDelDia.length === 0" severity="info">
            No hay turnos disponibles para este día
          </Message>
        </div>
      </div>
    </Dialog>

    <!-- Leyenda -->
    <Card class="leyenda-card">
      <template #content>
        <h4>Leyenda de disponibilidad</h4>
        <div class="leyenda-items">
          <div class="leyenda-item">
            <div class="color-indicator disponible"></div>
            <span>Totalmente disponible</span>
          </div>
          <div class="leyenda-item">
            <div class="color-indicator parcial"></div>
            <span>Parcialmente ocupado</span>
          </div>
          <div class="leyenda-item">
            <div class="color-indicator completo"></div>
            <span>Completamente ocupado</span>
          </div>
        </div>
      </template>
    </Card>
  </div>
</template>
<style src="@/assets/styles/record.css">
</style>
<style scoped>
</style>