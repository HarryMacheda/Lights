"use client"

import { useState, useEffect, useContext } from "react"
import { ApiClient } from '../api/client/client'

import {default as styles} from '../styles/components'
import {themeContext} from '../context/ThemeContext'

import Link from 'next/link'


export function DeviceList()
{
    const [devices, setDevices] = useState([]);
    const [isLoading, setLoading] = useState(true);

    const theme = useContext(themeContext)

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
        <div className={[styles.devices.DeviceList, theme.components.devices.DeviceList].join(' ')}>
        {devices.map(function(x, i){
            return (
                <Device key={i} Id={x.id} Name={x.name} State={1}/>
            );
            })}
        </div>
    )
}

interface DeviceProps
{
    Id: string;
    Name: string;
    State: number;
}

function Device(props:DeviceProps){

    const theme = useContext(themeContext)

    return(
            <div className={[styles.devices.Device, theme.components.devices.Device].join(' ')}>
                <Link class="Link" href={"/" + props.Id}>
                    <span className={styles.devices.Span}>{props.Name}</span>
                    <p class="Subtitle">{props.Id}</p>
                </Link>
            </div>
    )
}
