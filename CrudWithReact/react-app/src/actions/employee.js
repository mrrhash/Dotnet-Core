import api from "./api"

export const ACTION_TYPES ={
    CREATE : 'CREATE',
    UPDATE : 'UPDATE',
    DELETE : 'DELETE',
    FETCH_ALL : 'FETCH_ALL'
}

export const fetchAllEmployees = () => dispatch =>{
    //get api request
    
    api.employee().fetchAll()
    .then(response =>{
        console.log(response)
        dispatch({
            type: ACTION_TYPES.FETCH_ALL,
            payload : response.data
        })
    })
    .catch(err => console.log(err));
    
}