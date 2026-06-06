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
## Process hầu hết bind trên IP của chính máy nó đang chạy?
Đúng. Mặc định process bind `127.0.0.1` (chỉ nhận từ localhost) hoặc một IP cụ thể của máy. Ít ai bind `0.0.0.0` vì sẽ nhận connection từ mọi nơi — chỉ làm vậy khi cần expose service ra ngoài (như khi debug mobile).
## `0.0.0.0` nghĩa là gì?
Đại diện cho "tất cả network interfaces". Khi bind `0.0.0.0:5000`, process lắng nghe trên cả `localhost`, `192.168.2.26`, `192.168.2.1`, và mọi IP khác của máy.
## Máy nhận được request từ internet và máy không nhận được thì khác nhau chỗ nào? Gọi là gì?
- **Máy nhận được từ internet** (public server): có **Public IP** — IP duy nhất trên internet, do ISP cấp. Ví dụ server production `157.66.101.51`.
- **Máy không nhận được từ internet** (home/office): có **Private IP** (`192.168.x.x`, `10.x.x.x`) — nằm sau NAT của router, internet không biết địa chỉ cụ thể của máy này.

Laptop của mình là loại 2 — có IP private, không nhận được request trực tiếp từ internet trừ khi router forward port vào.

## Local rule là gì?
Rule firewall được tạo thủ công trên máy (qua Windows Defender Firewall hoặc `netsh`). Ai có quyền admin trên máy đó đều tạo được — kể cả ứng dụng khi cài đặt.

## GPO là gì?
Group Policy Object — cơ chế quản lý cấu hình Windows tập trung. IT Admin tạo trên Active Directory server rồi đẩy xuống máy người dùng, override local settings.

## WiFi profile là gì?
Windows gán một "network profile" cho mỗi mạng WiFi đã từng kết nối: **Public**, **Private**, hoặc **Domain**. Profile xác định mức độ tin cậy → ảnh hưởng đến bộ firewall rules nào được áp dụng.

## Ý nghĩa của Private/Public trong WiFi profile?
- **Private** = mạng tin cậy, mình kiểm soát (nhà, văn phòng) → firewall thoáng hơn, local rules có hiệu lực.
- **Public** = mạng công cộng (quán cà phê, sân bay) → firewall strict hơn, ẩn máy khỏi network discovery.
## Các lợi ích cụ thể mà Public/Private profile mang lại?
**Private**: local firewall rules có hiệu lực (mở port cho dev), máy hiện trong Network Explorer, có thể share file/printer với máy khác.
**Public**: local rules bị ignore (an toàn ở mạng lạ), máy ẩn khỏi Network Discovery, không share file/printer. Phù hợp ở quán cà phê, sân bay.
## Khi request từ A đến B thì TCP connection được thiết lập có phải không?
Đúng. Trước khi gửi HTTP request, browser thiết lập TCP connection với server qua 3-way handshake (SYN → SYN-ACK → ACK). Sau đó HTTP request mới đi qua connection đó.

## Firewall là tập hợp các rule, hay còn gì khác?
Firewall gồm: rules (allow/block cụ thể) + default actions (nếu không có rule nào match thì block hay allow?) + profiles (mỗi profile có bộ rules và default action riêng). Rules là thành phần chính, nhưng default action là "lưới an toàn cuối cùng".
## Rule chỉ có 2 loại là allow/block?
Về cơ bản đúng. Windows Firewall có 3 action: **Allow**, **Block**, và **Allow if secure** (chỉ allow nếu traffic được mã hóa qua IPsec). Thực tế 99% chỉ dùng Allow và Block.
## Có 2 loại rule chính là local rule và GPO rule phải k?
Đúng về cơ bản. Ngoài ra còn có connection security rules (IPsec). Thực tế dev chỉ quan tâm 2 loại này. GPO rule luôn được ưu tiên hơn local rule.

## GPO overwrite local rule?
Đúng. Khi có conflict, GPO rule luôn thắng. Hơn nữa GPO có thể tắt hẳn khả năng đọc local rules (`LocalFirewallRules: N/A`).

## So sánh rule và policy?
- **Rule**: điều kiện cụ thể — "allow TCP port 5000 inbound từ mọi IP"
- **Policy (GPO)**: container chứa nhiều rules + settings, áp dụng cho một nhóm máy/user. Policy còn chứa password policy, software deployment policy, v.v.

## WiFi profile chỉ apply cho 1 WiFi cụ thể thôi phải k?
Đúng. Mỗi mạng WiFi (theo SSID) có profile riêng. WiFi nhà = Private, WiFi quán cà phê = Public. Khi kết nối lần đầu, Windows hỏi loại network — lần sau tự nhớ.

## Ai tạo ra WiFi profile?
Windows tự tạo khi lần đầu kết nối và hỏi user chọn Public/Private. Sau đó GPO có thể override hoặc lock profile đó.
## Ở mobile thì không có WiFi profile?
Đúng. WiFi profile (Public/Private/Domain) là khái niệm của **Windows**. Android và iOS không có cơ chế này — chúng quản lý bảo mật theo cách khác (app permission, sandbox). Mobile không có Windows Firewall nên không liên quan.
## IT helpdesk tạo GPO, còn user tạo local rule?
Đúng về cơ bản. GPO được tạo bởi Domain Admin/IT trên Active Directory server rồi đẩy xuống máy. Local rule thì bất kỳ user nào có quyền admin đều tạo được.

## Chủ WiFi có thể tạo GPO rule không?
Không. GPO là cơ chế của Windows Domain, không liên quan đến WiFi. Chủ WiFi chỉ quản lý router (SSID, password, firewall của router). GPO chỉ IT admin trong môi trường domain mới tạo được.
## Windows Domain là gì?
Mạng máy tính được quản lý tập trung bởi một server gọi là **Domain Controller** (chạy Active Directory). Tất cả máy "join domain" = đều dưới quyền quản lý của IT admin. Admin có thể đẩy GPO, quản lý user/password, cài phần mềm từ xa. Thường thấy trong môi trường công ty.
## Tại sao Windows Firewall block inbound từ external device?
Hành vi mặc định — bảo vệ máy khỏi kết nối không mong muốn. Mọi inbound connection từ device khác đều bị block trừ khi có rule cho phép.

## Firewall xác định device là external device bằng cách nào?
Dựa vào **IP nguồn** của packet. Nếu IP nguồn là `127.0.0.1` hoặc IP của chính máy → internal. Nếu IP nguồn khác (ví dụ `192.168.2.50` của phone) → external → apply inbound rules.

## Trong WiFi profile Public, local rule luôn bị bỏ qua phải không?
không,
Chỉ khi GPO cấu hình `LocalFirewallRules: N/A`. Không phải mặc định luôn thế. Máy cá nhân không join domain thường không bị ảnh hưởng.

## "Domain" trong networking có mấy nghĩa?
3 nghĩa phổ biến:
1. **Windows Domain**: mạng máy tính quản lý tập trung qua Active Directory (công ty, trường học)
2. **Internet domain / DNS domain**: tên miền website — `google.com`, `tungle.uk`
3. **WiFi profile "Domain"**: profile thứ 3 của Windows (ngoài Public/Private) — tự động gán khi máy detect đang trong Windows Domain network
## Ai tạo ra local rule?
User hoặc ứng dụng (với quyền admin). Ví dụ: cài game → game tự thêm rule mở port. Hoặc tự thêm thủ công qua Windows Defender Firewall.

## Ví dụ về WiFi profile Public/Private?
- **Public**: kết nối WiFi quán cà phê → Windows hỏi "network này loại gì?" → chọn Public → firewall strict, ẩn máy khỏi network discovery.
- **Private**: WiFi nhà mình → chọn Private → firewall thoáng hơn, máy hiện trong network, local rules có hiệu lực.
## Network discovery là gì?
Tính năng của Windows cho phép máy "thông báo" sự hiện diện trong mạng và "thấy" các máy khác. Khi bật: máy xuất hiện trong Network Explorer, có thể share file/printer. Khi tắt (profile Public): máy ẩn — các máy khác không thấy trong danh sách.

## Khi thiết bị A bị ẩn khỏi network discovery thì các máy cùng mạng không thể giao tiếp được với A?
Sai. Network discovery chỉ ảnh hưởng đến "danh bạ" — có thấy nhau trong Network Explorer không. Vẫn ping được và kết nối được nếu biết IP. Ẩn discovery ≠ block traffic.
## Tại sao tắt local rules lại bảo vệ user?
Ví dụ: bạn cài phần mềm lạ ở quán cà phê → phần mềm tự thêm local rule mở port 8080 → các máy trong quán có thể kết nối vào máy bạn. Nếu profile Public tắt local rules → rule đó vô hiệu → máy bạn an toàn.
## Tắt local rules không có quá nhiều ý nghĩa trong việc bảo vệ user thông thường?
Đúng. Tác dụng chính là ngăn app/malware tự mở port mà user không hay. Với user bình thường không cài phần mềm lạ thì khác biệt không đáng kể. Dev mới cảm nhận rõ — vì cần mở port cho server local.

## Rules thường được dùng khi nào?
- Dev cần mở port cho local server (như rule "SuperApp BE 5000")
- Cài server software (game server, VPN, web server)
- App tự thêm khi cài (Zoom, Skype, game launchers)
- IT cần block một port/IP cụ thể

## Mặc định khi kết nối WiFi mới thì profile là Public?
Đúng. Windows default gán Public nếu không hỏi. Ở Windows 10/11 thường có popup "Do you want your PC to be discoverable?" — chọn **Yes** = Private, **No** = Public. Nhiều user bấm No cho nhanh → profile Public.

## Người dùng bình thường sẽ không cảm nhận được sự khác biệt?
Đúng. Browser, email, Zalo, YouTube đều hoạt động bình thường với cả 2 profile. Chỉ cảm nhận khi: cần share file với máy khác (cần Private) hoặc cần mở port cho server dev (cần Private để local rule có hiệu lực).

## Tại sao profile Private cho phép local rule còn Public thì không?
Windows thiết kế theo mức tin cậy: Private = mạng nhà/văn phòng → tin cậy → local rules được đọc. Public = quán cà phê → không tin cậy → GPO tắt local rules để bảo vệ người dùng khỏi vô tình mở port nguy hiểm.

## Test từ laptop thành công nhưng phone vẫn không reach được — tại sao?
Test từ laptop tới chính laptop (`127.0.0.1`) bypass firewall inbound rules — traffic là loopback, không bị check. Phone là external device với IP khác → bị chặn bởi firewall inbound.

## Tại sao đổi sang Private profile giải quyết vấn đề API pending?
Flow: phone gửi request đến BE port 5000 → Firewall thấy IP nguồn là phone (external) → kiểm tra inbound rules → WiFi ở profile Public → GPO bật `LocalFirewallRules: N/A` → local rule "SuperApp BE 5000" bị bỏ qua → packet bị drop → pending.
Đổi sang Private: GPO không tắt local rules → rule có hiệu lực → allow inbound → request qua được.

## Mặc định thì Public profile sẽ tắt local rules?
Không phải mặc định của Windows thuần. Đây là do **GPO** cấu hình `LocalFirewallRules: N/A` — chỉ xảy ra khi máy join Windows Domain và IT admin set policy đó. Máy cá nhân không join domain thì Public profile vẫn cho phép local rules bình thường.

## Windows Firewall chỉ đơn giản là tập hợp local rule + GPO rule?
Về cơ bản đúng. Ngoài ra còn có: default action per profile (block all / allow all khi không có rule nào match), và Windows Service Hardening rules (tự động). Nhưng với dev, hiểu "local rule + GPO rule, GPO thắng" là đủ.

## Rule là thành phần chính của policy (GPO)?
Đúng. Policy (GPO) là container chứa nhiều settings, trong đó firewall rules là một loại setting. Policy còn chứa password policy, software deployment policy, registry settings, v.v.

## Giải thích "inbound" trong rule "allow TCP port 5000 inbound từ mọi IP"?
Inbound = traffic đi **vào** máy (từ bên ngoài vào). Outbound = traffic đi **ra** khỏi máy. Rule này nghĩa là: cho phép bất kỳ IP nào gửi packet TCP đến port 5000 của máy này.

## Đổi WiFi từ Public → Private có ý nghĩa gì với dev?
Profile Private cho phép local firewall rules có hiệu lực — rule "SuperApp BE 5000" sẽ được đọc và connection từ phone được allow. Đây là bước cần thiết khi debug mobile qua WiFi IP.

## Thường thì Public profile sẽ tắt local rule?
Không phải "thường". Chỉ xảy ra khi máy **join Windows Domain** và IT admin cấu hình GPO `LocalFirewallRules: N/A`. Máy cá nhân không join domain → Public profile vẫn cho phép local rules. Trường hợp của mình bị chặn là vì máy đang trong môi trường domain có GPO đó.
