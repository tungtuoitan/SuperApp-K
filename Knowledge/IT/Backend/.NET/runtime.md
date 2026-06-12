---
id: 318
name: "runtime"
---

<!--# Runtime Systems là gì? [id:2775 order:1]
là tập hợp các thành phần phần mềm chịu trách nhiệm thực thi chương trình sau khi compile xong. -->

# Runtime là gì? [id:2776 order:2]
là hệ thống có trách nhiệm chạy code.

<!--# Runtime Systems là gì? [id:2865 order:3]
là tập hợp các thành phần phần mềm chịu trách nhiệm thực thi chương trình sau khi compile xong. -->

# Phân biệt CLR, Runtime, Runtime engine, Execution engine? [id:2777 order:4]
Đây là 4 tên khác nhau cho cùng 1 khái niệm trong .NET. CLR = Common Language Runtime = Runtime = Runtime engine = Execution engine. Trong văn nói chúng được dùng thay thế nhau.

# Phân biệt Runtime và Virtual machine? [id:2778 order:5]
Trong văn nói, 90% VM === Runtime. Cả hai đều là môi trường thực thi code. Điểm khác: VM thường ám chỉ môi trường ảo hóa toàn bộ OS; Runtime chỉ ảo hóa ở mức ngôn ngữ (JVM, CLR).

# runtime gồm những gì? [id:2866 order:6]
gồm: JIT compiler, GC, type system, thread scheduler, exception handler, và BCL (thư viện chuẩn).

<!--# Công việc cụ thể của Runtime là gì? [id:2779 order:7]
- Load program vào memory
- JIT compile IL sang machine code
- Quản lý bộ nhớ qua GC
- Xử lý exception
- Enforce type safety -->

# Execution Engine là gì? [id:2780 order:8]
là phần cốt lõi của runtime, thực hiện các lệnh IL.

<!--# Memory Manager là gì? [id:2781 order:9]
là thành phần có nhiệm vụ quản lý bộ nhớ, bao gồm: cấp phát, theo dõi, và thu hồi bộ nhớ khi không dùng. -->

# Garbage Collector là gì? [id:2782 order:10]
là thành phần trong Memory Manager, tự động thu hồi bộ nhớ của object không còn reference. Không cần dev gọi `free()`.

<!--# GC trong .NET là gì? [id:2867 order:11]
là Garbage Collector — tự động giải phóng memory của object không còn được tham chiếu, không cần dev tự `free()`. -->

<!--# Thread & Concurrency Manager là gì? [id:2783 order:12]
là thành phần chịu trách nhiệm tạo, quản lý, và lên lịch các thread trong process. -->

<!--# Standard Library Integration là gì? [id:2784 order:13]
là các thư viện được tích hợp sẵn vào runtime — BCL (Base Class Library), gồm `List`, `Dictionary`, `Stream`, `HttpClient`... -->

<!--# Interop Layer là gì? [id:2785 order:14]
là tầng cho phép .NET gọi native code (C/C++), OS API mà không cần viết lại từ đầu. -->

# Exception Handling System là gì? [id:2786 order:15]
là thành phần trong CLR xử lý exception — catch, propagate, và unwind call stack khi lỗi xảy ra.

# Type System là gì? [id:2787 order:16]
là thành phần quản lý các kiểu dữ liệu trong runtime — đảm bảo type safety, hỗ trợ reflection và generics.

<!--# Kiến trúc chạy của .NET như thế nào? [id:2788 order:17]
Từ trên xuống: Application Layer → Framework Layer (ASP.NET Core, EF Core...) → CLR (JIT, GC, Type System) → OS. -->

# IL là gì? [id:2868 order:18]
là Intermediate Language — bytecode mà compiler C# tạo ra. CLR sẽ JIT compile IL thành machine code lúc runtime.

<!--# Bytecode là gì? [id:2789 order:19]
là dạng mã trung gian, không phải machine code của CPU cụ thể. IL trong .NET là bytecode — platform-independent, CLR mới dịch sang machine code của từng CPU. -->

<!--# Intermediate language là gì? [id:2790 order:20]
là IL — ngôn ngữ trung gian mà Roslyn (C# compiler) tạo ra. CLR đọc IL và JIT compile sang machine code. Cho phép .NET cross-platform vì IL không gắn với CPU cụ thể. -->

# Machine code là gì? [id:2791 order:21]
là tập lệnh nhị phân mà CPU đọc và thực thi trực tiếp — output cuối cùng sau khi JIT compile IL.

# compiler tạo ra gì? [id:2869 order:22]
tạo ra IL (file `.dll` hoặc `.exe`) cùng metadata, không phải machine code trực tiếp.

# tại sao tại cần compiler? [id:2870 order:23]
Vì CPU không đọc được code C#. Compiler dịch C# → IL để CLR hiểu, rồi CLR JIT tiếp sang machine code mà CPU chạy được.

# JIT cũng là compiler à ? [id:2871 order:24]
Đúng. JIT (Just-In-Time) là 1 loại compiler, dịch IL → machine code lúc runtime, khác với compiler "ahead-of-time" dịch trước khi chạy.

<!--# tại sao không dịch code c# sang machine code luôn? [id:2872 order:25]
Vì machine code phụ thuộc CPU (x86, ARM, ...). Dịch sang IL trước rồi JIT sau giúp .NET cross-platform — 1 file `.dll` chạy được trên nhiều CPU. -->

<!--# 1 file dll chỉ chạy được trên 1 cpu cụ thể thôi à? [id:2873 order:26]
Không. File `.dll` chứa IL — platform-independent. CLR trên từng CPU sẽ JIT compile IL sang machine code phù hợp lúc runtime. -->

# CLR tạo ra gì? [id:2874 order:27]
tạo ra machine code

# JIT là gì? [id:2875 order:28]
là quá trình CLR biên dịch IL sang machine code

<!--# compiler tạo ra gì? [id:2876 order:29]
tạo ra IL (file `.dll` hoặc `.exe`) cùng metadata, không phải machine code trực tiếp. -->

# tại sao tại cần compiler? [id:2877 order:30]
Vì CPU không đọc được code C#. Compiler dịch C# → IL để CLR hiểu, rồi CLR JIT tiếp sang machine code mà CPU chạy được.

# JIT cũng là compiler à ? [id:2878 order:31]
Đúng. JIT (Just-In-Time) là 1 loại compiler, dịch IL → machine code lúc runtime, khác với compiler "ahead-of-time" dịch trước khi chạy.

<!--# tại sao không dịch code c# sang machine code luôn? [id:2879 order:32]
Vì machine code phụ thuộc CPU (x86, ARM, ...). Dịch sang IL trước rồi JIT sau giúp .NET cross-platform — 1 file `.dll` chạy được trên nhiều CPU. -->

<!--# 1 file dll chỉ chạy được trên 1 cpu cụ thể thôi à? [id:2880 order:33]
Không. File `.dll` chứa IL — platform-independent. CLR trên từng CPU sẽ JIT compile IL sang machine code phù hợp lúc runtime. -->

# CLR tạo ra gì? [id:2881 order:34]
tạo ra machine code

# JIT là gì? [id:2882 order:35]
là quá trình CLR biên dịch IL sang machine code

# JIT Compiler là gì? [id:2792 order:36]
là thành phần trong CLR có nhiệm vụ chuyển bytecode/IL (Intermediate Language) thành machine code lúc runtime.

# JIT compile khi nào? [id:2793 order:37]
Mỗi method chỉ được JIT compile lần đầu khi được gọi. Sau đó machine code được cache lại — lần gọi tiếp theo chạy thẳng machine code, không compile lại.

# Roslyn là gì? [id:2794 order:38]
là compiler chính thức của C# và VB trong .NET. Roslyn biên dịch code C# → IL → output file .dll hoặc .exe.

<!--# Khi C# .NET app chạy, chuyện gì xảy ra? [id:2795 order:39]
1. Host của .NET khởi động
2. CLR load assembly (.dll)
3. JIT compile method thành machine code khi method được gọi lần đầu
4. GC quản lý bộ nhớ trong suốt quá trình chạy
5. Khi app tắt, CLR dọn dẹp tài nguyên -->

<!--# Khi ứng dụng Go chạy, chuyện gì xảy ra? [id:2796 order:40]
1. Build chương trình, sinh ra file binary (machine code trực tiếp, không có IL)
2. Binary chạy trực tiếp trên OS — không cần runtime như CLR hay JVM
3. Go runtime (nhỏ, nhúng trong binary) xử lý goroutine scheduling và GC -->