<script setup lang="ts">
 import { ref, computed, onMounted } from 'vue';
import FullCalendar from '@fullcalendar/vue3';

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

</script>
<template>
    <div class="reservas-container">
    <!-- Leyenda -->
    <Card class="leyenda-card">
      <template #content>
        <h4>Estados de días</h4>
        <div class="leyenda-items">
          <div class="leyenda-item">
            <div class="color-indicator disponible"></div>
            <span>Disponible</span>
          </div>
          <div class="leyenda-item">
            <div class="color-indicator completo"></div>
            <span>Ocupado</span>
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