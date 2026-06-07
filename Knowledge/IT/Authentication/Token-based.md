---
id: 277
name: "Token-based"
---

# Token-based phù hợp với hệ thống nào? [id:2305 order:1]
phù hợp với hầu hết các hệ thống

# Token-based không phù hợp với hệ thống nào? [id:2306 order:2]
web server side rendering
hệ thống cần revoke quyền ngay lập tức
hệ thống tài chính/ ngân hàng

# tại sao token-based k phù hợp với hệ thống ngân hàng? [id:2307 order:3]
vì ngân hàng cần bảo mật cao, cần ban user NGAY LẬP TỨC, và token k thể làm điều đó

# tại sao session phù hợp với SSR web, còn token thì không phù hợp? [id:2308 order:4]
vì SSR thì request ban đầu k có bước js nên k gửi token đi được, còn session_id dc gửi TỰ ĐỘNG BỞI BROWER cho nên được