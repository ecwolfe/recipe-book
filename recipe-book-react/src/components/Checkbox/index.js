import React from 'react';

export default function Checkbox(props) {
    return (
        <>
            <input key={props.key} type='checkbox' name={props.name} defaultChecked={props.checked} onChange={ () => props.onChange(props.id) }/>
            <label htmlFor={props.name}> {props.label} </label>
        </>
    );
}