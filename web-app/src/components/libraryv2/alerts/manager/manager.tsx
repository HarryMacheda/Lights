"use client"
import { createContext, ReactNode, useContext, useState, useRef } from "react"
import { AlertProps, Alert, AlertType } from "../alert/alert";

import styles from "./manager.module.css"

export const AlertContext = createContext<(arg: AlertProps) => void>((x) => {})

export function useAlerts() {
    const CreateAlert = useContext(AlertContext);

    if (CreateAlert === undefined) {
        throw new Error("CreateAlert is not defined, use inside and AlertContextProvider");
    }

    const SuccessAlert = (title:string, message:string) => {
        CreateAlert({title: title, message:message, duration:2000, type: AlertType.Success});
    }
    const ErrorAlert = (title:string, message:string) => {
        CreateAlert({title: title, message:message, duration:3000, type: AlertType.Error});
    }
    const WarningAlert = (title:string, message:string) => {
        CreateAlert({title: title, message:message, duration:3000, type: AlertType.Warning});
    }
    const InformationAlert = (title:string, message:string) => {
        CreateAlert({title: title, message:message, duration:3000, type: AlertType.Information});
    }

    return {CreateAlert, SuccessAlert, ErrorAlert, WarningAlert, InformationAlert}
}


type AlertManagerProps = Readonly<{
    children:ReactNode
}>;


export default function AlertManager({children}:AlertManagerProps)
{
    const containerRef = useRef<HTMLDivElement>(null);

    const [alerts, setAlerts] = useState<Record<string, AlertProps>>({})

    const CreateAlert = (arg: AlertProps) => {
        //Create a unique id
        let ID = Date.now().toString(36) + Math.random().toString(36).substring(2);

        //If we dont have any alerts open the container
        if(Object.keys(alerts).length == 0){
            containerRef.current?.showPopover();
        }

        setAlerts((prevAlerts) => ({...prevAlerts,[ID]: arg,}));
        setTimeout(() => {DismissAlert(ID); arg.onDismiss ? arg.onDismiss() : () => {};}, arg.duration);

    }

    const DismissAlert = (id:string) =>
    {
        setAlerts((prevAlerts) => {
            const updatedAlerts = { ...prevAlerts };
            delete updatedAlerts[id];
            if (Object.keys(updatedAlerts).length === 0) {
                containerRef.current?.hidePopover();
            }
            return updatedAlerts;
        });
    }

    //hack to make this always appear on top
    window.addEventListener("dialog-open",() => {
        containerRef.current?.hidePopover();
        containerRef.current?.showPopover();
    })


    return (
        <>
            <div ref={containerRef} className={styles.Dialog} popover="manual">
                {Object.entries(alerts).map(([id, alert]) => (
                    <Alert
                        key={id}
                        title={alert.title}
                        type={alert.type}
                        message={alert.message}
                    />
                ))}
            </div>
            <AlertContext.Provider value={CreateAlert}>
                {children}
            </AlertContext.Provider>
        </>
    );
}