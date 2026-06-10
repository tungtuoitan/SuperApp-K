# tại sao sync giữa markdown và db lại khó?
- vì markdown là dữ liệu k có cấu trúc, việc transfer dữ liệu k cùng cấu trúc sẽ có nhiều vấn đề
- có nhiều lỗi cú pháp do markdown được tạo ở vscode, ở đó ta k thể validate data được


# khi nào nên tách deamon thành service riêng, khi nào nên đặt nó nằm trong api server?
Quyết định dựa trên workload và lifecycle của daemon. Xem 2 câu dưới để chi tiết.

# khi nào nên tách deamon thành service riêng?
Khi đáp ứng ít nhất một trong các điều kiện:
- Workload nặng, làm chậm request thread của API
- Cần scale độc lập với API (chạy nhiều instance daemon mà không scale API)
- Cần deploy/restart riêng (sync lỗi không kéo theo restart cả API)
- Lifecycle khác API (chạy schedule dài, on-demand, hoặc cần CPU/RAM riêng)

# workload là gì?
Khối lượng công việc (CPU, RAM, IO) mà 1 process phải xử lý trong 1 đơn vị thời gian. Workload nặng = tốn nhiều tài nguyên hoặc kéo dài.

# workload có được đo bằng số không?
Có. Đo bằng các metric cụ thể: CPU usage (%), RAM (MB), số request/giây, số job/phút, latency trung bình (ms). Tool monitor như Prometheus, App Insights, Grafana track các con số này.

# đo api bằng tool monitor để cải thiện performance có phổ biến không?
Có. Đây là thực hành chuẩn — gọi là APM (Application Performance Monitoring). Hầu hết team backend production đều dùng để xác định bottleneck trước khi optimize.

# ta chỉ có thể phân phát tài nguyên cho process chứ k thể chia nhỏ hơn cho từng phần trong process được phải không?
Sai. OS cấp tài nguyên ở mức process, nhưng bên trong process có thể chia tiếp cho từng thread/task qua thread pool, semaphore, rate limiter. Code app tự kiểm soát phân chia bên trong.

# thread là gì?
là đơn vị thực thi nhỏ nhất mà OS lên lịch (schedule). Nhiều thread chạy song song trong cùng 1 process, chia sẻ memory space nhưng có stack riêng.

# đặc điểm của thread?
- Share memory với thread khác trong cùng process → giao tiếp nhanh nhưng dễ race condition
- Có stack riêng → mỗi thread theo dõi call stack của nó độc lập
- OS quản lý việc switch giữa các thread (context switch)
- Tốn tài nguyên hơn task vì OS phải track kernel object cho mỗi thread

# task là gì?
là đơn vị công việc bất đồng bộ ở tầng app, không nhất thiết gắn với 1 thread cố định. Trong .NET, `Task` đại diện cho 1 operation async có thể chạy trên thread pool.

# đặc điểm của task?
- Nhẹ hơn thread — nhiều task dùng chung ít thread qua thread pool
- Có thể await, chain (`.ContinueWith`), cancel qua `CancellationToken`
- Không tự chạy song song — song song hay không phụ thuộc vào thread pool và scheduler
- Dùng cho I/O-bound work: await giải phóng thread trong khi chờ I/O

# quan hệ giữa process, thread và task?
- Process chứa nhiều thread, có memory space riêng
- Thread là đơn vị OS thực sự chạy code
- Task là abstraction ở tầng app, được scheduler map lên thread khi cần chạy
Thứ tự từ lớn đến nhỏ: Process → Thread → Task.
# ví dụ các trường hợp cần scale deamon?
- Daemon consume message queue: traffic tăng đột biến, cần thêm worker để xử lý kịp
- Daemon xuất báo cáo / render PDF: nhiều user request song song, mỗi job nặng
- Daemon crawl / sync data từ nhiều nguồn: cần chia shard để chạy song song

# ví dụ trường hợp việc giữ cho api hoạt động liên tục là quan trọng?
- API serve websocket / streaming: restart làm rớt kết nối, client phải reconnect
- API có warmup cache lâu: restart gây cold start, request đầu chậm vài giây
- API serve traffic cao: mỗi lần restart đều có khoảng downtime ngắn ảnh hưởng SLA

# warmup cache là gì?
là quá trình app load sẵn dữ liệu hay dùng vào RAM trước khi serve request, để request đầu không phải query DB/API chậm. Ví dụ: load full bảng config, build index in-memory.

# cold start là gì?
là trạng thái app vừa khởi động, chưa có cache, chưa JIT compile, chưa pool connection — request đầu chậm hơn bình thường vài lần. Sau vài request, app "warm" lên thì tốc độ ổn định.

# downtime là gì?
là khoảng thời gian app không phục vụ được request, tính từ lúc start restart đến lúc sẵn sàng nhận traffic lại. Downtime gồm thời gian shutdown + startup + warmup.

# SLA là gì?
Service Level Agreement — cam kết về mức dịch vụ, thường tính uptime (vd 99.9%/năm). Mỗi 0.1% downtime tương đương ~8.7 giờ/năm — rất ít, nên mỗi lần restart đều phải tính.

# deamon on-demand là gì, cho ví dụ?
Daemon chỉ chạy khi có trigger sự kiện, xong thì idle hoặc tắt — không chạy liên tục theo schedule. Ví dụ: daemon export Excel khởi chạy khi user click nút export, hoàn tất thì kết thúc.

# deamon k phải chạy liên tục à, có thể dùng trigger à?
Đúng. Daemon truyền thống chạy liên tục để chờ event, nhưng kiểu on-demand thì khởi tạo theo trigger và tắt sau khi xong. Cả hai đều là daemon vì chạy ngầm, không có UI.

# nếu vậy thì deamon khác job thế nào?
Daemon là process chạy nền, là chủ thể thực thi. Job là đơn vị công việc rời rạc, là cái được thực thi. Một daemon có thể chạy nhiều job khác nhau theo thời gian.

# job tương ứng với function, còn deamon tương ứng với host phải không?
Đúng theo analogy. Job là đơn vị thực thi (như function được gọi), daemon là môi trường giữ runtime để gọi job đó (như host nuôi function).

# analogy là gì?
Phép so sánh tương tự — dùng cấu trúc của thứ A đã quen để giải thích thứ B mới. Không phải A và B giống hệt, chỉ giống về quan hệ.

# deamon tương tự program.cs, startup.cs phải không?
Đúng phần bootstrap. `program.cs` / `startup.cs` là code khởi tạo daemon (host) — chúng định nghĩa cách daemon chạy và quản lý job. Bản thân daemon là process đang chạy sau khi `program.cs` đã run xong.

# bootstrap là gì?
Code chạy đầu tiên khi app khởi động, lo phần setup: load config, register dependency, mở kết nối, build host. Sau khi bootstrap xong, app mới sẵn sàng nhận request hoặc chạy job.

# vậy trên Azure, azure có deamon lắng nge event theo thời gian, ta chỉ việc tạo job thôi phải không?
Đúng. Azure Functions, Logic Apps, WebJobs hoạt động theo model này — Azure quản daemon (host process lắng nghe trigger HTTP, queue, timer, blob...), user chỉ viết function/workflow. Đây là bản chất của serverless.

# host là gì?
Process/môi trường runtime nuôi và quản lý lifecycle của các thành phần con (DI container, config, logging, scheduled task). Trong .NET, `IHost` là object chứa toàn bộ app — start nó là start daemon.

# vậy host là process à ? hay nó chỉ là 1 class?
Cả hai. `IHost` về bản chất là 1 class trong .NET, nhưng khi gọi `host.Run()` thì class này điều khiển toàn bộ process — nó định nghĩa process làm gì. Nói "host là process" theo nghĩa logic; nói "host là class" theo nghĩa code.

# runtime là gì?
Lớp execution engine chạy code của ngôn ngữ — cung cấp GC, JIT, type system, threading. Ví dụ CLR cho .NET, JVM cho Java, V8 cho JavaScript. Code không tự chạy được; phải có runtime dịch và thực thi.

# phân biệt host, process, runtime?
- Process: đơn vị OS cấp, có PID và memory space riêng
- Runtime: engine bên trong process, dịch và chạy code (CLR, JVM)
- Host: lớp app cấp, orchestrate các service/component bên trong runtime (IHost trong .NET)
Layer xếp từ ngoài vào: OS → Process → Runtime → Host → App code.
# nếu deamon nằm trong api server thì nó và service được gắn vào chung 1 host, còn nếu deamon viết riêng thì nó sẽ là 1 app riêng và có lớp Host bên trong phải không?
Đúng. Cùng host = cùng process, share DI/config. Tách riêng = mỗi app có host riêng, process riêng, config riêng — giao tiếp qua DB hoặc message queue.

# memory space là gì?
Vùng RAM mà OS cấp cho 1 process, các process khác không đọc/ghi trực tiếp được. Mỗi process có address space riêng — biến trong process A không nhìn thấy được từ process B.

# tài nguyên của process chỉ gồm RAM và CPU à?
Không. Còn: file handle (số file mở cùng lúc), socket/network connection, thread, GPU, disk IO bandwidth. OS quản hết các loại này, mỗi loại đều có thể bị cap.

# serverless là gì?
Mô hình mà cloud provider quản hết server và daemon, dev chỉ viết function. Không phải "không có server" mà là "dev không thấy server" — provider auto scale, auto restart, auto bill theo lượt invoke.

# invoke là gì?
Lượt gọi function. Mỗi HTTP request, mỗi message từ queue, mỗi lần timer tick đều là 1 invoke. Serverless tính tiền theo số invoke và thời gian mỗi invoke chạy.

# cần cpu/ram riêng có nghĩa là gì?
Daemon chiếm tài nguyên đủ lớn để ảnh hưởng tới process khác cùng máy. Ví dụ daemon chạy ML inference ngốn 100% CPU sẽ làm API cùng process chậm theo. Tách ra cho mỗi cái có ngân sách riêng.

# mặc định tài nguyên cấp cho 1 process là k giới hạn phải không?
Đúng. OS không cap CPU/RAM cho 1 process trừ khi có cấu hình (cgroup, container limit, job object). Mặc định các process cạnh tranh tài nguyên với nhau — process nào ngốn nhiều thì process khác bị chậm.

# khi nào nên để deamon nằm trong api server?
Khi workload nhẹ, chạy ngắn, không block request thread. Dùng background service trong cùng process là đủ — share config, share DI, deploy 1 lần.

# nếu daemon chạy trong api server thì khi api restart, daemon có mất state không?
Có. Daemon chạy trong cùng process với API — restart API là restart luôn daemon. Nếu daemon đang giữa chừng task, task đó bị huỷ.

# làm sao để daemon trong api server không mất tiến độ khi restart?
Persist tiến độ ra ngoài (DB, file, cache) và resume khi daemon khởi động lại. Không lưu state quan trọng trong memory của daemon.
