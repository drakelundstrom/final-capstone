<template>
  <div id="app">
    <div id="nav">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout |</router-link>
      <router-link v-bind:to="{ name: 'Tournaments'}" > View Tournaments</router-link>
      <router-link v-bind:to="{ name: 'CreateTournament'}" v-if="$store.state.user.role == 'admin'"> | Create a Tournament</router-link>

    </div>
    <router-view id ="sign-in" />
    <div id="title">
    
  </div>
    
  </div>

  
</template>



<style>

#app {
  font-family: Microsoft JhengHei, Calibri, Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color:  #cce1e6;
  background-color:  #374968;
  text-transform: uppercase;
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #abbad3;
}

#nav a.router-link-exact-active {
  color:#cfe9af;
}

.footer {
  font-size: 0.9rem;
}
@import '../assets/styles.css';



</style>



