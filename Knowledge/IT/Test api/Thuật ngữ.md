---
id: 51
name: "Thuật ngữ"
---

# Throughput là gì? [id:402 order:1]
Số request BE xử lý xong mỗi giây (req/s).

# Baseline là gì? [id:403 order:2]
Số đo mốc từ 1 lần test cụ thể, dùng để so sánh các lần test sau — biết performance lên hay xuống.

# Outlier là gì? [id:404 order:3]
1 request lẻ chậm bất thường so với phần còn lại.

# Khi nào outlier đáng quan tâm? [id:405 order:4]
Khi có pattern — ví dụ 100 outliers 5s mỗi giờ. 1 outlier đơn lẻ trong 83k request thì bỏ qua.

# GC pause là gì? [id:406 order:5]
.NET định kỳ dọn memory, tạm "đông" thread vài chục ms — request rơi đúng lúc đó sẽ chậm bất thường.

# GC pause thường kéo dài bao lâu? [id:407 order:6]
10–100ms với .NET 8 server GC. Chỉ lo nếu pause vài giây liên tục.
<!--# Cold start cache miss là gì? [id:408 order:7]
Lần đầu cache chưa có data, phải query DB rồi mới populate — request đó chậm hơn bình thường. -->
# cold start cache miss là 1 câu, hay là động từ, hay danh từ vậy?
# cold start thì cache miss phải không?
# cold start là start lần đầu phải không?
# Tại sao p99 thường cao hơn p95 trong sticky test? [id:409 order:8]

# cache warm là gì?