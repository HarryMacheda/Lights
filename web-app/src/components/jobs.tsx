"use client"

import { useState, useEffect, useContext } from "react"
import { ApiClient } from '../api/client/client'

import { SideNav } from "./ui/containers/sidenav"
import {JobListItem} from './job'

import {default as styles} from '../styles/components'
import {themeContext} from '../context/ThemeContext'

export function Jobs({ AppId, update }: { AppId: string, update: (arg: object) => void }){
    const [single, setSingle] = useState([]);
    const [continuous, setContinuous]  = useState([]);
    const [isLoading, setLoading] = useState(true);

    const theme = useContext(themeContext)

    useEffect(() => {
        const fetchData = async () => {
            try {
              const result = await ApiClient.get('/worker/routes/' + AppId);
              setSingle(result.runOnceJobs);
              setContinuous(result.continuousJobs);
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
        <SideNav title={"Jobs"}>
            <div>
                {single.map(function(x, i){
                    return (
                        <JobListItem name={x.jobName} description={x.jobDescription} job={x.job} arguments={x.arguments} handleClick={update}/>
                    );
                })}
            </div>
            <div>
                {continuous.map(function(x, i){
                    return (
                        <JobListItem name={x.jobName} description={x.jobDescription} job={x.job} arguments={x.arguments} handleClick={update}/>
                    );
                })}
            </div>
        </SideNav>
    )
}
