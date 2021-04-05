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
        <tr v-for="(tournament, index) in tournaments" v-bind:key="index">
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

data(){

    return{
        message : "",
    };
},

created(){

    this.message = "";

    tournamentService
    .getTournaments()
    
}

};
</script>

<style>


</style>

