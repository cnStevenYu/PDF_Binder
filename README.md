PDF_Binder
==========

PDF_Binder(foxit reader4.1.1 exploit)
PDF捆绑器，可捆绑win平台下的任何可执行程序。


漏洞描述：如果PDF文件的Title字段过长，Foxit Reader 4.1.1.805在读取Title字段时会发生缓冲区溢出。


原因：Title字段过长，Foxit Reader 4.1.1.805调用lstrcpyW函数的时候会发生缓冲区溢出从而覆盖掉SEH。

