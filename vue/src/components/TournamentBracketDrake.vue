<template>
  <div>
    <h1>Tournament Schedule</h1>
    <div class="bracketContainer" id="eightTeams">
      <div class="box quarterfinals1">{{this.quarterFinal1}}</div>
      <div class="box quarterfinals2">{{this.quarterFinal2}}</div>
      <div class="box quarterfinals3">{{this.quarterFinal3}}</div>
      <div class="box quarterfinals4">{{this.quarterFinal4}}</div>
      <div class="box quarterfinals5">{{this.quarterFinal5}}</div>
      <div class="box quarterfinals6">{{this.quarterFinal6}}</div>
      <div class="box quarterfinals7">{{this.quarterFinal7}}</div>
      <div class="box quarterfinals8">{{this.quarterFinal8}}</div>
      <div class="box semifinals1">{{this.semiFinal1}}</div>
      <div class="box semifinals2">{{this.semiFinal2}}</div>
      <div class="box semifinals3">{{this.semiFinal3}}</div>
      <div class="box semifinals4">{{this.semiFinal4}}</div>
      <div class="box finals1">{{ this.final1 }}</div>
      <div class="box finals2">{{ this.final2 }}</div>
      <div class="box winner">{{ this.winner }}</div>
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
        return "";
      }
      if (this.participants.length == 1) {
        return this.participants[0].username;
      }
      if (this.matches.length == this.tournament.numberOfMatches) {
        return this.matches[this.tournament.numberOfMatches - 1].victorTeamName;
      }

      return "";
    },
    final1() {
      if (this.participants.length < 2) {
        return "";
      }
      if (this.participants.length == 2) {
        return this.participants[0].username;
      }
      if (this.matches.length >= this.tournament.numberOfMatches - 2) {
        return this.matches[this.tournament.numberOfMatches - 3].victorTeamName;
      }
     return "";
    },
    final2() {
      if (this.participants.length < 2) {
        return "";
      }
      if (this.participants.length == 2 || this.participants.length == 3) {
        return this.participants[1].username;
      }
      if (this.matches.length >= this.tournament.numberOfMatches - 1) {
        return this.matches[this.tournament.numberOfMatches - 2].victorTeamName;
      }
      return "";
    },
    semiFinal1() {
      if (this.participants.length < 3) {
        return "";
      }
      if (this.participants.length >= 3 && this.participants.length <5) {
        return this.participants[0].username;
      }
      if (this.matches.length >= this.tournament.numberOfMatches - 6) {
        return this.matches[this.tournament.numberOfMatches - 7].victorTeamName;
      }
      return "";
    },
    semiFinal2() {
      if (this.participants.length < 3) {
        return "";
      }
      if (this.participants.length >= 3 && this.participants.length <6) {
        return this.participants[1].username;
      }
      if (this.matches.length >= this.tournament.numberOfMatches - 5) {
        return this.matches[this.tournament.numberOfMatches - 6].victorTeamName;
      }
      return "";
    },
    semiFinal3() {
      if (this.participants.length < 4) {
        return "";
      }
      if (this.participants.length >= 4 && this.participants.length <7) {
        return this.participants[2].username;
      }
      if (this.matches.length >= this.tournament.numberOfMatches - 4) {
        return this.matches[this.tournament.numberOfMatches - 5].victorTeamName;
      }
      return "";
    },
    semiFinal4() {
      if (this.participants.length < 4) {
        return "";
      }
      if (this.participants.length >= 4 && this.participants.length <8) {
        return this.participants[3].username;
      }
      if (this.matches.length >= this.tournament.numberOfMatches - 3) {
        return this.matches[this.tournament.numberOfMatches - 4].victorTeamName;
      }
      return "";
    },
    quarterFinal1() {
      if (this.participants.length < 5) {
        return "";
      }
      if (this.participants.length >= 5 && this.participants.length <9) {
        return this.participants[0].username;
      }
      if (this.matches.length >= this.tournament.numberOfMatches - 14) {
        return this.matches[this.tournament.numberOfMatches - 15].victorTeamName;
      }
      return "";
    },
    quarterFinal2() {
      if (this.participants.length < 5) {
        return "";
      }
      if (this.participants.length >= 5 && this.participants.length <10) {
        return this.participants[1].username;
      }
      if (this.matches.length >= this.tournament.numberOfMatches - 13) {
        return this.matches[this.tournament.numberOfMatches - 14].victorTeamName;
      }
      return "";
    },
    quarterFinal3() {
      if (this.participants.length < 6) {
        return "";
      }
      if (this.participants.length >= 6 && this.participants.length <11) {
        return this.participants[2].username;
      }
      if (this.matches.length >= this.tournament.numberOfMatches - 12) {
        return this.matches[this.tournament.numberOfMatches - 13].victorTeamName;
      }
      return "";
    },
    quarterFinal4() {
      if (this.participants.length < 6) {
        return "";
      }
      if (this.participants.length >= 6 && this.participants.length <12) {
        return this.participants[3].username;
      }
      if (this.matches.length >= this.tournament.numberOfMatches - 11) {
        return this.matches[this.tournament.numberOfMatches - 12].victorTeamName;
      }
      return "";
    },
    quarterFinal5() {
      if (this.participants.length < 7) {
        return "";
      }
      if (this.participants.length >= 7 && this.participants.length <13) {
        return this.participants[4].username;
      }
      if (this.matches.length >= this.tournament.numberOfMatches - 10) {
        return this.matches[this.tournament.numberOfMatches - 11].victorTeamName;
      }
      return "";
    },
    quarterFinal6() {
      if (this.participants.length < 7) {
        return "";
      }
      if (this.participants.length >= 7 && this.participants.length <14) {
        return this.participants[5].username;
      }
      if (this.matches.length >= this.tournament.numberOfMatches - 9) {
        return this.matches[this.tournament.numberOfMatches - 10].victorTeamName;
      }
      return "";
    },
    quarterFinal7() {
      if (this.participants.length < 8) {
        return "";
      }
      if (this.participants.length >= 8 && this.participants.length <15) {
        return this.participants[6].username;
      }
      if (this.matches.length >= this.tournament.numberOfMatches - 8) {
        return this.matches[this.tournament.numberOfMatches - 9].victorTeamName;
      }
      return "";
    },
    quarterFinal8() {
      if (this.participants.length < 8) {
        return "";
      }
      if (this.participants.length >= 8 && this.participants.length <16) {
        return this.participants[7].username;
      }
      if (this.matches.length >= this.tournament.numberOfMatches - 7) {
        return this.matches[this.tournament.numberOfMatches - 8].victorTeamName;
      }
      return "";
    },
  },
 /* methods: {
  nameInBracket(locationNumber) {
      // removing extra participants
      if (locationNumber > 2 * this.participants.length - 1) {
        return "";
      }
      if (
        locationNumber - this.tournament.numberOfMatches <=
        this.participants.length
      ) {
        return this.participants[locationNumber - numberOfMatches].username;
      }
      if (GetMatchNumber(locationNumber) != -1) {
        return this.matches[GetMatchNumber(locationNumber)].victorTeamName;
      }

      return "";
    },
   
  }, */
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