import React from 'react';

export default function Textbox(props) {
    return (
        <>
            <label>{props.name}</label>
            <input type={props.pass ? 'password' : 'text'} value={props.value} onChange={e => props.setValue(e.target.value)}/> 
        </>
    );
}