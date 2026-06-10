# dependency injection là gì?
là 1 pattern

# Dependency Injection | DI là gì?
là kỹ thuật giúp 1 object nhận các dependency từ bên ngoài thay vì tự tạo. Hầu hết framework backend hiện nay đều có DI built-in.

# Dependency là gì?
là 1 object mà class cần để hoạt động. Ví dụ: `UserService` cần `EmailSender` → `EmailSender` là dependency của `UserService`.

# DI có phải là technique không?
Có. DI vừa là pattern (cách tổ chức) vừa là technique (cách code).

# Nhược điểm khi class không dùng DI?
- Class phải tự khởi tạo dependency → tight coupling
- Object được khởi tạo ở mọi nơi → khi thay đổi phải sửa nhiều chỗ
- Khó test vì không thể inject mock
- Khó bảo trì, mở rộng

# DI giải quyết vấn đề gì?
- Tight coupling: class tự `new` dependency
- Khó test: không inject được mock
- Khó thay đổi: muốn đổi implementation phải sửa nhiều chỗ

# singleton, scoped, transient là gì?
là 3 lifetime của service trong DI container — quy định khi nào instance được tạo mới.

# Singleton, Scoped, Transient khác nhau thế nào?
- Singleton: 1 instance dùng suốt lifetime app
- Scoped: 1 instance mỗi HTTP request
- Transient: tạo mới mỗi lần inject
