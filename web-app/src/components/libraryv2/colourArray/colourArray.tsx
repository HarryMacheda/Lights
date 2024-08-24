import { useState, useEffect } from "react"

import Button from "../button/button";
import styles from "./colourArray.module.css"
import Colour from "../colour/colour";

type ColourArray = Readonly<{
    name: string;
    value: string[];
    handleChange: (arg: any) => void;
}>;

export default function ColourArray({name, value, handleChange}: ColourArray)
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

    const UpdateColour = (index: number) => (color: string) => {
        let newValues = values; 
        newValues.splice(index, 1, color);
        setValues([...newValues]);
    }
    useEffect(() => {
            handleChange(values.join(','));
    }
    ,[values]);

    useEffect(() => {
        setValues([...value]);
    }
    ,[name]);

    return (
        <>
            <Button type={"primary"} size={"medium"} text={"Add New"} onClick={() => AddColor()}/>
            <br/>
            <br/>
            <div className={styles.ColoursContainer}>
                {values.map((x, i) => {
                    return  <span key={i}>
                        <Colour type={"primary"} size={"small"} value={x} onChange={(e) => UpdateColour(i)(e)}/>&emsp;
                        <Button type={"primary"} size={"medium"} text={"Delete"} onClick={() => DeleteColour(i)}/> 
                </span>})}
            </div>
        </>
    )
}