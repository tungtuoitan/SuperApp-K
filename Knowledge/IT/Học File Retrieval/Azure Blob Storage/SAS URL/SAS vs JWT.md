---
id: 309
name: "SAS vs JWT"
---

# SAS và JWT có điểm gì giống nhau về cơ chế? [id:2657 order:1]
Cả hai đều dùng HMAC để ký — sửa thông tin là chữ ký sai, bị từ chối.

# SAS và JWT khác nhau ở chỗ nào? [id:2658 order:2]
JWT nằm trong Authorization header. SAS nằm trên URL.

# JWT dùng để làm gì? [id:2659 order:3]
Xác thực người dùng với backend.

# SAS dùng để làm gì? [id:2660 order:4]
Ủy quyền truy cập file trực tiếp với Azure.

# SAS có stateless không? [id:2661 order:5]
Có.

# Tại sao SAS stateless? [id:2662 order:6]
Azure không cần lưu danh sách SAS — chỉ verify chữ ký là đủ.

# JWT bị lộ nguy hiểm hơn hay SAS bị lộ nguy hiểm hơn? [id:2663 order:7]
JWT bị lộ nguy hiểm hơn.

# Tại sao JWT bị lộ nguy hiểm hơn SAS? [id:2664 order:8]
JWT cho phép giả danh user và làm mọi thứ user làm được. SAS chỉ truy cập được đúng file đó trong thời hạn giới hạn.

---