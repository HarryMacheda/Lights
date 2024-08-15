import { useState, createContext } from "react"
import {default as themes} from '../styles/themes'


export const themeContext = createContext(themes.dark)

export function useThemeContext({children})
{
    return (
        <themeContext.Provider value={themes.dark}>
            {children}
        </themeContext.Provider>
    )
}
