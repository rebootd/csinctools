@echo off
IF "%~dp0"=="%CD%\" goto checkargs
goto normal

:checkargs
IF "%~1"=="" goto debug
IF "%~1"=="clean" goto clean

:release
..\..\SharedLibs\nant\nant.exe -buildfile:unrepo.build clean release
goto end

:debug
..\..\SharedLibs\nant\nant.exe -buildfile:unrepo.build clean build
goto end

:clean
..\..\SharedLibs\nant\nant.exe -buildfile:unrepo.build clean
goto end

:test
ECHO test!

:end
