"use client"

import { useState, useEffect, useContext } from "react"
import { ApiClient } from '../api/client/client'

import { SideNav } from "./libraryv2/containers/sidenav/sidenav"
import JobListItem from "./lights/jobs/jobListItem/jobListItem"

import {themeContext} from '../context/ThemeContext'
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome"
import { faArrowRight, faRepeat } from "@fortawesome/free-solid-svg-icons"

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
    }, [AppId])

    if(isLoading){
        return (<>Loading...</>)
    }
    return(
        <SideNav>
                {single.map(function(x:any, i:number){
                    return (
                        <JobListItem key={i} icon={<FontAwesomeIcon icon={faArrowRight}/>} name={x.jobName} description={x.jobDescription} job={x.job} arguments={x.arguments} handleClick={update}/>
                    );
                })}
                {continuous.map(function(x:any, i:number){
                    return (
                        <JobListItem key={i} icon={<FontAwesomeIcon icon={faRepeat}/>} name={x.jobName} description={x.jobDescription} job={x.job} arguments={x.arguments} handleClick={update}/>
                    );
                })}
        </SideNav>
    )
}
