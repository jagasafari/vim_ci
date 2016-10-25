stop-process -name Quiz
remove-item c:\run\Quiz\*
copy-item c:\vim_ci\Quiz\bin\Debug\* c:\run\Quiz\
c:\run\Quiz\Quiz.exe

