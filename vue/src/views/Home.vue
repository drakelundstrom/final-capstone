<template>
  <div class="home">
    <h1>Welcome back, {{$store.state.user.username}}!</h1>
    <h1>View your tournaments here</h1>
    <p>You must be authenticated to see this</p>

  <h2>Tournments You're In</h2>
    <table class="table style">
      
      <thead>
        <tr>
          <th scope="col">Tournament ID</th>
          <th scope="col">Tournament Name</th>
          <th scope="col">Sport</th>
          <th scope="col">Tournament Status</th>
          <th scope="col"> </th>

          </tr>
      </thead>
      <tbody> <!-- filter by user id here? -->
         <tr v-for="(tournament, index) in this.participantTournament" v-bind:key="index">
      <th scope="row">{{ tournament.tournamentId }}</th>
      <td>{{ tournament.tournamentName }}</td>
      <td>{{ tournament.sportName }}</td>
      <td>{{ tournament.tournamentStatus }}</td>
      <td><router-link id="details" v-bind:to="{name: 'Tournament', params: {id: tournament.tournamentId} }">View Details</router-link></td>
    </tr>
    
      </tbody>
      
      
       </table>

        <h2>Tournments You've Hosted</h2>
    <table class="table style">
      
      <thead>
        <tr>
          <th scope="col">Tournament ID</th>
          <th scope="col">Tournament Name</th>
          <th scope="col">Sport</th>
          <th scope="col">Tournament Status</th>
          <th scope="col"> </th>
          </tr>
      </thead>
      <tbody> <!-- filter by user id here? -->
         <tr v-for="(tournament, index) in this.creatorTournament" v-bind:key="index">
      <th scope="row">{{ tournament.tournamentId }}</th>
      <td>{{ tournament.tournamentName }}</td>
      <td>{{ tournament.sportName }}</td>
      <td>{{ tournament.tournamentStatus }}</td>
      <td> <!-- router link here--> </td>
    </tr>
    
      </tbody>
      
      
       </table>

       

  </div>
</template>

<script>
import TournamentService from '../services/TournamentService.js';



export default {
  
  name: "home",
  components: {

  },

  data() {
    return{

    }

  },

  created(){
     TournamentService.getTournamentByParticipant().then((response) =>{
       this.$store.commit("SET_PARTICIPANT_TOURNAMENTS", response.data);
     });

     TournamentService.getTournamentByCreator().then((response) =>{
       this.$store.commit("SET_CREATOR_TOURNAMENTS", response.data);
     });


  },

  computed: {
    creatorTournament(){
      return this.$store.state.creatorTournaments;
    },

    participantTournament(){
      return this.$store.state.participantTournaments;
    },
  }
  
}


</script>

<style>

.style {
  background-color: #5875a7 ;
}
.style th{
  color: #cce1e6;
}

.style td{
  color: #cce1e6;
  border-color: #abd874;
}

.home h2{
  font-size: 20px;
}

</style>
