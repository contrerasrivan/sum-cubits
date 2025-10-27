<script setup lang="ts">
import UserService from '@/features/users/services/UserService'

import { onMounted, ref } from 'vue'
import { useI18n } from 'vue-i18n'

const userService = new UserService()
const { t } = useI18n()
</script>