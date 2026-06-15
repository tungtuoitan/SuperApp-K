---
id: 313
name: "aspnet-core"
---

# ASP.NET Core là gì? [id:2739 order:1]
là web framework chính của .NET, dùng để build API, web app, real-time app.

# ASP.NET Core là HTTP Framework không? [id:2740 order:2]
Có. HTTP Framework là framework dùng để build web server/API — ASP.NET Core đúng định nghĩa này.

# HTTP Framework là gì? [id:2741 order:3]
là framework dùng để build web server và API — xử lý HTTP request/response.

# HTTP Server là gì? [id:2742 order:4]
là phần mềm nhận kết nối mạng và xử lý giao thức HTTP.

# HTTP Server và Web Server khác nhau không? [id:2743 order:5]
Gần như giống nhau. Web server ám chỉ server xử lý request từ browser (chủ yếu HTTP/HTTPS). HTTP server nhấn mạnh rằng server xử lý giao thức HTTP. Hiện nay hai từ dùng thay thế nhau.

<!--# Lịch sử phát triển HTTP Server diễn ra thế nào? [id:2744 order:6]
- 1990s: Web server đơn giản, chỉ serve static file
- 2000s: App lớn dần, server serve HTML + chạy PHP + xử lý logic → dev tách ra 2 loại: static server và app server
- 2010s: Framework như Rails, Django, .NET MVC tích hợp HTTP server vào app
- 2016+: ASP.NET Core tích hợp Kestrel, không cần IIS nữa -->

<!--# Thành phần của web server build bằng ASP.NET Core gồm gì? [id:2745 order:7]
- Kestrel: nhận HTTP connection
- Middleware pipeline: xử lý request (logging, auth, routing...)
- Controller/Endpoint: xử lý business logic
- Response: trả về HTTP response -->

<!--# Điểm mạnh của ASP.NET Core là gì? [id:2746 order:8]
- Cross-platform (chạy trên Linux, macOS, Windows)
- High performance
- Tích hợp sẵn Kestrel
- Pipeline linh hoạt, cho phép thêm middleware
- DI container built-in -->

# High performance trong ASP.NET Core nghĩa là gì? [id:2747 order:9]
là: xử lý request nhanh, phục vụ nhiều request cùng lúc, dùng ít CPU/RAM. Đo bằng: latency (ms), throughput (req/s), memory usage (MB).

# Vì sao ASP.NET Core nhanh? [id:2748 order:10]
- Dùng Kestrel (HTTP server viết tối ưu cho .NET)
- Dùng nhiều async/await — thread không bị block
- Pipeline rất nhẹ — chỉ chạy middleware cần thiết

# Vì sao ASP.NET Core có thể cross-platform? [id:2749 order:11]
- Chạy trên CLR, CLR được implement trên nhiều OS
- Không phụ thuộc IIS và Windows API, dùng kernel API cross-platform
- Thư viện chuẩn được thiết kế cross-platform

# Điều kiện để app cross-platform là gì? [id:2750 order:12]
Cần 3 điều kiện:
- Runtime cross-platform (CLR chạy được trên Linux/macOS)
- Thư viện/framework cross-platform
- OS API mà code dùng phải cross-platform

# ASP là gì? [id:2751 order:13]
là Active Server Pages — tên cũ của Microsoft cho công nghệ web server-side scripting. ASP.NET Core không liên quan đến ASP cũ, chỉ giữ tên vì lịch sử.