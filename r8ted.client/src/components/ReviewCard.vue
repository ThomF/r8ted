<template>
    <div class="card">
        <div class="card-body">
            <!-- TODO look into grabbing user info on these? -->
            <div>
                <h5>{{ review.userName }}</h5>
                <h4>{{ review.title }}</h4>
                <p>{{ review.description }}</p>
            </div>
        </div>
        <i class=" text-danger mdi mdi-heart">{{ review.likes }}</i>
    </div>
</template>


<script>
import { Account } from '../models/Account';
import { Review } from '../models/Review';

export default {
    props: {
        review: { type: Review },
        account: { type: Account }
    },
    setup() {
        return {

        }
    }
}
</script>


<style lang="scss" scoped></style>