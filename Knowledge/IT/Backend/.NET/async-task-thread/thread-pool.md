---
id: 350
name: "thread-pool"
---

# mỗi process có 1 thread pool phải không? [id:3367 order:1]
Đúng.
.NET runtime tạo 1 `ThreadPool` mặc định cho mỗi process — share cho tất cả Task, async/await, `Task.Run`.

# lí do thread pool tồn tại? [id:3087 order:2]
để tối ưu performance

# tại sao thread pool lại tối ưu performance? [id:3368 order:3]
Vì tái sử dụng thread thay vì tạo/hủy liên tục.
Thread đã tạo sẵn → nhận task xong rồi idle chờ task tiếp, không tốn chi phí khởi tạo OS thread mỗi lần.

# tạo 1 OS thread mới thì tốn gì? [id:3088 order:4]
~1ms và 1MB stack

# liên hệ giữa stack và pool.thread? [id:3089 order:5]
Mỗi pool thread có 1 stack riêng
(~1MB) cấp khi thread tạo ra.

# khi nào stack được reset? [id:3090 order:6]
khi 1 task kết thúc

# thread chạy 1 task tại 1 thời điểm à? [id:3091 order:7]
Đúng.
1 thread chỉ chạy 1 task tại 1 thời điểm — đó là bản chất của thread (đơn vị thực thi tuần tự). Muốn chạy nhiều task song song thì cần nhiều thread.

# pool.thread khác .NET Thread ở chỗ pool.thread luôn sống có phải không? [id:3092 order:8]
Đúng.
Pool thread sống suốt vòng đời process (idle thì sleep), nhận task khác sau khi xong.

# hoạt động của scheduler, queue, thread pool? [id:3093 order:9]
khi có thread rảnh, scheduler bốc task trong queue ra cho thread chạy

# scheduler, queue, thread pool đều thuộc runtime phải không? [id:3094 order:10]
Đúng.
Cả 3 đều là component của .NET runtime (CLR). Process khởi động → runtime tạo sẵn pool + scheduler + queue. App code chỉ submit task, không quản lý 3 cái đó.

# hầu hết mọi hoạt động trong .net đều dùng pool.thread phải không [id:3095 order:11]
đúng
`Task`, `async/await`, `Parallel.For`, ASP.NET request handler đều chạy trên pool. Chỉ khi `new Thread()` mới tạo thread riêng. Main thread của app cũng không thuộc pool.

# request thread được lấy từ đâu? [id:3369 order:12]
từ thread pool

# pool là gì? [id:3100 order:13]
Pool là tập hợp tài nguyên được tạo sẵn và tái sử dụng thay vì tạo/hủy mỗi lần.

# pool có phải là pattern không? [id:3370 order:14]
Có,
đây là pattern — "Object Pool Pattern". Ví dụ: thread pool, connection pool, memory pool.

# worker và thread là 1 à? [id:3101 order:15]
đúng
Trong context thread pool: worker = thread.
"Worker" nhấn mạnh vai trò (thread chuyên nhận task), còn "thread" là khái niệm kỹ thuật (đơn vị thực thi của OS).

# công việc của pool.thread chỉ là xử lí task từ queue phải không? [id:3102 order:16]
Đúng.
Pool thread khi tạo ra → vào loop: lấy task từ queue, chạy, xong rồi quay lại lấy task tiếp. Idle quá lâu thì OS đưa vào sleep. Không làm việc gì khác.

# 1 Thread trong thread pool có tương ứng với 1 OS thread không? [id:2902 order:17]
Có. Mỗi worker thread trong thread pool là 1 OS thread thật. Pool chỉ tái sử dụng — không tạo/dọn liên tục để tiết kiệm overhead.

# worker liên hệ gì với pool.thread? [id:3103 order:18]
chúng là 1

# khi nào pool.thread được dùng? [id:3371 order:19]
khi có request, hoặc gọi Task.Run() với CPU-bound work