import { useHttp } from "@/composables/useHttp";

import type { GetViewListResponse } from "@/features/views/interfaces/GetViewListResponse";

import type { VistaDto } from "@/features/views/models/VistasDto";

export default class ViewService {
    API_URL = 'vistas';
    async getViewList(): Promise<VistaDto[] | undefined>  {
        const { data } = await useHttp(this.API_URL).get().json<GetViewListResponse>();
        return data.value?.vistaDtos;
    }
}