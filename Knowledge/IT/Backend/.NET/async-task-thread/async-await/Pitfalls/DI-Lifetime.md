---
name: "DI-Lifetime"
---

# trong background job, tại sao Không dùng scoped service đã đăng kí?
vì scoped service đi theo request, background job là singleton, khi đó service trong job sẽ bị dispose

# dbContext nên dùng lifetime gì? vì sao?
Scoped.
Vì dbContext là thread-unsafe, mỗi request phải dùng dbContext riêng.

# nếu inject singleton vào scoped service thì có vấn đề gì không? vì sao?
Không. 
vì Singleton sống lâu hơn scoped service nên scoped service dùng thoải mái. 

# cách xác định lifetime cho service?
- nếu Stateless hoặc thread-safe thì chọn Singleton.
- nếu service dùng DBContext, thì chọn Scoped (vd: service nghiệp vụ, repository)
- còn lại thì dùng Transient

# trong 3 lifetime thì cái nào tốt nhất, vì sao?
Không có cái "tốt nhất" vì:
    Singleton tiết kiệm nhưng phải thread-safe. 
    Scoped là an toàn cho web
    Transient linh hoạt nhưng tốn bộ nhớ

# Transient lifetime là ít phổ biến nhất phải không?
Đúng. 
Trong web phần lớn là Scoped (theo request) + một số Singleton. Transient ít dùng nhất, chỉ cho service nhẹ, stateless cần instance mới mỗi lần.

# quy tắc inject?
- chỉ inject service có đời sống ≥ đời của mình.

# khi request thread và thread của background job cùng dùng dbContext thì sẽ bị lỗi phải không? vì sao lỗi? nếu bị lỗi thì cách tránh là gì?
Đúng 
vì DbContext không thread-safe. 
Tránh: background job tạo scope riêng (`IServiceScopeFactory.CreateScope()`) để có DbContext riêng, không dùng chung với request.

# các service trong background job thì nên dùng lifetime gì?
nên tự tạo scope và dispose sau khi dùng

# background job thì có lifetime gì?
singleton

# tại sao k nên new thủ công mà phải tạo qua IServiceScopeFactory.CreateScope() ?
Vì `new` thủ công thì dev phải tự quản lí vòng đời -> cực

# nếu dùng new thì quản lí vòng đời có khó không?
Có. cực ở chỗ phải nhớ Dispose() thủ công 

# nếu k dispose thì chuyện gì xảy ra ?
 connection, file handle, memory không được giải phóng 
 → cạn connection pool, đầy bộ nhớ,...

# resolve nghĩa là gì?
là lấy / khởi tạo một instance service từ DI container (`scope.ServiceProvider.GetService<T>()`).

# resolve có mấy nghĩa?
2 nghĩa: 
(1) DI — lấy instance service từ DI container; 
(2) chung — giải quyết / xác định giá trị 

# cho câu ví dụ dùng resolve?
Tạo scope rồi resolve `DbContext` từ container:
```cs
using var scope = scopeFactory.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<AppDbContext>(); // resolve
```

# scopeFactory.CreateScope() có ý nghĩa gì?
là tạo một DI scope mới — vùng chứa scoped service riêng (vd DbContext riêng). Dùng `using` để xong việc thì dispose toàn bộ scoped service trong scope đó.

# scope trong "DI scope" có nghĩa là gì? giải thích cụ thể
(hiểu phiến phiến thôi)
là PHẠM VI SỐNG của nhóm scoped service. 

HTTP Request được tạo -> SCOPE được tạo
khi SCOPE được tạo -> scoped service được tạo 
khi SCOPE kết thúc. -> scoped service bị dispose

Một SCOPE = một `IServiceScope`; 

# DI container là gì?
là thành phần để triển khai DI pattern

# vai trò của DI Container?
là giúp dev tạo, cung cấp quản lí và dispose service tự động

# vòng đời là gì?
là khoảng thời gian từ lúc object được tạo tới lúc bị hủy.

# tại sao phải xác định lifetime cho service?
Để DI biết tạo bao nhiêu instance và hủy khi nào: 
dùng chung cả app, riêng từng request, hay mới mỗi lần. Sai → rò rỉ state, captive dependency, hoặc dùng object đã dispose.

# singleton, scoped, transient là scope hay là lifetime?
là lifetime (vòng đời). 

# controller, service , repository đều là 1 class hết phải không?
Đúng — đều là class C#. 

# controller có lifetime gì?
scoped

# tại sao controller lại có lifetime scoped?
Vì controller phục vụ đúng 1 request và thường phụ thuộc các scoped service (DbContext). 
Tạo mới mỗi request giúp cô lập state giữa các request.

# tại sao hầu hết service, repo có lifetime scoped?
vì chúng phụ thuộc DBContext

# khi khởi tạo instance trực tiếp thì lifetime là gì? vì sao?
k có lifetime, vì instance này không được đăng kí với DI

# singleton, scoped, transient là scope hay là lifetime ?
là lifetime (vòng đời).
