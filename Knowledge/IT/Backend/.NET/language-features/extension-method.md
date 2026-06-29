---
id: 342
name: "extension-method"
---

# extension method là gì? [id:3221 order:1]
method thêm vào type đã có mà không sửa source code của type đó. Khai báo là `static method` trong `static class`, với `this` trước param đầu tiên.

<!--# ví dụ extension method? [id:3222 order:2]
`"hello".IsNullOrEmpty()` nếu viết `public static bool IsNullOrEmpty(this string s)`. LINQ methods (`Where`, `Select`, `ToList`...) đều là extension method của `IEnumerable<T>`. -->

<!--# lí do extension method tồn tại? [id:3223 order:3]
để thêm method vào type không sở hữu -->

# type không sở hữu là gì? [id:3224 order:4]
type do người khác viết mà bạn không thể sửa source
— ví dụ: `string`, `DateTime`, hay class từ thư viện bên thứ 3. Extension method cho phép thêm method vào những type này.

# ví dụ cần dùng extension method [id:3225 order:5]
thêm validation vào `string`: `email.IsValidEmail()`.