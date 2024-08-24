"use client"

import styles from './colour.module.css'

//props
type ColourProps = Readonly<{
    value: string,
    type: string,
    size: string,
    onChange: (arg: string) => void
}>;

export default function Colour({ value, type, size, onChange} : ColourProps)
{
    //Build the className from props
    let classnames = styles.colour;

    //Type of button
    switch (type)
    {
        case "primary":
            classnames += " " +styles.primary;
            break;
        case "secondary":
            classnames += " " +styles.secondary;
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
        <input type='color' className={classnames} defaultValue={value} onChange={(e) => onChange(e.target.value)} />
    )
}