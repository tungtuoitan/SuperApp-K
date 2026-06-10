---
id: 310
name: "Sync-K-and-Git"
---

# tại sao sync giữa markdown và db lại khó? [id:2667 order:1]
- vì markdown là dữ liệu k có cấu trúc, việc transfer dữ liệu k cùng cấu trúc sẽ có nhiều vấn đề
- có nhiều lỗi cú pháp do markdown được tạo ở vscode, ở đó ta k thể validate data được

# khi nào nên tách deamon thành service riêng, khi nào nên đặt nó nằm trong api server? [id:2668 order:2]
Quyết định dựa trên workload và lifecycle của daemon. Xem 2 câu dưới để chi tiết.

# khi nào nên tách deamon thành service riêng? [id:2669 order:3]
Khi đáp ứng ít nhất một trong các điều kiện:
- Workload nặng, làm chậm request thread của API
- Cần scale độc lập với API (chạy nhiều instance daemon mà không scale API)
- Cần deploy/restart riêng (sync lỗi không kéo theo restart cả API)
- Lifecycle khác API (chạy schedule dài, on-demand, hoặc cần CPU/RAM riêng)

# workload là gì? [id:2670 order:4]
Khối lượng công việc (CPU, RAM, IO) mà 1 process phải xử lý trong 1 đơn vị thời gian. Workload nặng = tốn nhiều tài nguyên hoặc kéo dài.

# ví dụ các trường hợp cần scale deamon? [id:2671 order:5]
- Daemon consume message queue: traffic tăng đột biến, cần thêm worker để xử lý kịp
- Daemon xuất báo cáo / render PDF: nhiều user request song song, mỗi job nặng
- Daemon crawl / sync data từ nhiều nguồn: cần chia shard để chạy song song

<!--# ví dụ trường hợp việc giữ cho api hoạt động liên tục là quan trọng? [id:2672 order:6]
- API serve websocket / streaming: restart làm rớt kết nối, client phải reconnect
- API có warmup cache lâu: restart gây cold start, request đầu chậm vài giây
- API serve traffic cao: mỗi lần restart đều có khoảng downtime ngắn ảnh hưởng SLA -->

# deamon on-demand là gì, cho ví dụ? [id:2673 order:7]
Daemon chỉ chạy khi có trigger sự kiện, xong thì idle hoặc tắt — không chạy liên tục theo schedule. Ví dụ: daemon export Excel khởi chạy khi user click nút export, hoàn tất thì kết thúc.

# deamon k phải chạy liên tục à, có thể dùng trigger à? [id:2674 order:8]
Đúng. Daemon truyền thống chạy liên tục để chờ event, nhưng kiểu on-demand thì khởi tạo theo trigger và tắt sau khi xong. Cả hai đều là daemon vì chạy ngầm, không có UI.

# nếu vậy thì deamon khác job thế nào? [id:2675 order:9]
Daemon là process chạy nền, là chủ thể thực thi. Job là đơn vị công việc rời rạc, là cái được thực thi. Một daemon có thể chạy nhiều job khác nhau theo thời gian.

# job tương ứng với function, còn deamon tương ứng với host phải không? [id:2676 order:10]
Đúng theo analogy. Job là đơn vị thực thi (như function được gọi), daemon là môi trường giữ runtime để gọi job đó (như host nuôi function).

# analogy là gì? [id:2677 order:11]
Phép so sánh tương tự — dùng cấu trúc của thứ A đã quen để giải thích thứ B mới. Không phải A và B giống hệt, chỉ giống về quan hệ.

# deamon tương tự program.cs, startup.cs phải không? [id:2678 order:12]
Đúng phần bootstrap. `program.cs` / `startup.cs` là code khởi tạo daemon (host) — chúng định nghĩa cách daemon chạy và quản lý job. Bản thân daemon là process đang chạy sau khi `program.cs` đã run xong.

# bootstrap là gì? [id:2679 order:13]
Code chạy đầu tiên khi app khởi động, lo phần setup: load config, register dependency, mở kết nối, build host. Sau khi bootstrap xong, app mới sẵn sàng nhận request hoặc chạy job.

# vậy trên Azure, azure có deamon lắng nge event theo thời gian, ta chỉ việc tạo job thôi phải không? [id:2680 order:14]
Đúng. Azure Functions, Logic Apps, WebJobs hoạt động theo model này — Azure quản daemon (host process lắng nghe trigger HTTP, queue, timer, blob...), user chỉ viết function/workflow. Đây là bản chất của serverless.

<!--# host là gì? [id:2681 order:15]
Process/môi trường runtime nuôi và quản lý lifecycle của các thành phần con (DI container, config, logging, scheduled task). Trong .NET, `IHost` là object chứa toàn bộ app — start nó là start daemon. -->

# runtime là gì? [id:2682 order:16]
Lớp execution engine chạy code của ngôn ngữ — cung cấp GC, JIT, type system, threading. Ví dụ CLR cho .NET, JVM cho Java, V8 cho JavaScript. Code không tự chạy được; phải có runtime dịch và thực thi.

# phân biệt host, process, runtime? [id:2683 order:17]
- Process: đơn vị OS cấp, có PID và memory space riêng
- Runtime: engine bên trong process, dịch và chạy code (CLR, JVM)
- Host: lớp app cấp, orchestrate các service/component bên trong runtime (IHost trong .NET)
Layer xếp từ ngoài vào: OS → Process → Runtime → Host → App code.

# serverless là gì? [id:2684 order:18]
Mô hình mà cloud provider quản hết server và daemon, dev chỉ viết function. Không phải "không có server" mà là "dev không thấy server" — provider auto scale, auto restart, auto bill theo lượt invoke.

# cần cpu/ram riêng có nghĩa là gì? [id:2685 order:19]
Daemon chiếm tài nguyên đủ lớn để ảnh hưởng tới process khác cùng máy. Ví dụ daemon chạy ML inference ngốn 100% CPU sẽ làm API cùng process chậm theo. Tách ra cho mỗi cái có ngân sách riêng.

# mặc định tài nguyên cấp cho 1 process là k giới hạn phải không? [id:2686 order:20]
Đúng. OS không cap CPU/RAM cho 1 process trừ khi có cấu hình (cgroup, container limit, job object). Mặc định các process cạnh tranh tài nguyên với nhau — process nào ngốn nhiều thì process khác bị chậm.

# khi nào nên để deamon nằm trong api server? [id:2687 order:21]
Khi workload nhẹ, chạy ngắn, không block request thread. Dùng background service trong cùng process là đủ — share config, share DI, deploy 1 lần.

# nếu daemon chạy trong api server thì khi api restart, daemon có mất state không? [id:2688 order:22]
Có. Daemon chạy trong cùng process với API — restart API là restart luôn daemon. Nếu daemon đang giữa chừng task, task đó bị huỷ.

# làm sao để daemon trong api server không mất tiến độ khi restart? [id:2689 order:23]
Persist tiến độ ra ngoài (DB, file, cache) và resume khi daemon khởi động lại. Không lưu state quan trọng trong memory của daemon.