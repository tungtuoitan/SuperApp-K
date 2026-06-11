---
id: 64
name: "Mobile-debug-setup"
---

# Có mấy cách debug mobile với SuperApp? [id:533 order:1]
2 cách: USB + port forwarding, hoặc cùng WiFi + local IP.

<!--# khi remote-debugging bằng cable thì packet đi từ moble chrome > cable > pc chrome > webpack dev server, còn wifi thì packet đi từ mobile chrome > router > pc chrome > webpack dev server phải không? [id:534 order:2] -->

# Công cụ nào dùng để debug mobile? [id:535 order:3]
`chrome://inspect/#devices` trên laptop.

# Daemon là gì? Đọc là gì? [id:536 order:4]
Đọc là "dee-mon". Process chạy ngầm (background) liên tục, không có UI, phục vụ các yêu cầu khi cần. Ví dụ: ADB daemon chạy ngầm trên laptop, chờ phone kết nối USB để xử lý debug commands và port forwarding.

# deamon khác gì job nhỉ? [id:537 order:5]
Daemon chạy ngầm liên tục từ lúc khởi động OS đến lúc tắt máy, phục vụ nhiều client. Job là tác vụ có start–end rõ ràng, chạy 1 lần hoặc theo schedule rồi kết thúc.

<!--# deamon, job có thể chạy độc lập không? [id:2803 order:6]
Có. Cả hai đều chạy như process riêng, không cần app chính. Daemon chạy nền dài hạn, job có thể trigger thủ công hoặc theo schedule. -->

# deamon, job có thể là process cũng có thể là class à? [id:2804 order:7]
Đúng. Ở góc OS, daemon/job là process. Trong code, có thể là class (ví dụ `IHostedService` trong .NET là class chạy như background job bên trong process app).

# Port forwarding trong `chrome://inspect` là gì? [id:538 order:8]
Tính năng cho phép Chrome trên phone truy cập các port trên laptop như thể chúng là port của chính phone. Cài `3000 → localhost:3000` thì khi phone request `localhost:3000`, ADB tunnel chuyển request sang `localhost:3000` trên laptop.

# `applicationUrl` trong `launchSettings.json` là gì? [id:539 order:9]
Địa chỉ mà .NET BE lắng nghe khi chạy — IP:port mà server bind. Ví dụ `http://0.0.0.0:5000` = lắng nghe mọi interface trên port 5000. API path (`/api/k/...`) là phần riêng của routing, không liên quan.

# `chrome://inspect/#devices` hoạt động thế nào? [id:540 order:10]
Chrome trên laptop kết nối với Chrome trên phone qua USB (ADB — Android Debug Bridge). Khi phone cắm USB và bật USB Debugging, laptop "thấy" các tab đang mở trên Chrome phone và có thể inspect chúng.

# Mỗi app thường chỉ có 1 port để nhận request thôi? [id:541 order:11]
Thường đúng — BE dùng 5000, FE dùng 3000. Một port chỉ có 1 process bind được (không share). Một app có thể bind nhiều port (ví dụ HTTP 80 + HTTPS 443), nhưng thường không cần.

# 1 port chỉ bind được 1 process, nhưng 1 process bind được nhiều port? [id:542 order:12]
Đúng. Port là tài nguyên độc quyền — chỉ 1 process "sở hữu" tại 1 thời điểm. Nhưng 1 process có thể bind nhiều port tùy thích, ví dụ .NET app vừa listen HTTP :5000 vừa listen HTTPS :5001.

# IP và host có nghĩa tương tự nhau không? [id:543 order:13]
Không hoàn toàn. **IP** là địa chỉ số (`192.168.2.26`). **Host** rộng hơn — có thể là IP hoặc domain name (`localhost`, `example.com`). Domain được DNS resolve thành IP.

<!--# Khi dùng port forwarding, phone truy cập FE bằng URL nào? [id:544 order:14]
`http://localhost:3000`. -->

<!--# Tại sao port forwarding không cần cùng mạng? [id:545 order:15]
Vì traffic đi qua USB cable, không qua WiFi hay Ethernet. Không cần IP, không cần firewall rule, không cần CORS. -->

<!--# USB cable có phải network interface không? [id:546 order:16]
Không theo nghĩa thông thường. USB là giao thức kết nối thiết bị, không phải network protocol. ADB tạo virtual network interface qua USB để truyền data — đó là interface ảo, không phải USB cable là network interface. -->

<!--# Nếu PC kết nối Ethernet, mobile kết nối WiFi thì chrome://inspect không dùng được? [id:547 order:17]
Dùng được bình thường. `chrome://inspect` dùng USB cable (ADB), không phụ thuộc vào WiFi hay Ethernet của laptop. Miễn là laptop và phone kết nối qua USB và bật USB Debugging. -->

# BE cần sửa file nào để nhận connection từ ngoài (WiFi)? [id:548 order:18]
`launchSettings.json` — đổi `applicationUrl` từ `http://localhost:5000` thành `http://0.0.0.0:5000`.

# Khi forward, phải có app nào đó nhận và forward request? [id:549 order:19]
Đúng. Trong port forwarding qua USB, **ADB daemon** làm việc đó — listen trên port phone, nhận packet từ phone qua USB, rồi gửi vào `localhost:PORT` của laptop.

<!--# Port forwarding hoạt động thế nào ở tầng thấp? [id:550 order:20]
ADB tạo tunnel qua USB. Phone gửi request tới `localhost:PORT` → ADB bắt lấy → forward qua USB → laptop nhận và xử lý → trả kết quả ngược lại qua USB → phone nhận response. -->

<!--# Tại sao API pending khi dùng WiFi IP nhưng FE vào được bình thường? [id:551 order:21]
FE (port 3000, webpack-dev-server) tự thêm Windows Firewall exception khi khởi động → port 3000 tự được mở. BE (port 5000, .NET) không tự làm vậy → phải có firewall rule thủ công → rule bị vô hiệu do WiFi profile Public + GPO → packet drop → pending. -->

# Firewall chỉ áp dụng cho wireless, cable thì không bị check? [id:552 order:22]
Sai. Firewall áp dụng cho **tất cả** network interfaces — WiFi, Ethernet, VPN, Docker đều bị check. Port forwarding qua USB "bypass" firewall không phải vì USB không bị check, mà vì ADB forward traffic thành connection từ `127.0.0.1` (loopback) — loopback không bị apply inbound rules.

# API pending có nghĩa là gì? [id:553 order:23]
Browser đã gửi request nhưng không nhận được response (kể cả không nhận tín hiệu từ chối). Khác với "refused" là connection bị từ chối ngay. Pending do: firewall drop packet, server quá tải, hoặc network không route được tới đích.

# Khi thiết bị A truy cập B:3000, nghĩa là gửi 1 packet? [id:554 order:24]
Thực ra là nhiều packet. Flow HTTP cơ bản:
1. TCP handshake: 3 packet (SYN, SYN-ACK, ACK)
2. HTTP request: 1+ packet
3. HTTP response: nhiều packet (tùy kích thước)
Mỗi packet có header chứa IP nguồn + IP đích. Router đọc IP đích để biết forward về đâu.

# Chuyện gì xảy ra khi phone gõ `192.168.2.26:3000`? [id:555 order:25]
1. Phone gửi packet TCP tới `192.168.2.26:3000` qua WiFi router
2. Router forward packet đến laptop (cùng subnet, không qua internet)
3. Laptop nhận packet tại WiFi adapter
4. Windows Firewall kiểm tra: có rule nào allow port 3000 inbound không?
5. webpack-dev-server đã tạo exception → FE OK
6. Port 5000: rule có nhưng bị GPO override → drop packet → phone không nhận response → pending