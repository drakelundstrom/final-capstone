<template>
  <div id="register" class="text-center">
    <form class="form-register" @submit.prevent="register">
      <h1 class="h3 mb-3 font-weight-normal">Create Account</h1>
      <div class="alert alert-danger" role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
      </div>
      <label for="username" class="sr-only">Username</label>
      <input :maxlength="max"
        type="text"
        id="username"
        class="form-control"
        placeholder="Username(50 char max)"
        v-model="user.username"
        required
        autofocus
      />
      <label for="password" class="sr-only">Password</label>
      <input :maxlength="max"
        type="password"
        id="password"
        class="form-control"
        placeholder="Password(50 char max)"
        v-model="user.password"
        required
      />
      <input :maxlength="max"
        type="password"
        id="confirmPassword"
        class="form-control"
        placeholder="Confirm Password"
        v-model="user.confirmPassword"
        required
      />
      <select id="userRole" v-model="user.role">
          <option value="user">Participant Only</option>
         <option value="admin">Creator and Participant</option>
        </select>
      <router-link :to="{ name: 'login' }" id="login-link">Have an account?</router-link>
      <button  type="submit">
        Create Account
      </button>
    </form>
  </div>
</template>

<script>
import authService from '../services/AuthService';

export default {
  name: 'register',
  data() {
    return {
      max: 50,
      user: {
        username: '',
        password: '',
        confirmPassword: '',
        role: 'user',
      },
      registrationErrors: false,
      registrationErrorMsg: 'There were problems registering this user.',
    };
  },
  methods: {
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = 'Password & Confirm Password do not match.';
      } else {
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
              this.$router.push({
                path: '/login',
                query: { registration: 'success' },
              });
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = 'Bad Request: Validation Errors';
            }
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = 'There were problems registering this user.';
    },
  },
};
</script>

<style>

#confirmPassword{
  grid-area: confirm;
}

 #confirmPassword{
  display: grid;
  grid: 
  'confirm';
  margin-left: auto;
  margin-right: auto;
  border-radius: 40px;
  margin-bottom: 5px;
  background-color: #e7f4d7;
}

#login-link{
  padding: 5px;
  font-weight: bold;
  color:  #abbad3;
}

button{
  grid-area: submitbtn;
  border-radius: 8px;
background-color: #f2f2f2;
border: 2px solid  #e7f4d7;
}
#userRole{
  margin-left: auto;
  margin-right: auto;
  display: grid;
}

</style>
