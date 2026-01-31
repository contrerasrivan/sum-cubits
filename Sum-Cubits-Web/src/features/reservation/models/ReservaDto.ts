import type { TurnoDto } from "@/features/turns/models/TurnoDto";
export interface ReservaDto {
  fechaReserva: string;
  turnosDisponibles: TurnoDto[];
}