<template>
  <div>
    <h1>Tournament Details:</h1>
    <img :src="this.imageLink" alt="picture of sport" width="30%"  class="shadow-lg p-3 mb-5 bg-body rounded" />
    <table class="table style w-auto">
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

    <button
      type="submit"
      id="jointbn"
      @click="onSubmit"
      v-if="!showJoin"
    >
      Join Now!
    </button>
    <h1>List of Participants:</h1>
    <table>
      <tr v-for="part in this.participants" v-bind:key="part.username">
        <td>{{ part.username }}</td>
      </tr>
    </table>
    <h1 id="title">Tournament Schedule</h1>
  </div>
</template>

<script>
import TournamentService from "../services/TournamentService";
export default {
  name: "TournamentDetail",

  data: function () {
    return {
      participant: {},
      participantUsername: [],
    };
  },

  props: ["id"],
  created() {
    TournamentService.getParticipantsInTournament(this.id).then((response) => {
      this.$store.commit("SET_PARTICIPANTS", response.data);
    });

    TournamentService.getTournament(this.id).then((response) => {
      this.$store.commit("SET_TOURNAMENT", response.data);
    });
    //let tournaments = this.$store.state.tournaments;
    //this.tournament = tournaments.find(
    /*  (item) => {
        return item.tournamentId == this.id;
      }, */

    //);
  },
  methods: {
    onSubmit() {
      this.participant.userId = this.$store.state.user.userId;
      this.participant.tournamentId = this.tournament.tournamentId;

      TournamentService.joinTournament(this.participant)
        .then((response) => {
          if (response.status >= 200 && response.status < 300) {
            window.alert(
              `Successfully joined ${this.tournament.tournamentName}`
            );
          }
            this.refresh();
        })
        .catch((error) => {
          window.alert(
            "Something went wrong :/\nAre you sure you didn't already join this one? \n" +
              error
          );
        });

      //clear participant ?
    },
    refresh(){
      location.reload();
    }
  },
  computed: {
    participants() {
      return this.$store.state.participants;
    },
    tournament() {
      return this.$store.state.tournament;
    },
    isTournamentOwner() {
      if (!this.$store.state.user) {
        return false;
      }
      if (this.$store.state.user.userId != this.tournament.creatorId) {
        return false;
      }
      return true;
    },
    imageLink() {
      let startLink = "/sportsPhotos/";
      let endLink = ".jpg";
      let fullLink = startLink + this.tournament.sportName + endLink;
      console.log(fullLink);
      return fullLink;
    },
    showJoin() {

this.participants.forEach(person => {
  this.participantUsername.push(person.username)
});

      if (
        this.$store.state.token != "" &&
        this.tournament.numberOfParticipants <
          this.tournament.maxNumberParticipants &&
        this.tournament.tournamentStatus == "Recruiting" &&
        this.participantUsername.includes(this.$store.state.user.username)
      ) {
        return true;
      }
      else{
      return false;
      }
    },
  },
};
</script>

<style>
h1 {
  font-size: 30px;
}

#descrip {
  font-weight: bold;
  text-shadow: 5px 5px 5px black;
}

button {
  margin-top: 10px;
}

table {
  margin-bottom: 15px;
}
</style>