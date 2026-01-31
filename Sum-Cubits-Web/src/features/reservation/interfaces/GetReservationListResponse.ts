import type {ReservaDto} from "@/features/reservation/models/ReservaDto";

export interface GetReservationListResponse {
  reservationDto: ReservaDto[];
}