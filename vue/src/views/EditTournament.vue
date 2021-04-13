<template>
  <div>
    <h1>Tournament Details:</h1>
    <table id="deets" class ="table style w-auto ">
      <tbody>
        <tr>
          <td id="descrip">Tournament Name:</td>
          <td>{{ tournament.tournamentName }}</td>
        </tr>

        <tr>
          <td id="descrip">Tournament ID:</td>
          <td>{{ tournament.tournamentId }}</td>
        </tr>

        <tr>
          <td id="descrip">Sport:</td>
          <!-- is completed or not -->
          <td>{{ tournament.sportName}}</td>
        </tr>

        <tr>
          <td id="descrip">Creator:</td>
          <td>{{ tournament.creatorUsername }}</td>
        </tr>

        <tr>
          <td id="descrip">Status:</td>
          <!-- is completed or not -->
          <td>{{ tournament.tournamentStatus }}</td>
        </tr>
      </tbody>
    </table>

    <h2>Current Participants:</h2>
    <ul id="listpartic" v-for="part in this.participants" v-bind:key="part.username">
     
        <li id="partic" >{{part.username }}</li>
      
    </ul>



    <h2 id="editdescrip">Change Tournament Status</h2>
    <form v-on:submit.prevent="onSubmit">
      <select v-model="editTournament.tournamentStatus">
        <option value="Recruiting">Recruiting</option>
        <option value="Active">Active</option>
        <option value="Completed">Completed</option>
      </select>
      <button type="submit">Change</button>
    </form>


  </div>
</template>

<script>
import TournamentService from "../services/TournamentService";
export default {
  data() {
    return {
        editTournament: {
            tournamentId : parseInt(this.$route.params.id)
        }
    };
  },

  created() {
    TournamentService.getTournament(this.$route.params.id).then((response) => {
      this.$store.commit("SET_TOURNAMENT", response.data);
    });
    TournamentService.getParticipantsInTournament(this.$route.params.id).then((response) => {
      this.$store.commit("SET_PARTICIPANTS", response.data);
    });
  },
  computed: {
    tournament() {
      return this.$store.state.tournament;
    },
     participants() {
      return this.$store.state.participants;
    },

  },
  methods: {
    
    onSubmit() {
        TournamentService.editTournament(this.editTournament)
        .then(window.alert(`Tournament status successfully updated`))
        .catch((error) => {
            console.log(error)
        })
    }
  }
};
</script>

<style>
input {
  height: 30px;
  width: 8%;
  border-radius: 20px;
  background-color: #e7f4d7;
}

select {
  border-radius: 20px;
  background-color: #e7f4d7;
}

button {
  border-radius: 8px;
  background-color: #f2f2f2;
  border: 2px solid #e7f4d7;
}

#editdescrip{
  margin-bottom: 1px;
}

#deets{
  margin-bottom: 50px;
}



  #partic{
  list-style: none;
  color: #ff844c;
  
}

#partic:before {
  content: "";
  display: inline-block;
  height: 20px;
  width: 20px;
  background-size: contain;
  background-image: url("../../assets/sportsPhotos/icon.png");
}



</style>