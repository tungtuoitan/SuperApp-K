---
name: "Service-State"
---

# singleton bị share state thì có vấn đề gì?
- Race condition khi nhiều request cùng ghi.
- Dữ liệu request này lẫn sang request khác.

# "state per-request" là gì? ví dụ?
là giữ dữ liệu riêng theo từng request, không dùng chung. 
Ví dụ: DbContext (track entity của request này), thông tin user đang đăng nhập, transaction hiện tại.

# sự khác nhau giữa state per-request và stateless ?
State per-request = CÓ state nhưng riêng từng request  
Stateless: k GIỮ state nào cả

# tại sao DBContext là state per-request?
Vì các entity state bên trong DBContext của mỗi request là khác nhau, không thể dùng chung được.

# connection pool có được dùng ở đâu trong web server k nhỉ?
EF Core có dùng db connection pool

# ví dụ stateless và stateful
- Stateless: hàm `Sum(list)` — kết quả chỉ phụ thuộc input.
- Stateful: counter giữ `_count` tăng dần qua mỗi lần gọi.

# lưu ý khi dùng dbContext?
trong 1 request, tránh dùng nhiều dbContext cùng lúc

# trong request, fire-and-forget 2 lần gọi update db thì có sao không?
dễ bị ném lỗi/lỗi data do dbContext là thread-unsafe

# nếu service là stateless thì nên dùng lifetime gì? tại sao?
dùng Singleton ->
vì nó nhẹ nhất.

# statful service thì nên dùng lifetime gì? tại sao?
Tùy phạm vi state: 
nếu state theo request → Scoped; 
nếu state toàn app + thread-safe → Singleton. 

# ví dụ các stateful service phổ biến?
- DbContext 
- Cache in-memory (state toàn app).
- Service giữ counter / connection tracker.

# so sánh stateful và stateless?
- Stateless: không giữ state, -> thread-safe.
- Stateful: giữ state, -> cần cẩn thận thread-safe

# code này sai gì?
```cs
public class CacheService // Singleton
{
    public CacheService(AppDbContext db) { } // captured dependency!
}
```
singleton giữ mãi 1 DbContext, request sau dùng context đã dispose → lỗi.

# cách dùng stateful service trong singleton đúng cách?
tự tạo scope rồi dispose sau khi dùng

# service singleton thuần là gì?
là singleton không phụ thuộc service đời ngắn hơn, 
Ví dụ: `IConfiguration`, `ILoggerFactory`, một cache thread-safe.

# tại sao service singleton thuần thì inject thẳng được?
vì nó sống suốt app, không bị dispose theo request → background job dùng lúc nào cũng còn hợp lệ, không cần tạo scope.

# tại sao singleton phải stateless hoặc threadsafe?
Vì 1 instance singleton bị mọi request (nhiều thread) dùng đồng thời. Nếu nó giữ mutable state mà không đồng bộ → race condition. Stateless hoặc thread-safe thì mới an toàn.

# bản chất, singleton là global instance, còn scoped là instance được tạo trong request caller phải không?
Đúng về cơ bản. 
Singleton = 1 instance global cả app. 
Scoped = 1 instance cho mỗi scope (mặc định mỗi HTTP request), dispose khi scope kết thúc.
