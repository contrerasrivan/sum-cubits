import type { PermissionDto} from "@/features/permissions/models/PemissionDto";

export interface GetPermissionListResponse {
    permissionsList?: PermissionDto[];
}