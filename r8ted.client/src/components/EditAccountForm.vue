<template>
    <div class="container-fluid">
        <h3 class="my-2 border-bottom border-dark text-danger">Edit Account</h3>
        <form class="row" @submit.prevent="editAccount()">
            <div class="mb-3">
                <label for="" class="form-label">Name</label>
                <input type="text" class="form-control" v-model="editable.name" name="name" id="" aria-describedby="name"
                    placeholder="">
            </div>
            <div class="mb-3">
                <label for="" class="form-label">Account Picture</label>
                <input type="text" class="form-control" v-model="editable.picture" name="picture" id=""
                    aria-describedby="helpId" placeholder="">
            </div>
            <div class="mb-3">
                <label for="" class="form-label">Cover Image</label>
                <input type="text" class="form-control" v-model="editable.banner" name="coverImg" id=""
                    aria-describedby="helpId" placeholder="">
            </div>

            <button class="btn btn-success" data-bs-dismiss="modal" :disabled="!isFormComplete"><i
                    class=" fs-2 mdi mdi-shape-square-plus"></i></button>
        </form>
    </div>
    <h1>Account form</h1>
</template>


<script>
import { ref } from 'vue';
import { accountService } from '../services/AccountService';
import Pop from '../utils/Pop';

export default {
    computed: {
        isFormComplete() {
            return this.editable.name && this.editable.picture && this.editable.banner;
        }
    },
    setup() {
        const editable = ref({})
        return {
            editable,
            async editAccount() {
                try {
                    await accountService.editAccount(editable.value)
                    Pop.success("Account Edited!")
                    editable.value = {}
                } catch (error) {
                    Pop.error('Something Went Wrong! Try again Later...', error.message)
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped></style>