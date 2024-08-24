"use client"

import styles from "./alert.module.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSkullCrossbones, faCircleCheck, faCircleExclamation, faTriangleExclamation } from "@fortawesome/free-solid-svg-icons";

export type AlertProps = Readonly<{
    title: string;
    message: string;
    type: AlertType;
}>;

export enum AlertType {
    Warning,
    Success,
    Error,
    Information
}

export function Alert({title, message, type}:AlertProps)
{
    let classes = styles.Alert;
    let icon = null;
    switch(type) {
        case AlertType.Success:
            classes += " " + styles.Success;
            icon = faCircleCheck;
            break;
        case AlertType.Error:
            classes += " " + styles.Error;
            icon = faSkullCrossbones;
            break;
        case AlertType.Warning:
            classes += " " + styles.Warning;
            icon = faTriangleExclamation;
            break;
        case AlertType.Information:
            classes += " " + styles.Information;
            icon = faCircleExclamation;
            break;
    }

    return (
        <div className={classes}>
            <FontAwesomeIcon icon={icon}/>&emsp;
            <div>
                <span>{title}</span>
                <span>{message}</span>
            </div>
        </div>
    )
}