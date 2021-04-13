<template>
  <div>
    <form v-on:submit.prevent="onSubmit">
      <select v-model="editTournament.tournamentStatus">
        <option value="Recruiting">Recruiting</option>
        <option value="Active">Active</option>
        <option value="Completed">Completed</option>
      </select>
      <button type="submit">Edit Tournament</button>
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
  },
  computed: {

  },
  methods: {
    tournament() {
      return this.$store.state.tournament;
    },
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
</style>