import './App.css';
import React, { useState } from 'react';
import { Routes, Route } from "react-router-dom";
import Login from "./pages/Login";
import Recipes from "./pages/Recipes";
import Recipe from "./pages/Recipe";
import NotFound from "./pages/NotFound";

export default function App() {
  const [authurized, setAuth] = useState(false);
  
  return (
    <div className="App">
      <Routes>
        <Route path='/' element={ <Login setLogin={setAuth} /> } />
        <Route path='/recipes/:userId' element={ <Recipes auth={authurized} /> } >
          <Route path='/recipes/:userId' element={ <Recipe /> } />
        </Route> 
        <Route path='/*' element={ <NotFound/> } />
      </Routes>
    </div>
  );
}

