<template>
  <div class="tourview">
    <p id="searching">
      Looking for a Specific Tournament?<select
        id="search active"
        v-model="searchActive"
      >
        <option value="true">yes</option>
        <option value="false">no</option>
      </select>
    </p>
    <div id="search-function" v-if="searchActive == 'true'">
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
          <option
            id="Tournaments"
            v-for="(sport, index) in sports"
            v-bind:key="index"
          >
            {{ sport.sportName }}
          </option>
        </select>
      </p>
      <p>
        Tournament Status
        <select id="statusFilter" v-model="filter.tournamentStatus">
          <option value="">Any Option</option>
          <option value="Recruiting">Recruiting</option>
          <option value="Active">Active</option>
          <option value="Completed">Completed</option>
        </select>
      </p>
    </div>

    <table class="table w-auto style" id="list-of-tournaments">
      <thead>
        <tr>
          <th scope="col">Tournament Name</th>
          <th scope="col">Tournament ID</th>
          <th scope="col">Sport</th>
          <th scope="col">Creator Username</th>
          <th scope="col">Status</th>
        </tr>
      </thead>

      <tbody v-if="searchActive == 'false'">
        <tr v-for="(tournament, index) in this.tournaments" v-bind:key="index">
          <td>
            <router-link
              id="details"
              v-bind:to="{
                name: 'Tournament',
                params: { id: tournament.tournamentId },
              }"
              >{{ tournament.tournamentName }}</router-link
            >
          </td>
          <td>{{ tournament.tournamentId }}</td>
          <td>{{ tournament.sportName }}</td>
          <td>{{ tournament.creatorUsername }}</td>
          <td>{{ tournament.tournamentStatus }}</td>
        </tr>
      </tbody>
      <tbody v-if="searchActive == 'true'">
        <tr v-for="(tournament, index) in this.filteredList" v-bind:key="index">
          <router-link
            id="details"
            v-bind:to="{
              name: 'Tournament',
              params: { id: tournament.tournamentId },
            }"
          >
            <td>{{ tournament.tournamentName }}</td></router-link
          >
          <td>{{ tournament.tournamentId }}</td>
          <td>{{ tournament.sportName }}</td>
          <td>{{ tournament.creatorUsername }}</td>
          <td>{{ tournament.tournamentStatus }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import tournamentService from "../services/TournamentService.js";
import SportsService from "../services/SportsService.js";

export default {
  name: "TournamentView",

  data() {
    return {
      filter: {
        tournamentName: "",
        tournamentId: "",
        creatorUsername: "",
        sportName: "",
        tournamentStatus: "",
      },
      searchActive: "false",
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
    SportsService.getSports().then((response) => {
      this.$store.commit("SET_SPORTS", response.data);
    });
  },
  computed: {
    tournaments() {
      return this.$store.state.tournaments;
    },
    filteredList() {
      return this.tournaments.filter((a) => {
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
          a.tournamentStatus
            .toLowerCase()
            .includes(this.filter.tournamentStatus.toLowerCase())
        );
      });
    },
    sports() {
      return this.$store.state.sports;
    },
  },
};
</script>

<style>
h3 {
  font-size: 23px;
  color: #9666ff;
}
p {
  font-size: 15px;
  color: #cbb3ff;
}
input {
  height: 17px;
  width: 8%;
  border-radius: 20px;
  background-color: #cbb3ff;
}

select {
  border-radius: 20px;
  background-color: #cbb3ff;
}
table {
  border-collapse: collapse;
  border-radius: 27px;
  border-style: hidden;
  box-shadow: 0 0 0 3px #1fff65;

  justify-content: center;
  margin-left: auto;
  margin-right: auto;
}
th {
  font-size: 18px;
  padding-right: 10px;
  padding-left: 10px;
}

td {
  padding-right: 10px;
  padding-left: 10px;
}

#details {
  font-weight: bold;
  color: #ff844c;
  text-decoration: underline;
}

#details:hover {
  text-shadow: 5px 5px 5px black;
}

thead {
  border-bottom: 3px solid #1fff65;
}

.style th {
  color: #ff844c;
}

.style td {
  color: #ffc1a5;
  border-color: #1fff65;
}

.tourview {
  background-image: url("../../assets/bnwbackground.png");
  background-color: #cccccc;
  height: 90vh;
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
  background-attachment: fixed;
}

#searching {
  font-weight: bolder;
  color: #a379ff;
  text-shadow: 0px 2px 2px white;
  font-size: 18px;
}

#search-function p {
  font-weight: bolder;
  color: #a379ff;
  text-shadow: 0px 2px 2px white;
  font-size: 17px;
}
</style>

