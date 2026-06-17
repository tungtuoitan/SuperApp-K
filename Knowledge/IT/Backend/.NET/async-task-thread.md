---
id: 320
name: "async-task-thread"
---

# khi nào nên dùng async/await? [id:2811 order:1]
Khi method có I/O (DB query, HTTP call, file). Không nên dùng cho CPU-bound work — sẽ không có lợi.

# cứ có IO là luôn nên dùng await phải không? [id:2812 order:2]
Gần như đúng cho server-side. IO async giúp thread không bị block, server xử lý được nhiều request đồng thời. Trừ trường hợp IO rất ngắn hoặc app tool một thread.

# lợi ích của async khi dùng cho IO? [id:2813 order:3]
Thread không bị block khi chờ IO → trả về thread pool để xử lý request khác. Server cùng số thread phục vụ được nhiều request hơn → throughput cao.

<!--# khi nào nên dùng Task? [id:2814 order:4]
Khi cần chạy work đồng thời/bất đồng bộ — IO async, parallel processing, hoặc compose nhiều operation. Mặc định nên dùng Task thay vì Thread. -->

<!--# Task liên quan gì đến async? [id:2815 order:5]
`async` method trong C# trả về Task. Task đại diện cho công việc đang/sẽ hoàn thành — `await` task để chờ kết quả mà không block thread. -->

# khi nào nên dùng Thread? [id:2816 order:6]
Hiếm khi. Chỉ khi cần kiểm soát thấp như set priority, dùng `ThreadStatic`, hoặc tích hợp legacy API. Còn lại dùng Task.

# CPU-bound work là gì? [id:2817 order:7]
là công việc tốn CPU để tính toán — encrypt, parse, image processing, machine learning. Đối ngược với IO-bound (chờ DB/network/file).

<!--# bound nghĩa là gì? [id:2818 order:8]
là "bị giới hạn bởi". CPU-bound = bị giới hạn bởi tốc độ CPU; IO-bound = bị giới hạn bởi tốc độ IO (DB, network, disk). -->

<!--# Task và Thread khác nhau thế nào? [id:2819 order:9]
Thread là đơn vị OS thực sự, tốn tài nguyên. Task là abstraction cao hơn, nhiều Task chạy trên ít thread qua thread pool — nhẹ hơn và dễ compose hơn. -->

<!--# abstraction cao hơn nghĩa là gì? cho ví dụ phổ biến [id:2820 order:10]
là layer ẩn đi chi tiết của layer dưới, dev dùng API đơn giản hơn. Ví dụ: Task ẩn Thread, EF Core ẩn SQL, HttpClient ẩn TCP socket. -->

<!--# abstraction có những nghĩa nào? [id:2821 order:11]
- Trong code: che giấu chi tiết, phơi interface đơn giản (Task, ORM, HttpClient)
- Trong thiết kế: vẽ kiến trúc ở level cao, bỏ qua implementation detail
- Trong OOP: `abstract class`, `abstract method` — khai báo mà không implement -->

<!--# đơn vị OS là gì? [id:2822 order:12]
là tài nguyên thực do OS cấp phát và quản lý — process, thread, file handle, socket. -->

# abstraction nghĩa là gì? [id:2823 order:13]
là che giấu chi tiết phức tạp bên dưới, chỉ phơi ra interface đơn giản. Task abstract Thread, ORM abstract SQL.

# (task abstract thread) nghĩa là (Task là 1 abstract của thread) à ? [id:2824 order:14]
Đúng. Task là lớp abstraction nằm trên Thread — bạn xài Task, runtime tự lo phân Thread bên dưới.

# compose là gì? [id:2825 order:15]
là ghép nhiều thành phần nhỏ lại thành thành phần lớn hơn. Trong .NET, compose Task là chain `await` nhiều operation, hoặc dùng `Task.WhenAll`.

# Task<ResultOptions> Error(LogDto log); trong này Task có nghĩa gì? [id:2951 order:16]
nghĩa là method này async — trả về `Task<ResultOptions>` thay vì trả thẳng `ResultOptions`. Caller phải `await` để lấy giá trị thật.

<!--# result type Task có nghĩa là chưa có kq, đang đợi có phải không? [id:2952 order:17] -->

# khi nào dùng private? [id:2953 order:18]
khi member chỉ dùng nội bộ trong class.

# mặc định thì member là private hay public? [id:2954 order:19]

# các keyword ngược lại với private? [id:2955 order:20]

# string dạng này gọi là gì? $"{x}-abc"; [id:2956 order:21]
là string interpolation

# các keyword phổ biến trước 1 biến/hàm? [id:2957 order:22]
`public`, `private`, `protected`, `internal`
`static`, `readonly`, `const`, `virtual`, `override`, `abstract`, `sealed`
`async`, `await`, `volatile`
`ref`, `out`, `in`, `params`