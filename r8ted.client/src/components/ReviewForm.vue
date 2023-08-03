<template>
    <div class="container-fluid">
        <h3 class="my-2 border-bottom border-dark">REVIEW </h3>
        <form class="row" @submit.prevent="submitReview()">
            <div class="mb-3">
                <label for="" class="form-label">Title</label>
                <input type="text" class="form-control" v-model="editable.title" name="title" id="" aria-describedby="title"
                    placeholder="">
            </div>
            <div class="mb-3">
                <label for="" class="form-label">Overall Opinions!</label>
                <input type="text-area" class="form-control" v-model="editable.description" name="description" id=""
                    aria-describedby="helpId" placeholder="">
            </div>
            <div class="mb-3">
                <label for="" class="form-label">Rate coolness</label>
                <input type="number" class="form-control" v-model="editable.catOne" name="CatOne" id=""
                    aria-describedby="catOne" placeholder="0">
            </div>

            <button class="btn btn-success" data-bs-dismiss="modal" :disabled="!isFormComplete"><i
                    class=" fs-2 mdi mdi-shape-square-plus"></i></button>
        </form>
    </div>
    <h1>review form</h1>
</template>


<script>
import { ref } from 'vue';

export default {
    computed: {
        isFormComplete() {
            return this.editable.name && this.editable.picture && this.editable.banner;
        }
    },
    setup() {
        const editable = ref({})
        return {
            editable
        }
    }
}
</script>


<style lang="scss" scoped></style>