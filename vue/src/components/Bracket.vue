<template>
  <main id="tournament">
    <ul class="round round-2">
      <li class="spacer">&nbsp;</li>

      <li class="game game-top winner">{{ this.bracket[7].username }}</li>
      <li class="game game-spacer">&nbsp;</li>
      <li class="game game-bottom">{{ this.bracket[8].username }}</li>

      <li class="spacer1">&nbsp;</li>

      <li class="game game-top winner">{{ this.bracket[9].username }}</li>
      <li class="game game-spacer">&nbsp;</li>
      <li class="game game-bottom">{{ this.bracket[10].username }}</li>

      <li class="spacer1">&nbsp;</li>

      <li class="game game-top">{{ this.bracket[11].username }}</li>
      <li class="game game-spacer">&nbsp;</li>
      <li class="game game-bottom winner">{{ this.bracket[12].username }}</li>

      <li class="spacer1">&nbsp;</li>

      <li class="game game-top">{{ this.bracket[13].username }}</li>
      <li class="game game-spacer">&nbsp;</li>
      <li class="game game-bottom winner">{{ this.bracket[14].username }}</li>

      <li class="spacer">&nbsp;</li>
    </ul>
    <ul class="round round-3">
      <li class="spacer">&nbsp;</li>

      <li class="game game-top winner">{{ this.bracket[3].username }}</li>
      <li id="spacing1" class="game game-spacer">&nbsp;</li>
      <li class="game game-bottom">{{ this.bracket[4].username }}</li>

      <li class="spacer">&nbsp;</li>

      <li class="game game-top">{{ this.bracket[5].username }}</li>
      <li id="spacing1" class="game game-spacer">&nbsp;</li>
      <li class="game game-bottom winner">{{ this.bracket[6].username }}</li>

      <li class="spacer">&nbsp;</li>
    </ul>
    <ul class="round round-4">
      <li class="spacer">&nbsp;</li>

      <li class="game game-top winner">{{ this.bracket[1].username }}</li>
      <li id="spacefinal" class="game game-spacer">&nbsp;</li>
      <li class="game game-bottom">{{ this.bracket[2].username }}</li>

      <li class="spacer">&nbsp;</li>
    </ul>
    <ul class="round round-5">
      <li class="game winner">
        {{
          this.bracket[0].username == "" ? "???" : this.bracket[0].username
        }}
        WINS!!!
      </li>
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
  },
};
</script>

<style>
#title {
  justify-items: center;
}
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