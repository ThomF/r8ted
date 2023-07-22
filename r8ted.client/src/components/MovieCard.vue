<template>
    <!-- TODO Router Link to Movie Details or Pop it up? DECIDE -->
    <router-link :to="{ name: 'MovieDetails', params: { movieId: movie.id } }">
        <!-- <div class="card">
            <img :src="movie.posterImg" :alt="movie.title">
            <div class="card-body bg-dark">
                {{ movie.title }}
            </div>
        </div> -->
        <div class="image-container">
            <img :src="movie.posterImg" class="img-fluid roundCard pt-2 pb-2" alt="">
            <!-- <h2 class="hidden-text">{{ movie.title }}</h2> -->
        </div>
    </router-link>
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


<style lang="scss" scoped>
// CHAT GPT SILLY STUFF

.image-container {
    position: relative;
    display: inline-block;
}

.hidden-text {
    position: absolute;
    bottom: 0;
    left: 0;
    width: 100%;
    background-color: rgba(0, 0, 0, 0.331);
    color: white;
    text-align: center;
    padding: 10px;
    opacity: 0;
    transition: opacity 0.3s ease;
}

.image-container:hover .hidden-text {
    opacity: 1;
}


// 
.elevate {
    position: relative;
}

.elevate img {
    display: block;
    max-width: 100%;
    height: auto;
}

.elevate .ovBt {
    position: absolute;
    bottom: 0;
    left: 0;
    right: 0;
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 8px;
    background-color: rgba(0, 0, 0, 0);
    color: #fff;
    font-size: 1.2rem;
    font-weight: bold;
}

.elevate .ovBt .title {
    margin: 0;
}

.elevate .ovBt .pfp {
    width: 40px;
    height: 40px;
    border-radius: 50%;
    object-fit: cover;
}


.qfont {
    font-family: Quando;
}


.title {
    text-shadow: 2px 2px 1px black;
    // transform: translateY(-60px);
}


.roundCard {
    border-radius: 20px;
}
</style>