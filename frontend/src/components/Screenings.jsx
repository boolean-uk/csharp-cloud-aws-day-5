import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { API_URL } from '../config';

function Screenings() {
  const [screenings, setScreenings] = useState([]);
  const [selectedMovie, setSelectedMovie] = useState(null);

  useEffect(() => {
    if (selectedMovie) {
      fetchScreenings(selectedMovie);
    }
  }, [selectedMovie]);

  const fetchScreenings = async (movieId) => {
    try {
      const response = await axios.get(`${API_URL}/movies/${movieId}/screenings`);
      setScreenings(response.data.data);
    } catch (error) {
      console.error('Error fetching screenings:', error);
    }
  };

  return (
    <div>
      <h1>Screenings</h1>
      <input
        type="number"
        placeholder="Enter movie ID"
        onChange={(e) => setSelectedMovie(e.target.value)}
      />
      <ul>
        {screenings.map((screening) => (
          <li key={screening.id}>
            Screen {screening.screenNumber} - {new Date(screening.startsAt).toLocaleString()}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default Screenings;