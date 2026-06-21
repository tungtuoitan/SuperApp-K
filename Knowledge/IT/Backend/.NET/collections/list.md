---
name: "list"
---

# C#.List tương tự JS. gì?
JS.Array

# sự khác nhau giữa C#.List và C#.Array?
Array là fixed size, List là dynamic size

# List là abstract của array à?
ROT: đúng.
List là wrapper thêm 1 lớp abstraction quanh array — nó dùng array bên trong để lưu data, nhưng expose API động (Add, Remove, Insert) thay vì index cố định.

# làm con cháu thì có lợi ích gì?
kế thừa mọi thứ từ tổ tiên

# mặc định dùng Collection thay vì Array phải không? vì sao?
Đúng.
vì collection linh hoạt hơn, mạnh hơn.
Trong code app thông thường, nên dùng `List<T>` (hoặc collection phù hợp khác) thay vì array — linh hoạt hơn, API tiện hơn. Chỉ dùng array khi có lý do cụ thể (performance, interop, fixed-size data).

# array và list cái nào phổ biến hơn? vì sao?
List phổ biến hơn.
Vì hầu hết trường hợp cần collection động, dev dùng `List<T>` cho tiện.
Array chỉ phổ biến trong code performance-critical, interop, hoặc khi xử lý dữ liệu cố định (byte buffer, image pixel).

# build trên nền array nghĩa là gì?
bên trong, các collection như `List<T>` dùng 1 array để lưu data thật. Khi array đầy, nó tự cấp phát array mới to hơn rồi copy data sang.

# tại sao collection lại build trên nền array?
vì array là cấu trúc đơn giản và nhanh nhất để lưu phần tử cùng kiểu liên tiếp. Build trên array giúp List vẫn truy cập theo index O(1) như array, chỉ thêm logic resize.

# logic resize k gây bad performance à?
Có gây, nhưng chỉ khi resize.
Mỗi lần đầy, List cấp phát array mới gấp đôi và copy toàn bộ — chi phí O(n) cho lần đó. Nhưng tính trung bình (amortized), thêm 1 phần tử vẫn là O(1).
