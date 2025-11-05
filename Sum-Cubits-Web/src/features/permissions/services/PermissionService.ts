import { useHttp } from "@/composables/useHttp";

import type { GetViewListResponse } from "@/features/views/interfaces/GetViewListResponse";

import type { PermissionDto } from "@/features/permissions/models/PemissionDto";
import type { GetPermissionListResponse } from "@/features/permissions/interfaces/GetPermiisionListResponse";

export default class PermissionService {
    API_URL = 'permissions';
    async getPermissionList(): Promise<PermissionDto[] | undefined>  {
        const { data } = await useHttp(this.API_URL).get().json<GetPermissionListResponse>();
        return data.value?.permissionsList;
    }
}