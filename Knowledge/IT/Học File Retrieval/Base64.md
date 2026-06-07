---
id: 279
name: "Base64"
---

# Base64 giải quyết bài toán gì? [id:2315 order:1]
Nhúng binary data vào môi trường chỉ chứa text được (JSON, HTML, Email).

# Base64 có phải mã hóa bảo mật không? [id:2316 order:2]
Không.

# Tại sao Base64 không phải mã hóa bảo mật? [id:2317 order:3]
Ai cũng decode được mà không cần key.

# Base64 làm tăng kích thước file bao nhiêu? [id:2318 order:4]
33%.

# Tại sao Base64 tăng 33%? [id:2319 order:5]
Vì 3 bytes binary được biểu diễn bằng 4 ký tự ASCII.

# Base64 có stream được không? [id:2320 order:6]
Không.

# Tại sao Base64 không stream được? [id:2321 order:7]
Phải decode toàn bộ chuỗi mới có data — không thể decode một nửa.

# Base64 ảnh hưởng RAM như thế nào? [id:2322 order:8]
File tồn tại 3 lần trong RAM: string base64 → ArrayBuffer → Blob.

# Email attachment có thể dùng stream thay Base64 không? [id:2323 order:9]
Không.

# Tại sao email attachment không dùng stream được? [id:2324 order:10]
Email không phải HTTP — không có khái niệm stream. Base64 là chuẩn MIME bắt buộc (RFC 2045).

# Khi nào Base64 là lựa chọn đúng? [id:2325 order:11]
Khi cần nhúng binary vào text-based format: email attachment, data URI trong HTML, file nhỏ bundle cùng API response.