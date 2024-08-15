"use client"

import { useState, useContext } from "react";
import styles from "@/styles";

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCaretRight, faCaretLeft } from '@fortawesome/free-solid-svg-icons'

import { themeContext } from "@/context/ThemeContext";

type CustomComponentProps = Readonly<{
    children: React.ReactNode;
    title: string;
  }>;

export function SideNav({ children, title }: CustomComponentProps)
{
    const [isOpen, setIsOpen] = useState(true);

    const theme = useContext(themeContext)

    const toggleOpen = async () => {
        setIsOpen(!isOpen);
    }

    if (!isOpen)
    {
        return (
            <div className={[styles.components.ui.containers.sidenav.SidenavClosed, theme.components.ui.containers.sidenav.SidenavClosed].join(' ')}>
                <button className={[styles.components.ui.containers.sidenav.Caret, theme.components.ui.containers.sidenav.Caret].join(' ')} onClick={() => toggleOpen()}>
                    <FontAwesomeIcon icon={faCaretRight}/>
                </button>
            </div>
        )
    }

    return (
        <div className={[styles.components.ui.containers.sidenav.SidenavOpen, theme.components.ui.containers.sidenav.SidenavOpen].join(' ')}>
            {title}
            <button className={[styles.components.ui.containers.sidenav.Caret, theme.components.ui.containers.sidenav.Caret].join(' ')} onClick={() => toggleOpen()}>
                <FontAwesomeIcon icon={faCaretLeft}/>
            </button>
            {children}
        </div>
    )
}