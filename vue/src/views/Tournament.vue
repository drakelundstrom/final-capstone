<template>
    <tournament-detail v-bind:id="tournamentId" /> 
     
</template>

<script>
import TournamentDetail from '../components/TournamentDetail.vue';


export default {
    name: 'Tournament',

    components:{
        TournamentDetail,
    },

    data(){
        return {
           tournamentId: 0, 
        }
    },

    created(){
        this.tournamentId = this.$route.params.id;
    }

};
</script>

<style>

</style>