---
name: "casting"
---

# casting là gì?
là báo compiler "tôi biết object này thực sự là kiểu X" bằng cú pháp `(Type)value`.

# casting trong .NET tương ứng với gì trong typescript?
ROT: tương ứng với "as"

# khi nào cần dùng casting?
khi cần type chính xác nhưng compiler không tự convert được
Ví dụ: `(Dog)animal` khi biết `animal` thực sự là `Dog`.

# casting khác gì type conversion?
casting là báo type, conversion là đổi type

# type conversion trong .NET tương ứng với toNumber(),.. trong js phải k?
rot: đúng
`Convert.ToInt32()`, `int.Parse()` tương tự `Number()`, `parseInt()` trong JS — đều chuyển từ kiểu không liên quan. Nhưng .NET strict hơn: throw exception nếu input sai định dạng, JS thì trả `NaN`.
