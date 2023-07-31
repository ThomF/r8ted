<template>
    <div class="card">
        {{ review.title }}
    </div>
</template>


<script>
import { Review } from '../models/Review';

export default {
    props: {
        review: { type: Review }
    },
    setup() {
        return {}
    }
}
</script>


<style lang="scss" scoped></style>