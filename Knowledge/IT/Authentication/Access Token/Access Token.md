---
id: 275
name: "Access Token"
---

# Token là gì? [id:2289 order:1]
- là 1 chuỗi dữ liệu để cho phép user gọi API để truy cập tài nguyên

# thành phần của Access Token [id:2290 order:2]
- gồm 3 phần: header, payload, signature

# Token tương ứng với cái gì ở thế giới thực? [id:2291 order:3]
- tấm vé vào cửa, hoặc chìa khoá tạm thời

# Tại sao lại dùng Token thay vì session truyền thống? [id:2292 order:4]
- session k hỗ trợ mobile và các  (do chỉ có trên browser)
- session khó scale cho các ứng dụng lớn, micro service, còn token thì dễ hơn vì stateless

# Các loại token phổ biến? [id:2293 order:5]
- JWT
- SAML

# Access Token là gì? [id:2294 order:6]
- là token dùng để truy cập tài nguyên của server,

# ReFresh token là gì? [id:2295 order:7]
- là token dùng để lấy access token mới khi access token hết hạn

# Claim trong token là gì? [id:2296 order:8]
Các mẩu thông tin nhỏ (key-value) nằm trong token (ví dụ: name, email, role…).

# đặc điểm của Access Token? [id:2297 order:9]
- được gửi kèm trong mỗi request đến server
- thời gian sống nhắn, thường được set từ 15' - 1h

# JWT là gì? [id:2298 order:10]
Loại 1 loại token

# đặc điểm của Refresh Token? [id:2299 order:11]
- không được dùng để truy cập tài nguyên
- thời gian sống dài, (vài ngày, vài tuần hoặc vài tháng)

# Ưu điểm của Token-based Authentication [id:2300 order:12]
- dễ scale ngang
- đa nền tảng

# Nhược điểm của Token-based [id:2301 order:13]
không thể thu hồi ngay lập tức.