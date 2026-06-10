# middleware trong ASP.NET Core là gì?
là thành phần xử lý HTTP request/response theo pipeline.

# ware trong middleware có nghĩa là phần mềm phải không??
Đúng. `ware` viết tắt của `software`, `middle` là ở giữa — middleware là phần mềm nằm giữa request và handler cuối.

# circuit là gì?
là mạch xử lý — trong .NET, hay gặp ở Circuit Breaker pattern (chặn call khi service downstream lỗi liên tục) và Blazor Circuit (kết nối SignalR giữa browser và server).

# cách đọc circuit ?
Đọc là "sơ-kịt" (tiếng Anh /ˈsɜːr.kɪt/).

# IHostedService là gì?
là interface để chạy background task

# một .net server đơn giản nhất gồm những gì?
- Kestrel: nhận HTTP connection
- Middleware pipeline: xử lý request
- Endpoint/Controller: business logic

# mặc định thì k có middleware nào cả phải không? tức request sẽ đi đến Kestrel và đến thẳng controller ?
Gần đúng. ASP.NET Core mặc định có vài middleware tối thiểu (routing, endpoint). Còn auth/logging/cors thì dev tự `app.Use...` thêm.

# routing, endpoint cũng là middleware à? nhiệm vụ của chúng là gì?
Đúng, cả hai là middleware tích hợp sẵn.
- Routing middleware: match URL với route pattern, xác định endpoint sẽ chạy
- Endpoint middleware: thực thi endpoint đã match (gọi controller hoặc handler)

# web server của .net là gì?
là Kestrel — HTTP server mặc định, viết tối ưu cho .NET, tích hợp sẵn trong ASP.NET Core.

# kestrel có phải là http server không?
Có. Kestrel là HTTP server thuần — chỉ xử lý HTTP/HTTPS, không có reverse proxy feature như Nginx.

# mỗi middleware là 1 class độc lập à?
Thường là vậy. Mỗi middleware là 1 class có method `InvokeAsync(HttpContext, RequestDelegate)`. Cũng có thể viết inline bằng `app.Use(...)` lambda.

# request đi qua những gì trước khi đến db?
1. Kestrel
2. Middleware pipeline
3. Controller/Endpoint
4. Service layer (business logic)
5. Repository / EF Core
6. DB
