@ECHO OFF
SETLOCAL ENABLEDELAYEDEXPANSION
SET CONFIGURATION=%~1
SET VERSION=%~2
SET PROJECTDIR=%CD%
SET TARGETDIR=%PROJECTDIR%\bin\%CONFIGURATION%

PUSHD ..\..
ECHO %CD%
SET ROOTDIR=%CD%
POPD

ECHO Step 2/4: Copying language files...
XCOPY /S /Y /F "%PROJECTDIR%\Translations\*" "%TARGETDIR%\MLauncher-langs\"

IF NOT "%CONFIGURATION%" == "Release" (
	ECHO Detected non-release configuration.
	GOTO FINISH
)

ECHO Step 3/4: Cleaning-up TARGETDIR...
DEL /Q "%TARGETDIR%\*.?db" "%TARGETDIR%\*.xml" "%TARGETDIR%\zip\"

ECHO Step 4/4: Creating zip archive with languages...
WHERE 7z >nul 2>nul
IF %ERRORLEVEL% NEQ 0 (
	ECHO 7z not found being installed.
	GOTO FINISH
)
7z a "%TARGETDIR%\MLauncher.zip" "%TARGETDIR%\MLauncher.exe" "%TARGETDIR%\MLauncher-langs\" -r
IF NOT DEFINED DLLS (
	GOTO FINISH
)

:FINISH
ECHO Finishing script...
