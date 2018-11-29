import React from 'react';
import './Person.css';

const person = (props) => {
    if (props.name === undefined && props.stand === undefined && props.children === undefined)
        return <div className="Person" onClick={props.click}><p><b>THERE ARE NO PROPS, FOR IT IS I!! DIO!!</b></p></div>
    else
        return (
            <div className="Person">
                <p onClick={props.click}>My name is <b><u>{props.name}</u></b> and my stand is <b><u>{props.stand}</u></b>! {props.children}</p>
                Change Name: <input type="text" onChange={props.changedName} value={props.name}/>
            </div>
        )
    
};

export default person;