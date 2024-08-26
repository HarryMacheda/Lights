# Alert Manager Component Documentation

## Overview

The `AlertManager` component is responsible for managing and displaying alert messages throughout the application. It uses a React context to provide a function for creating alerts and handles the display and dismissal of these alerts. Alerts are displayed in a container that appears above other content, and custom logic is used to ensure proper stacking with dialogs.

## Components

### `AlertContext`

A React context that provides a function to create alerts. This context is used to share the alert creation function across components.

### `useAlerts`

A custom hook that provides functions to create different types of alerts. It consumes the `AlertContext` and provides convenient methods to create success, error, warning, and informational alerts.

#### Usage

```tsx
import { useAlerts } from './AlertManager';

const SomeComponent: React.FC = () => {
    const { CreateAlert, SuccessAlert, ErrorAlert, WarningAlert, InformationAlert } = useAlerts();

    return (
        <div>
            <button onClick={() => SuccessAlert('Success', 'Operation completed successfully.')}>
                Show Success Alert
            </button>
            <button onClick={() => ErrorAlert('Error', 'An error occurred.')}>
                Show Error Alert
            </button>
            <button onClick={() => WarningAlert('Warning', 'This is a warning message.')}>
                Show Warning Alert
            </button>
            <button onClick={() => InformationAlert('Information', 'Here is some information.')}>
                Show Information Alert
            </button>
            <button onClick={() => CreateAlert({message: "Message", title:"Title", type:AlertType.Error, onDismiss:Dismiss, duration:3000 }}>
                Show Alert with more props
            </button>
        </div>
    );
};
```