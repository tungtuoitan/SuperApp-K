# Runtime Systems là gì?
là tập hợp các thành phần phần mềm chịu trách nhiệm thực thi chương trình sau khi compile xong.

# Runtime là gì?
là hệ thống có trách nhiệm chạy code.

# Phân biệt CLR, Runtime, Runtime engine, Execution engine?
Đây là 4 tên khác nhau cho cùng 1 khái niệm trong .NET. CLR = Common Language Runtime = Runtime = Runtime engine = Execution engine. Trong văn nói chúng được dùng thay thế nhau.

# Phân biệt Runtime và Virtual machine?
Trong văn nói, 90% VM === Runtime. Cả hai đều là môi trường thực thi code. Điểm khác: VM thường ám chỉ môi trường ảo hóa toàn bộ OS; Runtime chỉ ảo hóa ở mức ngôn ngữ (JVM, CLR).

# Công việc cụ thể của Runtime là gì?
- Load program vào memory
- JIT compile IL sang machine code
- Quản lý bộ nhớ qua GC
- Xử lý exception
- Enforce type safety

# Execution Engine là gì?
là phần cốt lõi của runtime, thực hiện các lệnh IL.

# Memory Manager là gì?
là thành phần có nhiệm vụ quản lý bộ nhớ, bao gồm: cấp phát, theo dõi, và thu hồi bộ nhớ khi không dùng.

# Garbage Collector là gì?
là thành phần trong Memory Manager, tự động thu hồi bộ nhớ của object không còn reference. Không cần dev gọi `free()`.

# Thread & Concurrency Manager là gì?
là thành phần chịu trách nhiệm tạo, quản lý, và lên lịch các thread trong process.

# Standard Library Integration là gì?
là các thư viện được tích hợp sẵn vào runtime — BCL (Base Class Library), gồm `List`, `Dictionary`, `Stream`, `HttpClient`...

# Interop Layer là gì?
là tầng cho phép .NET gọi native code (C/C++), OS API mà không cần viết lại từ đầu.

# Exception Handling System là gì?
là thành phần trong CLR xử lý exception — catch, propagate, và unwind call stack khi lỗi xảy ra.

# Type System là gì?
là thành phần quản lý các kiểu dữ liệu trong runtime — đảm bảo type safety, hỗ trợ reflection và generics.

# Kiến trúc chạy của .NET như thế nào?
Từ trên xuống: Application Layer → Framework Layer (ASP.NET Core, EF Core...) → CLR (JIT, GC, Type System) → OS.

# Bytecode là gì?
là dạng mã trung gian, không phải machine code của CPU cụ thể. IL trong .NET là bytecode — platform-independent, CLR mới dịch sang machine code của từng CPU.

# Intermediate language là gì?
là IL — ngôn ngữ trung gian mà Roslyn (C# compiler) tạo ra. CLR đọc IL và JIT compile sang machine code. Cho phép .NET cross-platform vì IL không gắn với CPU cụ thể.

# Machine code là gì?
là tập lệnh nhị phân mà CPU đọc và thực thi trực tiếp — output cuối cùng sau khi JIT compile IL.

# JIT Compiler là gì?
là thành phần trong CLR có nhiệm vụ chuyển bytecode/IL (Intermediate Language) thành machine code lúc runtime.

# JIT compile khi nào?
Mỗi method chỉ được JIT compile lần đầu khi được gọi. Sau đó machine code được cache lại — lần gọi tiếp theo chạy thẳng machine code, không compile lại.

# Roslyn là gì?
là compiler chính thức của C# và VB trong .NET. Roslyn biên dịch code C# → IL → output file .dll hoặc .exe.

# Khi C# .NET app chạy, chuyện gì xảy ra?
1. Host của .NET khởi động
2. CLR load assembly (.dll)
3. JIT compile method thành machine code khi method được gọi lần đầu
4. GC quản lý bộ nhớ trong suốt quá trình chạy
5. Khi app tắt, CLR dọn dẹp tài nguyên

# Khi ứng dụng Go chạy, chuyện gì xảy ra?
1. Build chương trình, sinh ra file binary (machine code trực tiếp, không có IL)
2. Binary chạy trực tiếp trên OS — không cần runtime như CLR hay JVM
3. Go runtime (nhỏ, nhúng trong binary) xử lý goroutine scheduling và GC
