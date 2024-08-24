"use client"
import { ReactNode } from 'react';
import styles from './jobListItem.module.css'

type JobListItemProps = Readonly<{
    name: string;
    description: string;
    job: string;
    arguments: object[];
    icon: ReactNode;
    handleClick: (arg: object) => void;
}>;

export default function JobListItem({ name, description, job, arguments:args, icon, handleClick}: JobListItemProps){

    let retObject = { name:name, description:description, job:job, arguments:args }

    return (
        <div className={styles.ListItem} onClick={() => handleClick(retObject)}>
            <span>{name} {icon && icon}</span>
            <span>{description}</span>
        </div>
    )
}

