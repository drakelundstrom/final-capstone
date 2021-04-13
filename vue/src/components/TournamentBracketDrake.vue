<template>
  <div>
    <div class="bracketContainer" id="eightTeams">
      <div class="box quarterfinals1">{{ this.bracket[7].username }}</div>
      <div class="box quarterfinals2">{{ this.bracket[8].username }}</div>
      <div class="box quarterfinals3">{{ this.bracket[9].username }}</div>
      <div class="box quarterfinals4">{{ this.bracket[10].username }}</div>
      <div class="box quarterfinals5">{{ this.bracket[1].username }}</div>
      <div class="box quarterfinals6">{{ this.bracket[12].username }}</div>
      <div class="box quarterfinals7">{{ this.bracket[13].username }}</div>
      <div class="box quarterfinals8">{{ this.bracket[14].username }}</div>
      <div class="box semifinals1">{{ this.bracket[3].username }}</div>
      <div class="box semifinals2">{{ this.bracket[4].username }}</div>
      <div class="box semifinals3">{{ this.bracket[5].username }}</div>
      <div class="box semifinals4">{{ this.bracket[6].username }}</div>
      <div class="box finals1">{{ this.bracket[1].username }}</div>
      <div class="box finals2">{{ this.bracket[2].username }}</div>
      <div class="box winner">{{ this.bracket[0].username }}</div>
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
    TournamentService.getBracketForTournament(this.id).then((response) => {
      this.$store.commit("SET_BRACKET", response.data);
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
    bracket() {
      return this.$store.state.bracket;
    },
    /*
    winner() {
      if (this.participants.length == 0  || (!(this.tournament.numberOfMatches + 1)) || (this.matches.length < 0)) {
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
    finals1() {
      if (this.participants.length < 2  || (!(this.tournament.numberOfMatches)) || (this.matches.length < 0)) {
        return "";
      }
      if (this.participants.length == 2) {
        
        return this.participants[2 - this.tournament.numberOfMatches - 1]
          .username;
      }
      if (this.matches.length > this.tournament.numberOfMatches - 2) {
        return this.matches[this.tournament.numberOfMatches - 3].victorTeamName;
      }
      return "";
    },
    finals2() {
      if (this.participants.length < 2  || (!(this.tournament.numberOfMatches)) || (this.matches.length < 0)) {
        return "";
      }
      if (this.participants.length == 2 || this.participants.length == 3) {
        
        return this.participants[3 - this.tournament.numberOfMatches - 1]
          .username;
      }
      if (this.matches.length > this.tournament.numberOfMatches - 1) {
        return this.matches[this.tournament.numberOfMatches - 2].victorTeamName;
      }
      return "";
    },
    semifinals1() {
      if (this.participants.length < 3  || (!(this.tournament.numberOfMatches)) || (this.matches.length < 0)) {
        return "";
      }
      if (this.participants.length >= 3 && this.participants.length < 5) {
       
        return this.participants[4 - this.tournament.numberOfMatches - 1]
          .username;
      }
      if (this.matches.length > this.tournament.numberOfMatches - 4) {
        return this.matches[this.tournament.numberOfMatches - 7].victorTeamName;
      }
      return "";
    },
    semifinals2() {
      if (this.participants.length < 3  || (!(this.tournament.numberOfMatches)) || (this.matches.length < 0)) {
        return "";
      }
      if (this.participants.length >= 3 && this.participants.length < 6) {
       
        return this.participants[5 - this.tournament.numberOfMatches - 1]
          .username;
      }
      if (this.matches.length > this.tournament.numberOfMatches - 5) {
        return this.matches[this.tournament.numberOfMatches - 6].victorTeamName;
      }
      return "";
    },
    semifinals3() {
      if (this.participants.length < 4  || (!(this.tournament.numberOfMatches)) || (this.matches.length < 0)) {
        return "";
      }
      if (this.participants.length >= 4 && this.participants.length < 7) {
        
        return this.participants[6 - this.tournament.numberOfMatches - 1]
          .username;
      }
      if (this.matches.length > this.tournament.numberOfMatches - 4) {
        return this.matches[this.tournament.numberOfMatches - 5].victorTeamName;
      }
      return "";
    },
    semifinals4() {
      if (this.participants.length < 4  || (!(this.tournament.numberOfMatches)) || (this.matches.length < 0)) {
        return "";
      }
      if (this.participants.length >= 4 && this.participants.length < 8) {
       
        return this.participants[7 - this.tournament.numberOfMatches - 1]
          .username;
      }
      if (this.matches.length > this.tournament.numberOfMatches - 3) {
        return this.matches[this.tournament.numberOfMatches - 4].victorTeamName;
      }
      return "";
    },
    quarterfinals1() {
      
      
      if ((this.participants.length < 5) || (!(this.tournament.numberOfMatches)) || (this.matches.length < 0)) {
        return "";
      }
      if (this.participants.length >= 5 && this.participants.length < 9) {
        
        const index = 8 - this.tournament.numberOfMatches - 1;
        
        return this.participants[index].username;
      }
      // if (this.matches.length >= this.tournament.numberOfMatches - 14) {
      //   return this.matches[this.tournament.numberOfMatches - 15]
      //     .victorTeamName;
      // }
      return "";
    },
    quarterfinals2() {
      if (this.participants.length < 5  || (!(this.tournament.numberOfMatches)) || (this.matches.length < 0)) {
        return "";
      }
      if (this.participants.length >= 5 && this.participants.length < 10) {
       
        return this.participants[9 - this.tournament.numberOfMatches - 1]
          .username;
      }
      // if (this.matches.length >= this.tournament.numberOfMatches - 13) {
      //   return this.matches[this.tournament.numberOfMatches - 14]
      //     .victorTeamName;
      // }
      return "";
    },
    quarterfinals3() {
      if (this.participants.length < 6  || (!(this.tournament.numberOfMatches)) || (this.matches.length < 0)) {
        return "";
      }
      if (this.participants.length >= 6 && this.participants.length < 11) {
        
        return this.participants[10 - this.tournament.numberOfMatches - 1]
          .username;
      }
      // if (this.matches.length >= this.tournament.numberOfMatches - 12) {
      //   return this.matches[this.tournament.numberOfMatches - 13]
      //     .victorTeamName;
      // }
      return "";
    },
    quarterfinals4() {
      if (this.participants.length < 6  || (!(this.tournament.numberOfMatches)) || (this.matches.length < 0)) {
        return "";
      }
      if (this.participants.length >= 6 && this.participants.length < 12) {
        
        return this.participants[11 - this.tournament.numberOfMatches - 1]
          .username;
      }
      // if (this.matches.length >= this.tournament.numberOfMatches - 11) {
      //   return this.matches[this.tournament.numberOfMatches - 12]
      //     .victorTeamName;
      // }
      return "";
    },
    quarterfinals5() {
      if (this.participants.length < 7  || (!(this.tournament.numberOfMatches)) || (this.matches.length < 0)) {
        return "";
      }
      if (this.participants.length >= 7 && this.participants.length < 13) {
        
        return this.participants[12 - this.tournament.numberOfMatches - 1]
          .username;
      }
      // if (this.matches.length >= this.tournament.numberOfMatches - 10) {
      //   return this.matches[this.tournament.numberOfMatches - 11]
      //     .victorTeamName;
      // }
      return "";
    },
    quarterfinals6() {
      if (this.participants.length < 7  || (!(this.tournament.numberOfMatches)) || (this.matches.length < 0)) {
        return "";
      }
      if (this.participants.length >= 7 && this.participants.length < 14) {
        
        return this.participants[13 - this.tournament.numberOfMatches - 1]
          .username;
      }
      // if (this.matches.length >= this.tournament.numberOfMatches - 9) {
      //   return this.matches[this.tournament.numberOfMatches - 10]
      //     .victorTeamName;
      // }
      return "";
    },
    quarterfinals7() {
      if (this.participants.length < 8  || (!(this.tournament.numberOfMatches)) || (this.matches.length < 0)) {
        return "";
      }
      if (this.participants.length >= 8 && this.participants.length < 15) {
        
        return this.participants[14 - this.tournament.numberOfMatches - 1]
          .username;
      }
      // if (this.matches.length >= this.tournament.numberOfMatches - 8) {
      //   return this.matches[this.tournament.numberOfMatches - 9].victorTeamName;
      // }
      return "";
    },
    quarterfinals8() {
      if (this.participants.length < 8  || (!(this.tournament.numberOfMatches)) || (this.matches.length < 0)) {
        return "";
      }
      if (this.participants.length >= 8 && this.participants.length < 16) {
        
        return this.participants[15 - this.tournament.numberOfMatches - 1]
          .username;
      }
      // if (this.matches.length >= this.tournament.numberOfMatches - 7) {
      //   return this.matches[this.tournament.numberOfMatches - 8].victorTeamName;
      // }
      return "";
    }, */
/*
    position1() {
      if (this.participants.length == 0 || (!(this.tournament.numberOfMatches))) {
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
  }, */
 /* methods: {
    nameInBracket(locationNumber) {
      // removing extra participants
      if (!(this.tournament.numberOfMatches) || !(this.participants[0].username)) {
        return "";
      }
       if (locationNumber > 2 * this.participants.length - 1  )  {
        return "";
      }
     if (
        locationNumber - this.tournament.numberOfMatches <=
        this.participants.length
      ) {
        // return this.participants[0].username;
        return this.participants[
          locationNumber - this.tournament.numberOfMatches - 1
        ].username;
      } */  /*
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

      return locationNumber;
    },*/
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