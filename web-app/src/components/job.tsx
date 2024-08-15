"use client"
import { useContext } from "react"


import {default as styles} from '../styles/components'
import {themeContext} from '../context/ThemeContext'

type CustomComponentProps = Readonly<{
    name: string;
    description: string;
    job: string;
    arguments: object[];
    handleClick: (arg: object) => void;
}>;

export function JobListItem({ name, description, job, arguments:args, handleClick}: CustomComponentProps){

    let retObject = { name:name, description:description, job:job, arguments:args }

    const theme = useContext(themeContext)

    return (
        <div className={[styles.job.Job, theme.components.job.Job].join(' ')} onClick={() => handleClick(retObject)}>
            {name}<br/>
            {description}<br/>
            {job}
            <br/>
        </div>
    )
}

