"use client"
import { useState, useEffect } from "react"

import { Argument } from "@/components/argument";
import { ApiClient } from "@/api/client/client";

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

    useEffect(() => {
        const defaultValues = args.map((x:any) => x.argument.value);
        setValues([...defaultValues]);
    }, [job, args]);    

    const handleChange = (index:number) => (data: any) => {
        if(values == null){ return; }
        let old = [...values];
        old[index] = data;
        setValues(old);       
    }

    const submitJob = async () => {
        //
        let url = "/worker/startjob/" + encodeURIComponent(appId) + "/" + encodeURIComponent(job);
        let response = await ApiClient.post(url, values);
        console.log(response);
    }

    return (
        <div>
            {name}<br/>
            {description}<br/>
            {job}
            <br/><br/>
            <button onClick={() => submitJob()}>submit</button>
            <br/><br/>
            {args.map((x:any, i:number) => {return <Argument key={i} name={x.name + " " + job} value={x.argument.value} type={x.argument.controlType} handleChange={(e) => handleChange(i)(e)}/>})}
        </div>
    )
}