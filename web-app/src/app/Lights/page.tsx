"use client"

import { useState, useEffect } from "react"
import { ApiClient } from '../../api/client/client'

export default function Lights()
{
    const [devices, setDevices] = useState([]);
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
        <>
        {JSON.stringify(devices)}
        </>
    )
} 