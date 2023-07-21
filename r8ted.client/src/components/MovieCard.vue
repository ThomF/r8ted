<template>
    <!-- TODO Router Link to Movie Details or Pop it up? DECIDE -->
    <div class="card">
        <img :src="movie.posterImg" :alt="movie.title">
        <div class="card-body bg-dark">
            {{ movie.title }}
        </div>
    </div>
    <!-- <div class="bg-white rounded-lg shadow-md p-6 max-w-sm">
        <img src="https://via.placeholder.com/300" alt="Card Image">
        <h3 class="">Card Title</h3>


    </div> -->
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