<template>
  <main id="tournament">
    <h1>Tournament Schedule</h1>
    <ul class="round round-2">
      <li class="spacer">&nbsp;</li>

      <li class="game game-top winner">{{this.quarterFinal1}}</li>
      <li class="game game-spacer">&nbsp;</li>
      <li class="game game-bottom">{{this.quarterFinal2}}</li>

      <li class="spacer1">&nbsp;</li>

      <li class="game game-top winner">{{this.quarterFinal3}}</li>
      <li class="game game-spacer">&nbsp;</li>
      <li class="game game-bottom">{{this.quarterFinal4}}   </li>

      <li class="spacer1">&nbsp;</li>

      <li class="game game-top">{{this.quarterFinal5}}   </li>
      <li class="game game-spacer">&nbsp;</li>
      <li class="game game-bottom winner">{{this.quarterFinal6}}   </li>

      <li class="spacer1">&nbsp;</li>

      <li class="game game-top">{{this.quarterFinal7}}   </li>
      <li class="game game-spacer">&nbsp;</li>
      <li class="game game-bottom winner">{{this.quarterFinal8}}   </li>

      <li class="spacer">&nbsp;</li>
    </ul>
    <ul class="round round-3">
      <li class="spacer">&nbsp;</li>

      <li class="game game-top winner">{{this.semiFinal1}}   </li>
      <li id="spacing1" class="game game-spacer">&nbsp;</li>
      <li class="game game-bottom">{{this.semiFinal2}}   </li>

      <li class="spacer">&nbsp;</li>

      <li class="game game-top">{{this.semiFinal3}}   </li>
      <li id="spacing1" class="game game-spacer">&nbsp;</li>
      <li class="game game-bottom winner">{{this.semiFinal4}}   </li>

      <li class="spacer">&nbsp;</li>
    </ul>
    <ul class="round round-4">
      <li class="spacer">&nbsp;</li>

      <li class="game game-top winner">{{ this.final1 }}   </li>
      <li id="spacefinal" class="game game-spacer">&nbsp;</li>
      <li class="game game-bottom">{{ this.final2 }}   </li>

      <li class="spacer">&nbsp;</li>
    </ul>
    <ul class="round round-5">
      <li class="game winner">{{( (this.winner == "")? "???"  : this.winner )}} WINS!!!</li>
    </ul>
  </main>
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
main {
  display: flex;
  flex-direction: row;
  justify-content: center;
}
.round {
  display: flex;
  flex-direction: column;
  justify-content: center;
  width: 200px;
  list-style: none;
  padding: 0;
}
.round .spacer {
  flex-grow: 1;
}
.round .spacer:first-child,
.round .spacer:last-child {
  flex-grow: 0.5;
}

.spacer1 {
  padding: 10px;
}

.round .game-spacer {
  flex-grow: 1;
}

#spacing1 {
  flex-grow: 1.6;
}

#spacefinal {
  flex-grow: 1.37;
}

/*
 *  General Styles
*/
body {
  padding: 10px;
  line-height: 1.4em;
}

li.game {
  padding-left: 20px;
}

li.game.winner {
  font-weight: bold;
}

li.game span {
  float: right;
  margin-right: 5px;
}

li.game-top {
  border-bottom: 1px solid #aaa;
}

li.game-spacer {
  border-right: 1px solid #aaa;
  min-height: 40px;
}

li.game-bottom {
  border-top: 1px solid #aaa;
}
</style>