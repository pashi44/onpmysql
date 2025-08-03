import React, { useReducer } from 'react';

//  Initial state object for useReducer
const initialState = {
  name: '',         // Current input value
  nameList: []      // List of submitted names
};

// Reducer function (called by dispatch)
function reducer(state, action) {
  switch (action.type) {
    case 'SET_NAME':
      return {
        ...state,
        name: action.payload
      };

    case 'ADD_NAME':
      // Adds the current name to the list (if not empty), then clears input
      if (state.name.trim() === '') return state;
      return {
        ...state,
        nameList: [...state.nameList, state.name],
        name: ''
      };

    default:
      return state;
  }
}

export default function Reduce() {
  // dispatch is a function that calls the reducer function internally managed by React
  // reducer(state, action) → returns new state
  const [state, dispatch] = useReducer(reducer, initialState);

  return (
    <div style={{ padding: '20px' }}>
      <h2>UseReducer Example</h2>

      {/* Controlled input field */}
      <input
        type="text"
        value={state.name}
        placeholder="Enter a name"
        onChange={(e) =>
          dispatch({
            type: 'SET_NAME',         
            payload: e.target.value    
          })
        }
      />


<p> {state.name}</p>
      {/* Button to add name to the list */}
      <button onClick={() => dispatch({ type: 'ADD_NAME' })}>
        Add Name
      </button>

      {/* Display the list of names */}
      <h3>Names List:</h3>
      <ul>
        {state.nameList.map((name, index) => (
          <li key={index}>{name}</li>
        ))}
      </ul>
    </div>
  );
}