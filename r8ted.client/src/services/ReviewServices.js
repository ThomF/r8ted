import { AppState } from "../AppState"
import { Review } from "../models/Review"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class ReviewServices {
    async getReviews(movieId) {
        // logger.log('[MOVIEID in reviewServices]', movieId)
        const res = await api.get('api/review/movie/' + movieId)
        // logger.log('[GETTING REFIEWS]', res.data)
        AppState.reviews = res.data.map(r => new Review(r))
        // logger.log('[APPSTATE REVIEWS]', AppState.reviews)
    }
}
export const reviewServices = new ReviewServices()