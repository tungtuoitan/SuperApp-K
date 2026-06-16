# khi nào dùng abstract keyword?
Khi muốn class/member làm khuôn chung nhưng bắt class con tự implement chi tiết, và không cho phép tạo instance trực tiếp.

# chức năng của abstract keyword?
- chặn dev tạo instance
- bắt dev tự implement ở class con
- đánh dấu 1 class/member là "template"

# abstract class tương tự interface có phải không?
Đúng.

# sự khác nhau chính giữa abstract class và interface?
multi-inherited (interface) và single-inherited (abstract class).

# abstract class và interface đều k dùng new được à?
Đúng.

# vì sao abstract class bị cấm new?
Vì abstract class là khuôn — không phải thực thể độc lập. Khi class chứa abstract member thì còn lý do thêm: instance gọi member đó sẽ không có body để chạy.

# tại sao abstract class là khuôn?
vì nó được thiết kế để làm khuôn.

# class dùng abstract gọi là gì?
abstract class.

# class k dùng abstract gọi là gì?
concrete class.

# concrete class là gì?
là class thường, không có từ khoá `abstract`.

# tạo abstract và implement từ abstract, và implement trực tiếp luôn, 2 cách này gọi là gì?
Cách qua abstract gọi là abstraction (một trong 4 nguyên lý OOP). Cách viết thẳng gọi là concrete class — không có lớp trừu tượng ở giữa.

# abstraction là abstract class à?
Không.

# quan hệ giữa abstraction và abstract class?
Abstract class là công cụ để hiện thực hoá nguyên lý abstraction.

# mọi member abstract chỉ là signature, k bao giờ có body phải không?
Đúng. Member `abstract` chỉ có signature, class con bắt buộc `override` để cung cấp body.

# khi dùng abstract cho member thì chỉ được trong abstract class à?
Đúng.

# tại sao abstract member không thể nằm trong concrete class?
vì nếu nằm trong concrete class thì khi abstract member được gọi, nó k có body -> sai.

# abstract class chỉ có nghĩa là k được khởi tạo, có phải không?
Không hẳn. Ngoài việc cấm khởi tạo, abstract class còn cho phép chứa abstract member (signature không body) bắt class con override — đây mới là điểm chính.

# abstract class có thể chứa code phải không?
Đúng.

# abstract có thể dùng trong mọi class phải không?
hầu hết là thế.

# abstract k thể dùng trong class nào?
sealed và static class.

# tại sao abstract không được dùng trong static class?
vì abstract class được dùng cho mục đích kế thừa, còn static class thì lại k cho kế thừa -> mâu thuẫn mục đích.

# abstract có thể dùng cho mọi member có phải không?
Không.

# abstract dùng được cho những member nào?
Chỉ dùng được cho method, property, indexer, event.

# member nào k thể dùng abstract?
field, constructor, hay member `private`/`static`.

# những từ khoá k thể đi cùng với abstract?
- `sealed`
- `static`
- `private`
- `virtual`

# nếu cha dùng abstract member mà con k triển khai thì sao?
Compile error.

# bao nhiêu abstract, bấy nhiêu override phải không?
Đúng. Trừ khi class con cũng `abstract` thì được hoãn việc override xuống đời cháu.

# con và cha đều là abstract, việc này có phổ biến không?
Không phổ biến nhưng hợp lệ. Thường gặp khi hierarchy sâu — cha định nghĩa khái niệm chung nhất, con-abstract gom thêm logic cho một nhánh, rồi cháu mới là concrete. Ví dụ: `Animal` → `Mammal` (abstract) → `Dog`.

# khi con và cha đều là abstract thì con k cần override phải không?
Đúng. Con có thể override một phần hoặc bỏ qua hoàn toàn — vì con vẫn là abstract, không bị buộc phải đầy đủ. Nghĩa vụ override sẽ rơi xuống concrete class đầu tiên trong chuỗi.

# chỉ có thể kế thừa từ abstract class phải không?
Không.

# ta có thể dùng member của abstract class trực tiếp mà k kế thừa không?
Chỉ dùng được `static` member trực tiếp qua tên class. Member instance bắt buộc phải qua instance, mà abstract class lại không `new` được, nên buộc phải kế thừa rồi tạo instance class con.
