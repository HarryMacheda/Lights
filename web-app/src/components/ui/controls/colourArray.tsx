"use client"
import { useState, useEffect } from "react"
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faPlus, faTrash } from '@fortawesome/free-solid-svg-icons'

import styles from '@/styles/components/ui/controls/colourArray.module.css'

type CustomComponentProps = Readonly<{
    name: string;
    value: string[];
    handleChange: (arg: object) => void;
}>;

export function colourArray({name, value, handleChange}: CustomComponentProps)
{
    const [values, setValues] = useState([...value]);

    const AddColor = () => {
        setValues([...values,"#FFFFFF"]);
    }

    const DeleteColour = (index: number) => {
        let newValues = values; 
        newValues.splice(index, 1);
        setValues([...newValues]);
    }

    const UpdateColour = (index: number) => (event: any) => {
        let newValues = values; 
        newValues.splice(index, 1, event.target.value);
        setValues([...newValues]);
    }
    useEffect(() => {
        handleChange(values.join(','));
    }
    ,[values]);

    useEffect(() => {
        console.log(values.join(','));
        setValues([...value]);
    }
    ,[name]);

    return (
        <>
            <button onClick={() => AddColor()}><FontAwesomeIcon icon={faPlus}/> Add New</button><br/>
            <div className={styles.ColoursContainer}>
                {values.map((x, i) => {return  <span key={i}><input type="color" value={x} onChange={(e) => UpdateColour(i)(e)}/> <button onClick={() => DeleteColour(i)}><FontAwesomeIcon icon={faTrash}/> Delete</button></span>})}
            </div>
        </>
    )
}