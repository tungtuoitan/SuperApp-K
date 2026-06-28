---
id: 0
name: "Pitfalls"
---

# có vấn đề gì? 
```cs
public Task<Data> Get()
{
    using var db = new AppDbContext();
    return db.LoadAsync();
}
```
db bị dispose trước khi LoadAsync()

# using được dùng để làm gì?
```cs
using var db = new AppDbContext();
```
để tài nguyên unmanaged tự giải phóng khi ra khỏi scope

# có vấn đề gì?
```cs
public Task<IActionResult> Get()
{
    try { return DoAsync(); }
    catch (Exception ex) 
    { return Handle(ex); }
}
```
exception bị nuốt vì k dùng await

# trong asp.net core, .Result và .Wait có được dùng không?
Không nên. 
Chúng block thread (sync-over-async) → lãng phí thread pool, dưới tải cao gây starvation. Luôn ưu tiên `await`.

# có khi nào cần dùng .result .wait do k dùng được await không?
Hiếm. 
Vd trong constructor, `Main` cũ, hoặc property getter — nơi không thể `async`. Khi đó cân nhắc `GetAwaiter().GetResult()` và chấp nhận rủi ro block. Tốt nhất vẫn refactor để dùng `await`.

# thread pool starvation là gì? 
là pool hết thread

# sync-over-async là gì?
là gọi code async theo kiểu đồng bộ bằng `.Result` / `.Wait()` 
— block thread đứng chờ task xong thay vì await.

# cancellationToken là gì?
là kĩ thuật trong .NET triển khai cooperative cancellation pattern
(code tự kiểm tra token và tự dừng, không bị ép kill.)

# ép kill là gì? 
là runtime ÉP thread dừng 

# ép kill khác gì tự dừng?
ép kill thì state hỏng
ạm dừng thì an toàn, sạch sẽ.

# trong ASP.NET Core luôn luôn tự dừng à?
Đúng. 
.NET hiện đại bỏ `Thread.Abort` — mọi cancellation đều cooperative, code phải tự kiểm tra `CancellationToken`.

# cooperative nghĩa là gì?
là "hợp tác" 
— bên bị hủy tự nguyện phối hợp dừng, không bị ép.

# cooperative cancellation pattern là gì?
là mô hình hủy mà bên bị hủy tự nguyện kiểm tra tín hiệu rồi dừng, thay vì bị ép dừng từ ngoài.
 Caller phát tín hiệu qua `CancellationToken`, code đang chạy tự check `IsCancellationRequested` / `ThrowIfCancellationRequested()`.

# CancellationToken là công nghệ của ai?
của .NET 

# ValueTask có phổ biến trong ASP.net core không?
không
App thường cứ dùng `Task`.

# cách fire-and-forget đúng cách trong ASP.NET Core?
Không dùng scoped service đã inject trực tiếp mà hãy khởi tạo mới cho nó

# tại sao bọc I/O async trong Task.Run trong controller là thừa?
vì I/O async vốn đã không giữ thread trong lúc chờ. cho nên cứ dùng await I/O async là được

# best practice để gọi nhiều IO song song? cho ví dụ?
Dùng `Task.WhenAll` với các task I/O độc lập, không cần `Task.Run`:
```cs
var t1 = _http.GetAsync(url1);
var t2 = _db.LoadAsync(id);
await Task.WhenAll(t1, t2);
```
Lưu ý: không dùng chung 1 DbContext cho các task song song.
