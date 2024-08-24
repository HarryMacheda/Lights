"use client"

import Link from 'next/link'
import styles from './device.module.css';

type DeviceProps = Readonly<{
    Id: string,
    Name: string,
    State: number
}>;

export default function Device({Id, Name, State}:DeviceProps){

    return(
            <div className={styles.Device}>
                <Link href={"/" + Id}>
                    <span>{Name}</span>
                    <p>{Id}</p>
                </Link>
            </div>
    )
}