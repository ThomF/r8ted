<template>
  <!-- <div class="about text-center">
    <img :src="account.banner" alt="">

    <h1>Welcome {{ account.name }} !</h1>
    <img class="rounded" :src="account.picture" alt="" />
    <p>{{ account.email }}</p>
  </div> -->

  <!-- FIXME on update BG breaks so maybe get rid of banners??
                                    ***bg-coverImg
  -->
  <div class="container-fluid rounded ">
    <div class="row">
      <div class="col-3"></div>
      <div class="col-md-6">
        <div class="d-flex justify-content-center pt-5">
          <div v-if="!editorOpen">
            <img class="rounded-circle" width="300" height="300" :src="account.picture" alt="">
          </div>
          <form v-else @submit.prevent="editAccount()">
            <!-- <img class="rounded-circle" width="300" height="300" :src="account.picture" alt=""> -->
            <h3>Enter Image URL for Profile Image</h3>
            <input type="text" v-model="editable.picture" :placeholder="account.picture" class="form-control"
              maxlength="25000" minlength="0">
          </form>
        </div>
        <div class="card frosted mt-3">
          <div class="card-body">
            <div class="">
              <div class="d-flex justify-content-center">
                <div>
                  <h3 v-if="!editorOpen" class="text-center text-light"><b>{{ account.name }}</b></h3>
                  <form v-else @submit.prevent="editAccount()">
                    <input type="text" v-model="editable.name" :placeholder="account.name"
                      class="form-control text-center" maxlength="25000" minlength="0">
                  </form>
                </div>
                <p v-if="account.verified" class="mdi mdi-check-decagram text-primary fs-4" title="verified"></p>
              </div>
            </div>
            <div class="">
              <!-- NOTE look into bio? -->
              <!-- <h6 class="text-center text-light">{{ account.bio }}</h6> -->
            </div>
          </div>

          <div v-if="editorOpen == true">
            <form @submit.prevent="editAccount()">
              <button type="submit" class="btn btn-success "><i class="fs-5 mdi mdi-check"></i></button>
            </form>
          </div>
        </div>

        <div v-if="!editorOpen" class="text-center edit-btn">
          <button type="button" class="btn btn-outline justify-content-center on-hover" @click="openEditor"
            aria-label="Edit Account" title="Edit Account">
            <i class="mdi mdi-pencil fs-1 text-light"></i>
          </button>
        </div>
      </div>
    </div>
  </div>


  <!-- SECTION DONE -- CHANGE this from a modal to just editable sections on press. will look cleaner -->
  <!-- <button class="btn btn-success mdi mdi-pen" data-bs-toggle="modal" data-bs-target="#editAccount"
    title="edit account"></button> -->
  <!-- <modal id="editAccount">
    <EditAccountForm />
  </modal> -->
</template>

<script>
import { computed, onUnmounted, ref } from 'vue';
import { AppState } from '../AppState';
import { accountService } from '../services/AccountService';
import Pop from '../utils/Pop';
export default {
  setup() {
    const editable = ref({})

    onUnmounted(() => {
      AppState.accountEditor = false
    })

    return {
      editable,
      account: computed(() => AppState.account),
      coverImg: computed(() => `url("${AppState.account?.coverImg}")`),
      editorOpen: computed(() => AppState.accountEditor),
      openEditor() {
        try {
          AppState.accountEditor = true
          editable.value = { ...AppState.account }
        } catch (error) {
          Pop.error(error, 'Something Went Wrong! Try Again Later.')
        }
      },
      closeEditor() {
        try {
          AppState.accountEditor = false
        } catch (error) {
          Pop.error(error, 'Something Went Wrong! Try Again Later.')
        }
      },
      async editAccount() {
        try {
          const dataToSend = {
            name: this.editable.name,
            picture: this.editable.picture,
            banner: this.editable.coverImg
          };
          await accountService.editAccount(dataToSend);
          Pop.success("Account Edited!");
          this.editable = {};
          this.closeEditor();
          // this.coverImg = this.account?.coverImg;
        } catch (error) {
          Pop.error('Something Went Wrong! Try again Later...', error.message);
        }
      }
    }
  }
}
</script>

<style scoped>
.bg-coverImg {
  background-image: v-bind(coverImg);
  background-size: cover;
  background-position: center;
  height: 70vh;

}

.grade {
  background: rgba(160, 70, 123, 0.684);
  background: linear-gradient(180deg, rgba(177, 78, 136, 0.682) 100%, #d9dace 0%);
}

.grade:hover {
  opacity: .65;
  text-transform: uppercase;
}

.shadow-1 {
  text-shadow: 2px 2px 4px black;

}

.bebas {
  font-family: 'Bebas Neue', cursive;
  text-shadow: 1px 1px 2px black;
}

.account-data {
  transform: translateY(-120%);
}

.edit-btn {
  transform: translateY(-300%);

}

.frosted {
  box-shadow: 0 0 5px 0;
  background: inherit;
  backdrop-filter: blur(80px);
  /* font-family: 'Bebas Neue', cursive; */
  text-shadow: 1px 1px 2px black;
  /* margin: 100px; */
}

.frosted-x {
  box-shadow: 0 0 5px 0;
  background: inherit;
  /* margin: 100px; */
}
</style>
