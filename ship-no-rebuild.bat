@echo off

echo.
echo CLEARING "ship"

if not exist "ship" mkdir ship
del /Q ship\*.*

echo.
echo COPYING
echo.

call aux-copy.bat

echo.
echo Done!
echo.
pause
exit