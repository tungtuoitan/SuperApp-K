---
id: 325
name: "middleware-pipeline"
---

# middleware trong ASP.NET Core là gì? [id:2853 order:1]
là thành phần xử lý HTTP request/response theo pipeline.

# ware trong middleware có nghĩa là phần mềm phải không?? [id:2854 order:2]
Đúng. `ware` viết tắt của `software`, `middle` là ở giữa — middleware là phần mềm nằm giữa request và handler cuối.


# cách đọc circuit ? [id:2856 order:4]
Đọc là "sơ-kịt" (tiếng Anh /ˈsɜːr.kɪt/).

# IHostedService là gì? [id:2857 order:5]
là interface để chạy background task

# .net server đơn giản nhất gồm những gì? [id:2858 order:6]
- Kestrel: nhận HTTP connection
- Middleware pipeline: xử lý request
- Endpoint/Controller: business logic

# mặc định thì k có middleware nào cả phải không? tức request sẽ đi đến Kestrel và đến thẳng controller ? [id:2859 order:7]
Gần đúng. ASP.NET Core mặc định có vài middleware tối thiểu (routing, endpoint). Còn auth/logging/cors thì dev tự `app.Use...` thêm.

# routing, endpoint cũng là middleware à? nhiệm vụ của chúng là gì? [id:2860 order:8]
Đúng, cả hai là middleware tích hợp sẵn.
- Routing middleware: match URL với route pattern, xác định endpoint sẽ chạy
- Endpoint middleware: thực thi endpoint đã match (gọi controller hoặc handler)

# web server của .net là gì? [id:2861 order:9]
là Kestrel — HTTP server mặc định, viết tối ưu cho .NET, tích hợp sẵn trong ASP.NET Core.

# kestrel có phải là http server không? [id:2862 order:10]
Có. Kestrel là HTTP server thuần — chỉ xử lý HTTP/HTTPS, không có reverse proxy feature như Nginx.

# mỗi middleware là 1 class độc lập à? [id:2863 order:11]
Thường là vậy. Mỗi middleware là 1 class có method `InvokeAsync(HttpContext, RequestDelegate)`. Cũng có thể viết inline bằng `app.Use(...)` lambda.

# request đi qua những gì trước khi đến db? [id:2864 order:12]
1. Kestrel
2. Middleware pipeline
3. Controller/Endpoint
4. Service layer (business logic)
5. Repository / EF Core
6. DB

# pipeline là gì? [id:2921 order:13]
là chuỗi các middleware

# trong MinimalAPI có pipeline không? [id:2922 order:14]
Có.