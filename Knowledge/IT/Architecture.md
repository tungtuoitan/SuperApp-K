---
id: 33
name: "Architecture"
---

# lợi ích của public api? [id:200 order:4]
Ẩn implementation detail
Cho phép refactor internal mà không ảnh hưởng consumer
Một entry point duy nhất

# Barrel là gì? [id:201 order:5]
là file index chứa public api của 1 module

# nhược điểm của barrel? [id:202 order:6]
dependency mơ hồ
dễ circular
build chậm trong monorepo