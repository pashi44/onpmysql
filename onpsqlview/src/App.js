import logo from './logo.svg';
import './App.css';
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import TwitterPage from "./components/TwitterPage"; // adjust path as needed
import ZomatoComponent from './components/Zomato';

function App() {
  return (
  

      <Router>
      <Routes>
        <Route path="/tweets" element={<TwitterPage />} />
        <Route path="/records" element={<ZomatoComponent />} />


      </Routes>
    </Router>
  );
}

export default App;
