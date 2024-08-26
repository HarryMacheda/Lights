"use client"
import { ReactNode, useRef, useImperativeHandle, forwardRef, ForwardedRef  } from "react";

import styles from "./Dialog.module.css"

//Wrapper over the native dialog
//We want it to register custom events

type DialogProps = Readonly<{
    open?: boolean; //Is it open by default
    modal?: boolean; //Should it be open on the top layer
    title?: string;
    children:ReactNode;
    ref:any;
}>;

export interface IDialog {
    Open: () => void;
    Close: () => void;
  }

const Dialog = forwardRef<IDialog, DialogProps>(({open, modal, title, children}:DialogProps, ref: ForwardedRef<IDialog>): JSX.Element => {

    const dialogRef = useRef<HTMLDialogElement>(null);

    const Open = () => {
        if(modal){ dialogRef.current?.showModal(); }
        else {dialogRef.current?.show(); }

        const event = new CustomEvent('dialog-open');
        window?.dispatchEvent(event);
    } 
    const Close = () => {
        dialogRef.current?.close();

        const event = new CustomEvent('dialog-close');
        window?.dispatchEvent(event);
    }

    useImperativeHandle(ref, () => ({
        Open,
        Close
    }));


    return(
        <dialog className={styles.Dialog} ref={dialogRef} open={open ? open : false}>
            <div><span>{title ? title : "Dialog"}</span> <button onClick={Close}>X</button></div>
            <div>{children}</div>
        </dialog>
    )


});

export default Dialog;
