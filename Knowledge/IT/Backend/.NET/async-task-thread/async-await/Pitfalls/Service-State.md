---
id: 362
name: "Service-State"
---

<!--# singleton bị share state thì có vấn đề gì? [id:3560 order:1]
- Race condition khi nhiều request cùng ghi.
- Dữ liệu request này lẫn sang request khác. -->

# "state per-request" là gì? ví dụ? [id:3561 order:2]
là giữ dữ liệu riêng theo từng request, không dùng chung.
Ví dụ: DbContext (track entity của request này), thông tin user đang đăng nhập, transaction hiện tại.

# sự khác nhau giữa state per-request và stateless ? [id:3562 order:3]
State per-request = CÓ state nhưng riêng từng request
Stateless: k GIỮ state nào cả

# tại sao DBContext là state per-request? [id:3563 order:4]
Vì các entity state bên trong DBContext của mỗi request là khác nhau, không thể dùng chung được.

# connection pool có được dùng ở đâu trong web server k nhỉ? [id:3564 order:5]
EF Core có dùng db connection pool

# ví dụ stateless và stateful [id:3565 order:6]
- Stateless: hàm `Sum(list)` — kết quả chỉ phụ thuộc input.
- Stateful: counter giữ `_count` tăng dần qua mỗi lần gọi.

<!--# lưu ý khi dùng dbContext? [id:3566 order:7]
trong 1 request, tránh dùng nhiều dbContext cùng lúc -->

<!--# trong request, fire-and-forget 2 lần gọi update db thì có sao không? [id:3567 order:8]
dễ bị ném lỗi/lỗi data do dbContext là thread-unsafe -->

# nếu service là stateless thì nên dùng lifetime gì? tại sao? [id:3568 order:9]
dùng Singleton ->
vì nó nhẹ nhất.

# statful service thì nên dùng lifetime gì? tại sao? [id:3569 order:10]
Tùy phạm vi state:
nếu state theo request → Scoped;
nếu state toàn app + thread-safe → Singleton.

# ví dụ các stateful service phổ biến? [id:3570 order:11]
- DbContext
- Cache in-memory (state toàn app).
- Service giữ counter / connection tracker.

<!--# so sánh stateful và stateless? [id:3571 order:12]
- Stateless: không giữ state, -> thread-safe.
- Stateful: giữ state, -> cần cẩn thận thread-safe -->

# code này sai gì? [id:3572 order:13]
```cs
public class CacheService // Singleton
{
    public CacheService(AppDbContext db) { } // captured dependency!
}
```

singleton giữ mãi 1 DbContext, request sau dùng context đã dispose → lỗi.

<!--# cách dùng stateful service trong singleton đúng cách? [id:3573 order:14]
tự tạo scope rồi dispose sau khi dùng -->

# service singleton thuần là gì? [id:3574 order:15]
là singleton không phụ thuộc service đời ngắn hơn,
Ví dụ: `IConfiguration`, `ILoggerFactory`, một cache thread-safe.

# tại sao service singleton thuần thì inject thẳng được? [id:3575 order:16]
vì nó sống suốt app, không bị dispose theo request → background job dùng lúc nào cũng còn hợp lệ, không cần tạo scope.

# tại sao singleton phải stateless hoặc threadsafe? [id:3576 order:17]
Vì 1 instance singleton bị mọi request (nhiều thread) dùng đồng thời. Nếu nó giữ mutable state mà không đồng bộ → race condition. Stateless hoặc thread-safe thì mới an toàn.

# bản chất, singleton là global instance, còn scoped là instance được tạo trong request caller phải không? [id:3577 order:18]
Đúng về cơ bản.
Singleton = 1 instance global cả app.
Scoped = 1 instance cho mỗi scope (mặc định mỗi HTTP request), dispose khi scope kết thúc.