import { AppState } from "../AppState"
import { Movie } from "../models/Movie"
import { logger } from "../utils/Logger"
import { movieApi } from "./AxiosService"

class MovieServices {

    async getMovies() {
        const res = await movieApi.get('discover/movie')
        AppState.movies = res.data.results.map(m => new Movie(m))
        logger.log("[GETTING FROM TMD {APPSTATE}]", AppState.movies)

        AppState.currentPage = res.data.page
        AppState.totalPages = res.data.total_pages
    }

    async getMovieById(movieId) {
        const res = await movieApi.get('movie/' + movieId)
        AppState.movie = new Movie(res.data)
    }

}

export const movieServices = new MovieServices()