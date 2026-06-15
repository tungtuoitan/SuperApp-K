---
id: 56
name: "Mã hóa và tunnel"
---

# Mã hóa và tunnel khác nhau như thế nào? [id:457 order:1]
Mã hóa bảo vệ nội dung gói tin. Tunnel ẩn metadata — ai đang nói chuyện với ai, traffic đi đâu.

# Nếu đã mã hóa rồi thì cần tunnel làm gì? [id:458 order:2]
Mã hóa ẩn nội dung nhưng không ẩn IP đích. ISP vẫn thấy bạn kết nối đến server nào. Tunnel ẩn luôn điều đó.

# Tunnel thực chất là gì? [id:459 order:3]
Encapsulation — bọc gói tin bên trong gói tin khác. Router ngoài chỉ thấy lớp header ngoài, không biết bên trong có gì.

# Ai có thể giải mã inner packet? [id:461 order:4]
Chỉ VPN server — vì chỉ server mới có khóa tương ứng.