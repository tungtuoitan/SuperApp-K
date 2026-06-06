# Mạng Cơ Bản — IP, Subnet, Gateway, Interface

## IP là gì?
Địa chỉ định danh của thiết bị trong mạng — giống như số nhà trong một khu phố.

## DHCP là gì?
Dynamic Host Configuration Protocol — giao thức tự động cấp IP cho thiết bị khi kết nối vào mạng. Thay vì tự điền IP thủ công, thiết bị hỏi DHCP server "cho tôi xin IP" và được cấp phát.

## Subnet là gì?
Subnet (mạng con) là một dải IP mà các thiết bị trong đó có thể giao tiếp trực tiếp với nhau mà không qua router.

## Gateway là gì?
Cổng ra vào của subnet — mọi traffic đi ra ngoài internet đều qua đây. Thường là router.

## Router là gì?
Thiết bị vật lý định tuyến packet — quyết định packet đi đường nào. Trong nhà: cấp IP qua DHCP, forward traffic giữa các thiết bị trong subnet, và forward traffic ra internet qua modem.

## Modem là gì?
Chuyển đổi tín hiệu: digital từ máy tính ↔ analog từ đường dây ISP (cáp quang, ADSL...). Modem là "cầu nối" ra internet.

## Modem và router là 2 thiết bị tách rời nhau?
Thường thì không — nhà thường dùng thiết bị combo modem+router trong 1 cục. Nhưng về mặt kỹ thuật chúng là 2 vai trò khác nhau.

## Adapter là gì?
Phần cứng hoặc phần mềm giúp kết nối 2 thứ có giao diện khác nhau. Network adapter = card mạng, cho phép máy tính kết nối vào mạng.

## Card mạng là gì? Có phải card vật lý không?
Card mạng (NIC) thường là phần cứng vật lý gắn trong máy. Nhưng cũng có card mạng ảo: loopback (`127.0.0.1`), VPN adapter, Docker bridge — không có phần cứng vật lý tương ứng.

## Network interface là gì?
Điểm kết nối của máy vào mạng. Mỗi interface có: địa chỉ IP, MAC address, và driver. Gồm: WiFi adapter, Ethernet adapter, Loopback, VPN adapter... Mỗi cái có IP riêng.

## `localhost` tương ứng với IP gì?
`127.0.0.1`. Đây là mapping cố định trong file `hosts` của hệ điều hành — không cần DNS.

## `127.0.0.1` có phải là IP không?
Có, là một địa chỉ IPv4 đầy đủ. Thuộc dải `127.0.0.0/8` dành riêng làm loopback — mọi địa chỉ trong dải này đều trỏ về chính máy.

## IP sinh ra từ đâu?
Thường do DHCP server (thường là router) cấp phát tự động khi máy kết nối vào mạng.

## IP có thể là static không?
Có. Nếu cấu hình thủ công thì IP không đổi dù restart. Ví dụ `192.168.2.1` (Ethernet) là static IP được cài sẵn trên adapter.

## Router là gateway?
Trong mạng nhà, đúng — router chính là default gateway. Nhưng gateway là khái niệm rộng hơn: bất kỳ thiết bị nào đóng vai trò "cổng ra vào" giữa 2 mạng khác nhau đều là gateway.

## Vai trò của gateway?
Nhận packet từ trong subnet, kiểm tra IP đích: nếu IP đích nằm ngoài subnet → forward ra ngoài. Nếu IP đích trong cùng subnet → chuyển thẳng.

## 1 máy có nhiều IP không?
Có. Mỗi network interface có 1 IP riêng. Laptop thường có:
- `127.0.0.1` — loopback (luôn có)
- `192.168.2.26` — WiFi adapter
- `192.168.2.1` — Ethernet adapter
- Có thể có thêm: VPN adapter, Docker virtual network...

## `127.0.0.1` là loại IP nào?
IP của loopback interface — interface ảo, không gắn với phần cứng vật lý. Luôn có trên mọi máy, không thể xóa. Packet gửi tới đây không rời khỏi máy.

## IP các thiết bị dùng chung WiFi có đặc điểm gì?
Cùng prefix mạng — ví dụ tất cả đều là `192.168.2.x`. Điều này có nghĩa là cùng subnet, có thể giao tiếp trực tiếp mà không qua internet.

## Ping trực tiếp là gì?
Gửi packet thẳng từ thiết bị A đến thiết bị B mà không cần qua gateway/internet. Chỉ xảy ra khi 2 thiết bị cùng subnet.

## IP thay đổi khi nào?
- Khi disconnect rồi reconnect vào mạng khác
- Khi DHCP lease hết hạn (thường vài giờ đến vài ngày)
- Khi router restart và cấp lại IP

## Subnet có phải là 1 phần của IP không?
Subnet là một **dải** IP (nhiều địa chỉ), không phải 1 IP cụ thể. Ký hiệu `192.168.2.0/24`: `192.168.2.0` là địa chỉ mạng, `/24` = 24 bit đầu cố định → 8 bit còn lại cho thiết bị → 254 địa chỉ từ `.1` đến `.254`.

## Subnet của WiFi là gì? Có phải là IP của router không?
Subnet của WiFi là dải IP mà router cấp cho các thiết bị WiFi, ví dụ `192.168.2.0/24`. IP của router (`192.168.2.253`) là 1 địa chỉ nằm trong subnet đó, không phải là subnet.

## IP mặc định của router thường là `192.168.1.1` hay `192.168.0.1` — tại sao?
Quy ước của nhà sản xuất. `192.168.x.x` là dải IP private (RFC 1918) dành riêng cho mạng nội bộ, không route được trên internet. Router thường lấy địa chỉ đầu tiên trong subnet (`.1`) làm IP của mình.

## Sơ đồ thành phần trong mạng nhà đơn giản?
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

## PC dùng cáp Ethernet thì subnet có khác WiFi không?
Thông thường trong nhà, cùng router thì cùng subnet dù dùng cáp hay WiFi. Có thể khác nếu dùng static IP thủ công — như trường hợp `192.168.2.1` (Ethernet static) tách biệt với `192.168.2.26` (WiFi DHCP).

## Thiết bị cùng router thì luôn cùng subnet và ping trực tiếp được?
Phần lớn đúng, nhưng có ngoại lệ: router có thể cấu hình VLAN hoặc client isolation (WiFi isolation) để cô lập các thiết bị dù cùng subnet. Trong setup nhà bình thường thì đúng.

## Tại sao không dùng `ipconfig` để lấy IP WiFi?
`ipconfig` hiển thị tất cả interfaces, dễ nhầm Ethernet IP (`192.168.2.1`) với WiFi IP (`192.168.2.26`). Dùng `Get-NetIPAddress -InterfaceAlias "Wi-Fi"` để lấy đúng.

## `192.168.2.1` có phải IP WiFi của laptop không?
Không. Đó là Ethernet static IP. IP WiFi là `192.168.2.26`. Khi WiFi hiển thị `169.254.x.x` (APIPA) thì WiFi chưa kết nối được DHCP — không dùng được.
