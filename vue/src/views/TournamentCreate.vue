<template>
  <div class="tourcreate">
    <form v-on:submit.prevent="onSubmit" id="createNewTournament">
      <label for="">Tournament Name:</label>
      <input
        :maxlength="max"
        type="text"
        placeholder="(50 char max)"
        v-model="newTournament.tournamentName"
      />
      <p></p>
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
      <button class="thebutton" type="submit">Submit</button>
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
      max: 50,
    };
  },
  methods: {
    onSubmit() {
      this.$store.commit("ADD_TOURNAMENT", this.newTournament);
      TournamentService.createTournament(this.newTournament)
        .then(
          window.alert(
            `Tournament confirmed! Tournament name: ${this.newTournament.tournamentName} Sport: ${this.newTournament.sportName}`
          )
        )
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
input {
  height: 30px;
  width: 8%;
  border-radius: 20px;
  background-color: #d2ffe0;
}

select {
  border-radius: 20px;
  background-color: #d2ffe0;
}

button {
  border-radius: 8px;
  background-color: #d2ffe0;
  border: 2px solid #d2ffe0;
}

.tourcreate {
  background-image: url("../../assets/bnwthreepanelbckgrnd.png");
  background-color: #cccccc;
  height: 90vh;
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
  background-attachment: fixed;
  font-size: 20px;
}

.tourcreate label {
  color: #d1bcff;
  font-weight: bold;
  text-shadow: 3px 1px 2px black;
}
.thebutton{
  border: 1px solid black;
}
</style>