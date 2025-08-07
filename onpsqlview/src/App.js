import './App.css';
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import TwitterPage from "./components/TwitterPage"; // adjust path as needed
import ZomatoComponent from './components/Zomato';

import { useSelector, shallowEqual } from 'react-redux';


function App() {



const  storeObject =  useSelector((stateonj) =>stateonj);


  return (




<div>

<div  class="store">


<ul>

<li>{storeObject?.Name || "Default Name"}</li>


</ul>

</div>
<div>
      <Router>
      <Routes>
        <Route path="/tweets" element={<TwitterPage />} />
        <Route path="/records" element={<ZomatoComponent />} />


      </Routes>
    </Router>
</div>
</div>

  );
}

export default App;
