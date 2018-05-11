# Enable Service Profiler for ASP.NET Core application on CLR 2.1 RC images in Visual Studio
.NET Core CLR 2.1 is in pre-release. Since there are critical performance and robustness improvement, here we have this example to show how to build App Service based on CLR 2.1 image and enable the Service Profiler.

**Notes:**
* <span style="color:red">Warning: at this point, we still need some fix in the backend for the end to end story to be completed. You will always get trace analysis failure from the portal.</span>
* CLR 2.1 is not final yet, things could change;
* This example focuses on Enabling Service Profiler and might not follow some best practices, including some security ones like protecting the application insights instrumentation key;

## Walkthrough
* Create a ASP.NET Core MVC application with Linux Docker support;
* Enable Application Insights;
* Add private NuGet source to the solution folder: [NuGet.config](CLR21Example/NuGet.config).
* Update [Dockerfile](./CLR21Example/CLR21Example/Dockerfile) to use CLR 2.1 images:
```
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
...
FROM microsoft/dotnet:2.1-sdk AS build
COPY NuGet.config ./
...
RUN dotnet restore CLR21Example/CLR21Example.csproj -nowarn:msb3202,nu1503
```
The key point are:
* Use the proper images as build and runtime base;
* Copy over the NuGet.config for private NuGet store;
* Restore the project file than the solution file;

Optionally, enable the service profile logging like in [appsettings.json](CLR21Example/CLR21Example/appsettings.json)
```json
      "ServiceProfiler": "Information"
```
Bulid and publish.

