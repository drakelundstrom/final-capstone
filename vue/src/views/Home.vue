<template>
  <div class="home">
    <h1>Welcome back, {{$store.state.user.username}}!</h1>
    <h1>View your tournaments here</h1>
    <p>You must be authenticated to see this</p>
    <!-- <p> perhaps display past and current tournaments for current user?  </p> -->

  </div>
</template>

<script>

export default {
  name: "home",
  components: {

  }
};
</script>
