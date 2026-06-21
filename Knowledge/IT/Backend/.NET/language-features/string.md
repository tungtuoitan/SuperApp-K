---
id: 345
name: "string"
---

# string là mutable hay immutable? [id:3252 order:1]
immutable.

# lí do StringBuilder tồn tại? [id:3253 order:2]
để tiết kiệm tài nguyên,
do nối string trong vòng lặp tạo rất nhiều object tạm, tốn GC.

# == và .Equals() khác nhau thế nào? [id:3254 order:3]
với reference type: `==` mặc định so sánh reference (cùng object không). `.Equals()` có thể override để so sánh value. `string` override cả hai để so sánh content — nên với string thì như nhau.