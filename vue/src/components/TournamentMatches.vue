<template>
  <div>
      <h1>Results</h1>
      <table class="table w-auto style" id="tblallmatches">
      <thead>
        <tr>
          <th scope="col">Match Number</th>
          <th scope="col">Home Team</th>
          <th scope="col">Home Score</th>
          <th scope="col">Away Team</th>
          <th scope="col">Away Score</th>
          <th scope="col">Match Victor</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(round, index) in this.matchResults" v-bind:key="index">
          <td>{{ round.matchNumber }}</td>
          <td>{{ round.homeTeamName }}</td>
          <td>{{ round.homeTeamScore }}</td>
          <td>{{ round.awayTeamName }}</td>
          <td>{{ round.awayTeamScore }}</td>
          <td>{{ round.victorTeamName }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import TournamentService from "../services/TournamentService";
export default {
    created() {
    TournamentService.getMatchesInTournament(this.$route.params.id).then(
      (response) => {
        this.$store.commit("SET_MATCHES", response.data);
      }
    );
  },
computed: {
    tournament() {
      return this.$store.state.tournament;
    },
    participants() {
      return this.$store.state.participants;
    },
    nextMatch() {
      return this.$store.state.match;
    },
    matchResults() {
      return this.$store.state.matches;
    },
},
}
</script>

<style>

</style>