
import { useState,   useEffect } from "react";
import React from "react";


export default     function Effec({...props}){


const [state,setState]  =   useState( [] );


  useEffect(() => {
    const fetchData = async () => {
      try {
        const res = await fetch("http://r2.attlocal.net:80/api/zomato/records");
        const data = await res.json();
        setState(data);
      } catch (err) {
        console.error("Error fetching data:", err);
      }
    };

    fetchData(); 
  }, []);
 
return  (



<div>

<ul>

{state.map((k, index) => (
          <li key={index}>{k.restaurantName}</li>
        ))}
</ul>


</div>




);
}


