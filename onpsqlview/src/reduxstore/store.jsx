// import { legacy_createStore } from "redux"; // deprecated and migrated to configureStore

import { configureStore, createSlice } from '@reduxjs/toolkit';

// Initial state for the slice
const initialState = {
  Name: "prashanth",
  Age: '',
  Description: "this is object from redux store"
};

const userSlice = createSlice({
  name: 'user',
  initialState,


  reducers: {
    setName(state, action) {
      // Redux Toolkit uses Immer under the hood, so we can "mutate" here safely
      state.Name = action.payload; 
    },
    setAge(state, action) {
      state.Age = action.payload;
    },
    setDescription(state, action) {
      state.Description = action.payload;
    }
  }
});

// Limitations of reducer functions:
// 1. Reducers must be synchronous functions.
// 2. Do not mutate the original state in classic Redux (must return a new object).
//    BUT: Redux Toolkit uses Immer, so "mutations" are actually safe and become immutable updates under the hood.
// Example of classic reducer:
// const myReducerFunction = (initialState = myobj, action) => {
//   switch (action.type) {
//     case "Get_state":
//       return { ...initialState, Name: action.payload };
//     default: 
//       return { ...initialState };
//   }
// };

// Configure the Redux store
const store = configureStore({
  reducer: userSlice.reducer // can also pass { user: userSlice.reducer } for multi-slice
});

// Export actions so components can dispatch them
export const { setName, setAge, setDescription } = userSlice.actions;

export default store;
