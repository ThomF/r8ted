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
    <div v-else>
        <div class="container">
            <div class="row">
                <div class="col-4 offset-4">
                    <span class="loader bg-dark">
                        <span class="loader_ball"></span>
                        <span class="loader_ball"></span>
                        <span class="loader_ball"></span>
                    </span>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { computed, onMounted, onUnmounted } from 'vue';
import { useRoute } from 'vue-router';
import { AppState } from '../AppState';
import { movieServices } from '../services/MovieServices';
import { logger } from '../utils/Logger';

export default {

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

        onMounted(() => {
            getMovie()
        })
        onUnmounted(() => {
            AppState.movie = null
        })
        return {
            movie: computed(() => AppState.movie),
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