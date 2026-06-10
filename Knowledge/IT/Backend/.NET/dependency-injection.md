---
id: 314
name: "dependency-injection"
---

# Dependency Injection | DI là gì? [id:2752 order:1]
là kỹ thuật giúp 1 object nhận các dependency từ bên ngoài thay vì tự tạo. Hầu hết framework backend hiện nay đều có DI built-in.

# Dependency là gì? [id:2753 order:2]
là 1 object mà class cần để hoạt động. Ví dụ: `UserService` cần `EmailSender` → `EmailSender` là dependency của `UserService`.

# Nhược điểm khi class không dùng DI? [id:2754 order:3]
- Class phải tự khởi tạo dependency → tight coupling
- Object được khởi tạo ở mọi nơi → khi thay đổi phải sửa nhiều chỗ
- Khó test vì không thể inject mock
- Khó bảo trì, mở rộng