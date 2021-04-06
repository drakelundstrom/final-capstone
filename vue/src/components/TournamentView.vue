<template>
  <div>
    <!-- message? -->
    <div id="search-function">
      <h3>Search tournaments:</h3>
      <p>
        Tournament Name
        <input
          type="text"
          id="tourNameFilter"
          v-model="filter.tournamentName"
        />
      </p>
      <p>
        Tournament ID
        <input type="text" id="tourIdFilter" v-model="filter.tournamentId" />
      </p>
      <p>
        Creator
        <input type="text" id="creator" v-model="filter.creatorUsername" />
      </p>
      <p>
        Select a sport:
        <select id="statusFilter" v-model="filter.sportName">
          <option value="">Any Sport</option>
          <option value="soccer">Soccer</option>
          <option value="baseball">Baseball</option>
        </select>
      </p>
      <p>
        Tournament Status
        <select id="statusFilter" v-model="filter.tourComplete">
          <option value="">Any Option</option>
          <option value="Ongoing">OnGoing</option>
          <option value="Complete">Complete</option>
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
        <tr v-for="(tournament, index) in this.filteredList" v-bind:key="index">
          <td>{{ tournament.tournamentName }}</td>
          <td>{{ tournament.tournamentId }}</td>
          <td>{{ tournament.sportName }}</td>
          <td>{{ tournament.creatorUsername }}</td>
          <td>{{ tournament.tourComplete ? "Complete" : "Ongoing" }}</td>
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
    return {
      filter: {
        tournamentName: "",
        tournamentId: "",
        creatorUsername: "",
        sportName: "",
        tourComplete: "",
      },
    };
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

  computed: {
    filteredList() {
      return this.$store.state.tournaments.filter((a) => {
        return (
          a.tournamentName
            .toLowerCase()
            .includes(this.filter.tournamentName.toLowerCase()) &&
          a.tournamentId
            .toString()
            .includes(this.filter.tournamentId.toString()) &&
          a.creatorUsername
            .toLowerCase()
            .includes(this.filter.creatorUsername.toLowerCase()) &&
          a.sportName
            .toLowerCase()
            .includes(this.filter.sportName.toLowerCase()) &&
          (a.tourComplete ? "Complete" : "Ongoing").includes(
            this.filter.tourComplete
          )
        );
      });
    },
  },
};
</script>

<style>
</style>

