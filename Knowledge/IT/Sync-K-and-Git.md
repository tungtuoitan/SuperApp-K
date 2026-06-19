---
id: 310
name: "Sync-K-and-Git"
---

# tại sao sync giữa markdown và db lại khó? [id:2667 order:1]
- vì markdown là dữ liệu k có cấu trúc, việc transfer dữ liệu k cùng cấu trúc sẽ có nhiều vấn đề
- có nhiều lỗi cú pháp do markdown được tạo ở vscode, ở đó ta k thể validate data được

# khi nào nên tách deamon thành service riêng? [id:2669 order:3]
 - khi nó ảnh hưởng api server

# workload là gì? [id:2670 order:4]
Khối lượng công việc (CPU, RAM, IO) mà 1 process phải xử lý trong 1 đơn vị thời gian. Workload nặng = tốn nhiều tài nguyên hoặc kéo dài.

# ví dụ các trường hợp cần scale deamon? [id:2671 order:5]
- Daemon consume message queue: traffic tăng đột biến, cần thêm worker để xử lý kịp
- Daemon xuất báo cáo / render PDF: nhiều user request song song, mỗi job nặng
- Daemon crawl / sync data từ nhiều nguồn: cần chia shard để chạy song song

# ví dụ trường hợp việc giữ cho api hoạt động liên tục là quan trọng? [id:2672 order:6]
- streaming video, download file nặng

# deamon on-demand là gì, cho ví dụ? [id:2673 order:7]
Daemon chỉ chạy khi có trigger sự kiện, xong thì idle hoặc tắt — không chạy liên tục theo schedule. Ví dụ: daemon export Excel khởi chạy khi user click nút export, hoàn tất thì kết thúc.

# deamon k phải chạy liên tục à, có thể dùng trigger à? [id:2674 order:8]
Đúng. Daemon truyền thống chạy liên tục để chờ event, nhưng kiểu on-demand thì khởi tạo theo trigger và tắt sau khi xong. Cả hai đều là daemon vì chạy ngầm, không có UI.

<!--# nếu vậy thì deamon khác job thế nào? [id:2675 order:9]
Daemon là process chạy nền, là chủ thể thực thi. Job là đơn vị công việc rời rạc, là cái được thực thi. Một daemon có thể chạy nhiều job khác nhau theo thời gian. -->
# deamon là gì?
-Daemon là process chạy nền, giữ runtime — chủ thể thực thi (như host nuôi function). 
# job là gì?
Job là đơn vị công việc rời rạc — cái được thực thi (như function được gọi). 

# quan hệ deamon và job?
deamon quản lí và thực thi job

# deamon có thể chạy chung với api server không?
Có. 
Đó là kiểu hosted background service — daemon chạy chung process với API server (`IHostedService` trong .NET), share memory và DI container.

# azure webjob có phải là job không? nếu k thì nó là gì?
không, nó là deamon
Đúng kiểu Azure gọi nó là "job", nhưng về bản chất WebJob là 1 daemon — 1 process chạy nền liên tục (continuous) hoặc theo trigger (manual/scheduled). Tên "job" gây nhầm với "đơn vị công việc".
# azure webjob có thể chạy độc lập k cần azure phải không?
đúng. 
WebJob bản chất là 1 .NET console app — chạy được ở bất kỳ máy nào có .NET runtime. Azure chỉ cung cấp môi trường host (App Service) + tooling (deploy, log, scheduler).

# analogy là gì? [id:2677 order:11]
Phép so sánh tương tự — dùng cấu trúc của thứ A đã quen để giải thích thứ B mới. Không phải A và B giống hệt, chỉ giống về quan hệ.

# bootstrap là gì? [id:2679 order:13]
Code chạy đầu tiên khi app khởi động, lo phần setup: load config, register dependency, mở kết nối, build host. Sau khi bootstrap xong, app mới sẵn sàng nhận request hoặc chạy job.


# Các ý nghĩa của host? [id:2681 order:15]
là máy chủ
tên miền
ip

# runtime là gì? [id:2682 order:16]
Lớp execution engine chạy code của ngôn ngữ — cung cấp GC, JIT, type system, threading. Ví dụ CLR cho .NET, JVM cho Java, V8 cho JavaScript. Code không tự chạy được; phải có runtime dịch và thực thi.

# phân biệt host, process, runtime? [id:2683 order:17]
- Process: đơn vị OS cấp, có PID và memory space riêng
- Runtime: engine bên trong process, dịch và chạy code (CLR, JVM)
- Host: lớp app cấp, orchestrate các service/component bên trong runtime (IHost trong .NET)
Layer xếp từ ngoài vào: OS → Process → Runtime → Host → App code.


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