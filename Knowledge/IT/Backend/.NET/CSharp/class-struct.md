# class là gì?
là bản thiết kế cho object — chứa field, property, method. Là reference type.

# struct là gì?
tương tự class nhưng nhẹ hơn
# khi nào nên dùng struct? khi với class nhỏ thì ta thay thế bằng struct được à?
Khi data nhỏ (≤16 byte), immutable, dùng nhiều và muốn tránh allocation trên heap. Ví dụ: `DateTime`, `Point`. Class nhỏ không phải lúc nào cũng nên đổi sang struct — nếu hay copy hoặc cần kế thừa thì giữ class.
# mutable là gì?
là "có thể thay đổi" — mutable object cho phép sửa state sau khi tạo. Đối ngược là immutable (tạo xong không sửa được, ví dụ `string`).

# property là gì?
là cặp `get`/`set` để truy cập field — cú pháp giống biến nhưng có logic. Ví dụ `public int Age { get; set; }`.
# khi dùng trực tiếp 1 class dạng class.x thì lifetime là Transient phải không?
Không liên quan đến DI lifetime. `class.x` là truy cập static member, không tạo instance. Lifetime (Singleton/Scoped/Transient) chỉ áp dụng khi resolve service qua DI container.

# field và property khác nhau thế nào?
Field là biến thật trong class. Property là wrapper truy cập field, có thể thêm validation/logic. Convention: field private, property public.

# method là gì?
là hàm trong class — có signature (tên, tham số, kiểu trả về) và thân thực thi.

# constructor là gì?
là method đặc biệt chạy khi tạo object — cùng tên class, không có kiểu trả về.
# lí do constructor tồn tại?
- Dùng để khởi tạo state khi object được tạo.
