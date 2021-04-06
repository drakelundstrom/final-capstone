<template>
  <div id="app">
    <div id="nav">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
<<<<<<< HEAD
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
      <router-link v-bind:to="{ name: 'Tournaments'}"> View Tournaments</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'tournament'}">Find A Tournament</router-link>&nbsp;|&nbsp;
      <!-- <router-link v-bind:to="{ name: 'createtournament'}">Create a Tournament</router-link> -->
=======
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout |</router-link>
      <router-link v-bind:to="{ name: 'Tournaments'}" > View Tournaments</router-link>&nbsp;|&nbsp;
      

      <router-link v-bind:to="{ name: 'CreateTournament'}">Create a Tournament</router-link>
>>>>>>> 8a9bfddc5d0c66462db66d6355fb428ca4ee04a5
    </div>
    <router-view id ="sign-in" />
    <div id="title">
    
  </div>
    
  </div>

  
</template>



<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}

.footer {
  font-size: 0.9rem;
}
@import '../assets/styles.css';

</style>