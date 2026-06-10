# ASP.NET Core là gì?
là web framework chính của .NET, dùng để build API, web app, real-time app.

# ASP.NET Core là HTTP Framework không?
Có. HTTP Framework là framework dùng để build web server/API — ASP.NET Core đúng định nghĩa này.

# HTTP Framework là gì?
là framework dùng để build web server và API — xử lý HTTP request/response.

# HTTP Server là gì?
là phần mềm nhận kết nối mạng và xử lý giao thức HTTP.

# HTTP Server và Web Server khác nhau không?
Gần như giống nhau. Web server ám chỉ server xử lý request từ browser (chủ yếu HTTP/HTTPS). HTTP server nhấn mạnh rằng server xử lý giao thức HTTP. Hiện nay hai từ dùng thay thế nhau.

# Lịch sử phát triển HTTP Server diễn ra thế nào?
- 1990s: Web server đơn giản, chỉ serve static file
- 2000s: App lớn dần, server serve HTML + chạy PHP + xử lý logic → dev tách ra 2 loại: static server và app server
- 2010s: Framework như Rails, Django, .NET MVC tích hợp HTTP server vào app
- 2016+: ASP.NET Core tích hợp Kestrel, không cần IIS nữa

# Thành phần của web server build bằng ASP.NET Core gồm gì?
- Kestrel: nhận HTTP connection
- Middleware pipeline: xử lý request (logging, auth, routing...)
- Controller/Endpoint: xử lý business logic
- Response: trả về HTTP response

# Điểm mạnh của ASP.NET Core là gì?
- Cross-platform (chạy trên Linux, macOS, Windows)
- High performance
- Tích hợp sẵn Kestrel
- Pipeline linh hoạt, cho phép thêm middleware
- DI container built-in

# High performance trong ASP.NET Core nghĩa là gì?
là: xử lý request nhanh, phục vụ nhiều request cùng lúc, dùng ít CPU/RAM. Đo bằng: latency (ms), throughput (req/s), memory usage (MB).

# Vì sao ASP.NET Core nhanh?
- Dùng Kestrel (HTTP server viết tối ưu cho .NET)
- Dùng nhiều async/await — thread không bị block
- Pipeline rất nhẹ — chỉ chạy middleware cần thiết

# Vì sao ASP.NET Core có thể cross-platform?
- Chạy trên CLR, CLR được implement trên nhiều OS
- Không phụ thuộc IIS và Windows API, dùng kernel API cross-platform
- Thư viện chuẩn được thiết kế cross-platform

# Điều kiện để app cross-platform là gì?
Cần 3 điều kiện:
- Runtime cross-platform (CLR chạy được trên Linux/macOS)
- Thư viện/framework cross-platform
- OS API mà code dùng phải cross-platform

# ASP là gì?
là Active Server Pages — tên cũ của Microsoft cho công nghệ web server-side scripting. ASP.NET Core không liên quan đến ASP cũ, chỉ giữ tên vì lịch sử.
