---
id: 345
name: "string"
---

# string là mutable hay immutable? [id:3252 order:1]
immutable.

# lí do StringBuilder tồn tại? [id:3253 order:2]
để tiết kiệm tài nguyên,
do nối string trong vòng lặp tạo rất nhiều object tạm, tốn GC.
