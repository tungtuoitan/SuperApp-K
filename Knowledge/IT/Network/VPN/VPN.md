---
id: 53
name: "VPN"
---

# Network là gì? [id:411 order:1]
Network là nhiều thiết bị kết nối với nhau để trao đổi dữ liệu.

# Internet là gì? [id:412 order:2]
Internet là network rất lớn nối nhiều network nhỏ lại với nhau.

# VPN là gì? [id:413 order:3]
VPN là một mạng riêng ảo tạo kết nối mã hóa qua internet.

# VPN có thay thế internet không? [id:415 order:4]
Không.

# VPN có cần internet để hoạt động không? [id:416 order:5]
Có.

# VPN tunnel là gì? [id:417 order:6]
là bọc data lại trước khi gửi đi

# vpn tunnel cụ thể là gì? [id:2927 order:7]
là kênh truyền ảo giữa client và VPN server. Mỗi packet gốc được bọc thêm header mới và mã hóa, rồi gửi qua internet — người ngoài chỉ thấy gói mã hóa, không đọc được nội dung bên trong.

# VPN dùng để làm gì? [id:418 order:8]
ẩn danh
bảo mật
truy cập tài nguyên nội bộ từ xa

# Consumer VPN và corporate VPN khác nhau thế nào? [id:419 order:9]
Consumer VPN dành cho cá nhân, corporate dành cho doanh nghiệp

# Trong công ty, VPN dùng để làm gì? [id:420 order:10]
VPN cho phép nhân viên truy cập tài nguyên nội bộ từ xa.

# VPN có phải internet riêng không? [id:421 order:11]
Không.

# VPN có phải mạng vật lý không? [id:422 order:12]
Không.

# “Virtual” trong VPN nghĩa là gì? cụ thể là gì? [id:423 order:13]
nghĩa là không có dây/thiết bị riêng — VPN tạo ra 1 mạng logic chạy đè lên internet. Các thiết bị khác mạng vật lý vẫn "thấy nhau" như cùng 1 LAN.

# mạng logic là gì? [id:2929 order:14]
là mạng tồn tại ở mức phần mềm, không có dây cáp riêng. Các thiết bị được nhóm lại bằng cấu hình (IP ảo, routing rule), không bằng kết nối vật lý.

# Khi connect VPN, client có được cấp IP riêng không? [id:431 order:15]
Có.

# IP đó gọi là gì? [id:432 order:16]
Virtual IP hoặc VPN IP.

# Virtual IP dùng để làm gì? [id:433 order:17]
Để định danh và route traffic trong VPN.

# Split tunnel VPN là gì? [id:436 order:18]
Là kiểu VPN chỉ route một phần traffic qua VPN.

# Trong split tunnel, YouTube đi đâu? [id:437 order:19]
Đi internet thường.

# Trong split tunnel, DB công ty đi đâu? [id:438 order:20]
Đi qua VPN tunnel và VPN server.

# Vì sao công ty dùng split tunnel? [id:439 order:21]
Để giảm tải VPN server và tăng tốc internet.

# Full tunnel VPN là gì? [id:440 order:22]
Là kiểu VPN route toàn bộ traffic qua VPN server.

# VPN tunnel có chạy trên internet không? [id:441 order:23]
Có.

# Nếu không có internet thì VPN có hoạt động không? [id:442 order:24]
Không.

# Người ngoài internet thấy gì khi dùng VPN? [id:443 order:25]
Họ chỉ thấy client đang connect đến VPN server.

# User lạ làm sao bị chặn khỏi VPN công ty? [id:444 order:26]
VPN server yêu cầu account, password hoặc MFA.

# User → Server A → DB B có phải VPN không? [id:447 order:27]
Chưa hẳn.

# Mô hình User → Server A → DB B thường gọi là gì? [id:448 order:28]
Gateway, proxy hoặc bastion server.

# Khi nào Server A trở thành VPN server? [id:449 order:29]
Khi nó tạo tunnel, cấp virtual IP và route traffic mạng.