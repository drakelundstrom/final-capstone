<template>
  <div>
    <form v-on:submit.prevent="onSubmit">
      <input required type="text" v-model="newTournament.tournamentName" />
      <label for="">Tournament Name</label>
      <input type="text" name="Tournament" list="Tournaments" v-model="newTournament.sportName" />
      <datalist id="Tournaments">
        <option value="Baseball" />
        <option value="Soccer" />
        <option value="Basketball" />
      </datalist>
      <label for="">Sport</label>
      <input type="submit" />
    </form>
  </div>
</template>

<script>
import TournamentService from '../services/TournamentService';
export default {
    name: "TournamentCreate",
    data() {
        return{
            newTournament: {

              "CreatorUsername": this.$store.state.user.username,
            }
        }
    },
    methods: {
        onSubmit() {
            this.$store.commit("ADD_TOURNAMENT", this.newTournament);
            TournamentService.createTournament(this.newTournament)
            .then(this.$router.push({name: 'Tournaments'}))
            .catch((error) => {
                console.log(error)
            });
            this.resetForm();
        },
        resetForm(){
            this.newTournament = {}
        }
    }
};
</script>

<style>
</style>