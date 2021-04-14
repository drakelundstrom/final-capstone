<template>
  <div>
    <h1>Tournament Details:</h1>
    <table id="deets" class="table style w-auto">
      <tbody>
        <tr>
          <td id="descrip">Tournament Name:</td>
          <td>{{ tournament.tournamentName }}</td>
        </tr>

        <tr>
          <td id="descrip">Tournament ID:</td>
          <td>{{ tournament.tournamentId }}</td>
        </tr>

        <tr>
          <td id="descrip">Sport:</td>
          <!-- is completed or not -->
          <td>{{ tournament.sportName }}</td>
        </tr>

        <tr>
          <td id="descrip">Creator:</td>
          <td>{{ tournament.creatorUsername }}</td>
        </tr>

        <tr>
          <td id="descrip">Status:</td>
          <!-- is completed or not -->
          <td>{{ tournament.tournamentStatus }}</td>
        </tr>
      </tbody>
    </table>

    <h2 id="editdescrip">Change Tournament Status</h2>
    <form v-on:submit.prevent="onSubmit">
      <select v-model="editTournament.tournamentStatus">
        <option value="Recruiting">Recruiting</option>
        <option value="Active">Active</option>
        <option value="Completed">Completed</option>
      </select>
      <button type="submit">Change</button>
    </form>

<form v-on:submit.prevent="shuffleTeams">
  <button type="submit">Shuffle Teams</button>
</form>

    <div id="matches" v-if="this.isActive">
      <table>
        <thead>
          <th>
            <!-- for each for matches so only current matches display? perhaps?  -->
            Match {{ nextMatch.matchNumber }}
          </th>
        </thead>

        <tbody>
          <td>
            <form v-on:submit.prevent="addNextMatch">
              {{ nextMatch.homeTeamName }}
              <input
                type="number"
                id="homescore"
                class="form-control"
                placeholder="Score"
                v-model="nextMatch.homeTeamScore"
              />
              {{ nextMatch.awayTeamName }}
              <input
                type="number"
                id="awayscore"
                class="form-control"
                placeholder="Score"
                v-model="nextMatch.awayTeamScore"
              />

              Who won?
              <select type="number" v-model.number="nextMatch.victorTeamId">
                <option v-bind:value="nextMatch.homeTeamId">
                  {{ nextMatch.homeTeamName }}
                </option>
                <option v-bind:value="nextMatch.awayTeamId">
                  {{ nextMatch.awayTeamName }}
                </option>
              </select>
              <button type="submit">Submit</button>
            </form>
          </td>
        </tbody>
      </table>
    </div>
    <bracket v-bind:id="tournamentId" />

    <table class="table w-auto style" id="tblallmatches">
      <thead>
        <tr>
          <th scope="col">Match Number</th>
          <th scope="col">Home Team</th>
          <th scope="col">Home Score</th>
          <th scope="col">Away Team</th>
          <th scope="col">Away Score</th>
          <th scope="col">Match Victor</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(round, index) in this.matchResults" v-bind:key="index">
          <td>{{ round.matchNumber }}</td>
          <td>{{ round.homeTeamName }}</td>
          <td>{{ round.homeTeamScore }}</td>
          <td>{{ round.awayTeamName }}</td>
          <td>{{ round.awayTeamScore }}</td>
          <td>{{ round.victorTeamName }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import TournamentService from "../services/TournamentService";
import Bracket from "../components/Bracket.vue";
export default {
  components: {
    Bracket,
  },

  data() {
    return {
      editTournament: {
        tournamentId: parseInt(this.$route.params.id),
      },
      tournamentId: 0,
    };
  },

  created() {
    this.tournamentId = this.$route.params.id;
    TournamentService.getTournament(this.$route.params.id).then((response) => {
      this.$store.commit("SET_TOURNAMENT", response.data);
    });
    TournamentService.getParticipantsInTournament(this.$route.params.id).then(
      (response) => {
        this.$store.commit("SET_PARTICIPANTS", response.data);
      }
    );
    TournamentService.getNextMatch(this.$route.params.id).then((response) => {
      this.$store.commit("SET_NEXT_MATCH", response.data);
    });
    TournamentService.getMatchesInTournament(this.$route.params.id).then(
      (response) => {
        this.$store.commit("SET_MATCHES", response.data);
      }
    );
  },
  computed: {
    tournament() {
      return this.$store.state.tournament;
    },
    participants() {
      return this.$store.state.participants;
    },
    nextMatch() {
      return this.$store.state.match;
    },
    matchResults() {
      return this.$store.state.matches;
    },

    isActive(){
      if (this.tournament.tournamentStatus == 'Active') {
        return true;
      } else {
        return false;
      }
    },
  },
  methods: {
    onSubmit() {
      TournamentService.editTournament(this.editTournament)
        .then()//location.reload())
        .catch((error) => {
          console.log(error);
        });
    },
    addNextMatch() {
      TournamentService.addNextMatch(this.nextMatch)
        .then()//location.reload())
        .catch((error) => {
          console.log(error);
        });
    },
    shuffleTeams() {
      TournamentService.shuffleTeams(this.id)
        .then()//location.reload())
        .catch((error) => {
          console.log(error);
        });
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
  background-color: #f2f2f2;
  border: 2px solid #e7f4d7;
}

#editdescrip {
  margin-bottom: 1px;
}

#deets {
  margin-bottom: 50px;
}

#homescore,
#awayscore {
  display: grid;
  margin-left: auto;
  margin-right: auto;
  border-radius: 40px;
  margin-bottom: 5px;
  background-color: #d2ffe0;
  min-width: 70px;
}

#homescore {
  grid-area: homesc;
}

#awayscore {
  grid-area: awaysc;
}

#hometeam {
  display: grid;
  grid-area: homet;
}

#awayteam {
  display: grid;
  grid-area: awayt;
}

#matches {
  grid:
    "homet homesc"
    "awayt awaysc";
}
</style>