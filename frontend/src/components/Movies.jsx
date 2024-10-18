import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { API_URL } from '../config';

function Movies() {
  const [movies, setMovies] = useState([]);

  useEffect(() => {
    fetchMovies();
  }, []);

  const fetchMovies = async () => {
    try {
      const moviesUrl = `${API_URL}/movies`
      console.log(moviesUrl)
      
      const response = await fetch(moviesUrl)
      console.log(response)
      const jsonData = await response.json()
      console.log(jsonData)
      setMovies(jsonData.data);
    } catch (error) {
      console.error('Error fetching movies:', error);
    }
  };

  return (
    <div>
      <h1>Movies</h1>
      <ul>
        {movies.map((movie) => (
          <li key={movie.id}>{movie.title}</li>
        ))}
      </ul>
    </div>
  );
}

export default Movies;