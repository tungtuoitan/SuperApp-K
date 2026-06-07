---
id: 293
name: "Thuật ngữ"
---

# Throughput là gì? [id:2556 order:1]
Số request BE xử lý xong mỗi giây (req/s).

# Baseline là gì? [id:2557 order:2]
Số đo mốc từ 1 lần test cụ thể, dùng để so sánh các lần test sau — biết performance lên hay xuống.

# Outlier là gì? [id:2558 order:3]
1 request lẻ chậm bất thường so với phần còn lại.

# Khi nào outlier đáng quan tâm? [id:2559 order:4]
Khi có pattern — ví dụ 100 outliers 5s mỗi giờ. 1 outlier đơn lẻ trong 83k request thì bỏ qua.

# GC pause là gì? [id:2560 order:5]
.NET định kỳ dọn memory, tạm "đông" thread vài chục ms — request rơi đúng lúc đó sẽ chậm bất thường.

# GC pause thường kéo dài bao lâu? [id:2561 order:6]
10–100ms với .NET 8 server GC. Chỉ lo nếu pause vài giây liên tục.

# Cold start cache miss là gì? [id:2562 order:7]
Lần đầu cache chưa có data, phải query DB rồi mới populate — request đó chậm hơn bình thường.

<!--# Tại sao p99 thường cao hơn p95 trong sticky test? [id:2563 order:8]
Vì 1000 VU × 1 cold start mỗi VU = 1000 cache miss trong ramp-up, tạo tail latency. -->

<!--# Sau khi cache warm thì cold start còn ảnh hưởng không? [id:2564 order:9]
Không — tất cả VU loop trên ws đã cache, chỉ hit memory → p95 = 1ms. -->