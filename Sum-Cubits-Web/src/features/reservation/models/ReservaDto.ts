export interface TurnoConfirmado {
  reservaId: number;
  nombreTurno: string;
  nombreSalon: string;
}

export interface ReservaDto {
  fechaReserva: string;
  turnosConfirmados: TurnoConfirmado[];
}