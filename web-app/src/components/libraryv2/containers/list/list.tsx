"use client"

import React, { ReactNode } from 'react';
import styles from './list.module.css'

//props
type ListProps = Readonly<{
    vertical: boolean,
    children: React.ReactNode
}>;

export default function List({vertical, children} : ListProps){

    let classes = styles.List;

    //Direction
    classes += " " + ((vertical) ? styles.Vertical : styles.Horizontal);


    return (
        <div className={classes}>
            {React.Children.map(children, (child, index) => (
                <ListItem>
                    {child}
                </ListItem>
            ))}
        </div>
    )
}

type ListItemProps = Readonly<{
    children: ReactNode
}>;

function ListItem({ children }: ListItemProps){

    return <div>
        {children}
    </div>
}