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
    <footer>
   <div class="tcontainer"><div class="ticker-wrap"><div class="ticker-move">
  <div class="ticker-item"><i>"No one man should have all that power"</i> -John ; </div>
  <div class="ticker-item">Rachelle always wins.  </div>
  <div class="ticker-item"><i>"If you ain't first, you're last"</i> -Tom Cruise </div>
  <div class="ticker-item"><i>“Kowabunga dudettes. I’m so pumped to be on this surfing kick. Who else surfs out there? Gnarly day in the H20. Ridin’ waves!”</i> -Rachelle </div>
  <div class="ticker-item">It depends. &nbsp;&nbsp; </div>
  <div id ="hide" class="ticker-item">  Lorem ipsum dolor sit amet, consectetur adipiscing elit,  </div>
  <div id ="hide" class="ticker-item">     Lorem ipsum dolor sit amet, consectetur adipiscing elit,        </div>
  <div id ="hide" class="ticker-item">           Lorem ipsum dolor sit amet, consectetur adipiscing elit,   </div>
  <!-- make ticker smoother ending-->
</div></div></div> </footer>
    
  </div>

  

  
</template>



<style>
body {
  
  background-color: #374968;
  min-height: 100vh;
}

#app {
  font-family: Microsoft JhengHei, Calibri, Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color:  #cce1e6;
  text-transform: uppercase;
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #abbad3;
  text-shadow: 2px 2px 2px black;
  
}

#navlink:hover{
  text-shadow: 5px 5px 5px black;
}


#nav a.router-link-exact-active {
  color:#cfe9af;
  
}

footer {
  width: 100%;
  font-size: 30px;
   position: absolute;
  bottom: 5px;
}

/* OUTER CONTAINER */
.tcontainer {
  width: 100%;
  overflow: hidden; /* Hide scroll bar */
}
 
/* MIDDLE CONTAINER */
.ticker-wrap {
  width: 100%;
  padding-left: 100%; /* Push contents to right side of screen */
  background-color: #cce1e6;
}

/* INNER CONTAINER */
@keyframes ticker {
  0% { transform: translate3d(0, 0, 0); }
  100% { transform: translate3d(-100%, 0, 0); }
}
.ticker-move {
  /* Basically move items from right side of screen to left in infinite loop */
  display: inline-block;
  white-space: nowrap;
  padding-right: 100%;
  animation-iteration-count: infinite;
  animation-timing-function: linear;
  animation-name: ticker;
  animation-duration: 40s;
}
.ticker-move:hover{
  animation-play-state: paused; /* Pause scroll on mouse hover */
}

/* ITEMS */
.ticker-item{
  display: inline-block; /* Lay items in a horizontal line */
  padding: 0 2rem;
  color: #4c8a9a;
  text-shadow: 2px 2px 2px #374968;
}

#hide{
  color:#cce1e6;
  text-shadow: none;
}


</style>



