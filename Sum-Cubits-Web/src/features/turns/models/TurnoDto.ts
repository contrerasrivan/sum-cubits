export interface TurnoDto {
  turnoId: number;
  reservaId: number;
  nombreTurno: string;
  nombreSalon?: string;
  disponibili: boolean;
}