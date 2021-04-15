<template>
  <div class="home">
    <h1>Welcome back, {{ $store.state.user.username }}!</h1>
    <h1>View your tournaments here</h1>

    <h2>Tournments You're In</h2>
    <table class="table style">
      <thead>
        <tr>
          <th scope="col">Tournament ID</th>
          <th scope="col">Tournament Name</th>
          <th scope="col">Sport</th>
          <th scope="col">Tournament Status</th>
          <th scope="col"></th>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="(tournament, index) in this.participantTournament"
          v-bind:key="index"
        >
          <th scope="row">{{ tournament.tournamentId }}</th>
          <td>{{ tournament.tournamentName }}</td>
          <td>{{ tournament.sportName }}</td>
          <td>{{ tournament.tournamentStatus }}</td>
          <td>
            <router-link
              id="details"
              v-bind:to="{
                name: 'Tournament',
                params: { id: tournament.tournamentId },
              }"
              >View Details</router-link
            >
          </td>
        </tr>
      </tbody>
    </table>
    <div v-if="$store.state.user.role == 'admin'">
      <h2>Tournments You've Hosted</h2>
      <table class="table style">
        <thead>
          <tr>
            <th scope="col">Tournament ID</th>
            <th scope="col">Tournament Name</th>
            <th scope="col">Sport</th>
            <th scope="col">Tournament Status</th>
            <th scope="col"></th>
          </tr>
        </thead>
        <tbody>
          <!-- filter by user id here? -->
          <tr
            v-for="(tournament, index) in this.creatorTournament"
            v-bind:key="index"
          >
            <th scope="row">{{ tournament.tournamentId }}</th>
            <td>{{ tournament.tournamentName }}</td>
            <td>{{ tournament.sportName }}</td>
            <td>{{ tournament.tournamentStatus }}</td>
            <td>
              <router-link
                id="details"
                v-bind:to="{
                  name: 'EditTournament',
                  params: { id: tournament.tournamentId },
                }"
                v-if="tournament.tournamentStatus != 'Completed'"
                >Edit</router-link
              >
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import TournamentService from "../services/TournamentService.js";

export default {
  name: "home",
  components: {},

  data() {
    return {};
  },

  created() {
    TournamentService.getTournamentByParticipant().then((response) => {
      this.$store.commit("SET_PARTICIPANT_TOURNAMENTS", response.data);
    });

    TournamentService.getTournamentByCreator().then((response) => {
      this.$store.commit("SET_CREATOR_TOURNAMENTS", response.data);
    });
  },

  computed: {
    creatorTournament() {
      return this.$store.state.creatorTournaments;
    },

    participantTournament() {
      return this.$store.state.participantTournaments;
    },
  },
};
</script>

<style>
.style {
  background-color: #fff0e9;
  opacity: .85;
  border-color: #ffa379
}
.style th {
  color: #280c66;
  border-color: #ffa379;
}

.style td {
  color: #280c66;
  border-color: #ffa379;
}

.home h2 {
  font-size: 20px;
  text-shadow: 3px 1px 2px black;
}

.home{
 
  background-image: url("../../assets/bnwthreepanelbckgrnd.png");
  background-color: #cccccc; 
  height: 90vh; 
  background-position: center; 
  background-repeat: no-repeat; 
  background-size: cover;
   background-attachment: fixed;

}

.home h1{
  text-shadow: 1px 1px 2px black, 0 0 1em #651fff  , 0 0 0.2em #651fff  ;
}
</style>
