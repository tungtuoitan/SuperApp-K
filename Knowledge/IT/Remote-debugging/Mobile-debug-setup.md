---
id: 64
name: "Mobile-debug-setup"
---

# Có mấy cách debug mobile với SuperApp? [id:533 order:1]
2 cách: USB + port forwarding, hoặc cùng WiFi + local IP.

# khi remote-debugging bằng cable thì data đi như thể nào? [id:534 order:2]
Phone gửi request → ADB daemon trên phone bắt request → đẩy qua USB cable → ADB daemon trên laptop nhận → forward vào `localhost:PORT` của laptop. Toàn bộ traffic chạy trong loopback laptop, không qua WiFi/Ethernet.

# Công cụ nào dùng để debug mobile? [id:535 order:3]
`chrome://inspect/#devices` trên laptop.

<!--# Daemon là gì? Đọc là gì? [id:536 order:4]
Đọc là "dee-mon". Process chạy ngầm (background) liên tục, không có UI, phục vụ các yêu cầu khi cần. Ví dụ: ADB daemon chạy ngầm trên laptop, chờ phone kết nối USB để xử lý debug commands và port forwarding. -->

# deamon khác gì job nhỉ? [id:537 order:5]
Daemon chạy ngầm liên tục từ lúc khởi động OS đến lúc tắt máy, phục vụ nhiều client. Job là tác vụ có start–end rõ ràng, chạy 1 lần hoặc theo schedule rồi kết thúc.

<!--# deamon, job có thể chạy độc lập không? [id:2803 order:6]
Có. Cả hai đều chạy như process riêng, không cần app chính. Daemon chạy nền dài hạn, job có thể trigger thủ công hoặc theo schedule. -->

<!--# deamon, job có thể là process cũng có thể là class à? [id:2804 order:7]
Đúng. Ở góc OS, daemon/job là process. Trong code, có thể là class (ví dụ `IHostedService` trong .NET là class chạy như background job bên trong process app). -->

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

# USB cable có phải network interface không? [id:546 order:14]
Không phải

# mỗi adapter thường có 1 interface tương ứng phải không? [id:2930 order:15]
Đúng. 1 adapter (vật lý hoặc ảo) thường tạo ra 1 interface để OS gửi/nhận packet. Hiếm khi 1 adapter map tới nhiều interface.

# interface có phải là abstract của adapter không? [id:2931 order:16]
Đúng. Interface là abstraction tầng OS — có IP, MAC, route, do OS expose ra cho app dùng. Adapter là tầng dưới (NIC vật lý hoặc driver ảo) tạo ra interface đó.

<!--# driver là gì? [id:2932 order:17] -->

<!--# lí do driver tồn tại? [id:2933 order:18] -->

<!--# mọi phần cứng đều có interface phải không? [id:2934 order:19]
Không. -->

<!--# các phần cứng phổ biến có interface? [id:2935 order:20] -->

# NIC khác gì Adapter? [id:2936 order:21]
nó là 1 trong context network.

# Nếu PC kết nối Ethernet, mobile kết nối WiFi, và k được dùng usb cable thì có dùng dc chrome://inspect k? [id:547 order:22]
Không. `chrome://inspect/#devices` chỉ phát hiện phone qua USB cable (ADB). Không có cable thì laptop không "thấy" phone, dù cùng mạng đi nữa. Trường hợp này phải debug bằng cách khác — ví dụ truy cập local IP của laptop từ phone qua WiFi.

# dùng cáp cắm vào router cũng được gọi là ethernet à? [id:2937 order:23]
Đúng.

# A kết nối với wifi còn B kết nối với ethernet, vậy A và B có liên hệ với nhau không? [id:2938 order:24]
Có, nếu cả hai cắm chung 1 router và router đặt WiFi + Ethernet cùng subnet (setup nhà bình thường). Khi đó A và B ping trực tiếp được. Nếu router tách VLAN hoặc 2 subnet khác nhau thì phải đi qua gateway.

# mặc định thì wifi và ehternet cùng router sẽ cùng subnet à? [id:2939 order:25]
Đúng.

# BE cần sửa file nào để nhận connection từ ngoài (WiFi)? [id:548 order:26]
`launchSettings.json` — đổi `applicationUrl` từ `http://localhost:5000` thành `http://0.0.0.0:5000`.

# Khi forward, phải có app nào đó nhận và forward request? [id:549 order:27]
Đúng. Trong port forwarding qua USB, **ADB daemon** làm việc đó — listen trên port phone, nhận packet từ phone qua USB, rồi gửi vào `localhost:PORT` của laptop.

# khi dùng use cable thì khi mobile vào localhost:3000, traffic sẽ đi như thế nào, nói thật cụ thể từng bước? [id:2940 order:28]
1. Chrome trên phone gửi request tới `localhost:3000` (loopback của phone)
2. ADB daemon trên phone đã listen sẵn port 3000 (do `chrome://inspect` setup port forwarding) — bắt request
3. ADB daemon đóng gói request, đẩy qua USB cable
4. ADB daemon trên laptop nhận packet từ USB
5. Laptop daemon forward request vào `127.0.0.1:3000` của laptop
6. webpack-dev-server (FE) nhận request, xử lý, trả response
7. Response đi ngược lại: laptop → ADB laptop → USB → ADB phone → Chrome phone

# Firewall chỉ áp dụng cho wireless, cable thì không bị check phải không? [id:552 order:29]
Sai. Firewall áp dụng cho **tất cả** network interfaces — WiFi, Ethernet, VPN, Docker đều bị check. Port forwarding qua USB "bypass" firewall không phải vì USB không bị check, mà vì ADB forward traffic thành connection từ `127.0.0.1` (loopback) — loopback không bị apply inbound rules.

# API pending có nghĩa là gì? [id:553 order:30]
Browser đã gửi request nhưng không nhận được response (kể cả không nhận tín hiệu từ chối). Khác với "refused" là connection bị từ chối ngay. Pending do: firewall drop packet, server quá tải, hoặc network không route được tới đích.

# Khi thiết bị A truy cập B:3000, nghĩa là gửi 1 packet? [id:554 order:31]
Thực ra là nhiều packet. Flow HTTP cơ bản:
1. TCP handshake: 3 packet (SYN, SYN-ACK, ACK)
2. HTTP request: 1+ packet
3. HTTP response: nhiều packet (tùy kích thước)
Mỗi packet có header chứa IP nguồn + IP đích. Router đọc IP đích để biết forward về đâu.

# Chuyện gì xảy ra khi phone gõ `192.168.2.26:3000`? [id:555 order:32]
1. Phone gửi packet TCP tới `192.168.2.26:3000` qua WiFi router
2. Router forward packet đến laptop (cùng subnet, không qua internet)
3. Laptop nhận packet tại WiFi adapter
4. Windows Firewall kiểm tra: có rule nào allow port 3000 inbound không?
5. webpack-dev-server đã tạo exception → FE OK
6. Port 5000: rule có nhưng bị GPO override → drop packet → phone không nhận response → pending