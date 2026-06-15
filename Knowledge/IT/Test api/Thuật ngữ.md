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

# cold start cache miss là 1 câu, hay là động từ, hay danh từ vậy? [id:2945 order:8]
là cụm danh từ ghép — mô tả tình huống "lần khởi động đầu mà cache chưa có data". Không phải câu, không phải động từ.

# cold start thì cache miss phải không? [id:2946 order:9]
Đúng. Cold start = lần đầu chạy, cache trống → request đầu tiên buộc phải miss và đi xuống DB.

# cold start là start lần đầu phải không? [id:2947 order:10]
Đúng. Là lần khởi động đầu tiên (hoặc sau khi restart) khi mọi thứ chưa "ấm" — cache rỗng, JIT chưa compile, connection pool chưa tạo.

# Tại sao p99 thường cao hơn p95 trong sticky test? [id:409 order:11]
Vì p99 là 1% chậm nhất, p95 là 5% chậm nhất — p99 lấy từ phần đuôi xa hơn, nên giá trị lớn hơn. Trong sticky test, các request 1% chậm nhất thường rơi vào GC pause, cache miss, hoặc network jitter.

# p99 nghĩa là gì? [id:2948 order:12]
là response time tại vị trí 99% (p99)

# cách tính p99? [id:2949 order:13]
1. Sắp xếp tất cả response time tăng dần
2. lấy vị trí tương ứng với 99%
3. Giá trị tại vị trí đó là p99
Ví dụ: 1000 request → p99 là response time của request thứ 990 (sau khi sort).

# cache warm là gì? [id:2950 order:14]
là trạng thái cache đã có sẵn data — request tới sẽ hit cache, không phải đi DB. Đối lập với cold (cache rỗng).