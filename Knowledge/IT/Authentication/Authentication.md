---
id: 23
name: "Authentication"
---

# Uỷ quyền là gì? [id:37 order:1]
là việc cho phép một bên khác thao tác trong phạm vi nhất định thay cho mình, không cần đưa mật khẩu.

# user trao quyền cho web vào gg Drive, so với Azure trao quyền cho user thì khác nhau gì? [id:3617 order:2]
khác về **ai trao cho ai**:
- Drive: **user** trao quyền cho **web/app** truy cập tài nguyên của chính user (delegated, OAuth consent).
- Azure: **admin/tenant** trao quyền cho **user** truy cập tài nguyên của tổ chức (assigned, RBAC).

# ví dụ về Uỷ quyền? [id:38 order:3]
mình vào website SuperApp, nó mở ra trang google và gg hỏi mình: bạn có cho phép SuperApp truy cập vào Drive của bạn không?
khi mình đồng ý thì khi đó: ta đã UỶ QUYỀN cho SuperApp truy cập vào drive của ta

# Uỷ quyền và trao quyền có phải là 1 không? [id:39 order:4]
có, chúng là 1.

# Phân biệt Authentication và authorization? [id:40 order:5]
- authentication là xác thực, còn authorization là trao quyền
- E trước O
- xác thực xong thì mới trao quyền

# Token-based Authentication là gì? [id:61 order:6]
- là xác thực dựa trên Token

# Authentication là gì? [id:64 order:7]
là quá trình xác minh danh tính của user/client trước khi cho truy cập vào tài nguyên/ hệ thống