# Firewall Windows — TCP, Bind, GPO, WiFi Profile

## TCP là gì?
Transmission Control Protocol — giao thức truyền dữ liệu đảm bảo gói tin đến đúng thứ tự, không mất mát, có xác nhận. HTTP/HTTPS đều chạy trên TCP.

## Vai trò của TCP?
Đảm bảo dữ liệu truyền đi đúng thứ tự, không mất mát, có xác nhận. Nếu packet bị mất, TCP tự gửi lại.

## Inbound là gì?
Traffic đi **vào** máy (từ bên ngoài vào). Outbound = traffic đi ra khỏi máy.

## "Bind" nghĩa là gì?
Gắn process lắng nghe vào một địa chỉ IP cụ thể:
- `127.0.0.1:5000` = chỉ nhận connection từ chính máy đó
- `0.0.0.0:5000` = nhận connection từ mọi IP

## `0.0.0.0` nghĩa là gì?
Đại diện cho "tất cả network interfaces". Khi bind `0.0.0.0:5000`, process lắng nghe trên cả `localhost`, `192.168.2.26`, `192.168.2.1`, và mọi IP khác của máy.

## Local rule là gì?
Rule firewall được tạo thủ công trên máy (qua Windows Defender Firewall hoặc `netsh`). Ai có quyền admin trên máy đó đều tạo được — kể cả ứng dụng khi cài đặt.

## GPO là gì?
Group Policy Object — cơ chế quản lý cấu hình Windows tập trung. IT Admin tạo trên Active Directory server rồi đẩy xuống máy người dùng, override local settings.

## WiFi profile là gì?
Windows gán một "network profile" cho mỗi mạng WiFi đã từng kết nối: **Public**, **Private**, hoặc **Domain**. Profile xác định mức độ tin cậy → ảnh hưởng đến bộ firewall rules nào được áp dụng.

## Ý nghĩa của Private/Public trong WiFi profile?
- **Private** = mạng tin cậy, mình kiểm soát (nhà, văn phòng) → firewall thoáng hơn, local rules có hiệu lực.
- **Public** = mạng công cộng (quán cà phê, sân bay) → firewall strict hơn, ẩn máy khỏi network discovery.

## Khi request từ A đến B thì TCP connection được thiết lập?
Đúng. Trước khi gửi HTTP request, browser thiết lập TCP connection với server qua 3-way handshake (SYN → SYN-ACK → ACK). Sau đó HTTP request mới đi qua connection đó.

## Firewall là tập hợp các rule, hay còn gì khác?
Firewall gồm: rules (allow/block cụ thể) + default actions (nếu không có rule nào match thì block hay allow?) + profiles (mỗi profile có bộ rules và default action riêng). Rules là thành phần chính, nhưng default action là "lưới an toàn cuối cùng".

## Có 2 loại rule chính là local rule và GPO rule?
Đúng về cơ bản. Ngoài ra còn có connection security rules (IPsec). Thực tế dev chỉ quan tâm 2 loại này. GPO rule luôn được ưu tiên hơn local rule.

## GPO overwrite local rule?
Đúng. Khi có conflict, GPO rule luôn thắng. Hơn nữa GPO có thể tắt hẳn khả năng đọc local rules (`LocalFirewallRules: N/A`).

## So sánh rule và policy?
- **Rule**: điều kiện cụ thể — "allow TCP port 5000 inbound từ mọi IP"
- **Policy (GPO)**: container chứa nhiều rules + settings, áp dụng cho một nhóm máy/user. Policy còn chứa password policy, software deployment policy, v.v.

## WiFi profile chỉ apply cho 1 WiFi cụ thể thôi?
Đúng. Mỗi mạng WiFi (theo SSID) có profile riêng. WiFi nhà = Private, WiFi quán cà phê = Public. Khi kết nối lần đầu, Windows hỏi loại network — lần sau tự nhớ.

## Ai tạo ra WiFi profile?
Windows tự tạo khi lần đầu kết nối và hỏi user chọn Public/Private. Sau đó GPO có thể override hoặc lock profile đó.

## IT helpdesk tạo GPO, còn user tạo local rule?
Đúng về cơ bản. GPO được tạo bởi Domain Admin/IT trên Active Directory server rồi đẩy xuống máy. Local rule thì bất kỳ user nào có quyền admin đều tạo được.

## Chủ WiFi có thể tạo GPO rule không?
Không. GPO là cơ chế của Windows Domain, không liên quan đến WiFi. Chủ WiFi chỉ quản lý router (SSID, password, firewall của router). GPO chỉ IT admin trong môi trường domain mới tạo được.

## Tại sao Windows Firewall block inbound từ external device?
Hành vi mặc định — bảo vệ máy khỏi kết nối không mong muốn. Mọi inbound connection từ device khác đều bị block trừ khi có rule cho phép.

## Firewall xác định device là external device bằng cách nào?
Dựa vào **IP nguồn** của packet. Nếu IP nguồn là `127.0.0.1` hoặc IP của chính máy → internal. Nếu IP nguồn khác (ví dụ `192.168.2.50` của phone) → external → apply inbound rules.

## Trong WiFi profile Public, local rule luôn bị bỏ qua?
Chỉ khi GPO cấu hình `LocalFirewallRules: N/A`. Không phải mặc định luôn thế. Máy cá nhân không join domain thường không bị ảnh hưởng.

## Ai tạo ra local rule?
User hoặc ứng dụng (với quyền admin). Ví dụ: cài game → game tự thêm rule mở port. Hoặc tự thêm thủ công qua Windows Defender Firewall.

## Ví dụ về WiFi profile Public/Private?
- **Public**: kết nối WiFi quán cà phê → Windows hỏi "network này loại gì?" → chọn Public → firewall strict, ẩn máy khỏi network discovery.
- **Private**: WiFi nhà mình → chọn Private → firewall thoáng hơn, máy hiện trong network, local rules có hiệu lực.

## Tại sao tắt local rules lại bảo vệ user?
Ví dụ: bạn cài phần mềm lạ ở quán cà phê → phần mềm tự thêm local rule mở port 8080 → các máy trong quán có thể kết nối vào máy bạn. Nếu profile Public tắt local rules → rule đó vô hiệu → máy bạn an toàn.

## Tại sao profile Private cho phép local rule còn Public thì không?
Windows thiết kế theo mức tin cậy: Private = mạng nhà/văn phòng → tin cậy → local rules được đọc. Public = quán cà phê → không tin cậy → GPO tắt local rules để bảo vệ người dùng khỏi vô tình mở port nguy hiểm.

## Test từ laptop thành công nhưng phone vẫn không reach được — tại sao?
Test từ laptop tới chính laptop (`127.0.0.1`) bypass firewall inbound rules — traffic là loopback, không bị check. Phone là external device với IP khác → bị chặn bởi firewall inbound.

## Tại sao đổi sang Private profile giải quyết vấn đề API pending?
Flow: phone gửi request đến BE port 5000 → Firewall thấy IP nguồn là phone (external) → kiểm tra inbound rules → WiFi ở profile Public → GPO bật `LocalFirewallRules: N/A` → local rule "SuperApp BE 5000" bị bỏ qua → packet bị drop → pending.
Đổi sang Private: GPO không tắt local rules → rule có hiệu lực → allow inbound → request qua được.
