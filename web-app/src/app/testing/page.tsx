"use client"
import Button from "@/components/libraryv2/button/button"
import Colour from "@/components/libraryv2/colour/colour"
import List from "@/components/libraryv2/containers/list/list"
import Dialog, { IDialog } from "@/components/libraryv2/Dialog/Dialog"

import { useRef, useContext } from "react"

import { useAlerts } from "@/components/libraryv2/alerts/manager/manager"
import { AlertType } from "@/components/libraryv2/alerts/alert/alert"

export default function Page({ params }: { params: { AppId: string } })
{
    const {CreateAlert, SuccessAlert, ErrorAlert, WarningAlert, InformationAlert} = useAlerts();
    const dialogRef = useRef<IDialog>(null);

    const createAlert = (type:AlertType) => (e:any) =>{

        CreateAlert({message: "hello", title:"yo", type:type, onDismiss:Dismiss, duration:3000 })
    }

    const Dismiss = () => {
        console.log("dismissed");
    }

    const OpenModal = () =>
    {
        dialogRef.current?.Open();
    }

    return (
        <>
            <Button text={"Info"} type={"primary"} size={"small"} onClick={() => InformationAlert("Information","giving you some info")}/>
            <Button text={"Warning"} type={"primary"} size={"small"} onClick={() =>WarningAlert("Warning","think twice please")}/>
            <Button text={"Error"} type={"primary"} size={"small"} onClick={() => ErrorAlert("Error","something went wrong")}/>
            <Button text={"Success"} type={"primary"} size={"small"} onClick={() => SuccessAlert("Success","all good here")}/>
            <Button text={"Success"} type={"primary"} size={"small"} onClick={createAlert(AlertType.Success)}/>

            <Button text={"Open modal"} type={"primary"} size={"small"} onClick={OpenModal}/>   
            <Dialog ref={dialogRef} modal title={"A modal"}>
                allow me to be opened  
                <Button text={"Success"} type={"primary"} size={"small"} onClick={createAlert(AlertType.Success)}/>  
            </Dialog>   
        </>
    )
}