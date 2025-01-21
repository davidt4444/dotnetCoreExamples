
If not installed, download and install dotnet core
https://learn.microsoft.com/en-us/dotnet/core/install/macos

Tutorial from https://stackup.hashnode.dev/using-vs-code-create-aspnet-core-web-api

make a directory for the solution and open integrated terminal to it
I chose to name it the same as the name for the solution, but it doesn't matter
run 
dotnet new sln --name basic_content_service
dotnet new webapi --name BCS.Api
dotnet sln add ./BCS.Api/BCS.Api.csproj
<!-- If running in windows 
dotnet sln add .\BCS.Api\BCS.Api.csproj -->
dotnet build
dotnet run
Grok prompts
generate a web api controller for a model called post with openapi
generate a model for post
generate ipostservice
generate an implementation of IPostService
generate the dbcontext
generate add postservice
generate the db context for mysql
generate the database from post model

dotnet tool install --global dotnet-ef --version 9
<!--
https://learn.microsoft.com/en-us/answers/questions/2101715/how-to-fix-an-error-system-typeloadexception-in-an
This seems to make this stuff work
dotnet add package Mysql.Data --version 9.1.0
dotnet add package Mysql.EntityFrameworkCore --version 8.0.8
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.8
-->
dotnet ef migrations add InitialCreate -c YourDbContext
dotnet ef database update -c YourDbContext
<!--
If you run into errors starting out, run
dotnet ef migrations remove
dotnet build
or if you want to start over run
dotnet ef database update 0
dotnet build
and then start at the beginning of the list of things to do for ef
If you want to revert to last successful migration over run
dotnet ef database update migration-name
dotnet build
-->
dotnet build
dotnet run
https://x.com/i/grok/share/SnDlDbSkG1TvypJS0NXv8h0aw

At this point, clean up the class and variable names automatically with refactor in the right click menu.
Then go through and change the labels.

replace Stackup with BCS
replace stackup_vsc_setup with basic_content_service
rename Stackup.Api dir BCS.Api
rename Stackup.Api.csproj to BCS.Api.csproj
rename Stackup.Api.http to BCS.Api.http
rename stackup_vsc_setup dir basic_content_service
rename stackup_vsc_setup solution basic_content_service
delete the bin and the obj folder
dotnet build
dotnet run
Solution should validate

dotnet new wpf --name BCE.Native
#note the wpf template doesn't exist for the mac so for that...
#Grok:generate all the files needed for a basic wpf application
#it is the MyWpfApp in the base dir
dotnet sln add ./BCE.Native/BCE.Native.csproj
Grok 
Generate code needed to create a blog post editor from the wpf application template that uses the blog post service

use prompts to resolve dependencies
Most of them are missing references, and the generated code iis so so.
https://x.com/i/grok/share/QOhO2d3AWaYOgBMya923MnIYj


https://x.com/i/grok?conversation=1877845767018430752
