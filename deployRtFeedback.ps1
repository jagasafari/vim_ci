Stop-Process -name ci.Console
Remove-Item c:\run\RtFeedback.Console\* 
Copy-Item c:\vim_ci\ci.Console\bin\Debug\* c:\run\RtFeedback.Console
c:\run\RtFeedback.Console\ci.Console.exe
