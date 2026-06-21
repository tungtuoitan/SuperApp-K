---
name: "keywords"
---

# ý nghĩa keyword static?
static member thuộc về class, không thuộc instance.
Gọi qua tên class, không cần tạo object.

# đối lập với static là gì?
instance member (non-static)
— mỗi object có bản sao riêng, phải tạo object mới gọi được.

# mặc định là static hay instance?
mặc định là instance.
Phải thêm `static` tường minh thì mới là static member.

# có keyword instance không?
Không.
Instance là mặc định — không cần keyword, không khai báo gì thêm.

# làm sao để tạo instance member?
mặc định là instance, k cần khai báo gì thêm?

# readonly dùng để làm gì? khi nào dùng?
rot: gần giống constant, k thay đổi value sau khi khai báo

# tại sao có const rồi mà vẫn cần readonly?
vì `const` phải biết value lúc compile time và chỉ dùng được với primitive/string. `readonly` cho phép set value lúc runtime qua constructor, dùng được với mọi type (object, struct, collection).

# tại sao const cần biết value lúc compile time?
vì với const, compiler dùng value trực tiếp vào code

# tại sao const chỉ được dùng với primitive/string?
vì chỉ có thể nhét primitive và string vào IL code, k thể nhét reference type được.

# tại sao k thể nhét reference type vào IL code được?
vì phải cần `new` lúc runtime

# khi nào dùng const, khi nào dùng readonly?
dùng const khi hardcode
dùng readonly khi field được set qua constructor

# modifier là gì?
rot: là keyword bổ sung
vào khai báo để thay đổi hành vi: `public`, `private`, `static`, `readonly`, `const`, `abstract`, `sealed`... Mỗi modifier điều chỉnh một khía cạnh (access, lifetime, mutability).

# c#.const được dùng cho gì?
`const` chỉ dùng cho field và local variable.
Không dùng được cho property, method, hay parameter. Kiểu dữ liệu phải là primitive hoặc string — không thể là object/reference type.

# tại sao const k được dùng cho property, method?
vì `const` value được "inline" vào nơi gọi lúc compile, nên không thể có getter/setter (property) hay logic thực thi (method). Property và method cần runtime để chạy, còn const thì không tồn tại ở runtime.

# tại sao nên dùng public const string Blue = "blue"; thay vì public string Blue = "blue";
để code rõ nghĩa hơn, vì biến này là constant

# readonly đi cùng set được không? vì sao?
Không.
vì chúng có ý nghĩa trái ngược: readonly là immutable, còn set là mutable

# sự khác nhau giữa init và set?
`set` cho phép gán bất kỳ lúc nào.
`init` chỉ cho phép gán lần đầu

# sealed class là gì?
là class không thể bị kế thừa.

# khi nào dùng sealed?
khi muốn ngăn kế thừa vì lý do bảo mật hoặc thiết kế (class đã hoàn chỉnh, không muốn bị override). Cũng giúp runtime tối ưu virtual method call.

# sealed giúp bảo mật khỏi hacker à?
Không trực tiếp. `sealed` ngăn attacker extend class để override logic quan trọng (ví dụ override `Authenticate()` để bypass). Nhưng đây là edge case — lý do phổ biến hơn là thiết kế rõ ràng, không muốn class bị extend.

# lí do sealed tồn tại?
để nói với dev rằng k nên extend class

# extend khác gì kế thừa?
Cùng nghĩa.
"Extend" là tiếng Anh, "kế thừa" là tiếng Việt — cả hai đều chỉ việc class con dùng `:`  để thừa hưởng từ class cha.

# ví dụ phổ biến thực tế cần dùng sealed?
`string` trong .NET là sealed. Trong web API: DTO/response class thường sealed. Class xử lý auth/payment nên sealed để ngăn override vô tình.
