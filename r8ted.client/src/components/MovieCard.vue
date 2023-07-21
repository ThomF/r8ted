<template>
    <!-- TODO Router Link to Movie Details or Pop it up? DECIDE -->
    <div class="card">
        <img :src="movie.posterImg" :alt="movie.title">
        <div class="card-body">
            {{ movie.title }}
        </div>
    </div>
</template>


<script>
import { Movie } from '../models/Movie';

export default {
    props: {
        movie: { type: Movie }
    },
    setup() {
        return {}
    }
}
</script>


<style lang="scss" scoped></style>