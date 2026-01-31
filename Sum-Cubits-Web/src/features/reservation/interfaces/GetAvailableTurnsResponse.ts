export interface AvailableTurnoDto {
  turnoId: number;
  nombre: string;
  disponibili: boolean;
}

export type GetAvailableTurnsResponse = AvailableTurnoDto[];
