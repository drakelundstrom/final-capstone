<template>
  <div>
    <form v-on:submit.prevent="onSubmit">
      <input required type="text" v-model="newTournament.tournamentName" />
      <label for="">Tournament Name</label>
      <input
        type="text"
        name="Tournament"
        list="Tournaments"
        v-model="newTournament.sportName"
      />
      <select>
        <option
          id="Tournaments"
          v-for="(sport, index) in sports"
          v-bind:key="index"
          
        >
          {{ sport.sportName }}
        </option>
      </select>
      <label for="">Sport</label>
      <input type="submit" />
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
      sports: this.$store.state.sports,
    };
  },
  methods: {
    onSubmit() {
      this.$store.commit("ADD_TOURNAMENT", this.newTournament);
      TournamentService.createTournament(this.newTournament)
        .then(this.$router.push({ name: "Tournaments" }))
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
};
</script>

<style>
</style>