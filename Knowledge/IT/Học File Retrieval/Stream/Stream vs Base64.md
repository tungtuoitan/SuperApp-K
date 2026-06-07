---
id: 300
name: "Stream vs Base64"
---

# Cái nào tốn băng thông mạng hơn? [id:2599 order:1]
Base64 — tốn hơn 33% do encoding.

# Cái nào hiển thị nội dung nhanh hơn? [id:2600 order:2]
Stream.

# Tại sao stream hiển thị nhanh hơn? [id:2601 order:3]
Vì có thể render từ chunk đầu tiên, không cần chờ toàn bộ file.

# Cái nào browser cache được qua reload? [id:2602 order:4]
Stream (qua URL thật).

# Tại sao Base64 không cache được qua reload? [id:2603 order:5]
Vì Base64 không có URL — browser cache hoạt động theo URL.

# File 500KB dùng cách nào? [id:2604 order:6]
Cả hai đều ổn.

# File 20MB dùng cách nào? [id:2605 order:7]
Stream.

# Tại sao file 20MB không nên dùng Base64? [id:2606 order:8]
Dễ timeout API call và tốn RAM lớn.