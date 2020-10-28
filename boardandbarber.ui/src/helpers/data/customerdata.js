import axios from 'axios';
import { baseUrl } from '../constants.json';

const getAllCustomers = () => new Promise((resolve,reject) => {
  axios.get(`${baseUrl}/customers`)
    .then((response) => resolve(response.data))
    .catch((err) => reject(err));
});

export default {getAllCustomers};