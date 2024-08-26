"use client"

import styles from './button.module.css'

//props
type ButtonProps = Readonly<{
    text: string,
    type: string,
    size: string,
    onClick: (arg: any) => void
}>;

export default function Button({ text, type, size, onClick} : ButtonProps)
{
    //Build the className from props
    let classnames = styles.button + " ";

    //Type of button
    switch (type)
    {
        case "primary":
            classnames += styles.primary;
            break;
        case "secondary":
            classnames += styles.secondary;
            break;
    }

    //Size of button
    switch (size)
    {
        case "small":
            classnames += " " + styles.small;
            break;
        case "medium":
            classnames += " " + styles.medium;
            break;
        case "large":
            classnames += " " + styles.large;
            break;
    }

    return(
        <button className={classnames} onClick={onClick}>{text}</button>
    )
}