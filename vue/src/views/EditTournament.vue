<template>
  <div>
    <h1>Tournament Details:</h1>
    <table id="deets" class ="table style w-auto ">
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
          <td>{{ tournament.sportName}}</td>
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

    <h2>Current Participants:</h2>
    <ul id="listpartic" v-for="part in this.participants" v-bind:key="part.username">
     
        <li id="partic" >{{part.username }}</li>
      
    </ul>



    <h2 id="editdescrip">Change Tournament Status</h2>
    <form v-on:submit.prevent="onSubmit">
      <select v-model="editTournament.tournamentStatus">
        <option value="Recruiting">Recruiting</option>
        <option value="Active">Active</option>
        <option value="Completed">Completed</option>
      </select>
      <button type="submit">Change</button>
    </form>

    <div id="matches">

      <table>
        <thead>
          <th> <!-- for each for matches so only current matches display? perhaps?  -->
         Match 1 
          </th>
          <th> match 2</th>
          <th> match 3</th>
          <th> match 4</th>
          </thead>

          <tbody>
            <td> <form>
        Home team
          <input
        type="number"
        id="homescore"
        class="form-control"
        placeholder="Score"
        
      />
       Away team
          <input
        type="number"
        id="awayscore"
        class="form-control"
        placeholder="Score"
        
      />

      Who won? 
      <select>
        <option>Home</option>
        <option>Away</option>
      </select>
      <button type="submit">Submit</button>
        </form>
      
  </td>

  <td> <form>
        Home team
          <input
        type="number"
        id="homescore"
        class="form-control"
        placeholder="Score"
        
      />
       Away team
          <input
        type="number"
        id="awayscore"
        class="form-control"
        placeholder="Score"
        
      />

      Who won? 
      <select>
        <option>Home</option>
        <option>Away</option>
      </select>
      <button type="submit">Submit</button>
        </form>
      
  </td>

  <td> <form>
        <p id="hometeam">Home team</p>
          <input
        type="number"
        id="homescore"
        class="form-control"
        placeholder="Score"
        
      />
       <p id ="awayteam">Away team</p>
          <input
        type="number"
        id="awayscore"
        class="form-control"
        placeholder="Score"
        
      />

      Who won? 
      <select>
        <option>Home</option>
        <option>Away</option>
      </select>
      <button type="submit">Submit</button>
        </form>
      
  </td>

  <td> <form>
        Home team
          <input
        type="number"
        id="homescore"
        class="form-control"
        placeholder="Score"
        
      />
       Away team
          <input
        type="number"
        id="awayscore"
        class="form-control"
        placeholder="Score"
        
      />

      Who won? 
      <select>
        <option>Home</option>
        <option>Away</option>
      </select>
      <button type="submit">Submit</button>
        </form>
      
  </td>
          </tbody>
        </table>
     
      </div>


  </div>
</template>

<script>
import TournamentService from "../services/TournamentService";
export default {
  data() {
    return {
        editTournament: {
            tournamentId : parseInt(this.$route.params.id)
        }
    };
  },

  created() {
    TournamentService.getTournament(this.$route.params.id).then((response) => {
      this.$store.commit("SET_TOURNAMENT", response.data);
    });
    TournamentService.getParticipantsInTournament(this.$route.params.id).then((response) => {
      this.$store.commit("SET_PARTICIPANTS", response.data);
    });
  },
  computed: {
    tournament() {
      return this.$store.state.tournament;
    },
     participants() {
      return this.$store.state.participants;
    },

  },
  methods: {
    
    onSubmit() {
        TournamentService.editTournament(this.editTournament)
        .then(window.alert(`Tournament status successfully updated`))
        .catch((error) => {
            console.log(error)
        })
    }
  }
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
  background-color: #d2ffe0
}

button {
  border-radius: 8px;
  background-color: #f2f2f2;
  border: 2px solid #e7f4d7;
}

#editdescrip{
  margin-bottom: 1px;
}

#deets{
  margin-bottom: 50px;
}



  #partic{
  list-style: none;
  color: #ff844c;
  
}

#partic:before {
  content: "";
  display: inline-block;
  height: 20px;
  width: 20px;
  background-size: contain;
  background-image: url("../../assets/sportsPhotos/icon.png");
}


#homescore, #awayscore{
  display: grid;
  margin-left: auto;
  margin-right: auto;
  border-radius: 40px;
  margin-bottom: 5px;
  background-color:  #d2ffe0;
  min-width: 70px;
}

#homescore{
  grid-area: homesc;
}

#awayscore{
  grid-area: awaysc;
}

#hometeam{
  display: grid;
  grid-area: homet
}

#awayteam{
  display: grid;
  grid-area: awayt;
}

#matches{
    grid: 'homet homesc'
  'awayt awaysc';
}



</style>