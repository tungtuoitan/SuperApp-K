---
id: 308
name: "Bảo mật SAS"
---

# Chỉ dùng SAS có đủ bảo mật không? [id:2648 order:1]
Không.

# Tại sao SAS không đủ bảo mật một mình? [id:2649 order:2]
Vì SAS chỉ kiểm soát quyền truy cập file — không kiểm tra user là ai hay có được phép xem file đó không.

# SAS bị lộ URL thì sao? [id:2650 order:3]
Ai có URL đó có thể xem file trong thời hạn còn hiệu lực.

# Có thu hồi SAS URL ngay lập tức được không? [id:2651 order:4]
Không trực tiếp.

# Cách duy nhất để vô hiệu hóa SAS ngay lập tức là gì? [id:2652 order:5]
Đổi Storage Account Key — nhưng sẽ vô hiệu hóa toàn bộ SAS đang dùng.

# SAS được thiết kế để giấu URL không? [id:2653 order:6]
Không.

# SAS kiểm soát thiệt hại bằng cách nào? [id:2654 order:7]
Giới hạn thời hạn và quyền của URL.

# Lớp bảo mật quan trọng nhất khi dùng SAS là gì? [id:2655 order:8]
Authorization ở backend — kiểm tra user có quyền xem file đó không trước khi tạo SAS.

# Cần thêm những lớp bảo mật nào ngoài SAS? [id:2656 order:9]
Authentication, Authorization, HTTPS, Audit log.