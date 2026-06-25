---
id: 0
name: "thread-pool"
---

# mỗi process có 1 thread pool phải không? [id:2899 order:16]
Đúng.
.NET runtime tạo 1 `ThreadPool` mặc định cho mỗi process — share cho tất cả Task, async/await, `Task.Run`.

# lí do thread pool tồn tại? [id:3087 order:26]
để tối ưu performance

# tại sao thread pool lại tối ưu performance?
Vì tái sử dụng thread thay vì tạo/hủy liên tục.
Thread đã tạo sẵn → nhận task xong rồi idle chờ task tiếp, không tốn chi phí khởi tạo OS thread mỗi lần.

# tạo 1 OS thread mới thì tốn gì? [id:3088 order:27]
~1ms và 1MB stack

# liên hệ giữa stack và pool.thread? [id:3089 order:28]
Mỗi pool thread có 1 stack riêng
(~1MB) cấp khi thread tạo ra.

# khi nào stack được reset? [id:3090 order:29]
khi 1 task kết thúc

# thread chạy 1 task tại 1 thời điểm à? [id:3091 order:30]
Đúng.
1 thread chỉ chạy 1 task tại 1 thời điểm — đó là bản chất của thread (đơn vị thực thi tuần tự). Muốn chạy nhiều task song song thì cần nhiều thread.

# pool.thread khác .NET Thread ở chỗ pool.thread luôn sống có phải không? [id:3092 order:31]
Đúng.
Pool thread sống suốt vòng đời process (idle thì sleep), nhận task khác sau khi xong.

# hoạt động của scheduler, queue, thread pool? [id:3093 order:33]
khi có thread rảnh, scheduler bốc task trong queue ra cho thread chạy

# scheduler, queue, thread pool đều thuộc runtime phải không? [id:3094 order:34]
Đúng.
Cả 3 đều là component của .NET runtime (CLR). Process khởi động → runtime tạo sẵn pool + scheduler + queue. App code chỉ submit task, không quản lý 3 cái đó.

# hầu hết mọi hoạt động trong .net đều dùng pool.thread phải không [id:3095 order:35]
đúng
`Task`, `async/await`, `Parallel.For`, ASP.NET request handler đều chạy trên pool. Chỉ khi `new Thread()` mới tạo thread riêng. Main thread của app cũng không thuộc pool.

# request thread chính là thread trong pool phải không?
Đúng trong ASP.NET Core.
Kestrel nhận request → đẩy vào thread pool, 1 pool thread bốc lên chạy handler. Không có pool riêng cho request — chung pool với mọi Task khác.

# pool là gì? [id:3100 order:40]
Pool là tập hợp tài nguyên được tạo sẵn và tái sử dụng thay vì tạo/hủy mỗi lần.

# pool có phải là pattern không?
Có,
đây là pattern — "Object Pool Pattern". Ví dụ: thread pool, connection pool, memory pool.

# worker và thread là 1 à? [id:3101 order:41]
đúng
Trong context thread pool: worker = thread.
"Worker" nhấn mạnh vai trò (thread chuyên nhận task), còn "thread" là khái niệm kỹ thuật (đơn vị thực thi của OS).

# công việc của pool.thread chỉ là xử lí task từ queue phải không? [id:3102 order:42]
Đúng.
Pool thread khi tạo ra → vào loop: lấy task từ queue, chạy, xong rồi quay lại lấy task tiếp. Idle quá lâu thì OS đưa vào sleep. Không làm việc gì khác.

# 1 Thread trong thread pool có tương ứng với 1 OS thread không? [id:2902 order:25]
Có. Mỗi worker thread trong thread pool là 1 OS thread thật. Pool chỉ tái sử dụng — không tạo/dọn liên tục để tiết kiệm overhead.

# worker liên hệ gì với pool.thread? [id:3103 order:49]
chúng là 1

# khi nào pool.thread được dùng?
khi gọi `Task.Run`, `await`, ...
