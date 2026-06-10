---
id: 22
name: "Access Token Detail"
---

# Audience (aud) trong token là gì? [id:46 order:1]
là Đối tượng nhận token
(thường là URL của API).

# Tại sao Frontend không nên dùng id_token để gọi Backend API? [id:52 order:2]
Vì aud (audience) của id_token là Frontend, không phải Backend → Backend sẽ reject.

# thành phần của header? [id:28 order:3]
- chứa loại thuật toán mã hoá và token type

# Signature trong JWT có vai trò gì? [id:47 order:4]
Dùng để xác minh token do ai ký và dữ liệu có bị thay đổi không.

# các thành phần của body? [id:29 order:5]
- có các thành phần quan trọng dùng cho xác thực:
- exp: thời gian hết hạn
- iss: bên phát hành token
- aud: đối tượng dùng token
- ngoài ra có thể chứa role/permission: dùng để phân quyền

# PKCE là gì và tại sao dùng trong SPA? [id:54 order:6]
Proof Key for Code Exchange – cơ chế bảo mật giúp SPA (Frontend) không cần dùng client_secret.

# id_token và access_token khác nhau như thế nào? [id:55 order:7]
id_token: client dùng nó để biết được user vừa login là ai
access_token: Dùng để gọi API

# OAuth 2.0 và OIDC là gì? [id:56 order:8]
là Framework tiêu chuẩn dùng để uỷ quyền.

# payload trong access token chứa gì? [id:51 order:9]
- chứa thông tin về user/app và quyền truy cập.

# OIDC là gì? [id:57 order:10]
là 1 layer được xây dựng trên nền tảng OAuth 2.0, dùng để xác thực

# encrypt là gì? [id:43 order:11]
là mã hóa

# các Claims liên quan đến user/app trong Payload [id:59 order:12]
sub: ID của user hoặc service principal
oid: Object ID trong Azure
appid: ID của application (client)
tid: Tenant ID

# decrypt là gì? [id:44 order:13]
là giải mã

# ciphertext là gì? [id:45 order:14]
là dữ liệu đã mã hóa

# Các phương pháp xác thực phổ biến? [id:60 order:15]
- Token-based Authentication
- Session-based
- Password-based
- Two-Factor (2FA)
- Multi-Factor (MFA)
- Biometric
- Certificate-based
- Passwordless