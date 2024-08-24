"use client"
import { createContext, ReactNode, useContext, useState, useRef } from "react"
import { AlertProps, Alert } from "../alert/alert";

import styles from "./manager.module.css"

export const AlertContext = createContext<(arg: AlertProps) => void>((x) => {})

type AlertManagerProps = Readonly<{
    children:ReactNode
}>;

export default function AlertManager({children}:AlertManagerProps)
{
    const dialogRef = useRef(null);

    const [alerts, setAlerts] = useState<AlertProps[]>([]);

    const CreateAlert = (arg: AlertProps) => {
        if(alerts.length == 0){
            dialogRef.current?.show();
        }
        setAlerts((prevAlerts) =>[...prevAlerts, arg]);
        setTimeout(PopAlert, 3000);
    }

    const PopAlert = () => {
        setAlerts((prevAlerts) => {
            const updatedAlerts = prevAlerts.slice(1); // Remove the first alert
            if (updatedAlerts.length === 0) {
              dialogRef.current?.close();
            }
            return updatedAlerts;
          });
    }

    return(
        <>
            <dialog ref={dialogRef} className={styles.Dialog}>
                {alerts.map((alert) => {return <Alert title={alert.title} type={alert.type} message={alert.message}/>})}
            </dialog>
            <AlertContext.Provider value={CreateAlert} >
                {children}
            </AlertContext.Provider>
        </>
    )
}
