@echo off

path=%path%;%windir%\Microsoft.net\Framework\v4.0.30319

cd %~dp0

msbuild build.proj

pause