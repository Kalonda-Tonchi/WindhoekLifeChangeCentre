import axios from "axios";
/*
axios.defaults.baseURL = "http://localhost:58776/api/";

const donor = {
    read: () => axios.get("DCandidate/"),
    readById: (id) => axios.get("Donor/" + id),
    create: (newOne) => axios.post("Donor/", newOne),
    edit: (id, newOne) => axios.put("Donor/" + id, newOne),
    delete: (id) => axios.delete("Donor/" + id)
};

export default {
    donor
};
*/

const baseUrl = "http://localhost:58776/api/"



export default {

    donor(url = baseUrl + 'donor/') {
        return {
            read: () => axios.get(url),
            readById: id => axios.get(url + id),
            create: newRecord => axios.post(url, newRecord),
            update: (id, updateRecord) => axios.put(url + id, updateRecord),
            delete: id => axios.delete(url + id)
        }
    }
}