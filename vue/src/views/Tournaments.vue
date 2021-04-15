<template>
  <div>
    <h1>All tournaments</h1>
    <h2><i>Click on a tournament name to view additional details</i></h2>
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
h1 {
  font-size: 35px;
}

h2 {
  font-size: 15px;
}
</style>