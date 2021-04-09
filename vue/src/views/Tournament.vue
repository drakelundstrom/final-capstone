<template>
  <div>
    <tournament-detail v-bind:id="tournamentId" />
    <!-- <tournament-bracket-drake v-bind:id="tournamentId" /> -->
    <bracket v-bind:id="tournamentId" />
  </div>
</template>

<script>
import TournamentDetail from "../components/TournamentDetail.vue";
//import TournamentBracketDrake from "../components/TournamentBracketDrake.vue";
import Bracket from "../components/Bracket.vue";

export default {
  name: "Tournament",

  components: {
    TournamentDetail,
    //   TournamentBracketDrake,
    Bracket,
  },

  data() {
    return {
      tournamentId: 0,
    };
  },

  created() {
    this.tournamentId = this.$route.params.id;
  },
};
</script>

<style>
</style>