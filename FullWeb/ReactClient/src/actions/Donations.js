import { CREATE, UPDATE, DELETE, READ } from "./Constants";
import api from "../services/api";

const formatData = (data) => ({
    ...data,
    age: parseInt(data.age ? data.age : 0)
});

export const fetchAll = () => (dispatch) => {
    api.donor()
        .read()
        .then((response) => {
            dispatch({
                type: READ,
                payload: response.data
            });
        })
        .catch((err) => console.log(err));
};

export const create = (data, onSuccess) => (dispatch) => {
    data = formatData(data);
    api.donor()
        .create(data)
        .then((response) => {
            dispatch({
                type: CREATE,
                payload: response.data
            });
            onSuccess();
        })
        .catch((err) => console.log(err));
};

export const update = (id, data, onSuccess) => (dispatch) => {
    data = formatData(data);
    api.donor()
        .update(id, data)
        .then((response) => {
            dispatch({
                type: UPDATE,
                payload: { id, ...data }
            });
            onSuccess();
        })
        .catch((err) => console.log(err));
};

export const Delete = (id, onSuccess) => (dispatch) => {
    api.donor()
        .delete(id)
        .then((response) => {
            dispatch({
                type: DELETE,
                payload: id
            });
            onSuccess();
        })
        .catch((err) => console.log(err));
};
