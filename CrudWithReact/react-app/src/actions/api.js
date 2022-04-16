import axios from 'axios';

const baseUrl = "http://localhost:5229/api/";

export default {
    employee(url = baseUrl + 'Employee/'){
        return{
            fetchAll : () => axios.get(url),
            fetchById : id => axios.get(url + id),
            create : newRecord => axios.post(url,newRecord),
            update : (id, updaterecord) => axios.put(url + id , updaterecord),
            delete : id => axios.delete(url + id)
        }
    }
}