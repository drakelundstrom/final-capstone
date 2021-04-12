<template>
  <div>
    <h1>Tournament Schedule</h1>
    <div class="bracketContainer" id="eightTeams">
      <div class="box quarterfinals1">{{ this.position8 }}</div>
      <div class="box quarterfinals2">{{ this.position9 }}</div>
      <div class="box quarterfinals3">{{ this.position10 }}</div>
      <div class="box quarterfinals4">{{ this.position11 }}</div>
      <div class="box quarterfinals5">{{ this.position12 }}</div>
      <div class="box quarterfinals6">{{ this.position13 }}</div>
      <div class="box quarterfinals7">{{ this.position14 }}</div>
      <div class="box quarterfinals8">{{ this.position15 }}</div>
      <div class="box semifinals1">{{ this.position4 }}</div>
      <div class="box semifinals2">{{ this.position5 }}</div>
      <div class="box semifinals3">{{ this.position6 }}</div>
      <div class="box semifinals4">{{ this.position7 }}</div>
      <div class="box finals1">{{ this.position2 }}</div>
      <div class="box finals2">{{ this.position3 }}</div>
      <div class="box winner">{{ this.position1 }}</div>
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
      if (this.participants.length >= 3 && this.participants.length < 5) {
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
      if (this.participants.length >= 3 && this.participants.length < 6) {
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
      if (this.participants.length >= 4 && this.participants.length < 7) {
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
      if (this.participants.length >= 4 && this.participants.length < 8) {
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
      if (this.participants.length >= 5 && this.participants.length < 9) {
        return this.participants[0].username;
      }
      if (this.matches.length >= this.tournament.numberOfMatches - 14) {
        return this.matches[this.tournament.numberOfMatches - 15]
          .victorTeamName;
      }
      return "";
    },
    quarterFinal2() {
      if (this.participants.length < 5) {
        return "";
      }
      if (this.participants.length >= 5 && this.participants.length < 10) {
        return this.participants[1].username;
      }
      if (this.matches.length >= this.tournament.numberOfMatches - 13) {
        return this.matches[this.tournament.numberOfMatches - 14]
          .victorTeamName;
      }
      return "";
    },
    quarterFinal3() {
      if (this.participants.length < 6) {
        return "";
      }
      if (this.participants.length >= 6 && this.participants.length < 11) {
        return this.participants[2].username;
      }
      if (this.matches.length >= this.tournament.numberOfMatches - 12) {
        return this.matches[this.tournament.numberOfMatches - 13]
          .victorTeamName;
      }
      return "";
    },
    quarterFinal4() {
      if (this.participants.length < 6) {
        return "";
      }
      if (this.participants.length >= 6 && this.participants.length < 12) {
        return this.participants[3].username;
      }
      if (this.matches.length >= this.tournament.numberOfMatches - 11) {
        return this.matches[this.tournament.numberOfMatches - 12]
          .victorTeamName;
      }
      return "";
    },
    quarterFinal5() {
      if (this.participants.length < 7) {
        return "";
      }
      if (this.participants.length >= 7 && this.participants.length < 13) {
        return this.participants[4].username;
      }
      if (this.matches.length >= this.tournament.numberOfMatches - 10) {
        return this.matches[this.tournament.numberOfMatches - 11]
          .victorTeamName;
      }
      return "";
    },
    quarterFinal6() {
      if (this.participants.length < 7) {
        return "";
      }
      if (this.participants.length >= 7 && this.participants.length < 14) {
        return this.participants[5].username;
      }
      if (this.matches.length >= this.tournament.numberOfMatches - 9) {
        return this.matches[this.tournament.numberOfMatches - 10]
          .victorTeamName;
      }
      return "";
    },
    quarterFinal7() {
      if (this.participants.length < 8) {
        return "";
      }
      if (this.participants.length >= 8 && this.participants.length < 15) {
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
      if (this.participants.length >= 8 && this.participants.length < 16) {
        return this.participants[7].username;
      }
      if (this.matches.length >= this.tournament.numberOfMatches - 7) {
        return this.matches[this.tournament.numberOfMatches - 8].victorTeamName;
      }
      return "";
    },
    position1() {
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
    position2() {
      return this.nameInBracket(2);
    },
    position3() {
      return this.nameInBracket(3);
    },
    position4() {
      return this.nameInBracket(4);
    },
    position5() {
      return this.nameInBracket(5);
    },
    position6() {
      return this.nameInBracket(6);
    },
    position7() {
      return this.nameInBracket(7);
    },
    position8() {
      return this.nameInBracket(8);
    },
    position9() {
      return this.nameInBracket(9);
    },
    position10() {
      return this.nameInBracket(10);
    },
    position11() {
      return this.nameInBracket(11);
    },
    position12() {
      return this.nameInBracket(12);
    },
    position13() {
      return this.nameInBracket(13);
    },
    position14() {
      return this.nameInBracket(14);
    },
    position15() {
      return this.nameInBracket(15);
    },
  },
  methods: {
    nameInBracket(locationNumber) {
      // removing extra participants
      if (locationNumber > 2 * this.participants.length - 1) {
        return "";
      }
      if (
        locationNumber - this.tournament.numberOfMatches <=
        this.participants.length
      ) {
        return this.participants[
          locationNumber - this.tournament.numberOfMatches
        ].username;
      }

      switch (locationNumber) {
        case 2:
          if (this.matches.length >= this.tournament.numberOfMatches - 2) {
            return this.matches[this.tournament.numberOfMatches - 3]
              .victorTeamName;
          }
          break;
        case 3:
          if (this.matches.length >= this.tournament.numberOfMatches - 1) {
            return this.matches[this.tournament.numberOfMatches - 2]
              .victorTeamName;
          }
          break;
        case 4:
          if (this.matches.length >= this.tournament.numberOfMatches - 6) {
            return this.matches[this.tournament.numberOfMatches - 7]
              .victorTeamName;
          }
          break;
        case 5:
          if (this.matches.length >= this.tournament.numberOfMatches - 5) {
            return this.matches[this.tournament.numberOfMatches - 6]
              .victorTeamName;
          }
          break;
        case 6:
          if (this.matches.length >= this.tournament.numberOfMatches - 4) {
            return this.matches[this.tournament.numberOfMatches - 5]
              .victorTeamName;
          }
          break;
        case 7:
          if (this.matches.length >= this.tournament.numberOfMatches - 3) {
            return this.matches[this.tournament.numberOfMatches - 4]
              .victorTeamName;
          }
          break;
        case 8:
          if (this.matches.length >= this.tournament.numberOfMatches - 14) {
            return this.matches[this.tournament.numberOfMatches - 15]
              .victorTeamName;
          }
          break;
        case 9:
          if (this.matches.length >= this.tournament.numberOfMatches - 13) {
            return this.matches[this.tournament.numberOfMatches - 14]
              .victorTeamName;
          }
          break;
        case 10:
          if (this.matches.length >= this.tournament.numberOfMatches - 12) {
            return this.matches[this.tournament.numberOfMatches - 13]
              .victorTeamName;
          }
          break;
        case 11:
          if (this.matches.length >= this.tournament.numberOfMatches - 11) {
            return this.matches[this.tournament.numberOfMatches - 12]
              .victorTeamName;
          }
          break;
        case 12:
          if (this.matches.length >= this.tournament.numberOfMatches - 10) {
            return this.matches[this.tournament.numberOfMatches - 11]
              .victorTeamName;
          }

          break;
        case 13:
          if (this.matches.length >= this.tournament.numberOfMatches - 9) {
            return this.matches[this.tournament.numberOfMatches - 10]
              .victorTeamName;
          }
          break;
        case 14:
          if (this.matches.length >= this.tournament.numberOfMatches - 8) {
            return this.matches[this.tournament.numberOfMatches - 9]
              .victorTeamName;
          }
          break;
        case 15:
          if (this.matches.length >= this.tournament.numberOfMatches - 7) {
            return this.matches[this.tournament.numberOfMatches - 8]
              .victorTeamName;
          }
          break;
      }

      return "";
    },
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