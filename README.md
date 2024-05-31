<img src="assets/icon.png" width="100px" />

# Template.Maui.UITesting

Currently under development, a set of templates that will make it easier to add UI test projects to your .NET MAUI solution.

You think this is useful? Let me know!

## Installation

You can install the templates with `dotnet new install Template.Maui.UITesting`.

## Available Templates

These are the templates that are currently available. You can create these through Visual Studio 2022 or the command-line.

### Project Templates

These templates will create multiple projects:
* A shared project, this is where you want to have your tests as they will be shared across all platforms
* Android project, this project has the configuration for running UI tests on Android. You can also write Android specific tests here.
* iOS project, this project has the configuration for running UI tests on iOS. You can also write iOS specific tests here.
* Windows project, this project has the configuration for running UI tests on Windows. You can also write Windows specific tests here.
* macOS project, this project has the configuration for running UI tests on macOS. You can also write Windows macOS tests here.

The template has options to include/exclude platforms as you like.

| Name | Description | Command |
|----------|----------|----------|
| .NET MAUI UI Test Projects (MSTest & Appium) | Projects that contain MSTest tests with Appium that can run on .NET MAUI on Android, iOS, Windows and macOS | `dotnet new maui-uitest-mstest` |
| .NET MAUI UI Test Projects (NUnit & Appium) | Projects that contain NUnit tests with Appium that can run on .NET MAUI on Android, iOS, Windows and macOS | `dotnet new maui-uitest-nunit` |
| .NET MAUI UI Test Projects (xUnit & Appium) | Projects that contain xUnit.net tests with Appium that can run on .NET MAUI on Android, iOS, Windows and macOS | `dotnet new maui-uitest-xunit` |

### Item Templates

| Name | Description | Command |
|----------|----------|----------|
| .NET MAUI UI Test Class (MSTest) |Creates a new .NET MAUI UI test class using MSTest | `dotnet new maui-uitest-mstest-class` |
| .NET MAUI UI Test Class (NUnit) | Creates a new .NET MAUI UI test class using NUnit | `dotnet new maui-uitest-nunit-class` |
| .NET MAUI UI Test Class (xUnit.net) | Creates a new .NET MAUI UI test class using xUnit.net | `dotnet new maui-uitest-xunit-class` |
