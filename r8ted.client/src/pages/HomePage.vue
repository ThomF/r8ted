<template>
  <div class="container" v-if="movies">
    <div class="row">
      <div v-for="m in movies" class="col-3">
        <MovieCard :movie="m" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';
import { movieServices } from '../services/MovieServices';
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

    onMounted(() => {
      getMovies()
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
</style>
