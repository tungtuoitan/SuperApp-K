# 2 cách tạo API trong .NET Core là gì?
- Controller API: cách phổ biến, tổ chức theo class Controller
- Minimal API: viết endpoint trực tiếp trong `Program.cs`, không cần file controller

# Minimal APIs là gì?
là cách viết endpoint trực tiếp trong `Program.cs`, không cần file controller riêng.

# Ưu điểm của Minimal APIs là gì?
- Nhanh, gọn, ít boilerplate code
- Hiệu suất cao hơn Controller API
- Khởi động nhanh hơn

# Khi nào nên dùng Minimal APIs?
Khi build micro service, API nhỏ, hoặc khi muốn app khởi động nhanh.

# Tại sao Minimal APIs khởi động nhanh hơn Controller API?
- .NET không phải quét controller, scan validation, xác định route
- Pipeline ngắn hơn, không có các layer thừa như ModelValidation, Authorization layer
- Ít reflection hơn khi startup
