<!-- # async/await trong .NET là gì?
là cú pháp để viết code bất đồng bộ dạng tuần tự. `await` tạm ngưng method, giải phóng thread, tiếp tục khi operation hoàn thành. -->

# khi nào nên dùng async/await?
Khi method có I/O (DB query, HTTP call, file). Không nên dùng cho CPU-bound work — sẽ không có lợi.

# cứ có IO là luôn nên dùng await phải không?
Gần như đúng cho server-side. IO async giúp thread không bị block, server xử lý được nhiều request đồng thời. Trừ trường hợp IO rất ngắn hoặc app tool một thread.

# lợi ích của async khi dùng cho IO?
Thread không bị block khi chờ IO → trả về thread pool để xử lý request khác. Server cùng số thread phục vụ được nhiều request hơn → throughput cao.

# khi nào nên dùng Task?
Khi cần chạy work đồng thời/bất đồng bộ — IO async, parallel processing, hoặc compose nhiều operation. Mặc định nên dùng Task thay vì Thread.

# Task liên quan gì đến async?
`async` method trong C# trả về Task. Task đại diện cho công việc đang/sẽ hoàn thành — `await` task để chờ kết quả mà không block thread.

# khi nào nên dùng Thread?
Hiếm khi. Chỉ khi cần kiểm soát thấp như set priority, dùng `ThreadStatic`, hoặc tích hợp legacy API. Còn lại dùng Task.

# CPU-bound work là gì?
là công việc tốn CPU để tính toán — encrypt, parse, image processing, machine learning. Đối ngược với IO-bound (chờ DB/network/file).

# bound nghĩa là gì?
là "bị giới hạn bởi". CPU-bound = bị giới hạn bởi tốc độ CPU; IO-bound = bị giới hạn bởi tốc độ IO (DB, network, disk).

# Task và Thread khác nhau thế nào?
Thread là đơn vị OS thực sự, tốn tài nguyên. Task là abstraction cao hơn, nhiều Task chạy trên ít thread qua thread pool — nhẹ hơn và dễ compose hơn.

# abstraction cao hơn nghĩa là gì? cho ví dụ phổ biến
là layer ẩn đi chi tiết của layer dưới, dev dùng API đơn giản hơn. Ví dụ: Task ẩn Thread, EF Core ẩn SQL, HttpClient ẩn TCP socket.

# abstraction có những nghĩa nào?
- Trong code: che giấu chi tiết, phơi interface đơn giản (Task, ORM, HttpClient)
- Trong thiết kế: vẽ kiến trúc ở level cao, bỏ qua implementation detail
- Trong OOP: `abstract class`, `abstract method` — khai báo mà không implement

# đơn vị OS là gì?
là tài nguyên thực do OS cấp phát và quản lý — process, thread, file handle, socket.

# abstraction nghĩa là gì?
là che giấu chi tiết phức tạp bên dưới, chỉ phơi ra interface đơn giản. Task abstract Thread, ORM abstract SQL.

# (task abstract thread) nghĩa là (Task là 1 abstract của thread) à ?
Đúng. Task là lớp abstraction nằm trên Thread — bạn xài Task, runtime tự lo phân Thread bên dưới.

# compose là gì?
là ghép nhiều thành phần nhỏ lại thành thành phần lớn hơn. Trong .NET, compose Task là chain `await` nhiều operation, hoặc dùng `Task.WhenAll`.
