"use client"
import Button from "@/components/libraryv2/button/button"
import Colour from "@/components/libraryv2/colour/colour"
import List from "@/components/libraryv2/containers/list/list"
import { useState, useEffect, useContext } from "react"

import { AlertContext } from "@/components/libraryv2/alerts/manager/manager"
import { AlertType } from "@/components/libraryv2/alerts/alert/alert"

export default function Page({ params }: { params: { AppId: string } })
{
    const alerts = useContext(AlertContext);

    const createAlert = (type:AlertType) => (e:any) =>{

        alerts({message: "hello", title:"yo", type:type})
    }

    return (
        <>
            <Button text={"Info"} type={"primary"} size={"small"} onClick={createAlert(AlertType.Information)}/>
            <Button text={"Warning"} type={"primary"} size={"small"} onClick={createAlert(AlertType.Warning)}/>
            <Button text={"Error"} type={"primary"} size={"small"} onClick={createAlert(AlertType.Error)}/>
            <Button text={"Success"} type={"primary"} size={"small"} onClick={createAlert(AlertType.Success)}/>      
        </>
    )
}