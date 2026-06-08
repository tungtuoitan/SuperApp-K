---
id: 25
name: "Token-based"
---

# Token-based phù hợp với hệ thống nào? [id:62 order:12]
phù hợp với hầu hết các hệ thống

# Token-based không phù hợp với hệ thống nào? [id:228 order:16]
web server side rendering
hệ thống cần revoke quyền ngay lập tức
hệ thống tài chính/ ngân hàng

# tại sao token-based k phù hợp với hệ thống ngân hàng? [id:229 order:17]
vì ngân hàng cần bảo mật cao, cần ban user NGAY LẬP TỨC, và token k thể làm điều đó

# tại sao session phù hợp với SSR web, còn token thì không phù hợp? [id:230 order:18]
vì SSR thì request ban đầu k có bước js nên k gửi token đi được, còn session_id dc gửi TỰ ĐỘNG BỞI BROWER cho nên được