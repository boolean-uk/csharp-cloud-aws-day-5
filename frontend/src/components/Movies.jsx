import { useState, useEffect } from 'react';
import { API_URL } from '../config';

function Movies() {
  const [movies, setMovies] = useState([]);

  useEffect(() => {
    fetchMovies();
  }, []);

  const fetchMovies = async () => {
    try {
      const response = await fetch(`${API_URL}/movies` )
      const jsonData = await response.json()
      setMovies(jsonData.data);
    } catch (error) {
      console.error('Error fetching movies:', error);
    }
  };

  return (
    <div>
      <h1>Movies</h1>
      <ul>
        {movies.map((m) => (
          <li key={m.id}>{m.title}</li>
        ))}
      </ul>
    </div>
  );
}

export default Movies;