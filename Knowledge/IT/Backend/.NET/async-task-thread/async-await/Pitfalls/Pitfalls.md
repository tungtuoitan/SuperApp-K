---
id: 359
name: "Pitfalls"
---

# có vấn đề gì? [id:3501 order:1]
```cs
public Task<Data> Get()
{
    using var db = new AppDbContext();
    return db.LoadAsync();
}
```

db bị dispose trước khi LoadAsync()

# using được dùng để làm gì? [id:3502 order:2]
```cs
using var db = new AppDbContext();
```

để tài nguyên unmanaged tự giải phóng khi ra khỏi scope

# có vấn đề gì? [id:3503 order:3]
```cs
public Task<IActionResult> Get()
{
    try { return DoAsync(); }
    catch (Exception ex)
    { return Handle(ex); }
}
```

exception bị nuốt vì k dùng await

<!--# trong asp.net core, .Result và .Wait có được dùng không? [id:3504 order:4]
Không nên.
Chúng block thread (sync-over-async) → lãng phí thread pool, dưới tải cao gây starvation. Luôn ưu tiên `await`. -->

# có khi nào cần dùng .result .wait do k dùng được await không? [id:3505 order:5]
Hiếm.
Vd trong constructor, `Main` cũ, hoặc property getter — nơi không thể `async`. Khi đó cân nhắc `GetAwaiter().GetResult()` và chấp nhận rủi ro block. Tốt nhất vẫn refactor để dùng `await`.

# thread pool starvation là gì? [id:3506 order:6]
là pool hết thread

# sync-over-async là gì? [id:3507 order:7]
là gọi code async theo kiểu đồng bộ bằng `.Result` / `.Wait()`
— block thread đứng chờ task xong thay vì await.

# cancellationToken là gì? [id:3508 order:8]
là kĩ thuật trong .NET triển khai cooperative cancellation pattern
(code tự kiểm tra token và tự dừng, không bị ép kill.)

# ép kill là gì? [id:3509 order:9]
là runtime ÉP thread dừng

# ép kill khác gì tự dừng? [id:3510 order:10]
ép kill thì state hỏng
ạm dừng thì an toàn, sạch sẽ.

<!--# trong ASP.NET Core luôn luôn tự dừng à? [id:3511 order:11]
Đúng.
.NET hiện đại bỏ `Thread.Abort` — mọi cancellation đều cooperative, code phải tự kiểm tra `CancellationToken`. -->

# cooperative nghĩa là gì? [id:3512 order:12]
là "hợp tác"
— bên bị hủy tự nguyện phối hợp dừng, không bị ép.

# cooperative cancellation pattern là gì? [id:3513 order:13]
là mô hình hủy mà bên bị hủy tự nguyện kiểm tra tín hiệu rồi dừng, thay vì bị ép dừng từ ngoài.
 Caller phát tín hiệu qua `CancellationToken`, code đang chạy tự check `IsCancellationRequested` / `ThrowIfCancellationRequested()`.

# CancellationToken là công nghệ của ai? [id:3514 order:14]
của .NET

# ValueTask có phổ biến trong ASP.net core không? [id:3515 order:15]
không
App thường cứ dùng `Task`.

<!--# cách fire-and-forget đúng cách trong ASP.NET Core? [id:3516 order:16]
Không dùng scoped service đã inject trực tiếp mà hãy khởi tạo mới cho nó -->

# tại sao bọc I/O async trong Task.Run trong controller là thừa? [id:3517 order:17]
vì I/O async vốn đã không giữ thread trong lúc chờ. cho nên cứ dùng await I/O async là được

# best practice để gọi nhiều IO song song? cho ví dụ? [id:3518 order:18]
Dùng `Task.WhenAll` với các task I/O độc lập, không cần `Task.Run`:
```cs
var t1 = _http.GetAsync(url1);
var t2 = _db.LoadAsync(id);
await Task.WhenAll(t1, t2);
```
Lưu ý: không dùng chung 1 DbContext cho các task song song.