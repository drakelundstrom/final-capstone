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
    }
}