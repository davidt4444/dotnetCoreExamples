
If not installed, download and install dotnet core
https://learn.microsoft.com/en-us/dotnet/core/install/macos

Tutorial from https://stackup.hashnode.dev/using-vs-code-create-aspnet-core-web-api

make a directory for the solution and open integrated terminal to it
I chose to name it the same as the name for the solution, but it doesn't matter
run 
dotnet new sln --name stackup_vsc_setup
dotnet new webapi --name Stackup.Api
dotnet sln add ./Stackup.Api/Stackup.Api.csproj
<!-- If running in windows 
dotnet sln add .\Stackup.Api\Stackup.Api.csproj -->
dotnet build
dotnet run

