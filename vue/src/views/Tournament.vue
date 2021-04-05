<template>
    <tournament-detail v-bind:id="tournament_id"/>
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
           tournamentNumber: 0, 
        }
    },

    created(){
        this.tournamentNumber = this.$route.params.id;
    }

};
</script>

<style>

</style>