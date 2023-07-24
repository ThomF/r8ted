<template>
  <div class="about text-center">
    <img :src="account.banner" alt="">

    <h1>Welcome {{ account.name }} !</h1>
    <img class="rounded" :src="account.picture" alt="" />
    <p>{{ account.email }}</p>
  </div>
  <!-- TODO CHANGE this from a modal to just editable sections on press. will look cleaner -->
  <button class="btn btn-success mdi mdi-pen" data-bs-toggle="modal" data-bs-target="#editAccount"
    title="edit account"></button>
  <modal id="editAccount">
    <EditAccountForm />
  </modal>
</template>

<script>
import { computed } from 'vue';
import { AppState } from '../AppState';
export default {
  setup() {
    return {
      account: computed(() => AppState.account)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
