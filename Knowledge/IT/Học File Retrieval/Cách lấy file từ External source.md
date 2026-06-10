---
id: 45
name: "Cách lấy file từ External source"
---

# Có mấy cách lấy file từ external source? [id:362 order:1]
Bốn cách: Base64 trong JSON, Proxy Stream, lưu vào Azure Blob rồi trả SAS URL, Signed URL từ external source.

# Cách nào tốn băng thông backend nhiều nhất? [id:363 order:2]
Base64 — backend phải đọc toàn bộ file, encode rồi trả trong response.

# Cách nào backend tốn ít tài nguyên nhất? [id:364 order:3]
Signed URL — backend chỉ lấy URL rồi trả về, không đụng vào nội dung file.

# Khi nào nên lưu file vào Azure Blob trước rồi trả SAS? [id:365 order:4]
Khi file được xem nhiều lần hoặc external source không đảm bảo availability.

# Proxy stream phù hợp khi nào? [id:366 order:5]
Khi cần xử lý file lớn tốt hơn Base64 mà không muốn đổi storage infrastructure.

# Signed URL từ external source là gì? [id:367 order:6]
URL tạm thời có chữ ký do external source (S3, GCS...) tạo ra — tương tự SAS URL.