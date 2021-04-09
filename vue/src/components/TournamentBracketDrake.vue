<template>
  <div>
    <h1>Tournament Schedule</h1>
    <div class="bracketContainer" id="eightTeams">
      <div class="box quarterfinals1">a</div>
      <div class="box quarterfinals2">b</div>
      <div class="box quarterfinals3">c</div>
      <div class="box quarterfinals4">d</div>
      <div class="box quarterfinals5">e</div>
      <div class="box quarterfinals6">f</div>
      <div class="box quarterfinals7">g</div>
      <div class="box quarterfinals8">h</div>
      <div class="box semifinals1">i</div>
      <div class="box semifinals2">j</div>
      <div class="box semifinals3">k</div>
      <div class="box semifinals4">l</div>
      <div class="box finals1">m</div>
      <div class="box finals2">n</div>
      <div class="box winner">{{this.winner}}</div>
    </div>
  </div>
</template>

<script>
import TournamentService from "../services/TournamentService";
export default {
  props: ["id"],
  created() {
    TournamentService.getParticipantsInTournament(this.id).then((response) => {
      this.$store.commit("SET_PARTICIPANTS", response.data);
    });

    TournamentService.getTournament(this.id).then((response) => {
      this.$store.commit("SET_TOURNAMENT", response.data);
    });

    TournamentService.getMatchesInTournament(this.id).then((response) => {
      this.$store.commit("SET_MATCHES", response.data);
    });
  },
  computed: {
    participants() {
      return this.$store.state.participants;
    },
    tournament() {
      return this.$store.state.tournament;
    },
    matches() {
      return this.$store.state.matches;
    },
    winner() {
        if (this.participants.length == 0) {
            return this.participants[0].username;
        }

        return this.participants[1].username;
    }
  },
};
</script>

<style>
#eightTeams {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr 1fr;
  grid-template-areas:
    "quarterfinals1 semifinals1 finals1 winner"
    "quarterfinals2 semifinals1 finals1 winner"
    "quarterfinals3 semifinals2 finals1 winner"
    "quarterfinals4 semifinals2 finals1 winner"
    "quarterfinals5 semifinals3 finals2 winner"
    "quarterfinals6 semifinals3 finals2 winner"
    "quarterfinals7 semifinals4 finals2 winner"
    "quarterfinals8 semifinals4 finals2 winner";
    
}
.box {
    align-content: center;
text-justify: center;
    text-align: center;
    vertical-align: middle;
}
.quarterfinals1 {
  grid-area: quarterfinals1;
}
.quarterfinals2 {
  grid-area: quarterfinals2;
}
.quarterfinals3 {
  grid-area: quarterfinals3;
}
.quarterfinals4 {
  grid-area: quarterfinals4;
}
.quarterfinals5 {
  grid-area: quarterfinals5;
}
.quarterfinals6 {
  grid-area: quarterfinals6;
}
.quarterfinals7 {
  grid-area: quarterfinals7;
}
.quarterfinals8 {
  grid-area: quarterfinals8;
}
.semifinals1 {
  grid-area: semifinals1;
}
.semifinals2 {
  grid-area: semifinals2;
}
.semifinals3 {
  grid-area: semifinals3;
}
.semifinals4 {
  grid-area: semifinals4;
}
.finals1 {
  grid-area: finals1;
}
.finals2 {
  grid-area: finals2;
}
.winner {
  grid-area: winner;
}
</style>