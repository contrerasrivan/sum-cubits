<script setup lang="ts">
 import { ref, computed, onMounted } from 'vue';

// PrimeVue Components
import Card from 'primevue/card';

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

</template>
<style src="@/assets/styles/record.css">
</style>
<style scoped>
</style>