import type { Metadata } from "next";
import "./globals.css";
import "../styles/styles/text.css"

import styles from "./layout.module.css";

import DeviceList from "@/components/lights/devices/deviceList/deviceList";

import AlertManager from "@/components/libraryv2/alerts/manager/manager";


export const metadata: Metadata = {
  title: "Harrys Lights",
  description: "Web app for controlling your lights",
};

export default function RootLayout({
    children,
  }: Readonly<{
    children: React.ReactNode;
  }>) {
    return (
      <html>
        <head>
        </head>
        <body>
          <AlertManager>
            <div className={styles.LayoutContainer}>
              <div className={styles.DeviceListContainer}>
                Device List
                <DeviceList />
              </div>
              <div className={styles.Content}>
                {children}
              </div>
            </div>
          </AlertManager>
        </body>
      </html>
    );
  }