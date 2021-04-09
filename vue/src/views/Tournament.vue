<template>
  <div>
    <tournament-detail v-bind:id="tournamentId" />
    <tournament-bracket-drake v-bind:id="tournamentId" />
  </div>
</template>

<script>
import TournamentDetail from "../components/TournamentDetail.vue";
 import TournamentBracketDrake from "../components/TournamentBracketDrake.vue";

export default {
  name: "Tournament",

  components: {
    TournamentDetail,
    TournamentBracketDrake,
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