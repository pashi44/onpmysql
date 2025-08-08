import './App.css';
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import TwitterPage from "./components/TwitterPage"; // adjust path as needed
import ZomatoComponent from './components/Zomato';

import { useSelector, shallowEqual, useDispatch } from 'react-redux';


function App() {



const  storeObjectName =  useSelector((stateonj) => (stateonj.Name));
const  storeObjectDesc =  useSelector((stateonj) =>(stateonj.Description));

const  dispacthAction  =  useDispatch();
const handleClick = (e)=> dispacthAction({type : "Get_state" , payload : e.target.value });


  return (
<div>
  
<div  className="store">
<div>

<ul>
<li>{storeObjectName  || ""}</li>

<li>{storeObjectDesc || ""}</li>

</ul>

<input type='text'  
onChange={

 (e) =>handleClick(e)

} 
/>


</div>
</div>
<div>
      <Router>
      <Routes>
        <Route path="/tweets" element={<TwitterPage />} />
        <Route path="/records" element={<ZomatoComponent />} />


      </Routes>
    </Router>
</div>

{/* <p> {storeObject.Name} </p> */}

</div>

  );
}

export default App;
