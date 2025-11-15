import type { RoleDto } from "@/features/roles/models/RoleDto";

export interface GetRoleListResponse {
    rolesList: RoleDto[];
    totalCount: number;
}