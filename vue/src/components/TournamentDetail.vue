<template>
<table>
<tbody>
    <tr>
        <td>Tournament Name</td>
        <td>{{tournament.tournament_name}}</td>
    </tr>

    <tr>
        <td>Tournament ID</td>
        <td>{{tournament.tournament_id}}</td>

    </tr>

    <tr>

        <td>Creator</td>
        <td>{{tournament.creator_username}}</td>

    </tr>

    <tr>
        <td>Status</td> <!-- is completed or not --> 
        <td>{{tournament.is_completed}}</td>





           <!--  TournamentName TournamentId CreatorUsername IsCompleted NumberOfParticipants**** -->

    </tr>

</tbody>

</table>
    
</template>

<script>
export default {
    name: "TournamentDetail",

    data: function(){
        return{
            tournament: {},
        };
    },

    props:["id"],

    
}
</script>

<style>

</style>