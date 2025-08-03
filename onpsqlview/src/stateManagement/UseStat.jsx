import React, { useState } from "react";
import Reduce from "./UseRedu";


// ✅ Initial object — not a class, just a reference type
const andummyobject = {
  Name: "prashanth",
  age: '',
  count: 0,
  getObject: function () {
    return this;
  }
};

function Objectlist({...props}) {

  // ✅ Create a safe base object to use in list initialization
  const baseObject = {
    ...andummyobject,     // fallback structure
    ...props.obj,         // override if passed
    Name: props.Name || props.lase || "N/A"  // use Name or lase if passed
  };

  // ✅ Create the list using copies of the passed object (to avoid shared reference)
  const [list, setList] = useState([
    { ...baseObject },
    { ...baseObject },
    { ...baseObject }
  ]);
  
  const [inputValue, setInputValue] = useState("");

  // This triggers non-scalar re-rendering
  // - by creating new object references for each element in the array
  const handleChangeAllNames = () => {
    setList((prevList) =>
      prevList.map((obj) => ({
        ...obj,
        Name: inputValue || props.Name || props.lase || obj.Name // ✅ fallbacks
      }))
    );
  };

  return (
    <div style={{ border: "1px solid gray", margin: "10px", padding: "10px" }}>
      <h3>Object List Section</h3>

      <input
        type="text"
        value={inputValue}
        onChange={(e) => setInputValue(e.target.value)}
        placeholder="Enter name"
      />

      <button onClick={handleChangeAllNames}>
        Click to Apply Name to All
      </button>

      <ul>
        {list.map((item, index) => (
          <li key={index}>
            Name: {item.Name || "N/A"}, Age: {item.age}, Count: {item.count}
          </li>
        ))}
      </ul>
    </div>
  );
}

const Make = () => {
  const [initialObject, setInitialObject] = useState({ ...andummyobject });

  /*
     React looks out for scalar and non-scalar types to compare the modified DOM tree.
    
    - For scalar types (number, string, boolean), the returned values are by **value**.
      → So React automatically re-renders when a different value is passed.

    - For reference types (object, array, function), they are compared by **reference**.
      → We need to **destructure** the previous state (shallow copy)
      → Then return a **new object** with modified properties to trigger re-rendering.
  */

  function getsomething(e) {
    // not used here, placeholder for future actions
  }

  return (
    <div>
      <button
        onClick={() =>
          setInitialObject((prev) => ({
            ...prev,
            Name: "\t   radare",
            count: prev.count + 1
          }))
        }
      >
        getsomething
      </button>

      <p>Name: {initialObject.Name}</p>
      <p>Count: {initialObject.count}</p>

      <Objectlist Name="prashanths" obj={andummyobject} />

      <Objectlist lase="mouni" />

      <Objectlist />
      <Reduce/>
    </div>
  );
};

export default Make;
