---
id: 348
name: "task"
---

# Task type liên quan gì đến async? [id:2815 order:1]
`async` method trong C# trả về Task.

# task.run giống gì trong js? [id:3346 order:2]
Gần giống `Promise`
kết hợp với offload sang Web Worker. JS không có thread pool sẵn nên không có analog 1-1 — `setTimeout(fn, 0)` chỉ defer chứ không chạy thread khác.

# ví dụ CPU-bound work phổ biến? [id:3348 order:3]
encrypt/hash password, parse JSON lớn, xử lý ảnh, compress file, tính toán ML.

# khi có Task.Run, chuyện gì xảy ra? [id:3349 order:4]
Runtime lấy 1 pool thread, schedule lambda lên thread đó,
trả về `Task` ngay lập tức.
nếu có await thì giải phóng main thread, nếu k thì main thread chạy tiếp

# task.run tạo Task mới à? [id:3352 order:5]
Đúng.

`Task.Run(...)` tạo 1 Task mới, schedule nó lên thread pool và return Task object để caller có thể await

# Task liên hệ gì với thread pool? [id:2904 order:6]
Task mặc định schedule lên thread pool — `Task.Run(() => ...)` lấy 1 worker thread từ pool để chạy. Task không tự sở hữu thread riêng.

# hàm async luôn tạo ra Task mới à? [id:3353 order:7]
Đúng.
Compiler tự wrap body hàm `async` thành state machine và return về `Task`/`Task<T>`. Caller dùng task đó để await hoặc chờ kết quả.

# khi nào Task được tạo ra? [id:3354 order:8]
- Gọi `async` method
- Gọi `Task.Run(...)`
- Gọi I/O async (`File.ReadAllTextAsync`, `HttpClient.GetAsync`)

# mỗi request đến server tương ứng 1 Task à? tại sao? [id:3355 order:9]
đúng. Vì pipeline ASP.NET Core là async
<!-- — mỗi request được handler dispatch dưới dạng `async Task HandleRequest()`. Compiler bọc body thành Task để runtime resume khi I/O hoàn tất, không phải dedicate 1 thread suốt request. -->

# Task của await IO có đi vào queue không? [id:3356 order:10]
không.
Task ở đây là "phiếu chờ" — compiler tạo ra để caller có thể await. Phần thực thi thật sự do kernel xử lý qua IOCP/epoll, không có thread nào ngồi chờ trong queue.

# I/O có tạo task không? [id:3357 order:11]
Có
`File.ReadAllTextAsync` trả về 1 `Task<string>`, nhưng task này KHÔNG chiếm thread — nó chỉ là cái "phiếu chờ" runtime tạo ra. Khi kernel báo I/O xong, runtime mới complete task và resume code sau await.

# I/O Task có tốn thread không? [id:3358 order:12]
Không.
I/O Task chỉ là "phiếu chờ", kernel xử lý ngầm. Thread được trả về pool ngay khi gặp `await`, không bị giữ trong khi chờ I/O.

# mọi I/O đều tạo ra Task nhưng k tốn thread phải không? [id:3359 order:13]
Đúng
Task chỉ là "phiếu chờ", kernel + driver xử lý ngầm bằng IOCP/epoll. I/O sync (vd `File.ReadAllText`) thì khác — block thread cho tới khi xong, không tạo task.

# IO Task có đi vào queue không? [id:3137 order:14]
không
OS xử lý I/O ngay và không bỏ vào queue chờ.

# những task nào mà pool.thread k xử lí? [id:3139 order:15]
I/O-bound task:
HTTP call, file read/write, DB query. Những task này dùng I/O completion port của OS — không cần thread pool thread ngồi chờ, thread được trả về ngay khi đang chờ I/O.

<!--# khi gặp I/O bound task thì diễn biến thế nào? [id:3135 order:16]
khi method `await` 1 I/O operation, thread đang chạy được trả về thread pool. OS dùng I/O completion port để chờ kết quả. Khi I/O xong, runtime lấy 1 thread bất kỳ từ pool để continue method. -->

<!--# thread A chạy hàm a, trong a có await Task b thì b được chạy bởi thread nào? [id:3360 order:17]
Tùy task b.
Nếu b là `Task.Run(...)` → 1 pool thread khác (không phải A). Nếu b là I/O async (`HttpGet`, `DbQuery`) → không thread nào chạy cả, chỉ kernel I/O xử lý; khi xong, runtime mới lấy 1 pool thread (có thể chính là A) để resume hàm a sau `await`. -->