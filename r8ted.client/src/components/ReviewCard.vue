<template>
    <div class="card">
        <div class="card-body d-flex">
            <!-- TODO look into grabbing user info on these? -->
            <div class="d-flex flex-column p-1 m-1">
                <img class="userImg" :src="review.userImg" alt="">
                <i>{{ review.userName }}</i>
            </div>
            <div>
                <h4>{{ review.title }}</h4>
                <div class="">
                    <p>{{ review.description }}</p>
                </div>
            </div>
            <div>
                <h4>{{ review.catOne }}</h4>
            </div>
        </div>
        <div>
            <i class=" text-danger mdi mdi-heart">{{ review.likes }}</i>
        </div>
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


<style lang="scss" scoped>
.userImg {
    height: 60px;
    width: 60px;
    border-radius: 50%;
}
</style>