<template>
  <div id="login" class="text-center" >
    <form class="form-signin" @submit.prevent="login">
      <h1 id="plssignin" class="h3 mb-3 font-weight-normal">Please Sign In</h1>
      <div
        class="alert alert-danger"
        role="alert"
        v-if="invalidCredentials"
      >Invalid username and password!</div>
      <div
        class="alert alert-success"
        role="alert"
        v-if="this.$route.query.registration"
      >Thank you for registering, please sign in.</div>
      <label for="username" class="sr-only">Username</label>
      <input
        type="text"
        id="username"
        class="form-control"
        placeholder="Username"
        v-model="user.username"
        required
        autofocus
      />
      <label for="password" class="sr-only">Password</label>
      <input
        type="password"
        id="password"
        class="form-control"
        placeholder="Password"
        v-model="user.password"
        required
      />
      <router-link :to="{ name: 'register' }" id ="register-link">Need an account?</router-link>
      <button id = "signinbtn" type="submit">Sign in</button>
    </form>
  </div>
</template>


<script>
import authService from "../services/AuthService";

export default {
  name: "login",
  components: {},
  data() {
    return {
      
      user: {
        username: "",
        password: ""
      },
      invalidCredentials: false
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then(response => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push("/");
          }
        })
        .catch(error => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    }
  }
};
</script>

<style>

.text-center{
  color: #eee6ff;
  text-transform: capitalize;
  
 
  
}
h1{
font-size: 15pt;
grid-area: signin;

}
input{
  width: 5%;
  height: 10pt;
  grid-area: inputboxes;

}
label{
  padding: 5px;
  grid-area: labelname;
}

#register-link{
  padding: 5px;
  font-weight: bold;
  color:  black;

  text-shadow: white 20px 0 10px;
}

button {
  grid-area: submitbtn;
  border-radius: 8px;

}

.form-control{
  grid-area: forms;
  display: flex;
  text-align: center;
  width: 15%;
}

#signinbtn{
  background-color: #d2ffe0;
}
#username{
  
  grid-area: username;
  
}

#password{
  grid-area: password;
}
#username, #password{
  display: grid;
  grid: 'username'
  'password';
  margin-left: auto;
  margin-right: auto;
  border-radius: 40px;
  margin-bottom: 5px;
  background-color:  #d2ffe0;
}


 .text-center {
  background-image: url("/sportsPhotos/trophy-picture.jpg");
  background-color: #cccccc; 
  height: 90vh; 
  background-position: center; 
  background-repeat: no-repeat; 
  background-size: cover; 
} 

#plssignin{
  text-shadow: 1px 1px 2px black, 0 0 1em #651fff  , 0 0 0.2em #651fff  ;
  color: white;
}




 


</style>
