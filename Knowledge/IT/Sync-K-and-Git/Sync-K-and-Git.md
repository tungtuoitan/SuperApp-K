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

# ví dụ các trường hợp cần scale deamon?
- Daemon consume message queue: traffic tăng đột biến, cần thêm worker để xử lý kịp
- Daemon xuất báo cáo / render PDF: nhiều user request song song, mỗi job nặng
- Daemon crawl / sync data từ nhiều nguồn: cần chia shard để chạy song song

# ví dụ trường hợp việc giữ cho api hoạt động liên tục là quan trọng?
- API serve websocket / streaming: restart làm rớt kết nối, client phải reconnect
- API có warmup cache lâu: restart gây cold start, request đầu chậm vài giây
- API serve traffic cao: mỗi lần restart đều có khoảng downtime ngắn ảnh hưởng SLA

# deamon on-demand là gì, cho ví dụ?
Daemon chỉ chạy khi có trigger sự kiện, xong thì idle hoặc tắt — không chạy liên tục theo schedule. Ví dụ: daemon export Excel khởi chạy khi user click nút export, hoàn tất thì kết thúc.

# deamon k phải chạy liên tục à, có thể dùng trigger à?
Đúng. Daemon truyền thống chạy liên tục để chờ event, nhưng kiểu on-demand thì khởi tạo theo trigger và tắt sau khi xong. Cả hai đều là daemon vì chạy ngầm, không có UI.

# nếu vậy thì deamon khác job thế nào?
Daemon là process chạy nền, là chủ thể thực thi. Job là đơn vị công việc rời rạc, là cái được thực thi. Một daemon có thể chạy nhiều job khác nhau theo thời gian.

# job tương ứng với function, còn deamon tương ứng với host phải không?
# job tương tự program.cs, startup.cs phải không?
# vậy trên Azure, azure có deamon lắng nge event theo thời gian, ta chỉ việc tạo job thôi phải không?
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
