# Dialog Component Documentation

## Overview

The `Dialog` component is a React wrapper around the native `<dialog>` HTML element. It provides additional functionality for managing dialog visibility and registering custom events. This component can be controlled programmatically via `ref` to open and close the dialog, and it supports optional modal behavior.

## Props

### `open`

- **Type:** `boolean`
- **Default:** `false`
- **Description:** Determines whether the dialog is open by default. When `true`, the dialog will be rendered in an open state.

### `modal`

- **Type:** `boolean`
- **Default:** `false`
- **Description:** Specifies whether the dialog should be displayed as a modal (i.e., with a backdrop that prevents interaction with the rest of the page). If `true`, `dialog.showModal()` will be called; otherwise, `dialog.show()` will be used.

### `title`

- **Type:** `string`
- **Default:** `undefined`
- **Description:** The title displayed in the dialog header. This is optional.

### `children`

- **Type:** `ReactNode`
- **Description:** The content to be displayed inside the dialog. This can include any valid React nodes, such as text, components, or other elements.

### `ref`

- **Type:** `ForwardedRef<IDialog>`
- **Description:** A ref to expose `Open` and `Close` methods to the parent component for programmatic control of the dialog.

## Methods

### `Open`

- **Type:** `() => void`
- **Description:** Opens the dialog. It dispatches a `dialog-open` custom event and calls either `dialog.show()` or `dialog.showModal()` based on the `modal` prop.

### `Close`

- **Type:** `() => void`
- **Description:** Closes the dialog. It dispatches a `dialog-close` custom event and calls `dialog.close()`.

## Usage

### Basic Usage

```tsx
import React, { useRef } from 'react';
import Dialog from './Dialog';

const App: React.FC = () => {
    const dialogRef = useRef<IDialog>(null);

    return (
        <div>
            <button onClick={() => dialogRef.current?.Open()}>Open Dialog</button>
            <Dialog ref={dialogRef} title="Example Dialog">
                <p>This is the dialog content.</p>
                <button onClick={() => dialogRef.current?.Close()}>Close</button>
            </Dialog>
        </div>
    );
};

export default App;
```

### Custom Events

#### `dialog-open`

- **Type:** `CustomEvent`
- **Description:** This event is dispatched when the dialog is opened. It can be listened to by adding an event listener to the `window` object.
- **Usage Example:**

    ```tsx
    React.useEffect(() => {
        const handleDialogOpen = (event: Event) => {
            console.log('Dialog opened:', event);
        };

        window.addEventListener('dialog-open', handleDialogOpen);

        return () => {
            window.removeEventListener('dialog-open', handleDialogOpen);
        };
    }, []);
    ```

#### `dialog-close`

- **Type:** `CustomEvent`
- **Description:** This event is dispatched when the dialog is closed. Similar to `dialog-open`, this event can be listened to by adding an event listener to the `window` object.
- **Usage Example:**

    ```tsx
    React.useEffect(() => {
        const handleDialogClose = (event: Event) => {
            console.log('Dialog closed:', event);
        };

        window.addEventListener('dialog-close', handleDialogClose);

        return () => {
            window.removeEventListener('dialog-close', handleDialogClose);
        };
    }, []);
    ```
