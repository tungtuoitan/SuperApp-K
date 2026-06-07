---
id: 305
name: "Tunnel protocol"
---

<!--# VPN dùng những protocol nào? [id:2628 order:1]
WireGuard, IPSec/IKEv2, OpenVPN, L2TP/IPSec, PPTP. -->

<!--# Tại sao VPN cần protocol? [id:2629 order:2]
Để client và server nói cùng "ngôn ngữ" — biết cách đóng gói, mã hóa, trao đổi khóa, và xác thực. -->

<!--# Protocol nào nên dùng hiện nay? [id:2630 order:3]
WireGuard — nhanh nhất, codebase nhỏ (~4k dòng), dễ audit, dùng ChaCha20. -->

<!--# Khi nào dùng OpenVPN thay WireGuard? [id:2631 order:4]
Khi cần vượt firewall strict — OpenVPN chạy qua port 443, traffic trông như HTTPS nên khó bị block. -->

<!--# Tại sao không dùng PPTP? [id:2632 order:5]
MS-CHAPv2 của PPTP đã bị crack. Không an toàn. -->

<!--# L2TP chậm hơn vì sao? [id:2633 order:6]
Double encapsulation — L2TP tạo tunnel, IPSec mã hóa bên trên, hai lớp bọc nên nặng hơn. -->