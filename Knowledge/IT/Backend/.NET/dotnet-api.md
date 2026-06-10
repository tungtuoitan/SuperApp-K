---
id: 316
name: "dotnet-api"
---

# 2 cách tạo API trong .NET Core là gì? [id:2765 order:1]
- Controller API: cách phổ biến, tổ chức theo class Controller
- Minimal API: viết endpoint trực tiếp trong `Program.cs`, không cần file controller

# Minimal APIs là gì? [id:2766 order:2]
là cách viết endpoint trực tiếp trong `Program.cs`, không cần file controller riêng.

# Ưu điểm của Minimal APIs là gì? [id:2767 order:3]
- Nhanh, gọn, ít boilerplate code
- Hiệu suất cao hơn Controller API
- Khởi động nhanh hơn

# Khi nào nên dùng Minimal APIs? [id:2768 order:4]
Khi build micro service, API nhỏ, hoặc khi muốn app khởi động nhanh.

# Tại sao Minimal APIs khởi động nhanh hơn Controller API? [id:2769 order:5]
- .NET không phải quét controller, scan validation, xác định route
- Pipeline ngắn hơn, không có các layer thừa như ModelValidation, Authorization layer
- Ít reflection hơn khi startup