---
id: 339
name: "casting"
---

# casting là gì? [id:3208 order:1]
là báo compiler "tôi biết object này thực sự là kiểu X" bằng cú pháp `(Type)value`.

# casting trong .NET tương ứng với gì trong typescript? [id:3209 order:2]
ROT: tương ứng với "as"

# khi nào cần dùng casting? [id:3210 order:3]
khi cần type chính xác nhưng compiler không tự convert được
Ví dụ: `(Dog)animal` khi biết `animal` thực sự là `Dog`.

# casting khác gì type conversion? [id:3211 order:4]
casting là báo type, conversion là đổi type

# type conversion trong .NET tương ứng với toNumber(),.. trong js phải k? [id:3212 order:5]
rot: đúng
`Convert.ToInt32()`, `int.Parse()` tương tự `Number()`, `parseInt()` trong JS — đều chuyển từ kiểu không liên quan. Nhưng .NET strict hơn: throw exception nếu input sai định dạng, JS thì trả `NaN`.