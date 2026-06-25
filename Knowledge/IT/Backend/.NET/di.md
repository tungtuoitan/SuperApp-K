---
id: 322
name: "di"
---

# dependency injection là gì? [id:2829 order:1]
là 1 pattern

# DI là gì? [id:2830 order:2]
là kỹ thuật giúp tránh coupling

# DI là pattern hay kĩ thuật ? vì sao?
Vừa là pattern vừa là technique. 
Pattern ở chỗ nó mô tả cách tổ chức dependency. Technique ở chỗ nó là cách code cụ thể.

# DI có phải là technique không? [id:2832 order:4]
Có. DI vừa là pattern (cách tổ chức) vừa là technique (cách code).

# Nhược điểm khi class không dùng DI? [id:2833 order:5]
- Class phải tự khởi tạo dependency → tight coupling
- Object được khởi tạo ở mọi nơi → khi thay đổi phải sửa nhiều chỗ
- Khó test vì không thể inject mock
- Khó bảo trì, mở rộng

# DI giải quyết vấn đề gì? [id:2834 order:6]
- Tight coupling


# singleton, scoped, transient là gì? [id:2835 order:7]
là 3 lifetime của service trong DI container — quy định khi nào instance được tạo mới.

# Singleton, Scoped, Transient khác nhau thế nào? [id:2836 order:8]
- Singleton: 1 instance dùng suốt lifetime app
- Scoped: 1 instance mỗi HTTP request
- Transient: tạo mới mỗi lần inject

# Singleton, Scoped, Transient khác nhau gì? [id:2920 order:9]
- `Singleton`: vòng đời giống app.
- `Scoped`: vòng đời giống request.
- `Transient`: vòng đời giống hàm dùng nó

# pattern khác technique chỗ nào? [id:3142 order:11]
pattern mô tả "vấn đề + cách giải quyết" ở mức ý tưởng, không phụ thuộc ngôn ngữ.
Technique là cách triển khai pattern bằng code cụ thể.

# 1 pattern có thể có nhiều technique khác nhau à? [id:3143 order:12]
đúng
