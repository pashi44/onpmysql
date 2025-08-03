// ZomatoComponent.jsx
import React, { useEffect, useState } from 'react';
import axios from 'axios';
import "../index.css"

function ZomatoComponent() {
  const [restaurants, setRestaurants] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:5124/api/zomato/records')       
      .then(response => {

        console.log(response.headers);
        setRestaurants(response.data);
      })
      .catch(error => {
        console.error('Error fetching data:', error);
      });
  }, []);

  return (                      
    <div  id="zomato">
      <h2>Zomato Restaurant Details</h2>                                
      <ul>
        {restaurants.map((r, index) =>
(                
          <li key={index} >{r.restaurantName} -   {r.city}
          
          

<strong> {r.cuisines}</strong>          
          
          
          
          
          </li>
        
        
        ))}                              
      </ul>                      
    </div>
  );
}                     

export default ZomatoComponent;
