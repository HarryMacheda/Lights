"use client"
import { useState, useEffect, useContext } from "react"
import { ApiClient } from "@/api/client/client";

import List from "@/components/libraryv2/containers/list/list";
import Device from "../device/device";

export default function DeviceList()
{
    const [devices, setDevices] = useState<any>([]);
    const [isLoading, setLoading] = useState(true);

    useEffect(() => {
        const fetchData = async () => {
            try {
              const result = await ApiClient.get('/settings/devices');
              setDevices(result);
              setLoading(false);
            } catch (error) {
              console.error('Error fetching data:', error);
            }
        };      
          fetchData();
      }, [])

    if(isLoading){
        return (<>Loading...</>)
    }
    return(
        <List vertical={true}>
            {devices.map(function(x:any, i:number){
                return (
                    <Device key={i} Id={x.id} Name={x.name} State={1}/>
                );
            })}
        </List>
    )
}
