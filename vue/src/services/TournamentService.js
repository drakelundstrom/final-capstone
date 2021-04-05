import axios from 'axios';

const path = '/tournament';



export default{
    getTournaments(){
        const http = axios.create({
            baseURL: "http://localhost:8080"
        })
        return http.get(path)
    },

    getTournament(tournamentId){
        return axios.get(path + '/' + tournamentId)
    },


}