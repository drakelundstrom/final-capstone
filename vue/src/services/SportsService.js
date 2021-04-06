import axios from 'axios';

const path = '/sport';


export default {
    getSports() {
        return axios.get(path)
    },

}