import type { Metadata } from "next";
import { Inter } from "next/font/google";
import "./globals.css";
import "../styles/styles/text.css"

import "@/styles/app/Lights/layout.css"

import {DeviceList} from '../components/devices'


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
          <div className="LayoutContainer">
            <div className="DeviceListContainer">
              Device List
              <DeviceList />
            </div>
            <div className="Content">
              {children}
            </div>
          </div>
        </body>
      </html>
    );
  }