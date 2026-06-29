---
id: 58
name: "DNS và resolve hostname"
---

# Resolve hostname là gì? [id:468 order:1]
Quá trình hỏi DNS server để dịch tên miền (vpn.nordvpn.com) thành địa chỉ IP.

# Tại sao phải resolve hostname trước khi kết nối VPN? [id:469 order:2]
Vì máy tính cần địa chỉ IP cụ thể để kết nối — tên miền không dùng trực tiếp được.

# DNS query khi resolve hostname có bị lộ không? [id:470 order:3]
Có. DNS query đi ra trước khi tunnel được tạo, truyền cleartext qua UDP port 53 — ISP và hacker cùng mạng đều thấy.

<!--# Hacker thấy gì từ DNS query của VPN? [id:471 order:4]
Thấy cả tên miền (vpn.nordvpn.com) lẫn IP đích — biết bạn đang dùng VPN nào trước khi tunnel kịp lên. -->

# VPN tốt giải quyết DNS leak bằng cách nào? [id:472 order:5]
Dùng hardcoded IP trong app (không cần DNS) hoặc DNS-over-HTTPS (query mã hóa). Sau khi tunnel lên, mọi DNS query đi trong tunnel — VPN server resolve thay client.