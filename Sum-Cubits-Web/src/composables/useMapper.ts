//imports Dtos
import type { ReservaDto } from "@/features/reservation/models/ReservaDto";
import type { TurnoDto } from "@/features/turns/models/TurnoDto";


export function useMapper() {
  const fromReservaDto = <T>(dto?: ReservaDto): T => mapTo<T>(dto)
  const fromTurnoDto = <T>(dto?: TurnoDto): T => mapTo<T>(dto)

  const mapTo = <T>(dto?: unknown): T => {
    const obj: T = {} as T
    // @ts-expect-error we don't have specific type to manage
    Object.keys(dto).map((key: string) => (obj[key] = dto[key]))
    return obj
  }

  return {
    fromReservaDto,
    fromTurnoDto
  }
}

  
