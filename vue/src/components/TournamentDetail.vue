<template>
<div>
    <h1>Tournament Details:</h1>
<table>
<tbody>
    <tr>
        <td id ="descrip">Tournament Name: </td>
        <td>{{tournament.tournamentName}}</td>
    </tr>

    <tr>
        <td id ="descrip">Tournament ID:</td>
        <td>{{tournament.tournamentId}}</td>

    </tr>

    <tr>

        <td id ="descrip">Creator:</td>
        <td>{{tournament.creatorUsername}}</td>

    </tr>

    <tr>
        <td id ="descrip">Status: </td> <!-- is completed or not --> 
        <td>{{tournament.tournamentStatus}}</td>


        


           <!--  TournamentName TournamentId CreatorUsername IsCompleted NumberOfParticipants**** -->

    </tr>

</tbody>

</table>

<button type="submit" id ="jointbn" @click="onSubmit" v-if="($store.state.token != '') && (tournament.numberOfParticipants < tournament.maxNumberParticipants) && (tournament.tournamentStatus =='Recruiting')">Join Now!</button>
</div>
    
</template>

<script>
import TournamentService from '../services/TournamentService';
export default {
    name: "TournamentDetail",

    data: function(){
        return{
            tournament: {},
            participant: {},
        };
    },

    props:["id"],
    created(){
    
        let tournaments = this.$store.state.tournaments;
        this.tournament = tournaments.find((item) =>{
            return item.tournamentId == this.id;
        }
        )
    },
    methods: {
        onSubmit() {
            this.participant.userId = this.$store.state.user.userId;
            this.participant.tournamentId = this.tournament.tournamentId;

           TournamentService.joinTournament(this.participant)
           .then((response) =>{
               if(response.status >= 200 && response.status < 300){
                    window.alert(`Successfully joined ${this.tournament.tournamentName}`)
               }
               
           }
            )
           .catch((error) => {
               window.alert("Something went wrong :/\nAre you sure you didn't already join this one? \n" + error)
           })

           //clear participant ? 
        }
    }

    
}
</script>

<style>
h1{
    font-size: 30px;
}

#descrip{
    font-weight: bold;
    text-shadow: 5px 5px 5px black;
    

    
}

</style>