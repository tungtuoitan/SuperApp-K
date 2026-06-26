---
id: 63
name: "Networking-basic"
---

# IP là gì? [id:504 order:1]
Địa chỉ định danh của thiết bị trong mạng — giống như số nhà trong một khu phố.

# DHCP là gì? [id:505 order:2]
Dynamic Host Configuration Protocol — giao thức tự động cấp IP cho thiết bị khi kết nối vào mạng. Thay vì tự điền IP thủ công, thiết bị hỏi DHCP server "cho tôi xin IP" và được cấp phát.

# Subnet là gì? [id:506 order:3]
Subnet (mạng con) là một dải IP mà các thiết bị trong đó có thể giao tiếp trực tiếp với nhau mà không qua router.

# Gateway là gì? [id:507 order:4]
Cổng ra vào của subnet — mọi traffic đi ra ngoài internet đều qua đây. Thường là router.

# Router là gì? [id:508 order:5]
Thiết bị vật lý định tuyến packet — quyết định packet đi đường nào. Trong nhà: cấp IP qua DHCP, forward traffic giữa các thiết bị trong subnet, và forward traffic ra internet qua modem.

# Modem là gì? [id:509 order:6]
Chuyển đổi tín hiệu: digital từ máy tính ↔ analog từ đường dây ISP (cáp quang, ADSL...). Modem là "cầu nối" ra internet.

# Modem và router là 2 thiết bị tách rời nhau? [id:510 order:7]
Thường thì không — nhà thường dùng thiết bị combo modem+router trong 1 cục. Nhưng về mặt kỹ thuật chúng là 2 vai trò khác nhau.

# Adapter là gì? [id:511 order:8]
Phần cứng hoặc phần mềm giúp kết nối 2 thứ có giao diện khác nhau. Network adapter = card mạng, cho phép máy tính kết nối vào mạng.

# lí do driver tồn tại? [id:3302 order:9]
để OS có thể nói chuyện được với NIC

# lí do card mạng tồn tại? [id:3303 order:10]
để kết nối máy tính vào mạng

# hoạt động của card mạng? [id:3304 order:11]
Nhận dữ liệu số từ OS
→ chuyển thành tín hiệu điện (Ethernet) hoặc sóng radio (WiFi)
→ truyền ra mạng.

# Network Interface là gì? [id:3305 order:12]
là 1 struct chứa: IP address, MAC address, routing entry.

# chuyện gì xảy ra khi App gửi data đi? [id:3306 order:13]
Chrome gọi socket.Send(data)
OS chọn Interface và xác định adapter tương ứng
Adapter.Send(packet)
Driver chuyển lệnh trên thành lệnh mà NIC hiểu được
NIC truyền dữ liệu vật lí ra ngoài

# tại sao máy có nhiều network interface? [id:3307 order:14]
vì máy có thể có nhiều đường ra mạng khác nhau

<!--# quan hệ Interface và wifi, ethernet? [id:3308 order:15]
interface là abstract của 1 điểm tham gia vào mạng cụ thể
còn wifi, ethernet là các điểm tham gia vào mạng -->

# quan hệ giữa Adapter và NIC? [id:3309 order:16]
Adapter là abstract của NIC

# quan hệ giữa Interface và Adapter? [id:3310 order:17]
Interface là abstract của Adapter

# ví dụ điểm tham gia vào mạng? [id:3311 order:18]
wifi, vpn, loopback, ethernet

# Network interface là gì? [id:513 order:19]
Điểm kết nối của máy vào mạng. Mỗi interface có: địa chỉ IP, MAC address, và driver. Gồm: WiFi adapter, Ethernet adapter, Loopback, VPN adapter... Mỗi cái có IP riêng.

# lí do network interface tồn tại? [id:3312 order:20]
giúp App gửi request dễ dàng, với mọi loại NIC

# cho ví dụ abstraction tương tự Network Interface/Adapter? [id:3313 order:21]
File System Interface là abstract của các ổ cứng
Task là abstract của Thread

# tại sao có driver rồi mà vẫn cần adapter? [id:3314 order:22]
Driver giúp OS nói chuyện với NIC (tầng hardware).
Adapter là object đại diện NIC  (tầng software)

# adapter là gì? [id:3315 order:23]
- là struct/object đại diện cho 1 NIC

# `127.0.0.1` có phải là IP không? [id:515 order:24]
Có, là một địa chỉ IPv4 đầy đủ. Thuộc dải `127.0.0.0/8` dành riêng làm loopback — mọi địa chỉ trong dải này đều trỏ về chính máy.

# IP sinh ra từ đâu? [id:516 order:25]
Thường do DHCP server (thường là router) cấp phát tự động khi máy kết nối vào mạng.

# IP có thể là static không? [id:517 order:26]
Có. Nếu cấu hình thủ công thì IP không đổi dù restart. Ví dụ `192.168.2.1` (Ethernet) là static IP được cài sẵn trên adapter.

# Router là gateway? [id:518 order:27]
Trong mạng nhà, đúng — router chính là default gateway. Nhưng gateway là khái niệm rộng hơn: bất kỳ thiết bị nào đóng vai trò "cổng ra vào" giữa 2 mạng khác nhau đều là gateway.

# Vai trò của gateway? [id:519 order:28]
Nhận packet từ trong subnet, kiểm tra IP đích: nếu IP đích nằm ngoài subnet → forward ra ngoài. Nếu IP đích trong cùng subnet → chuyển thẳng.

# 1 máy có nhiều IP không? [id:520 order:29]
Có. Mỗi network interface có 1 IP riêng. Laptop thường có:
- `127.0.0.1` — loopback (luôn có)
- `192.168.2.26` — WiFi adapter
- `192.168.2.1` — Ethernet adapter
- Có thể có thêm: VPN adapter, Docker virtual network...

# `127.0.0.1` là loại IP nào? [id:521 order:30]
IP của loopback interface — interface ảo, không gắn với phần cứng vật lý. Luôn có trên mọi máy, không thể xóa. Packet gửi tới đây không rời khỏi máy.

# IP các thiết bị dùng chung WiFi có đặc điểm gì? [id:522 order:31]
Cùng prefix mạng — ví dụ tất cả đều là `192.168.2.x`. Điều này có nghĩa là cùng subnet, có thể giao tiếp trực tiếp mà không qua internet.

# Ping trực tiếp là gì? [id:523 order:32]
Gửi packet thẳng từ thiết bị A đến thiết bị B mà không cần qua gateway/internet. Chỉ xảy ra khi 2 thiết bị cùng subnet.

# IP thay đổi khi nào? [id:524 order:33]
- Khi disconnect rồi reconnect vào mạng khác
- Khi DHCP lease hết hạn (thường vài giờ đến vài ngày)
- Khi router restart và cấp lại IP

# Subnet có phải là 1 phần của IP không? [id:525 order:34]
Subnet là một **dải** IP (nhiều địa chỉ), không phải 1 IP cụ thể. Ký hiệu `192.168.2.0/24`: `192.168.2.0` là địa chỉ mạng, `/24` = 24 bit đầu cố định → 8 bit còn lại cho thiết bị → 254 địa chỉ từ `.1` đến `.254`.

# Subnet của WiFi là gì? Có phải là IP của router không? [id:526 order:35]
Subnet của WiFi là dải IP mà router cấp cho các thiết bị WiFi, ví dụ `192.168.2.0/24`. IP của router (`192.168.2.253`) là 1 địa chỉ nằm trong subnet đó, không phải là subnet.

# IP mặc định của router thường là `192.168.1.1` hay `192.168.0.1` — tại sao? [id:527 order:36]
Quy ước của nhà sản xuất. `192.168.x.x` là dải IP private (RFC 1918) dành riêng cho mạng nội bộ, không route được trên internet. Router thường lấy địa chỉ đầu tiên trong subnet (`.1`) làm IP của mình.

# Sơ đồ thành phần trong mạng nhà đơn giản? [id:528 order:37]
```
[Internet / ISP]
       |
    [Modem]         ← kết nối với ISP, chuyển tín hiệu
       |
    [Router]  ──── IP: 192.168.2.253 (gateway)
    /   |   \       cấp IP qua DHCP, định tuyến traffic
   /    |    \
[Laptop] [Phone] [PC]
WiFi .26  WiFi .50  Cáp .100
```

# wifi là 1 subnet phải không? [id:2941 order:38]
Đúng. Mỗi WiFi network (1 SSID) thường tương ứng 1 subnet — router cấp IP cùng dải cho tất cả thiết bị connect vào. Ví dụ tất cả device WiFi nhà đều có IP `192.168.2.x` → cùng subnet `192.168.2.0/24`.

# ssid là gì? [id:2942 order:39]
Service Set Identifier — tên hiển thị của 1 mạng WiFi (ví dụ "Home_5G", "VietnamPostOffice"). Là chuỗi tối đa 32 ký tự dùng để phân biệt các WiFi network với nhau.

# pc kết nối wifi và pc kết nối đến router bằng cáp thì giống nhau/khác nhau gì? [id:2943 order:40]
giống nhau: cùng subnet
khác nhau: adapter khác nhau (wifi adapter vs ethernet adapter)

# kết nối đến router wifi bằng cáp thì có phải là ethernet không? [id:2944 order:41]
Đúng. Bất kỳ kết nối nào dùng dây RJ45 cắm vào port LAN của router đều là Ethernet, dù router đó có hỗ trợ WiFi hay không.

# Thiết bị cùng router thì luôn cùng subnet và ping trực tiếp được? [id:530 order:42]
Phần lớn đúng, nhưng có ngoại lệ: router có thể cấu hình VLAN hoặc client isolation (WiFi isolation) để cô lập các thiết bị dù cùng subnet. Trong setup nhà bình thường thì đúng.

# Tại sao không dùng `ipconfig` để lấy IP WiFi? [id:531 order:43]
`ipconfig` hiển thị nhièu ip nên dễ lấy nhầm