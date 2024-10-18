import { useState, useEffect } from 'react';
import { API_URL } from '../config';

function Tickets() {
  const [tickets, setTickets] = useState([]);

  useEffect(() => {
    fetchTickets();
  }, []);

  const fetchTickets = async () => {
    try {
      const response = await fetch(`${API_URL}/tickets` )
      const jsonData = await response.json()
      setTickets(jsonData.data);
    } catch (error) {
      console.error('Error fetching tickets:', error);
    }
  };

  return (
    <div>
      <h1>Tickets</h1>
      <ul>
        {tickets.map((t) => (
          <li key={t.id}>{t.customerName}`s ticket for {t.movieName} at {t.screeningStartsAt}</li>
        ))}
      </ul>
    </div>
  );
}

export default Tickets;