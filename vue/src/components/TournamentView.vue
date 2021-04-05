<template>
  <div>
    <!-- message? -->

    <table>
      <thead>
        <tr>
          <th scope="col">Tournament Name</th>
          <th scope="col">Tournament ID</th>
          <th scope="col">Sport</th>
          <th scope="col">Creator Username</th>
          <th scope="col">Status</th>
          <!-- add num of participants -->
        </tr>
      </thead>

      <tbody>
        <tr
          v-for="(tournament, index) in this.$store.state.tournaments"
          v-bind:key="index"
        >
          <td>{{ tournament.tournament_name }}</td>
          <td>{{ tournament.tournament_id }}</td>
          <td>{{ tournament.sport }}</td>
          <td>{{ tournament.creator_username }}</td>
          <td>{{ tournament.status }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import tournamentService from "../services/TournamentService.js";

export default {
  name: "TournamentView",

  data() {
    return {};
  },

  methods: {
    
  },

  created() {

      tournamentService.getTournaments().then((response) => {
        this.$store.commit("SET_TOURNAMENTS", response.data)
      })
      .catch(error => {
        {const response = error.response;
        if(response.status === 401){
          this.invalidCredentials = true;
        }

      }

      })
    }

};
</script>

<style>
</style>

