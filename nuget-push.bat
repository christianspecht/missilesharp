@echo off

echo Push to NuGet?
echo (you need to execute build-release.bat first)
pause

call version-number.bat

cd %~dp0\release\lib-nuget

rem ..\..\src\packages\NuGet.CommandLine.1.8.40002\tools\nuget.exe setapikey xxx
rem -s https://preview.nuget.org

 ..\..\src\packages\NuGet.CommandLine.1.8.40002\tools\nuget.exe push MissileSharp.%VersionNumber%.nupkg
rem -s https://preview.nuget.org

pause