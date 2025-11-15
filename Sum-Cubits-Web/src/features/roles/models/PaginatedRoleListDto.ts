import type { RoleDto } from "@/features/roles/models/RoleDto";

export interface PaginatedRoleListDto {
    roleList: RoleDto[];
    totalCount: number;
}