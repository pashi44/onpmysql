import './App.css';
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import TwitterPage from "./components/TwitterPage";
import ZomatoComponent from './components/Zomato';
import { setName } from './reduxstore/store';
import { useSelector, useDispatch } from 'react-redux';

function App() {
  // Accessing values from store
  const storeObjectName = useSelector((state) => state.Name);
  const storeObjectDesc = useSelector((state) => state.Description);

  const dispatch = useDispatch();

  // Update store when input changes
  const handleClick = (e) => dispatch(setName(e.target.value));

  return (
    <div>
      <div className="store">
        <div>
          <ul>
            <li>{storeObjectName || ""}</li>
            <li>{storeObjectDesc || ""}</li>
          </ul>

          <input
            type='text'
            onChange={(e) => handleClick(e)}
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

      {/* <p>{storeObject.Name}</p> */}
    </div>
  );
}

export default App;
