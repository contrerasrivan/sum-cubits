import { useHttp } from '@/composables/useHttp'

import type { GetPermissionListResponse } from '@/features/permissions/interfaces/GetPermiisionListResponse'
import type { GetRoleListResponse } from '@/features/roles/interfaces/GetRoleListResponse'
import type { GetRoleListRequest } from '@/features/roles/interfaces/GetRoleListRequest'
import type { GetViewListResponse } from '@/features/views/interfaces/GetViewListResponse'
import type { GetRoleResponse } from '@/features/roles/interfaces/GetRoleResponse'

import type { PermissionDto } from '@/features/permissions/models/PemissionDto'
import type { RoleDto } from '@/features/roles/models/RoleDto'
import type { ViewDto } from '@/features/views/models/VistasDto'
import type { PaginatedRoleListDto } from '@/features/roles/models/PaginatedRoleListDto'


export default class RoleService {
  API_URL = 'roles'

  async getList(request?: GetRoleListRequest): Promise<PaginatedRoleListDto | undefined> {
    const { data } = await useHttp(this.API_URL, request).get().json<GetRoleListResponse>()
      if (!data.value) return undefined;
    return {
    roleList: data.value?.rolesList,
    totalCount: data.value?.totalCount
  }
  }

  async get(roleId: number): Promise<RoleDto | undefined> {
    const url = `${this.API_URL}/${roleId}`
    const { data } = await useHttp(url).get().json<GetRoleResponse>()
    return data.value?.role
  }

  async getViewList(roleId: number): Promise<ViewDto[] | undefined> {
    const url = `${this.API_URL}/${roleId}/views`
    const { data } = await useHttp(url).get().json<GetViewListResponse>()
    return data.value?.viewDtos
  }

  async getPermissionList(roleId: number): Promise<PermissionDto[] | undefined> {
    const url = `${this.API_URL}/${roleId}/permissions`
    const { data } = await useHttp(url).get().json<GetPermissionListResponse>()
    return data.value?.permissionsList
  }

/*   async create(request: CreateRoleRequest): Promise<void> {
    await useHttp(this.API_URL).post(request)
  }

  async createRoleView(request: CreateRoleViewRequest): Promise<void> {
    const url = `${this.API_URL}/${request.roleId}/views/${request.viewId}`
    await useHttp(url).post()
  }

  async createRolePermission(request: CreateRolePermissionRequest): Promise<void> {
    const url = `${this.API_URL}/${request.roleId}/permissions/${request.permissionId}`
    await useHttp(url).post()
  }

  async update(roleId: number, request: UpdateRoleRequest): Promise<void> {
    const url = `${this.API_URL}/${roleId}`
    await useHttp(url).put(request)
  } */

/*   async recover(roleId: number): Promise<void> {
    const url = `${this.API_URL}/${roleId}/recover`
    await useHttp(url).put()
  }

  async delete(roleId: number): Promise<void> {
    const url = `${this.API_URL}/${roleId}`
    await useHttp(url).delete()
  } */

/*   async deleteRoleView(request: DeleteRoleViewRequest): Promise<void> {
    const url = `${this.API_URL}/${request.roleId}/views/${request.viewId}`
    await useHttp(url).delete()
  }

  async deleteRolePermission(request: DeleteRolePermissionRequest): Promise<void> {
    const url = `${this.API_URL}/${request.roleId}/permissions/${request.permissionId}`
    await useHttp(url).delete()
  } */
}
