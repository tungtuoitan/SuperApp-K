---
id: 59
name: "Kill switch"
---

# Kill switch là gì? [id:473 order:1]
Cơ chế inject firewall rule vào OS: chỉ cho traffic đi qua VPN interface, block tất cả interface khác.

# Kill switch được bật và tắt khi nào? [id:474 order:2]
Rule được inject khi bật VPN app, chỉ bị gỡ khi tắt VPN app chủ động.

# Kill switch hoạt động khi VPN tunnel rớt mạng không? [id:475 order:3]
Có. Rule firewall tồn tại độc lập với trạng thái tunnel — tunnel rớt thì traffic bị block hoàn toàn, không lọt ra ngoài.

<!--# Ba trạng thái của kill switch là gì? [id:476 order:4]
VPN bật + tunnel up → traffic đi qua tunnel bình thường. VPN bật + tunnel rớt → traffic bị block. VPN tắt chủ động → rule gỡ, traffic đi thẳng internet. -->

# Mục đích chính của kill switch là gì? [id:477 order:5]
Không cho traffic lọt ra ngoài tunnel khi tunnel không còn — bảo vệ khoảng thời gian tunnel rớt mà người dùng không hay biết.

# Không có kill switch thì điều gì xảy ra? [id:478 order:6]
Khi tunnel rớt, OS tự fallback ra interface thật ngay lập tức — IP thật bị lộ trong vài giây mà người dùng không nhận ra.