"use client"
import { useState, useEffect } from "react"
import {default as Controls} from './ui/controls'

import Number from "./libraryv2/number/number";
import Colour from "./libraryv2/colour/colour";
import ColourArray from "./libraryv2/colourArray/colourArray";

type CustomComponentProps = Readonly<{
    name: string;
    value: string;
    type: number;
    handleChange: (arg: string) => void;
}>;

export function Argument({name, value, type, handleChange}:CustomComponentProps)
{
    switch (type)
    {
        case 1:
            return <Number value={value} type={"primary"} size={"medium"} onChange={handleChange}/>
        case 4:
            return <Colour value={value} type={"primary"} size={"medium"} onChange={handleChange}/>
        case 5:
            let values = value ? value.split(',') : [];
            return <ColourArray name={name} value={values} handleChange={handleChange}/>
        default:
            return <p>{value}</p>
    }

}