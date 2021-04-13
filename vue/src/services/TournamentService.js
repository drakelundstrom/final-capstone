import axios from 'axios';

const path = '/tournament';
//const createpath = '/create';


export default {
    getTournaments() {
        return axios.get(path)
    },

    getTournament(tournamentId) {
        return axios.get(path + '/' + tournamentId)
    },

    getParticipantsInTournament(tournamentId) {
        return axios.get(path + '/participants/' + tournamentId)
    },

    createTournament(newTournament) {
        return axios.post(path, newTournament)
    },

    joinTournament(participant){
        return axios.post(path + '/join', participant)
    },

    getMatchesInTournament(tournamentId){
        return axios.get(path + '/matches/'+ tournamentId)
    },

    getTournamentByParticipant(){
        return axios.get(path + '/participant')

    },
    
    getTournamentByCreator(){
        return axios.get(path + '/creator')

    },


    getBracketForTournament(tournamentId){
        return axios.get(path + '/fillbracket/'+ tournamentId)

    },

    editTournament(tournament){
        return axios.post(path + '/changeStatus', tournament)
    },

    getNextMatch(id){
        return axios.get(path + '/getNextMatch/' + id)
    }

}