---
id: 288
name: "VPN"
---

# Network là gì? [id:2404 order:1]
Network là nhiều thiết bị kết nối với nhau để trao đổi dữ liệu.

# Internet là gì? [id:2405 order:2]
Internet là network rất lớn nối nhiều network nhỏ lại với nhau.

# VPN là gì? [id:2406 order:3]
VPN là một mạng riêng ảo tạo kết nối mã hóa qua internet.

# VPN có thay thế internet không? [id:2407 order:4]
Không.

# VPN có cần internet để hoạt động không? [id:2408 order:5]
Có.

<!--# VPN tunnel là gì? [id:2409 order:6]
VPN tunnel là kết nối mã hóa giữa client và VPN server. -->

<!--# VPN dùng để làm gì? [id:2410 order:7]
VPN dùng để truy cập mạng riêng từ xa qua internet. -->

<!--# Consumer VPN và corporate VPN khác nhau thế nào? [id:2411 order:8]
Consumer VPN chủ yếu để privacy và đổi IP. Corporate VPN để vào mạng nội bộ công ty. -->

# Trong công ty, VPN dùng để làm gì? [id:2412 order:9]
VPN cho phép nhân viên truy cập tài nguyên nội bộ từ xa.

# VPN có phải internet riêng không? [id:2413 order:10]
Không.

# VPN có phải mạng vật lý không? [id:2414 order:11]
Không.

<!--# “Virtual” trong VPN nghĩa là gì? [id:2415 order:12]
Nó là mạng logic, không phải dây mạng thật. -->

<!--# VPN có luôn cần VPN server không? [id:2416 order:13]
Thông thường là có. -->

<!--# VPN server dùng để làm gì? [id:2417 order:14]
VPN server authenticate user, tạo tunnel và route traffic. -->

<!--# Client VPN có luôn connect đến VPN server trước không? [id:2418 order:15]
Thông thường là có. -->

# Khi connect VPN, client có được cấp IP riêng không? [id:2419 order:16]
Có.

# IP đó gọi là gì? [id:2420 order:17]
Virtual IP hoặc VPN IP.

# Virtual IP dùng để làm gì? [id:2421 order:18]
Để định danh và route traffic trong VPN.

<!--# Máy dùng VPN có thể có nhiều IP không? [id:2422 order:19]
Có. -->

<!--# Ví dụ máy có nhiều IP? [id:2423 order:20]
Một IP mạng nhà và một IP VPN. -->

<!--# Split tunnel VPN là gì? [id:2424 order:21]
Là kiểu VPN chỉ route một phần traffic qua VPN. -->

# Trong split tunnel, YouTube đi đâu? [id:2425 order:22]
Đi internet thường.

# Trong split tunnel, DB công ty đi đâu? [id:2426 order:23]
Đi qua VPN tunnel và VPN server.

# Vì sao công ty dùng split tunnel? [id:2427 order:24]
Để giảm tải VPN server và tăng tốc internet.

# Full tunnel VPN là gì? [id:2428 order:25]
Là kiểu VPN route toàn bộ traffic qua VPN server.

# VPN tunnel có chạy trên internet không? [id:2429 order:26]
Có.

# Nếu không có internet thì VPN có hoạt động không? [id:2430 order:27]
Không.

# Người ngoài internet thấy gì khi dùng VPN? [id:2431 order:28]
Họ chỉ thấy client đang connect đến VPN server.

# User lạ làm sao bị chặn khỏi VPN công ty? [id:2432 order:29]
VPN server yêu cầu account, password hoặc MFA.

<!--# Sau khi vào VPN, máy user giống như thế nào? [id:2433 order:30]
Giống như đang nằm trong mạng nội bộ công ty. -->

<!--# Bastion server khác VPN thế nào? [id:2434 order:31]
Bastion chỉ cho truy cập service cụ thể, còn VPN cho tham gia network riêng. -->

# User → Server A → DB B có phải VPN không? [id:2435 order:32]
Chưa hẳn.

# Mô hình User → Server A → DB B thường gọi là gì? [id:2436 order:33]
Gateway, proxy hoặc bastion server.

# Khi nào Server A trở thành VPN server? [id:2437 order:34]
Khi nó tạo tunnel, cấp virtual IP và route traffic mạng.