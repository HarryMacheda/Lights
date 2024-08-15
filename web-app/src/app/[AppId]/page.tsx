"use client"
import { useState, useEffect } from "react"
import { ApiClient } from "@/api/client/client"


import { Jobs } from "@/components/jobs"
import { Job } from "@/views/job"

export default function Page({ params }: { params: { AppId: string } })
{
  const [selectedJob, setSelectedJob] = useState<any>(null);

  const storageKey = params.AppId + "_SelectedJob";

  const UpdateJob = async (job: any) => {
    //Update job in local storage
    localStorage.setItem(storageKey, JSON.stringify(job))

    setSelectedJob(job);
  }

  //Load from storage
  if(selectedJob == null)
  {
    let storedJob = localStorage.getItem(storageKey);
    if(storedJob != null)
      {
        setSelectedJob(JSON.parse(storedJob))
      } 
  }

  return (<>
      <Jobs AppId={params.AppId} update={UpdateJob}/>
      <div>
        {selectedJob ? <Job appId={params.AppId} name={selectedJob.name} description={selectedJob.description} job={selectedJob.job} arguments={selectedJob.arguments}/> : null }
      </div>
    </>
  )
} 