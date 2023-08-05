<template>
    <div class="container-fluid">
        <h3 class="my-2 border-bottom border-dark">REVIEW </h3>
        <form class="row " @submit.prevent="submitReview(movie.id)">
            <section>
                <section>
                    <div class="mb-3">
                        <label for="" class="form-label">Title</label>
                        <input type="text" class="form-control" v-model="editable.title" name="title" id=""
                            aria-describedby="title" placeholder="">
                    </div>
                    <div class="mb-3">
                        <label for="" class="form-label">Overall Opinions!</label>
                        <input type="text-area" class="form-control" v-model="editable.description" name="description" id=""
                            aria-describedby="helpId" placeholder="">
                    </div>
                </section>
                <section class="d-flex justify-content-around">
                    <div class="mb-3">
                        <label for="" class="form-label">Rate Visuals</label>
                        <input type="number" class="form-control" v-model="editable.catOne" name="CatOne" id=""
                            aria-describedby="catOne" placeholder="0" max="10">
                    </div>
                    <div class="mb-3">
                        <label for="" class="form-label">Rate Music</label>
                        <input type="number" class="form-control" v-model="editable.catTwo" name="CatOne" id=""
                            aria-describedby="catOne" placeholder="0" max="10">
                    </div>
                </section>
            </section>
            <button class="btn btn-success" data-bs-dismiss="modal" :disabled="!isFormComplete"><i
                    class=" fs-2 mdi mdi-shape-square-plus"></i></button>
        </form>
    </div>
    <!-- <h1>review form</h1> -->
</template>


<script>
import { computed, ref } from 'vue';
import { AppState } from '../AppState';
import { reviewServices } from '../services/ReviewServices';
import Pop from '../utils/Pop';

export default {
    computed: {
        isFormComplete() {
            return this.editable.title && this.editable.description && this.editable.catOne && this.editable.catTwo;
        }
    },
    setup() {
        const editable = ref({})
        return {
            editable,
            movie: computed(() => AppState.movie),
            async submitReview(movieId) {
                try {

                    const review = editable.value
                    review.movie_id = movieId
                    await reviewServices.submitReview(review)
                    Pop.success('reviewed  ' + this.movie.title)
                } catch (error) {
                    Pop.error('Something Went Wrong?!!', error.message)
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped></style>