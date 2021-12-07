import React from 'react';

export default function Text(props) {
    return (
        <>
            <span style={{ whiteSpace: 'pre-wrap' }}> {props.value} </span>
        </>
    );
}