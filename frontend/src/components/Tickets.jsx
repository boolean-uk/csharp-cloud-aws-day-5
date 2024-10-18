import React, { useState } from 'react';
import axios from 'axios';
import { API_URL } from '../config';

function Tickets() {
  const [customerId, setCustomerId] = useState('');
  const [screeningId, setScreeningId] = useState('');
  const [numSeats, setNumSeats] = useState(1);
  const [ticket, setTicket] = useState(null);

  const bookTicket = async () => {
    try {
      const response = await axios.post(`${API_URL}/customers/${customerId}/screenings/${screeningId}`, {
        numSeats,
      });
      setTicket(response.data.data);
    } catch (error) {
      console.error('Error booking ticket:', error);
    }
  };

  return (
    <div>
      <h1>Book a Ticket</h1>
      <input
        type="number"
        placeholder="Customer ID"
        value={customerId}
        onChange={(e) => setCustomerId(e.target.value)}
      />
      <input
        type="number"
        placeholder="Screening ID"
        value={screeningId}
        onChange={(e) => setScreeningId(e.target.value)}
      />
      <input
        type="number"
        placeholder="Number of Seats"
        value={numSeats}
        onChange={(e) => setNumSeats(e.target.value)}
      />
      <button onClick={bookTicket}>Book Ticket</button>
      {ticket && (
        <div>
          <h2>Ticket Booked</h2>
          <p>Ticket ID: {ticket.id}</p>
          <p>Number of Seats: {ticket.numSeats}</p>
        </div>
      )}
    </div>
  );
}

export default Tickets;