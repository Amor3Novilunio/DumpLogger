###nuget Command Lines
* dotnet new classlib -n MyNuGetPackage
* dotnet pack --configuration Release
* dotnet nuget push bin/Release/MyNuGetPackage.1.0.0.nupkg --source https://api.nuget.org/v3/index.json --api-key YOUR_API_KEY
