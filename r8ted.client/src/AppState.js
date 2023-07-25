import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},

  /** @type {import('./models/Movie.js').Movie[]} */
  movies: [],
  /** @type {import('./models/Review.js').Review[]} */
  reviews: [],
  /** @type {import('./models/Movie.js').Movie|null} */
  movie: null,
  /** @type {import('./models/Review.js').Review |null} */
  review: null,

  reviewForm: false,
  /** @type {Number} */
  currentPage: 0,

  /** @type {Number} */
  totalPages: 0,

  /** @type {String|null} */
  query: null
})
