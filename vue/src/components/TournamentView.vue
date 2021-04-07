<template>
  <div>
    <!-- message? -->
<!-- I would like to make the search a button to collapse, but not sure on event handling -->
    <div id="search-function">
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
      })  //insert this then into the tourncreate then? 
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
    filteredList() {
      console.log(this.$store.state.tournaments)
      return this.$store.state.tournaments.filter((a) => {
        return (
          a.tournamentName
            .toLowerCase()
            .includes(this.filter.tournamentName.toLowerCase())  &&
          a.tournamentId.toString()
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
    sports() {
      return this.$store.state.sports;
    },
  },
};
</script>

<style>

h3{
  font-size: 23px;
  color: #87b8c4;
}
p{
  font-size: 15px;
  color: #87b8c4;
}
input{
  height: 17px;
  width: 8%; 
  border-radius: 20px;
  background-color: #e7f4d7;

}

select{
   border-radius: 20px;
  background-color: #e7f4d7;

}
table{
    border-collapse: collapse;
        border-radius: 27px;
        border-style: hidden; 
        box-shadow: 0 0 0 3px #abd874;
        
        justify-content: center;
        margin-left: auto;
        margin-right: auto;
}
th{
  padding-right: 10px;
  padding-left: 10px;
}

td{
  padding-right: 10px;
  padding-left: 10px;
}
</style>

