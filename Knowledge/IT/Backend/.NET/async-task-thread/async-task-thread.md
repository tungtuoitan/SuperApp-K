---
id: 320
name: "async-task-thread"
---

# khi nào nên dùng async/await? [id:2811 order:1]
Khi method có I/O (DB query, HTTP call, file).

# cứ có IO là luôn nên dùng await phải không? [id:2812 order:2]
Gần như đúng cho server-side. IO async giúp thread không bị block, server xử lý được nhiều request đồng thời. Trừ trường hợp IO rất ngắn hoặc app tool một thread.

# lợi ích của async khi dùng cho IO? [id:2813 order:3]
Thread không bị block khi chờ IO → trả về thread pool để xử lý request khác. Server cùng số thread phục vụ được nhiều request hơn → throughput cao.

# khi nào nên dùng Task.Run? [id:2814 order:4]
Khi cần offload CPU-bound work khỏi thread hiện tại (UI thread, request thread). Không dùng cho I/O — I/O async đã không tốn thread rồi.

# khi nào nên dùng Thread? [id:2816 order:5]
Hiếm khi. Chỉ khi cần kiểm soát thấp như set priority, dùng `ThreadStatic`, hoặc tích hợp legacy API. Còn lại dùng Task.

# CPU-bound work là gì? [id:2817 order:6]
là công việc tốn CPU để tính toán — encrypt, parse, image processing, machine learning. Đối ngược với IO-bound (chờ DB/network/file).

# bound nghĩa là gì? [id:2818 order:7]
là "bị giới hạn bởi".
CPU-bound = bị giới hạn bởi tốc độ CPU. I/O-bound = bị giới hạn bởi tốc độ I/O.

# Task và Thread khác nhau thế nào? [id:2819 order:8]
Thread là đơn vị OS thực sự, tốn tài nguyên.
Task là abstraction của Thread, Task tốn thread pool.

# Task khác Thread như thế nào? [id:2901 order:9]
Task:
    dùng cho short running
    chạy trên thread pool
Thread:
    dùng cho long running
    là OS thread

# "abstraction cao hơn" nghĩa là gì? cho ví dụ phổ biến [id:2820 order:10]
là layer nằm trên, ẩn đi chi tiết của layer bên dưới
Ví dụ: Task ẩn Thread, EF Core ẩn SQL, HttpClient ẩn TCP socket.

# abstraction có những nghĩa nào, là loại từ gì? [id:2821 order:11]
(n): khái niệm trừu tượng / lớp che giấu chi tiết.
Ví dụ: "Task is an abstraction over threads."
Cũng dùng như (v) "to abstract" = trừu tượng hóa.

# đơn vị OS là gì? [id:2822 order:12]
là tài nguyên thực do OS cấp phát và quản lý

# tài nguyên OS gồm những gì? [id:3317 order:13]
— process, thread, file handle, socket.

# abstraction nghĩa là gì? [id:2823 order:14]
là che giấu chi tiết phức tạp bên dưới, chỉ phơi ra interface đơn giản. Task abstract Thread, ORM abstract SQL.

# (task abstract thread) nghĩa là (Task là 1 abstract của thread) à ? [id:2824 order:15]
Đúng. Task là lớp abstraction nằm trên Thread — bạn xài Task, runtime tự lo phân Thread bên dưới.

# compose là gì? [id:2825 order:16]
là ghép nhiều thành phần nhỏ lại thành thành phần lớn hơn. Trong .NET, compose Task là chain `await` nhiều operation, hoặc dùng `Task.WhenAll`.

# Thread .NET có liên hệ gì với OS thread? [id:2900 order:17]
Quan trọng với UI app. WPF/WinForms chỉ cho update UI từ UI thread — nếu await xong nhảy sang thread khác, code update UI sẽ throw exception. ASP.NET Core và console app không có ràng buộc này nên chạy thread nào cũng được, lợi cho throughput.
1 thread .NET tương ứng với 1 OS thread

# method trả về Task thì nói lên điều gì? [id:2951 order:18]
```cs
Task<ResultOptions> Error(LogDto log);
```
cho dev biết: method này async

# result type Task có nghĩa là chưa có kq, đang đợi có phải không? [id:2952 order:19]
Đúng.
`Task<T>` là 1 promise — đại diện cho công việc đang chạy/sắp chạy. Khi xong, kết quả `T` mới có. Caller dùng `await` hoặc `.Result` để lấy.

# khi nào dùng private? [id:2953 order:20]
khi member chỉ dùng nội bộ trong class.

# mặc định thì member là private hay public? [id:2954 order:21]
Mặc định là `private` cho mọi member trong class/struct (không khai báo modifier).
Riêng interface member mặc định `public`.

# các keyword ngược lại với private? [id:2955 order:22]
- `public`: mọi nơi truy cập được
- `protected`: chỉ class kế thừa truy cập được
- `internal`: chỉ trong cùng assembly truy cập được
- `protected internal`: kết hợp 2 cái trên

# string dạng này gọi là gì? $"{x}-abc"; [id:2956 order:23]
là string interpolation

# các modifier phổ biến? [id:2957 order:24]
`public`, `private`, `protected`, `internal`, `static`, `readonly`, `override`, `virtual`, `abstract`, `sealed`.