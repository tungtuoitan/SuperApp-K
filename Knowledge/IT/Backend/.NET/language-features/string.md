---
name: "string"
---

# string là mutable hay immutable?
immutable.

# lí do StringBuilder tồn tại?
để tiết kiệm tài nguyên,
do nối string trong vòng lặp tạo rất nhiều object tạm, tốn GC.

# == và .Equals() khác nhau thế nào?
với reference type: `==` mặc định so sánh reference (cùng object không). `.Equals()` có thể override để so sánh value. `string` override cả hai để so sánh content — nên với string thì như nhau.
