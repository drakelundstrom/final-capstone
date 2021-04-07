<template>
  <div>
    <!-- message? -->
    <!-- I would like to make the search a button to collapse, but not sure on event handling -->
    <p>
      Do you want to filter the tournament list?<select
        id="search active"
        v-model="searchActive"
      >
        <option value="true">yes</option>
        <option value="false">no</option>
      </select>
    </p>
    <div id="search-function" v-if="searchActive == 'true'">
      <!-- make something clickable btn, anchor tag bootstrap, showform var == true onclick data element showform default false v-if or v-show on container to hide -->
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
          <!-- <option value="soccer">Soccer</option>
          <option value="baseball">Baseball</option> -->
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
        <select id="statusFilter" v-model="filter.tournamentStaus">
          <option value="">Any Option</option>
          <option value="Recruiting">Recruiting</option>
          <option value="Active">Active</option>
          <option value="Completed">Completed</option>
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

      <tbody v-if="searchActive == 'false'">
        <!-- <tr v-for="(tournament, index) in this.filteredList" v-bind:key="index"> -->
        <tr v-for="(tournament, index) in this.tournaments" v-bind:key="index">
         <router-link id="details" v-bind:to="{name: 'Tournament', params: {id: tournament.tournamentId} }"><td>{{ tournament.tournamentName }}</td></router-link>
          <td>{{ tournament.tournamentId }}</td>
          <td>{{ tournament.sportName }}</td>
          <td>{{ tournament.creatorUsername }}</td>
          <td>{{ tournament.tournamentStaus }}</td>
          
        </tr>
      </tbody>
      <tbody v-if="searchActive == 'true'">
        <tr v-for="(tournament, index) in this.filteredList" v-bind:key="index">
          <td>{{ tournament.tournamentName }}</td>
          <td>{{ tournament.tournamentId }}</td>
          <td>{{ tournament.sportName }}</td>
          <td>{{ tournament.creatorUsername }}</td>
          <td>{{ tournament.tournamentStaus }}</td>
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
        tournamentStaus: "",
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
      }) //insert this then into the tourncreate then?
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
  //watch: {
  // call again the method if the route changes
  // '$load': 'fetchData'
  // },
  // beforeRouteEnter(to, from, next) {
  //  this.filteredList();
  // },
  computed: {
    tournaments() {
      return this.$store.state.tournaments;
    },
    filteredList() {
      // console.log(this.$store.state.tournaments);
      //  return this.$store.state.tournaments.filter((a) => {
      
      return this.tournaments.filter((a) => {
        return (
          /*   a.tournamentName
            .toLowerCase()
            .includes(this.filter.tournamentName.toLowerCase()) &&
        //  a.tournamentId
        //    .toString()
         //   .includes(this.filter.tournamentId.toString()) &&
          a.creatorUsername.includes(this.filter.creatorUsername) &&
          a.sportName.includes(this.filter.sportName) &&
          a.tournamentStaus.includes(this.filter.tournamentStaus)
          // a.tournamentId == this.filter.tournamentId && 
          */
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
          a.tournamentStaus
            .toLowerCase()
            .includes(this.filter.tournamentStaus.toLowerCase())
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
  color: #87b8c4;
}
p {
  font-size: 15px;
  color: #87b8c4;
}
input {
  height: 17px;
  width: 8%;
  border-radius: 20px;
  background-color: #e7f4d7;
}

select {
  border-radius: 20px;
  background-color: #e7f4d7;
}
table {
  border-collapse: collapse; 
  border-radius: 27px;
  border-style: hidden; 
  box-shadow: 0 0 0 3px #abd874; 

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

#details{
   font-weight: bold;
  color: #87b8c4;
}

#details:hover{
  text-shadow: 5px 5px 5px black;
}

thead{
  border-bottom: 3px solid #abd874;
}

</style>

