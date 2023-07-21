import { logger } from "../utils/Logger"
import { movieApi } from "./AxiosService"

class MovieServices {

    async getMovies() {
        const res = await movieApi.get('discover/movie')
        logger.log("[GETTING FROM TMD]", res.data)
    }



}

export const movieServices = new MovieServices()