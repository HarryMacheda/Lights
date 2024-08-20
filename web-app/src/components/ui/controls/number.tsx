"use client"
import { useState, useEffect } from "react"

type CustomComponentProps = Readonly<{
    value: string;
    handleChange: (arg: any) => void;
}>;

export function number({value, handleChange}: CustomComponentProps)
{
    return (
        <input type="number" value={value} onChange={(e) => handleChange(e.target.value)}/>
    )
}