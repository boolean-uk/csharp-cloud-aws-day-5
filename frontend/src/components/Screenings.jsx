import { useState, useEffect } from 'react';
import { API_URL } from '../config';

function Screenings() {
  const [screenings, setScreenings] = useState([]);

  useEffect(() => {
    fetchScreenings();
  }, []);

  const fetchScreenings = async () => {
    try {
      const response = await fetch(`${API_URL}/screenings` )
      const jsonData = await response.json()
      setScreenings(jsonData.data);
    } catch (error) {
      console.error('Error fetching screenings:', error);
    }
  };

  return (
    <div>
      <h1>Screenings</h1>
      <ul>
        {screenings.map((s) => (
          <li key={s.id}>Showing {s.movieTitle} at {s.startsAt} - {s.numOfTicketsSold} of {s.capacity} tickets sold.</li>
        ))}
      </ul>
    </div>
  );
}

export default Screenings;