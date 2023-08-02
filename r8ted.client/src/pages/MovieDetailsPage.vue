<template>
    <div v-if="movie">
        <div class="container-fluid">
            <div class="row mt-3">
                <div class="">
                    <img class="bg-banner" :src="movie.backdropImg" :alt="movie.title">
                </div>
                <div class="col-md-4 mb-5">
                    <div class="card bg-clear elevation-5">
                        <img :src="movie.posterImg" :alt="movie.title">
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card bg-glass elevation-3">
                        <h2>{{ movie.title }}</h2>
                        <div class="card-body elevation-2">
                            {{ movie.overview }}

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div v-if="review" class="container">
        <div class="row">
            <!-- FIXME look into this -->
            <!-- <div v-if="reviews.userId && review.userId != account.id" class="card">
                create review
                <button class="btn btn-success">+</button>
            </div> -->


        </div>
        <!-- eslint-disable-next-line vue/require-v-for-key -->
        <div v-for=" r  in  review ">
            <ReviewCard :review="r" />
        </div>



    </div>
</template>


<script>
import { computed, onMounted, onUnmounted } from 'vue';
import { useRoute } from 'vue-router';
import { AppState } from '../AppState';
import { Review } from '../models/Review';
import { movieServices } from '../services/MovieServices';
import { reviewServices } from '../services/ReviewServices';
import { logger } from '../utils/Logger';

export default {
    props: {
        reviews: { type: Review }
    },
    setup() {
        const route = useRoute()

        async function getMovie() {
            try {
                const movieId = route.params.movieId
                await movieServices.getMovieById(movieId)
            } catch (error) {
                logger.error(error.message)
            }
        }
        async function getReviews() {
            try {
                const movieId = route.params.movieId
                await reviewServices.getReviews(movieId)
            } catch (error) {
                logger.error(error)
            }
        }

        onMounted(() => {
            getMovie()
            getReviews()
        })
        onUnmounted(() => {
            AppState.movie = null
        })
        return {
            movie: computed(() => AppState.movie),
            review: computed(() => AppState.reviews),
            account: computed(() => AppState.account),
            backdropImage: computed(() => `url(${AppState.movie?.backdropImg})`)
        }
    }
}
</script>


<style lang="scss" scoped>
.bg-banner {
    // background-image: v-bind(backdropImage);
    filter: blur(35px);
    height: 100vh;
    transform: scale(120%);
    z-index: -1;
    position: absolute;
}

.bg-clear {
    background-color: rgba(255, 255, 255, 0.157);
}

.bg-glass {
    // filter: blur(2px);
    // background: inherit;
    // backdrop-filter: ;

}

.loader {
    display: inline-block;
}

.loader_ball {
    display: inline-block;
    width: 25px;
    height: 25px;
    background-color: #fff;
    margin-inline: 5px;
    border-radius: 50%;
    animation: bounce 450ms alternate infinite;
}

.loader_ball:nth-child(2) {
    animation-delay: 150ms;
}

.loader_ball:nth-child(3) {
    animation-delay: 300ms;
}

@keyframes bounce {
    from {
        transform: scaleX(1.25);
    }

    to {
        transform: translateY(-50px) scaleX(1);
    }
}
</style>