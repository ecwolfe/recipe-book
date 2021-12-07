import React, { useState, useEffect } from 'react';
import { Navigate, Outlet, useParams, useNavigate } from "react-router-dom";

import { getUserById } from '../api/User';

const Recipes = (props) => {
    let params = useParams();
    const navigate = useNavigate();

    const [user, setUser] = useState({});

    useEffect(() => { 
        async function fetchData() {
            setUser(await getUserById(Number(params.userId)));
        }
        fetchData();
    }, [params.userId])

    if (!props.auth) {
        return <Navigate to='/' />;
    }

    function Logout() {
        navigate('/');
    }
    
    return (
        <>
            <div className="logout clickText" onClick={() => Logout() }>
                <span>Log out</span>
            </div>

            <h1 className="App-header">
                Recipes for {user.name}
            </h1>

            <div className="center-div">
                <Outlet />
            </div>
        </>);
  };
  
  export default Recipes;