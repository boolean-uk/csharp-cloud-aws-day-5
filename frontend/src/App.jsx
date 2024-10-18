import React from 'react';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
import Movies from './components/Movies';
import Customers from './components/Customers';
import Screenings from './components/Screenings';
import Tickets from './components/Tickets';

function App() {
  return (
    <Router>
      <div>
        <nav>
          <ul>
            <li><Link to="/movies">Movies</Link></li>
            <li><Link to="/customers">Customers</Link></li>
            <li><Link to="/screenings">Screenings</Link></li>
            <li><Link to="/tickets">Tickets</Link></li>
          </ul>
        </nav>

        <Routes>
          <Route path="/movies" element={<Movies />} />
          <Route path="/customers" element={<Customers />} />
          <Route path="/screenings" element={<Screenings />} />
          <Route path="/tickets" element={<Tickets />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;