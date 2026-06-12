# record là gì?
là reference type tối ưu cho data — auto generate `Equals`, `GetHashCode`, `ToString` theo property. Hay dùng cho DTO, immutable model. Có từ C# 9.
# khi nào nên dùng record?
- DTO truyền giữa layer
- Immutable model (config, value object)
- Khi cần so sánh bằng giá trị thay vì reference


# tuple là gì?
là kiểu chứa nhiều giá trị có tên — `(int Id, string Name) user = (1, "Tung")`.
# khi nào nên dùng tuple ?
Dùng khi muốn trả về nhiều giá trị mà không tạo class.
