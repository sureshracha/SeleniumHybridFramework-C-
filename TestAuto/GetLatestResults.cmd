
for /f "delims=" %%i in ('dir *.trx /b/a-d/od/t:c') do set LAST=%%i
echo The most recently created file is %LAST%

copy "%LAST%" %1