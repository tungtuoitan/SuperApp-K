---
id: 259
name: "Architecture"
---

# lợi ích của public api? [id:2207 order:1]
Ẩn implementation detail
Cho phép refactor internal mà không ảnh hưởng consumer
Một entry point duy nhất

# Barrel là gì? [id:2208 order:2]
là file index chứa public api của 1 module

# nhược điểm của barrel? [id:2209 order:3]
dependency mơ hồ
dễ circular
build chậm trong monorepo