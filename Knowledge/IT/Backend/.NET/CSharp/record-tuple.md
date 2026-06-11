# record là gì?
là reference type tối ưu cho data — auto generate `Equals`, `GetHashCode`, `ToString` theo property. Hay dùng cho DTO, immutable model. Có từ C# 9.
# khi nào nên dùng record?
- DTO truyền giữa layer
- Immutable model (config, value object)
- Khi cần so sánh bằng giá trị thay vì reference

<!-- # pattern matching là gì?
là cú pháp kiểm tra kiểu/giá trị gọn hơn — `if (obj is Customer c)`, `switch` expression với pattern. -->

<!-- # null-coalescing operator là gì?
- `??`: trả về vế phải nếu vế trái null. `var x = a ?? b;`
- `??=`: gán vế phải nếu vế trái null. `a ??= b;`
- `?.`: null-conditional, không truy cập nếu null. `obj?.Name` -->
<!-- 
# string interpolation là gì?
là cú pháp ghép string bằng `$`: `$"Hello {name}, age {age}"`. Thay cho `string.Format` hay `+`. -->
<!-- 
# verbatim string là gì?
là string với prefix `@` — bỏ qua escape character. `@"C:\path\file"` thay vì `"C:\\path\\file"`. -->

# tuple là gì?
là kiểu chứa nhiều giá trị có tên — `(int Id, string Name) user = (1, "Tung")`.
# khi nào nên dùng tuple ?
Dùng khi muốn trả về nhiều giá trị mà không tạo class.

<!-- # out và ref param khác nhau thế nào?
- `ref`: param phải khởi tạo trước khi gọi
- `out`: param không cần khởi tạo, hàm phải gán giá trị trước khi return -->
