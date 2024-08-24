"use client"
import { useState } from "react";
import styles from "./sidenav.module.css";

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCaretRight, faCaretLeft } from '@fortawesome/free-solid-svg-icons'
import List from "../list/list";

type SideNavProps = Readonly<{
    children: React.ReactNode;
}>;


export function SideNav({ children }: SideNavProps)
{
    const [isOpen, setIsOpen] = useState(true);

    const toggleOpen = async () => {
        setIsOpen(!isOpen);
    }

    let classes = styles.SideNav
    classes += " " + ((isOpen) ? styles.SidenavOpen : styles.SidenavClosed)


    
    return (
        <div className={classes}>
            <button className={styles.Caret } onClick={() => toggleOpen()}>
                <FontAwesomeIcon icon={ (isOpen) ? faCaretLeft : faCaretRight}/>
            </button>
            <List vertical={true}>
                {isOpen && children}
            </List>
        </div>
    )
}