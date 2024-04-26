# Articulate Card Generator
This is a program that will generate any number of Articulate cards and save into the [./builds](./builds/) folder. After 500 or so, there will start to be repeated terms.

Feel free to add more terms into [here](./src/data/articulate-data.json).

### Quickstart

1. Clone this repo and CD into the root. 
2. Setup a C# friendly IDE. I recommend VS Code with the [C# Dev Kit extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit).
3. Various different NuGet packages will have to be added. This should cover it.
```bash
  dotnet add package Newtonsoft.Json --version 13.0.3 &&
  dotnet add package SkiaSharp --version 2.88.8 && 
```
4. Run `dotnet build`
5. Run `dotnet run 50`, or however many cards you want to generate *up to 10000*.

