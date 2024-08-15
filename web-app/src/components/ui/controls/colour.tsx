"use client"
import { useState, useEffect } from "react"

type CustomComponentProps = Readonly<{
    value: string;
    handleChange: (arg: object) => void;
}>;

export function colour({value, handleChange}: CustomComponentProps)
{
    return (
        <input type="color" defaultValue={value} onChange={(e) => handleChange(e.target.value)}/>
    )
}