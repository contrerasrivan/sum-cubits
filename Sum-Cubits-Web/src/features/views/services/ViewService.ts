import { useHttp } from "@/composables/useHttp";

import type { GetViewListResponse } from "@/features/views/interfaces/GetViewListResponse";

import type { ViewDto } from "@/features/views/models/ViewDto";

export default class ViewService {
    API_URL = 'views';
    async getViewList(): Promise<ViewDto[] | undefined>  {
        const { data } = await useHttp(this.API_URL).get().json<GetViewListResponse>();
        return data.value?.viewsList;
    }
}