<template>
  <div>
    <form v-on:submit.prevent="onSubmit" id ="createNewTournament" >
      <label for="">Tournament Name:</label>
      <input required type="text" v-model="newTournament.tournamentName" />
      <p></p>
    <!--  <input
        type="text"
        name="Tournament"
        list="Tournaments"
        v-model="newTournament.sportName"
      /> -->
      <label for="">Sport:</label>
      
      <select form="createNewTournament" v-model="newTournament.sportName">
        <option
          id="Tournaments"
          v-for="(sport, index) in sports"
          v-bind:key="index"
        >
          {{ sport.sportName }}
        </option>
      </select>
      <p></p>
      <button class="btn btn-primary" type="submit" >Submit</button>
    </form>
  </div>
</template>

<script>
import TournamentService from "../services/TournamentService";
import SportsService from "../services/SportsService";
export default {
  name: "TournamentCreate",
  data() {
    return {
      newTournament: {
        CreatorUsername: this.$store.state.user.username,
      },
     // sports: this.$store.state.sports,
    };
  },
  methods: {
    onSubmit() {
      this.$store.commit("ADD_TOURNAMENT", this.newTournament);
      TournamentService.createTournament(this.newTournament)
        .then()//this.$router.push({ name: "Tournaments" }))
        .catch((error) => {
          console.log(error);
        });
      this.resetForm();
    },
    resetForm() {
      this.newTournament = {};
    },
  },
  created() {
    SportsService.getSports().then((response) => {
      this.$store.commit("SET_SPORTS", response.data);
    });
  },
  computed: {
    sports() {
      return this.$store.state.sports;
    },
  },
};
</script>

<style>
input{
  height: 30px;
  width: 8%; 
  border-radius: 20px;
  background-color: #e7f4d7;

}

select{
   border-radius: 20px;
  background-color: #e7f4d7;

}
</style>