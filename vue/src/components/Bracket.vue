<template>
  <div class="bracket">
    <img
      clss="bracketimage"
      src="../../assets/bracketimage.png"
      alt="Bracket"
      style="width: 50%"
    />
    <div class="zero" v-if="this.bracket[0].username != ''">
      {{ this.bracket[0].username }} WINS!
    </div>
    <div class="one">{{ this.bracket[1].username }}</div>
    <div class="two">{{ this.bracket[2].username }}</div>
    <div class="three">{{ this.bracket[3].username }}</div>
    <div class="four">{{ this.bracket[4].username }}</div>
    <div class="five">{{ this.bracket[5].username }}</div>
    <div class="six">{{ this.bracket[6].username }}</div>
    <div class="seven">{{ this.bracket[7].username }}</div>
    <div class="eight">{{ this.bracket[8].username }}</div>
    <div class="nine">{{ this.bracket[9].username }}</div>
    <div class="ten">{{ this.bracket[10].username }}</div>
    <div class="eleven">{{ this.bracket[11].username }}</div>
    <div class="twelve">{{ this.bracket[12].username }}</div>
    <div class="thirteen">{{ this.bracket[13].username }}</div>
    <div class="fourteen">{{ this.bracket[14].username }}</div>
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
  },
};
</script>

<style>
.bracket {
  position: relative;
  margin: 2%;
  display: block;
  margin-left: auto;
  margin-right: auto;
  width: 100%;
}
.bracketimage {
  position: absolute;
  left: 0;
  top: 0;
}

.zero {
  position: absolute;
  right: 22%;
  top: 48%;
}

.one {
  position: absolute;
  right: 38%;
  top: 20%;
}

.two {
  position: absolute;
  right: 38%;
  bottom: 27%;
}

.three {
  position: absolute;
  right: 50%;
  top: 8%;
}

.four {
  position: absolute;
  right: 50%;
  top: 33%;
}

.five {
  position: absolute;
  right: 50%;
  bottom: 39%;
}

.six {
  position: absolute;
  right: 50%;
  bottom: 15%;
}

.seven {
  position: absolute;
  right: 62%;
  top: 3%;
}

.eight {
  position: absolute;
  right: 62%;
  top: 13%;
}

.nine {
  position: absolute;
  right: 62%;
  top: 28%;
}

.ten {
  position: absolute;
  right: 62%;
  top: 38%;
}

.eleven {
  position: absolute;
  right: 62%;
  bottom: 44%;
}

.twelve {
  position: absolute;
  right: 62%;
  bottom: 34%;
}

.thirteen {
  position: absolute;
  right: 62%;
  bottom: 19%;
}

.fourteen {
  position: absolute;
  right: 62%;
  bottom: 9%;
}
</style>