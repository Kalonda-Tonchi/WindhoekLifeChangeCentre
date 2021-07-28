import { dCandidateReducer } from "./donorReducer";
import { combineReducers } from "redux";

const rootReducer = combineReducers({ donorReducer });

export default rootReducer;
