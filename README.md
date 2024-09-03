# UIOutline for unity

`UIOutline` is a custom UI effect for Unity that adds an outline around UI elements.  
This effect is achieved by displacing the vertices of the UI object in multiple directions, creating a smooth and uniform outline.

## Features

- Customizable smoothness for the outline.
- Support for graphic alpha transparency.
- Optimized for performance with object pooling.

## Installation

### Prerequisites

Ensure you have the Unity UI package installed:

1. Open Unity and go to `Window` -> `Package Manager`.
2. Search for `Unity UI` in the list of packages.
   - If it's not installed, click `+` -> `Add package from git URL...` and enter `com.unity.ugui`.

### Adding UIOutline to Your Project

1. Download or clone the repository.
2. Copy the `UIOutline.cs` script into your Unity project's `Assets/Scripts` directory.
3. Attach the `UIOutline` component to any UI element (e.g., Text, Image) from the Inspector.

## Usage

### Adding the component

1. Select the UI element (e.g., Text, Image) in the Hierarchy.
2. In the Inspector, click on `Add Component`.
3. Search for `UIOutline` and add it to the UI element.

### Configuring the outline

- `Smoothness`: Adjust the number of vertex displacement directions. Higher values result in a smoother outline but may impact performance.
- `Effect Color`: Set the color of the outline.
- `Effect Distance`: Set the distance of the outline from the original UI element.
- `Use Graphic Alpha`: Enable this to consider the alpha transparency of the original UI element.
