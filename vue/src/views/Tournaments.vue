<template>
  <div>
    <h1>All tournaments</h1>
    <tournament-view />
  </div>
</template>

<script>
import TournamentView from "../components/TournamentView";

export default {
  name: "tournaments",
  components: {
    TournamentView,
    
  },
};
</script>

<style>
h1{
  font-size: 35px;
}

</style>