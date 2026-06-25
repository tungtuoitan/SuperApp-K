---
id: 329
name: "abstract"
---

# khi nào dùng abstract keyword? [id:2985 order:1]
Khi muốn class/member làm khuôn chung nhưng bắt class con tự implement chi tiết, và không cho phép tạo instance trực tiếp.

# lí do abstract keyword tồn tại? [id:2986 order:2]
- giúp triển khai abstraction

# abstract class tương tự interface có phải không? [id:2987 order:3]
Đúng.

# sự khác nhau chính giữa abstract class và interface? [id:2988 order:4]
multi-inherited (interface) và single-inherited (abstract class).

# abstract class và interface đều k dùng new được à? [id:2989 order:5]
Đúng.

# vì sao abstract class bị cấm new? [id:2990 order:6]
Vì abstract class là khuôn — không phải thực thể độc lập. Khi class chứa abstract member thì còn lý do thêm: instance gọi member đó sẽ không có body để chạy.

# tại sao abstract class là khuôn? [id:2991 order:7]
vì nó được thiết kế để làm khuôn.

# class dùng abstract gọi là gì? [id:2992 order:8]
abstract class.

# class k dùng abstract gọi là gì? [id:2993 order:9]
concrete class.

# concrete class là gì? [id:2994 order:10]
là class thường, không có từ khoá `abstract`.

# abstraction là abstract class à? [id:2996 order:11]
Không.

# quan hệ giữa abstraction và abstract class? [id:2997 order:12]
Abstract class là công cụ để hiện thực hoá nguyên lý abstraction.

# mọi member abstract chỉ là signature, k bao giờ có body phải không? [id:2998 order:13]
Đúng. Member `abstract` chỉ có signature, class con bắt buộc `override` để cung cấp body.

# khi dùng abstract cho member thì chỉ được trong abstract class à? [id:2999 order:14]
Đúng.

# tại sao abstract member không thể nằm trong concrete class? [id:3000 order:15]
vì nếu nằm trong concrete class thì khi abstract member được gọi, nó k có body -> sai.

# abstract class chỉ có nghĩa là k được khởi tạo, có phải không? [id:3001 order:16]
Không hẳn. Ngoài việc cấm khởi tạo, abstract class còn cho phép chứa abstract member (signature không body) bắt class con override — đây mới là điểm chính.

# abstract class có thể chứa code phải không? [id:3002 order:17]
Đúng.

# abstract k thể dùng với class nào? tại sao? [id:3004 order:18]
sealed và static class.
vì seal và static ngăn k cho kế thừa

# abstract có thể dùng cho mọi member có phải không? [id:3006 order:19]
Không.

# abstract dùng được cho những member nào? [id:3007 order:20]
Chỉ dùng được cho method, property, indexer, event.

# member nào k thể dùng abstract? [id:3008 order:21]
field, constructor, hay member `private`/`static`.

# những từ khoá k thể đi cùng với abstract? [id:3009 order:22]
- `sealed`
- `static`
- `private`
- `virtual`

# nếu cha dùng abstract member mà con k triển khai thì sao? [id:3010 order:23]
Compile error.

# bao nhiêu abstract, bấy nhiêu override phải không? [id:3011 order:24]
Đúng. Trừ khi class con cũng `abstract` thì được hoãn việc override xuống đời cháu.

# con và cha đều là abstract, việc này có phổ biến không? [id:3012 order:25]
Không phổ biến nhưng hợp lệ. Thường gặp khi hierarchy sâu — cha định nghĩa khái niệm chung nhất, con-abstract gom thêm logic cho một nhánh, rồi cháu mới là concrete. Ví dụ: `Animal` → `Mammal` (abstract) → `Dog`.

# khi con và cha đều là abstract thì con k cần override phải không? [id:3013 order:26]
Đúng. Con có thể override một phần hoặc bỏ qua hoàn toàn — vì con vẫn là abstract, không bị buộc phải đầy đủ. Nghĩa vụ override sẽ rơi xuống concrete class đầu tiên trong chuỗi.

# chỉ có thể kế thừa từ abstract class phải không? [id:3014 order:27]
Không.

# ta có thể dùng member của abstract class trực tiếp mà k kế thừa không? [id:3015 order:28]
Chỉ dùng được `static` member trực tiếp qua tên class. Member instance bắt buộc phải qua instance, mà abstract class lại không `new` được, nên buộc phải kế thừa rồi tạo instance class con.