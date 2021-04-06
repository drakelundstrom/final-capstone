<template>
  <div>
    <!-- message? -->
    <div id="search-function">
      <h3>Search tournaments:</h3>
      <p>
        Tournament Name
        <input type="text" id="tourNameFilter" /> 
      </p>
      <p>
        Tournament ID
        <input type="text" id="tourIdFilter"  />
      </p>
      <p>
        Creator
        <input type="text" id="creator"  />
      </p>
      <!--v-model="filter.firstName"  v-model="filter.lastName" v-model="filter.username"
      v-model="filter.emailAddress"  v-model="filter.status">
          <option value="">Show All</option>
          <option value="Active">Active</option>
          <option value="Disabled">Disabled</option>-->
      <p>
        Select a sport:
         <select id="statusFilter" >
        </select>
      </p>
      <p>
        Tournament Status 
        <select id="statusFilter" >
        </select>
      </p>
    </div>

    <table id="list-of-tournaments">
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
          v-for="(tournament, index) in $store.state.tournaments"
          v-bind:key="index"
        >
          <td>{{ tournament.tournamentName }}</td>
          <td>{{ tournament.tournamentId }}</td>
          <td>{{ tournament.sportName }}</td>
          <td>{{ tournament.creatorUsername }}</td>
          <td>{{ tournament.tourComplete }}</td>
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

  methods: {},

  created() {
    tournamentService
      .getTournaments()
      .then((response) => {
        this.$store.commit("SET_TOURNAMENTS", response.data);
      })
      .catch((error) => {
        {
          const response = error.response;
          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        }
      });
  },
};
</script>

<style>
</style>

