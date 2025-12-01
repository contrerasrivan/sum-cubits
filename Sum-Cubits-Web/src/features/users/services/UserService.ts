import { useHttp } from '@/composables/useHttp'

import type { GetUserRolId } from '@/features/users/interfaces/GetUserRolIdResponse'

export default class UserService {
  API_URL = 'users'

  async getRoleId(userEmail: string): Promise<number> {
    const url = `${this.API_URL}/${userEmail}/rol`
    const { data } = await useHttp(url).get().json<GetUserRolId>()
    return data.value?.roleId ?? 0
  }
}