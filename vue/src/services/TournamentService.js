import axios from 'axios';

const path = '/tournament';



export default {
    getTournaments() {
        return axios.get(path)
    },

    getTournament(tournamentId) {
        return axios.get(path + '/' + tournamentId)
    },

    createTournament(newTournament) {
        return axios.post(path, newTournament)
    }
}