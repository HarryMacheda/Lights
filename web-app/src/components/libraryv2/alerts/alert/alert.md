# Alert Component Documentation

## Overview

The `Alert` component is designed to display different types of alerts with various styles and icons based on the alert type. It accepts props for the title, message, type, and duration of the alert and uses Font Awesome icons for visual representation.

## Props

### `title`

- **Type:** `string`
- **Description:** The title of the alert. This will be displayed prominently at the top of the alert.

### `message`

- **Type:** `string`
- **Description:** The message content of the alert. This provides additional information or context related to the alert.

### `type`

- **Type:** `AlertType`
- **Description:** Specifies the type of the alert. The alert type determines the styling and icon used.
- **Values:**
  - `AlertType.Warning` - Displays a warning alert with a caution icon.
  - `AlertType.Success` - Displays a success alert with a checkmark icon.
  - `AlertType.Error` - Displays an error alert with a crossbones icon.
  - `AlertType.Information` - Displays an informational alert with an exclamation icon.

### `duration`

- **Type:** `number`
- **Description:** The duration for which the alert should be displayed. This value is expected to be in milliseconds. A value of zero means
it should never expires.

### `onDismiss`

- **Type:** `() => void`
- **Description:** A callback function that is called when the alert is dismissed. This function can be used to handle any necessary cleanup or state updates.

## Enum

### `AlertType`

The `AlertType` enum defines the types of alerts:

```typescript
export enum AlertType {
    Warning,
    Success,
    Error,
    Information
}
```

## Usage
To use the Alert component, import it into your React component and provide the required props. Here's an example of how to use it:
``` tsx
import React from 'react';
import { Alert, AlertType } from './Alert';

const App: React.FC = () => {
    const handleDismiss = () => {
        console.log('Alert dismissed');
    };

    return (
        <div>
            <Alert
                title="Success!"
                message="Your operation was successful."
                type={AlertType.Success}
                duration={5000}
                onDismiss={handleDismiss}
            />
        </div>
    );
};

export default App;
```