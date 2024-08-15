"use client"
import { useState, useEffect } from "react"

type CustomComponentProps = Readonly<{
    value: string;
    handleChange: (arg: object) => void;
}>;

export function number({value, handleChange}: CustomComponentProps)
{
    return (
        <input type="number" defaultValue={value} onChange={(e) => handleChange(e.target.value)}/>
    )
}