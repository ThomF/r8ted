import Axios from 'axios'
import { baseURL } from '../env'
import { logger } from '../utils/Logger'

export const api = Axios.create({
  baseURL,
  timeout: 10000
})
export const movieApi = Axios.create({
  baseURL: 'https://api.themoviedb.org/3/',
  timeout: 8000,
  params: {
    api_key: 'eb73506f1385591c710db753fe0dbbb7',
    include_adult: true
  }
})
api.interceptors.request.use(config => config, handleAxiosError)
api.interceptors.response.use(response => response, handleAxiosError)

function handleAxiosError(error) {
  if (error.response) {
    // The request was made and the server responded with a status code
    // that falls out of the range of 2xx
    logger.warn('[📡 AXIOS_ERROR_RESPONSE_DATA]', error.response.data)
  } else if (error.request) {
    // The request was made but no response was received
    logger.warn('[📡 AXIOS_ERROR_NO_RESPONSE]', error.request)
  } else {
    // Something happened in setting up the request that triggered an Error
    logger.warn('[📡 AXIOS_ERROR_INVALID_REQUEST]', error.message)
  }
  return Promise.reject(error)
}
