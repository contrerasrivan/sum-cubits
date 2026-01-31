export interface CreateReservationRequest {
    fechaReserva: string;
    idSalon: number;
    idTurnos: number[];
    idEstado: number;
}