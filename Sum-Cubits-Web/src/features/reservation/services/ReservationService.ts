import { useHttp } from "@/composables/useHttp";

//import Response or Request 
import type { GetReservationListResponse } from "@/features/reservation/interfaces/GetReservationListResponse";
import type { GetAvailableTurnsRequest } from "@/features/reservation/interfaces/GetAvailableTurnsRequest";

//import Dtos
import type { TurnoDto } from "@/features/turns/models/TurnoDto";
import type { DeleteReservationRequest } from "@/features/reservation/interfaces/DeleteReservationRequest";
import type { CreateReservationRequest } from "@/features/reservation/interfaces/CreateReservationRequest";

export default class ReservationService {
    API_URL = 'reservations'

 async getReservationList(): Promise<GetReservationListResponse> {
    const url = `${this.API_URL}`
    const { data } = await useHttp(url).get().json<GetReservationListResponse>()
    return data.value ?? { reservationDto: [] }
  }


 async deleteReservation(request: DeleteReservationRequest): Promise<void> {
    const url = `${this.API_URL}`
    const { data } = await useHttp(url).delete(request).json()
    return data.value
 }

    async createReservation(request: CreateReservationRequest): Promise<void> {
    const url = `${this.API_URL}`
    const { data } = await useHttp(url).post(request).json()
    return data.value
  }

  async getAvailableTurns(request: GetAvailableTurnsRequest): Promise<TurnoDto[] | undefined> {
    const url = `${this.API_URL}/available-turns`
    const { data } = await useHttp(url, request).get().json<TurnoDto[]>()
    return data.value ?? undefined
  }
}