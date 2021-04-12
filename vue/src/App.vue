<template>
  <div id="app">
    <div id="nav">
      <router-link id ="navlink" v-bind:to="{ name: 'home' }">Home |</router-link>
      <router-link id ="navlink" v-bind:to="{ name: 'Tournaments'}" > View Tournaments |</router-link>
      <router-link id ="navlink" v-bind:to="{ name: 'login' }" v-if="$store.state.token == ''"> Login |</router-link>
      <router-link id ="navlink" v-bind:to="{ name: 'register' }" v-if="$store.state.token == ''"> Register | </router-link>
      <router-link id ="navlink" v-bind:to="{ name: 'CreateTournament'}" v-if="$store.state.user.role == 'admin'"> Create a Tournament |</router-link>
      <router-link id ="navlink" v-bind:to="{ name: 'AboutUs'}"> About Us |</router-link>
      <router-link id ="navlink" v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''"> Logout </router-link>

    </div>
    <router-view id ="sign-in" />
  
    
  </div>

  

  
</template>



<style>
body {
  
  background-image: linear-gradient(to right, #201980, #500c6f);
  min-height: 100vh;
}

#app {
  font-family: Microsoft JhengHei, Calibri, Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color:  #eee6ff;
  text-transform: uppercase;
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color:   #a379ff;
  text-shadow: 2px 2px 2px black;
  
}

#navlink:hover{
  text-shadow: 5px 5px 5px black;
}


#nav a.router-link-exact-active {
  color: #4cff84;
  
}

footer {
  width: 100%;
  font-size: 30px;
   position: absolute;
  bottom: 5px;
}





</style>



