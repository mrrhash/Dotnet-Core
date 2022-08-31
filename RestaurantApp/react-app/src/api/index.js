import axios from "axios"

const Base_Url = 'http://localhost:5017/api/';

export const EndPoints = {
    CUSTOMER : 'customer',
    ORDER : 'order',
    FOODITEM : 'fooditem'
}

export const createAPIEndPoint = endPoint =>{

    let url = Base_Url + endPoint + '/';

    return{
        fetchAll : ()=> axios.get(url),
        fetchById : id => axios.get(url + id),
        create : newRecord => axios.post(url , newRecord),
        delete : id => axios.delete(url + id),
        update : (id , updatedRecord) => axios.put(url + id,updatedRecord)
    }
}