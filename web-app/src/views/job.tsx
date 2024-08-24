"use client"
import { useState, useEffect } from "react"

import { Argument } from "@/components/argument";
import { ApiClient } from "@/api/client/client";

import styles from './job.module.css';
import Button from "@/components/libraryv2/button/button";

type CustomComponentProps = Readonly<{
    appId: string;
    name: string;
    description: string;
    job: string;
    arguments: object[];
}>;

export function Job({ appId, name, description, job, arguments:args }: CustomComponentProps)
{
    const [values, setValues] = useState<any>(null);
    const ArgumentKey = "JobArguments_" + appId + " " + job;

    useEffect(() => {
        let defaultValues = args.map((x:any) => x.argument.value);
        //Store default in local storage
        let storedValue = localStorage.getItem(ArgumentKey);
        if(storedValue){
            defaultValues = JSON.parse(storedValue);
        }

        setValues([...defaultValues]);
    }, [job, args]);    

    const handleChange = (index:number) => (data: any) => {
        if(values == null){ return; }
        let old = [...values];
        old[index] = data;
        setValues([...old]);       
    }

    const submitJob = async () => {
        //save the values to storage
        localStorage.setItem(ArgumentKey, JSON.stringify(values))
        let url = "/worker/startjob/" + encodeURIComponent(appId) + "/" + encodeURIComponent(job);
        let response = await ApiClient.post(url, values);
        console.log(response);
    }

    if(!values){
        return"Loading...";
    }
    return (
        <div className={styles.JobConatianer}>
            <div className={styles.Description}>
                <span>{name}</span>
                <span>{description}</span>
            </div>
            <hr/>
            <Button type={"primary"} size={"medium"} text={"Submit"} onClick={() => submitJob()} />
            <br/><br/>
            {args.map((x:any, i:number) => {return <><Argument key={i} name={x.name + " " + job} value={(values && values.length >0) ? values[i]: null} type={x.argument.controlType} handleChange={(e) => handleChange(i)(e)}/><br/></>})}
        </div>
    )
}