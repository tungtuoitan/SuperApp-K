# interface khác abstract class thế nào trong C#?
- Interface: chỉ định nghĩa contract (method/property), không có implementation (từ C# 8 có default impl)
- Abstract class: có thể có implementation, chỉ kế thừa được 1 class, thêm trạng thái (field)

# contract có nghĩa là gì?
là cam kết về những method/property mà class phải có, không quy định cách implement.

# contract ở đây có phải là dev cam kết với sourcecode không?
Đúng. Class implement interface = cam kết với compiler/codebase rằng class có đủ method/property mà interface yêu cầu.

# sự khác nhau giữa "định nghĩa" và triển khai?
Định nghĩa là khai báo signature (tên, tham số, kiểu trả về). Triển khai là viết code thực thi bên trong.

# signature là gì?
là phần "chữ ký" của method — gồm tên, danh sách tham số (kiểu + thứ tự), và kiểu trả về. Không bao gồm thân method.

# model cũng là 1 class phải không?
Đúng. Model trong .NET thường là class (hoặc record) đại diện cho 1 entity hay DTO — chỉ chứa property, ít/không có logic.

# các loại class phổ biến?
- Entity / Model: map với DB
- DTO: truyền data qua API
- Service: chứa business logic
- Repository: truy cập DB
- Controller: nhận HTTP request
- ViewModel: data cho UI
