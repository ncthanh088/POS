* Debug Blazor WASM guid

- launch.json
- tasks.json
- lauchSetting.json

{
  "version": "0.2.0",
  "configurations": [
    {
      "name": "POS-Agent",
      "type": "coreclr",
      "request": "launch",
      //"cwd": "${workspaceFolder}/src/POS.WebApp",
      "preLaunchTask": "build", // Ensure we don't watch an unbuilt site
      "program": "dotnet",
      "stopAtEntry": false,
      "serverReadyAction": {
        "action": "openExternally",
        "pattern": "\\bNow listening on:\\s+(https?://\\S+)"
      },
      "env": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      },
      "args": [
        "watch",
        "--project",
        "${workspaceFolder}/POS.WebApp.csproj", // Give .csproj file path relative to workspace root
        "--verbose", // Let's us confirm browser connects with hot reload capabilities,
        "-c",
        "Debug"
      ],
      "sourceFileMap": {
        "/Views": "${workspaceFolder}/Views"
      }
    }
  ]
}



// {
//   "version": "2.0.0",
//   "tasks": [
//       {
//           "label": "build",
//           "command": "dotnet",
//           "type": "process",
//           "args": [
//               "build",
//               "${workspaceFolder}/POS.WebApp.sln",
//               "-c",
//               "Debug"
//           ],
//           "problemMatcher": "$msCompile"
//       }
//   ]
// }
