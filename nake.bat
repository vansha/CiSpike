@ECHO OFF
SET DIR=%~dp0%
%DIR%\Tools\Nake\Nake.exe --trace -f %DIR%\Nake.csx -d %DIR% %*
