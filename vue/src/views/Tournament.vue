<template>
  <div>
    <tournament-detail v-bind:id="tournamentId" />
    <bracket v-bind:id="tournamentId" />
    <tournament-matches v-bind:id="tournamentId"/>
  </div>
</template>

<script>
import TournamentDetail from "../components/TournamentDetail.vue";
import Bracket from "../components/Bracket.vue";
import TournamentMatches from "../components/TournamentMatches.vue";

export default {
  name: "Tournament",

  components: {
    TournamentDetail,
    Bracket,
    TournamentMatches,
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