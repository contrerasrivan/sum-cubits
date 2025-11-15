import type { UserDto } from '@/features/users/models/UserDto'

export interface GetUserListResponse {
  userList: UserDto[]
  totalCount: number;
}