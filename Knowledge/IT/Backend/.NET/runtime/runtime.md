---
id: 318
name: "runtime"
---

# Runtime là gì? [id:2776 order:2]
là hệ thống có trách nhiệm chạy code.

# Phân biệt CLR, Runtime, Runtime engine, Execution engine? [id:2777 order:4]
trong văn nói, chúng là 1

# Phân biệt Runtime và Virtual machine? [id:2778 order:5]
Trong văn nói, 90% VM === Runtime. Cả hai đều là môi trường thực thi code. Điểm khác: VM thường ám chỉ môi trường ảo hóa toàn bộ OS; Runtime chỉ ảo hóa ở mức ngôn ngữ (JVM, CLR).

# runtime gồm những gì? [id:2866 order:6]
gồm: JIT compiler, GC, type system, thread scheduler, exception handler, và BCL (thư viện chuẩn).

# Công việc cụ thể của Runtime là gì? [id:2779 order:7]
- Load program vào memory
- compile IL sang machine code
- dọn dẹp bộ nhớ

# Execution Engine là gì? [id:2780 order:8]
là phần cốt lõi của runtime, thực hiện các lệnh IL.

# Garbage Collector là gì? [id:2782 order:10]
là thành phần trong Memory Manager, tự động thu hồi bộ nhớ của object không còn reference. Không cần dev gọi `free()`.

# GC trong .NET là gì? [id:2867 order:11]
là cỗ máy dọn dẹp tài nguyên

# GC có phải pattern không?
Có. GC implement pattern "Automatic Memory Management" 
— cụ thể hơn là biến thể của Mark-and-Sweep pattern. Nhưng trong .NET dev thường gọi nó là "feature của runtime" hơn là "pattern".

# Type System là gì? [id:2787 order:16]
là thành phần đảm bảo type safety

# Các layer trong .NET từ cao xuống thấp? [id:2788 order:17]
Application 
Framework
CLR 
OS.

# IL là gì? [id:2868 order:18]
là Intermediate Language — bytecode mà compiler C# tạo ra. CLR sẽ JIT compile IL thành machine code lúc runtime.

# Bytecode là gì? [id:2789 order:19]
là dạng mã trung gian 

# quan hệ giữa IL và bytecode?
IL là 1 dạng bytecode

# CLR cross platform bằng cách nào?
có nhiều CLR version, mỗi version sẽ tạo ra machine code tương thích với 1 loại OS/CPU cụ thể.

# CLR được tải xuống khi nào?
Khi cài .NET SDK hoặc .NET Runtime — installer tải CLR phù hợp với OS/CPU của máy. Sau đó mỗi lần chạy app .NET, OS load CLR vào memory trước khi chạy app.

# quan hệ giữa .dll và IL?
`.dll` là file chứa IL. 
IL là nội dung bên trong, `.dll` là format bọc ngoài (PE format) cùng với metadata, manifest, và resource.

# Machine code là gì? [id:2791 order:21]
là tập lệnh nhị phân mà CPU đọc và thực thi trực tiếp — output cuối cùng sau khi JIT compile IL.

# compiler tạo ra gì? [id:2869 order:22]
tạo ra IL (file `.dll` hoặc `.exe`) cùng metadata, không phải machine code trực tiếp.

# tại sao tại cần compiler? [id:2870 order:23]
Vì CPU không đọc được code C#. Compiler dịch C# → IL để CLR hiểu, rồi CLR JIT tiếp sang machine code mà CPU chạy được.

# JIT cũng là compiler à ? [id:2871 order:24]
Đúng. JIT (Just-In-Time) là 1 loại compiler, dịch IL → machine code lúc runtime, khác với compiler "ahead-of-time" dịch trước khi chạy.




# CLR tạo ra gì? [id:2874 order:27]
tạo ra machine code

# JIT là gì? [id:2875 order:28]
là quá trình CLR biên dịch IL sang machine code

# compiler tạo ra gì? [id:2876 order:29]
tạo ra IL 

# tại sao tại cần compiler? [id:2877 order:30]
Vì CPU không đọc được code C#. Compiler dịch C# → IL để CLR hiểu, rồi CLR JIT tiếp sang machine code mà CPU chạy được.

# JIT cũng là compiler à ? [id:2878 order:31]
Đúng. JIT (Just-In-Time) là 1 loại compiler, dịch IL → machine code lúc runtime, khác với compiler "ahead-of-time" dịch trước khi chạy.

<!--# 1 file dll chỉ chạy được trên 1 cpu cụ thể thôi à? [id:2880 order:33]
Không. File `.dll` chứa IL — platform-independent. CLR trên từng CPU sẽ JIT compile IL sang machine code phù hợp lúc runtime. -->

# CLR tạo ra gì? [id:2881 order:34]
tạo ra machine code

# JIT là gì? [id:2882 order:35]
là quá trình CLR biên dịch IL sang machine code

# Garbage Collection trong .NET hoạt động thế nào? [id:2903 order:36]
GC tự dọn object không còn reference trên heap. Chia 3 generation (0, 1, 2) — object sống lâu được "promote" lên generation cao hơn để dọn ít thường xuyên hơn.

# JIT Compiler là gì? [id:2792 order:37]
là thành phần trong CLR có nhiệm vụ chuyển bytecode/IL (Intermediate Language) thành machine code lúc runtime.

# JIT compile khi nào? [id:2793 order:38]
Mỗi method chỉ được JIT compile lần đầu khi được gọi. Sau đó machine code được cache lại — lần gọi tiếp theo chạy thẳng machine code, không compile lại.

# Roslyn là gì? [id:2794 order:39]
là compiler chính thức của C# và VB trong .NET. Roslyn biên dịch code C# → IL → output file .dll hoặc .exe.


# Khi C# .NET app chạy, chuyện gì xảy ra? [id:2795 order:40]
1. Host khởi động
2. CLR load assembly (.dll)
3. JIT tạo machine code
