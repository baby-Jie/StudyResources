for /f "tokens=*" %%a in (File.txt) do (
  echo line=%%a
  mkdir .%%a
)
pause