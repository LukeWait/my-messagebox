# Custom C# MessageBox

## Description
A C# class that extends the functionality of the built-in MessageBox, providing enhanced customization options and allowing for parent-relative positioning. This makes it ideal for Windows Forms applications where a more flexible dialog box solution is needed, particularly in multi-form solutions/testing where having the MessageBox appear over the parent is essential.

<p align="center">
  <img src="https://github.com/LukeWait/my-messagebox/raw/main/screenshots/my-messagebox-example.png" alt="MessageBox Screenshot" width="250">
</p>

## Table of Contents
- [Installation](#installation)
- [Usage](#usage)
- [Development](#development)
- [License](#license)
- [Source Code](#source-code)

## Installation

### From Source
To install and use the MyMessageBox class in your project:

1. Clone the repository:
    ```sh
    git clone https://github.com/LukeWait/my-messagebox.git
    cd my-messagebox
    ```

2. Include the `MyMessageBox.cs` file in your C# project directory.

## Usage
The `MyMessageBox` class allows you to display a custom message box in your Windows Forms application. 

### Parameters
The `Show` method requires the following parameters to control its appearance and behavior:
```csharp
MyMessageBox.Show(Form parentForm, string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
```

- **parentForm**: The parent form that the message box will appear over. This should be an instance of a `Form` that is currently displayed on the screen. In most cases, you can use `this` to refer to the current form.
- **message**: The message to display in the message box. Any string value is acceptable.
- **title**: The text to display in the title bar of the message box. Any string value is acceptable.
- **buttons**: The combination of buttons to display. Acceptable values include:
  - `MessageBoxButtons.OK`
  - `MessageBoxButtons.OKCancel`
  - `MessageBoxButtons.AbortRetryIgnore`
  - `MessageBoxButtons.YesNoCancel`
  - `MessageBoxButtons.YesNo`
  - `MessageBoxButtons.RetryCancel`
- **icon**: The icon to display in the message box. Acceptable values include:
  - `MessageBoxIcon.Error`
  - `MessageBoxIcon.Information`
  - `MessageBoxIcon.Question`
  - `MessageBoxIcon.Warning`
  - `MessageBoxIcon.None`

### Example Usage
Import the class in the global namespace:
```csharp
using CustomMessageBox;
```

To display a custom message box, use the following call:
```csharp
MyMessageBox.Show(this, "This is a custom message box.", "Custom MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Information);
```

## Development
The `MyMessageBox` class is designed to be customizable. Here are some areas of the code that you can alter to fit your preferences:

### Panel Colors
```csharp
// Lines 45-48
Panel bodyPanel = new Panel();
bodyPanel.Dock = DockStyle.Top;
bodyPanel.BackColor = Color.White; // Change this color

// Lines 50-53
Panel footerPanel = new Panel();
footerPanel.Height = 49;
footerPanel.Dock = DockStyle.Bottom;
footerPanel.BackColor = Color.CornflowerBlue; // Change this color
```

### Icon Sizes and Positions
```csharp
// Lines 71-72
iconBox.Location = new Point(20, 20); // Change the position
iconBox.Size = new Size(32, 32); // Change the size
```

### Font and Text Styles
```csharp
// Line 85
messageLabel.Font = new Font("Microsoft Sans Serif", 8); // Change the font and size
```

### Button Styles
```csharp
// Lines 159-163
button.BackColor = SystemColors.Control;
button.FlatAppearance.BorderColor = SystemColors.Control;
button.FlatStyle = FlatStyle.System;
```

## License
This project is licensed under the MIT License. See the LICENSE file for details.

## Source Code
The source code for this project can be found in the GitHub repository: [https://github.com/LukeWait/my-messagebox](https://www.github.com/LukeWait/my-messagebox).

