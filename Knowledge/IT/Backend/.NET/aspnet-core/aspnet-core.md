---
id: 313
name: "aspnet-core"
---

# ASP.NET Core là gì? [id:2739 order:1]
là web framework chính của .NET, dùng để build API, web app, real-time app.

# ASP.NET Core là HTTP Framework không? [id:2740 order:2]
Có. HTTP Framework là framework dùng để build web server/API — ASP.NET Core đúng định nghĩa này.

# HTTP Framework là gì? [id:2741 order:3]
là framework dùng để build web server và API — xử lý HTTP request/response.

# HTTP Server là gì? [id:2742 order:4]
là phần mềm nhận kết nối mạng và xử lý giao thức HTTP.

# HTTP Server và Web Server khác nhau không? [id:2743 order:5]
Gần như giống nhau. Web server ám chỉ server xử lý request từ browser (chủ yếu HTTP/HTTPS). HTTP server nhấn mạnh rằng server xử lý giao thức HTTP. Hiện nay hai từ dùng thay thế nhau.

# Điểm mạnh của ASP.NET Core là gì? [id:2746 order:7]
- Cross-platform
- High performance

# High performance trong ASP.NET Core nghĩa là gì? [id:2747 order:8]
là: xử lý request nhanh, phục vụ nhiều request cùng lúc, dùng ít CPU/RAM. Đo bằng: latency (ms), throughput (req/s), memory usage (MB).

# Vì sao ASP.NET Core nhanh? [id:2748 order:9]
- Dùng Kestrel (HTTP server viết tối ưu cho .NET)
- Dùng nhiều async/await — thread không bị block
- Pipeline rất nhẹ — chỉ chạy middleware cần thiết

# Vì sao ASP.NET Core có thể cross-platform? [id:2749 order:10]
- Chạy trên CLR, CLR được implement trên nhiều OS
- Không phụ thuộc IIS và Windows API, dùng kernel API cross-platform
- Thư viện chuẩn được thiết kế cross-platform

# Điều kiện để app cross-platform là gì? [id:2750 order:11]
Cần 3 điều kiện:
- Runtime cross-platform (CLR chạy được trên Linux/macOS)
- Thư viện/framework cross-platform
- OS API mà code dùng phải cross-platform

# ASP là gì? [id:2751 order:12]
là Active Server Pages — tên cũ của Microsoft cho công nghệ web server-side scripting. ASP.NET Core không liên quan đến ASP cũ, chỉ giữ tên vì lịch sử.

# this luôn có nghĩa là tham chiếu instance phải không? [id:2960 order:13]
đúng

# param của constructor đến từ đâu? [id:2961 order:14]
Từ params khi gọi `new` X(...)

# trong constructor thì khi nào cần dùng this? [id:2962 order:15]
Chỉ cần dùng khi field và tham số trùng tên.
 Nếu tên khác (ví dụ tham số là `birds`, field là `birdsPerDay`) thì compiler tự phân biệt được, không cần `this`.

# vai trò lớn nhất của this trong thực tế? [id:2963 order:16]
Phân biệt field với tham số trùng tên trong constructor.

# this được dùng và không được dùng ở đâu? [id:2965 order:18]
`this` dùng được ở mọi instance method/property.
không dùng được trong `static` method

# vì sao this không được dùng trong static method? [id:2966 order:19]
vì static không thuộc instance nào.

# Các cách dùng this phổ biến và ví dụ? [id:2967 order:20]
- Phân biệt field với tham số trùng tên: `this.name = name`
- Gọi constructor khác trong class: `: this(...)`
- Pass instance hiện tại ra ngoài: `Foo(this)`
- Chain method: `return this;`

<!--# trước mỗi object mới thì phải luôn có new à? [id:2968 order:21]
Có với reference type (class, array, delegate) — `new` cấp phát memory trên heap. Value type (struct, int, bool) không cần `new`, gán literal trực tiếp được. -->


# object là gì trong .NET?
là instance của 1 class (reference type). 
Tất cả class đều kế thừa `System.Object`. 


# nếu k dùng new cho object mới thì sao? [id:2969 order:22]
bị Compile error

<!--# vai trò của new? [id:2970 order:23]
- cấp phát memory,
- chạy constructor,
- trả về reference đến object mới. -->

# object nào cũng có constructor à? [id:2971 order:24]
đúng

# lí do constructor tồn tại? [id:2972 order:25]
khởi tạo value cho các field và DI

# literal là gì? [id:2973 order:26]
là giá trị viết trực tiếp trong code, không thông qua biến hay constructor.
Ví dụ: `5`, `"hello"`, `true`, `3.14`, `null`.

# cách khai báo array? [id:2974 order:27]
`new int[] {1,2,3}`

# array trong c# là collection à? [id:2975 order:28]
Có. Array implement `IEnumerable`, `ICollection`, `IList` nên được tính là collection. Khác `List<T>` ở chỗ size cố định.

<!--# array khác gì collection? [id:2976 order:29]
Array là 1 loại collection cụ thể. -->

# quá trình khởi tạo 1 instance? [id:2977 order:30]
4 bước theo thứ tự:
- Cấp phát memory trên heap
- Set field về default (`0`, `null`, `false`)
- Chạy field initializer (ví dụ `int x = 5;` ở chỗ khai báo field)
- Chạy constructor body

# khi intance khởi tạo, constructor sẽ chạy trước hay sẽ khởi tạo field trước? [id:2978 order:31]
khởi tạo Field trước
