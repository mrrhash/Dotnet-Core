import {ACTION_TYPES} from "../actions/employee";

const initialState = {
    list :[]
}

export const employee = (state=initialState,action) =>{
    switch (action.type) {
        case ACTION_TYPES.FETCH_ALL:

        return{
            ...state,
            list : [...action.payload]
                       
        }

        default:
            return state;
    }
    
    
}
