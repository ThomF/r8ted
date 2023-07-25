<template>
  <div class="container" v-if="movies">
    <div class="row">
      <div v-for="m in movies" class="col-3">
        <MovieCard :movie="m" />
      </div>
    </div>
  </div>

  <div v-else>
    <span class="loader bg-dark">
      <span class="loader_ball"></span>
      <span class="loader_ball"></span>
      <span class="loader_ball"></span>
    </span>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';
import { movieServices } from '../services/MovieServices';
import { reviewServices } from '../services/ReviewServices';
import { logger } from '../utils/Logger';

export default {
  setup() {
    async function getMovies() {
      try {
        await movieServices.getMovies()
      } catch (error) {
        logger.error(error)
      }
    }
    async function getReviews() {
      try {
        await reviewServices.getReviews()
      } catch (error) {
        logger.error(error)
      }
    }

    onMounted(() => {
      getMovies()
      getReviews()
    })
    return {
      movies: computed(() => AppState.movies)
    }
  }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
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
