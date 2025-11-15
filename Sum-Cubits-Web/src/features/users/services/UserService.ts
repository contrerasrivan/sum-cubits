import { useHttp } from '@/composables/useHttp'

import type { GetUserRoleIdResponse } from '@/features/users/interfaces/GetUserRoleIdResponse'

export default class UserService {
  API_URL = 'users'

  async getRoleId(): Promise<number> {
    const url = `${this.API_URL}/roleId`
    const { data } = await useHttp(url).get().json<GetUserRoleIdResponse>()
    return data.value?.roleId ?? 0
  }
}