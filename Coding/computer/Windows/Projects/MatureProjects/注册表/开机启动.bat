@echo off
 mode con lines=30 cols=60
 %1 mshta vbscript:CreateObject("Shell.Application").ShellExecute("cmd.exe","/c %~s0 ::","","runas",1)(window.close)&&exit
 
 echo "1. 输入1，增加新的启动项"
 echo "2. 输入2，删除启动项"
 set /p choose=
 if %choose%==1 (call :add) else (call :delete) 
 pause
 exit /b 0
 
 :add
 set /p keyname="please input a keyname:"
 set /p filepath="please input the path of file:"

 reg add hklm\software\microsoft\windows\currentversion\run /v %keyname% /t  reg_sz /d "%filepath%"
 exit /b 0
 
 :delete
set /p keyname="please input a keyname:"
reg delete hklm\software\microsoft\windows\currentversion\run /v %keyname%
 exit /b 0