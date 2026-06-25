---
id: 326
name: "types-oop"
---

# interface khác gì abstract class? [id:2883 order:1]
interface k chứa code,
abstract class có thể chứa code

# contract có nghĩa là gì? [id:2884 order:2]
là cam kết về những method/property mà class phải có, không quy định cách implement.

# contract là ai cam kết với ai? cam kết gì? [id:2885 order:3]
là dev cam kết với compiler/codebase
rằng class có đủ method/property mà interface yêu cầu.

# sự khác nhau giữa "định nghĩa" và triển khai? [id:2886 order:4]
Định nghĩa là khai báo signature (tên, tham số, kiểu trả về). Triển khai là viết code thực thi bên trong.

# signature là gì? [id:2887 order:5]
là phần "chữ ký" của method — gồm tên, danh sách tham số (kiểu + thứ tự), và kiểu trả về. Không bao gồm thân method.

# model cũng là 1 class phải không? [id:2888 order:6]
Đúng.
Model trong .NET thường là class (hoặc record) đại diện cho 1 entity hay DTO — chỉ chứa property, ít/không có logic.

# model class khác gì class thông thường ? [id:3383 order:7]
Không khác gì về mặt kỹ thuật

# các loại class phổ biến? [id:2889 order:8]
- Model, DTO, Service, Repo

# interface khác abstract class thế nào? [id:2905 order:9]
Interface chỉ định nghĩa contract (signature), 1 class implement nhiều interface. Abstract class có thể có code, field, constructor — chỉ kế thừa được 1.

# khi nào dùng abstract class? [id:2906 order:10]
khi cần triển khai abstraction