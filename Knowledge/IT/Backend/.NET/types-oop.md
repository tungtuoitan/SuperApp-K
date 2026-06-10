---
id: 326
name: "types-oop"
---

# interface khác abstract class thế nào trong C#? [id:2883 order:1]
- Interface: chỉ định nghĩa contract (method/property), không có implementation (từ C# 8 có default impl)
- Abstract class: có thể có implementation, chỉ kế thừa được 1 class, thêm trạng thái (field)

# contract có nghĩa là gì? [id:2884 order:2]
là cam kết về những method/property mà class phải có, không quy định cách implement.

# contract ở đây có phải là dev cam kết với sourcecode không? [id:2885 order:3]
Đúng. Class implement interface = cam kết với compiler/codebase rằng class có đủ method/property mà interface yêu cầu.

# sự khác nhau giữa "định nghĩa" và triển khai? [id:2886 order:4]
Định nghĩa là khai báo signature (tên, tham số, kiểu trả về). Triển khai là viết code thực thi bên trong.

# signature là gì? [id:2887 order:5]
là phần "chữ ký" của method — gồm tên, danh sách tham số (kiểu + thứ tự), và kiểu trả về. Không bao gồm thân method.

# model cũng là 1 class phải không? [id:2888 order:6]
Đúng. Model trong .NET thường là class (hoặc record) đại diện cho 1 entity hay DTO — chỉ chứa property, ít/không có logic.

# các loại class phổ biến? [id:2889 order:7]
- Entity / Model: map với DB
- DTO: truyền data qua API
- Service: chứa business logic
- Repository: truy cập DB
- Controller: nhận HTTP request
- ViewModel: data cho UI