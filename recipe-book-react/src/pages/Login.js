import React, { useState } from 'react';
import { useNavigate } from "react-router-dom";

import Textbox from '../components/Textbox';
import Button from '../components/Button';
import Text from '../components/Text';

import { getUserAPI, addUserAPI} from '../api/User';

export default function Login(props) {
    const [loginName, setLoginName] = useState('');
    const [password, setPassword] = useState('');
    const [errMsg, setErrMsg] = useState('');
    const [adding, setAdding] = useState(false);
    const navigate = useNavigate();

    async function tryLogin() {
        var error = '';

        if (loginName === '') {
            error = 'Please enter a Login. \r\n';
        }
        
        if (password === '') {
            error += 'Please enter a Password. \r\n';
        }
        setErrMsg(error);

        if (error === '')
        {
            var user = await getUserAPI(loginName);
            if (user.id === undefined || user.password !== password) 
            {
                setErrMsg('No matching Login.');
            }
            else {
                props.setLogin(true);
                navigate('/recipes/' + user.id);
            }
        }
    };

    async function addUser() {
        var error = '';
        if (loginName === '') {
            error = 'Please enter a Login. \r\n';
        }
        
        if (password === '') {
            error += 'Please enter a Password. \r\n';
        }
        setErrMsg(error);

        if (error === '')
        {
            var user = await addUserAPI( {name:loginName, password: password});
            if (user.id === undefined) 
            {
                setErrMsg('User was not Added.');
            }
            else {
                props.setLogin(true);
                navigate('/recipes/' + user.id);
            }
        }
    }

    function toggleAdding() {
        setAdding(!adding);
    }

    return (
        <>
            <div>
                <h1 className="App-header">
                    Login Page
                </h1>

                <div className="center-div">
                    <Textbox name='Login:' value={loginName} setValue={setLoginName} />
                    <br />
                    <Textbox name='Password:' value={password} setValue={setPassword} pass={true} />
                    <br /> 
                    {adding ? <Button  name='Add' setAction={ addUser } />  :
                            <Button  name='Submit' setAction={ tryLogin } /> }
                            
                    <div className="red">
                        <Text value={errMsg} />
                    </div>

                    <div className="clickText" onClick={ () => toggleAdding() }>
                        { adding ?  <span>Cancel</span> : <span>Add a new User</span>}
                    </div>
                    
                </div>
                    
            </div>
        </>
    );

}