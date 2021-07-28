import { CREATE, UPDATE, DELETE, READ } from "../actions/Constants";

const initialState = {
    list: []
};

export const donorReducer = (state = initialState, action) => {
    switch (action.type) {
        case READ:
            return {
                ...state,
                list: [...action.payload]
            };
        case CREATE:
            return {
                ...state,
                list: [...state.list, action.payload]
            };
        case UPDATE:
            return {
                ...state,
                list: state.list.map((x) =>
                    x.id === action.payload.id ? action.payload : x
                )
            };
        case DELETE:
            return {
                ...state,
                list: state.list.filter((x) => x.id !== action.payload.id)
            };
        default:
            return state;
    }
};
