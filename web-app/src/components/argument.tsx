"use client"
import { useState, useEffect } from "react"
import {default as Controls} from './ui/controls'

type CustomComponentProps = Readonly<{
    name: string;
    value: string;
    type: number;
    handleChange: (arg: object) => void;
}>;

export function Argument({name, value, type, handleChange}:CustomComponentProps)
{
    switch (type)
    {
        case 1:
            return <Controls.number value={value} handleChange={handleChange}/>
        case 4:
            return <Controls.colour value={value} handleChange={handleChange}/>
        case 5:
            let values = value.split(',');
            return <Controls.ColourArray name={name} value={values} handleChange={handleChange}/>
        default:
            return <p>{value}</p>
    }

}