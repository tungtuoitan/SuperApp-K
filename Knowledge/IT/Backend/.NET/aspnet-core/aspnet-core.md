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

<!--# Lịch sử phát triển HTTP Server diễn ra thế nào? [id:2744 order:6]
- 1990s: Web server đơn giản, chỉ serve static file
- 2000s: App lớn dần, server serve HTML + chạy PHP + xử lý logic → dev tách ra 2 loại: static server và app server
- 2010s: Framework như Rails, Django, .NET MVC tích hợp HTTP server vào app
- 2016+: ASP.NET Core tích hợp Kestrel, không cần IIS nữa -->

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

# this luôn có nghĩa là tham chiếu instance phải không?
đúng

# param của constructor đến từ đâu?
Từ params khi gọi `new` X(...)

# trong constructor thì khi nào cần dùng this? 
 Chỉ cần dùng khi field và tham số trùng tên. 
 Nếu tên khác (ví dụ tham số là `birds`, field là `birdsPerDay`) thì compiler tự phân biệt được, không cần `this`.

# vai trò lớn nhất của this trong thực tế?
Phân biệt field với tham số trùng tên trong constructor.

# hầu hết this chỉ được dùng trong constructor phải không?
Không. 
# this được dùng và không được dùng ở đâu?
`this` dùng được ở mọi instance method/property. 
không dùng được trong `static` method 
# vì sao this không được dùng trong static method?
vì static không thuộc instance nào.


# Các cách dùng this?
- Phân biệt field với tham số/biến local trùng tên
- Gọi constructor khác trong cùng class (`: this(...)`)
- Pass instance hiện tại ra ngoài (`Foo(this)`)
- Return chính object để chain method (`return this;`)

# trước mỗi object mới thì phải luôn có new à? return new int[] { 0, 2, 5, 3, 7, 8, 4 };
Có với reference type (class, array, delegate) — `new` cấp phát memory trên heap. Value type (struct, int, bool) không cần `new`, gán literal trực tiếp được.
# nếu k dùng new cho object mới thì sao?
bị Compile error 

# vai trò của new?
- cấp phát memory, 
- chạy constructor, 
- trả về reference đến object mới.

# object nào cũng có constructor à?
đúng

# lí do constructor tồn tại?
khởi tạo value cho các field và DI


# literal là gì?
là giá trị viết trực tiếp trong code, không thông qua biến hay constructor. 
Ví dụ: `5`, `"hello"`, `true`, `3.14`, `null`.

# cách khai báo array?
`new int[] {1,2,3}`

# array trong c# là collection à?
Có. Array implement `IEnumerable`, `ICollection`, `IList` nên được tính là collection. Khác `List<T>` ở chỗ size cố định.

# array khác gì collection?
Array là 1 loại collection cụ thể.

# quá trình khởi tạo 1 instance?
4 bước theo thứ tự:
- Cấp phát memory trên heap
- Set field về default (`0`, `null`, `false`)
- Chạy field initializer (ví dụ `int x = 5;` ở chỗ khai báo field)
- Chạy constructor body

# khi intance khởi tạo, constructor sẽ chạy trước hay sẽ khởi tạo field trước?
khởi tạo Field trước

# cách phân biệt constructor và method thông thường?
Constructor: 
    tên trùng tên class, 
    không có return type, 
    gọi qua `new`. 
# constructor bắt buộc k return và k có return type à?
Đúng.
# nếu viết constructor mà có return và return type thì sao?
Compile error. Constructor mà có return type sẽ bị compiler coi là method bình thường — và nếu tên trùng tên class thì compiler báo lỗi vì class không được phép có method trùng tên class.

# có bắt buộc phải có constructor không?
Không. 
# nếu k có constructor thì thế nào?
compiler tự sinh ra default constructor.

# khi nào thì được overwrite member của cha?
Khi member của cha được đánh dấu `virtual` hoặc `abstract`, và class con dùng `override`.

# nếu con cứ viết trùng signature của cha nhưng k dùng override thì sao?
Compiler warning, 
khi dùng method thì body được gọi phụ thuộc vào reference type
# hầu hết trường hợp, viết trùng signature thì sẽ đi kèm override phải không?
Đúng. 
Trùng signature mà cố tình không `override` (method hiding) là edge case hiếm — thường để giữ nguyên hành vi cũ khi gọi qua kiểu cha. Code thực tế gần như luôn dùng `override` để có polymorphism.

# tính kế thừa mặc định diễn ra thế nào?
Class con tự động thừa hưởng mọi member `public`, `protected`, `internal` của cha.

# override keyword dùng để làm gì?
Để class con thay implementation của member `virtual`/`abstract` trong class cha.

# pseudo-code là gì?
là code giả — viết bằng cú pháp gần ngôn ngữ tự nhiên, không compile được, chỉ để diễn đạt ý tưởng thuật toán.

# pseudo-code đọc là gì?
đọc là "sudo-code" (/ˈsuː.doʊ.koʊd/). Tiền tố `pseudo-` nghĩa là "giả".
# pseudo có liên quan đến sudoku hay sudo trong commandline không?
Không. 

# khi nào dùng abstract keyword?
khi chỉ muốn tạo signature

# chức năng của abstract keyword?
- đánh dấu 1 class/member là "template"

# abstract class tương tự interface có phải không?
đúng
# sự khác nhau chính giữa abstract class và interface?
 multi-inherited và single-inherited
# abstract class và interface đều k dùng new được à?
Đúng.

# class có nằm trong class được không?
Được.

# mọi member abstract chỉ là signature, k bao giờ có body phải không?
Đúng. 


# tạo abstract và implement từ abstract, và implement trực tiếp luôn, 2 cách này gọi là gì?
Cách qua abstract gọi là abstraction (một trong 4 nguyên lý OOP). Cách viết thẳng gọi là concrete class — không có lớp trừu tượng ở giữa.
# class dùng abstract gọi là gì?
abstract class
# abstraction là abstract class à?
Không. 
# quan hệ giữa abstraction và abstract class?
Abstract class là công cụ để hiện thực hoá nguyên lý abstraction.

# class k dùng abstract gọi là gì?
concrete class

# new được dùng với gì?
Với reference type (class, array, delegate) và Value type (struct, int…)

# tại sao class chỉ kế thừa được 1 class?
Vì C# cấm multiple class inheritance. 
Quy tắc này áp dụng cho mọi class, không riêng abstract class.
# vì sao c# lại cấm multiple class inheritance?
vì khi 2 cha cùng có method trùng tên, con không biết theo cha nào.
# cho ví dụ về vấn đề của multiple class inheritance?
C++ cho phép: `class C : public A, public B {}` — class `C` kế thừa cả `A` và `B`. Nếu cả `A` và `B` cùng có method `Print()` thì `c.Print()` mơ hồ — đây là diamond problem.
# khi A : B và B : C thì A có liên hệ gì với C không? 
có, C là ông nội của A
# thông thường có cần quan tâm đến class ông nội không? vì sao?
không, vì class cha là đã đủ vì class cha đã có tất cả member của ông nội rồi

# khi nào cần quan tâm tới class ông nội?
chỉ khi cần override member do ông nội khai báo

# cách lựa chọn giữa interface và abstract class?
bắt đầu với interface, và chuyển sang abstract class khi cần thiết
# abstract class có thể chứa code phải không?
Đúng.

# abstract class chỉ có nghĩa là k được khởi tạo, có phải không?
Không hẳn. Ngoài việc cấm khởi tạo, abstract class còn cho phép chứa abstract member (signature không body) bắt class con override — đây mới là điểm chính.
# khi dùng abstract cho member thì chỉ được trong abstract class à?
Đúng. 
# tại sao abstract member không thể nằm trong concrete class?
vì nếu nằm trong concrete class thì khi abstract member được gọi, nó k có body -> sai

# concrete class là gì?
là class thường, không có từ khoá `abstract`

# vì sao abstract class bị cấm new?
Vì abstract class là khuôn — không phải thực thể độc lập. Khi class chứa abstract member thì còn lý do thêm: instance gọi member đó sẽ không có body để chạy.
# tại sao abstract class là khuôn?
vì nó được thiết kế để làm khuôn
# bao nhiêu abstract, bấy nhiêu override phải không?
Đúng. Trừ khi class con cũng `abstract` thì được hoãn việc override xuống đời cháu.
# con và cha đều là abstract, việc này có phổ biến không?
Không. 


# khi con và cha đều là abstract thì con k cần override phải không?
Đúng. 

# lí do override tồn tại?
- triển khai body cho abstract member
# override chỉ được dùng trong class con phải không?
Đúng. 
`override` chỉ có ý nghĩa khi thay implementation của member do class cha khai báo `virtual`/`abstract`. Class gốc (không kế thừa) không có gì để override.

# những từ khoá k thể đi cùng với abstract?
- `sealed`
- `static` 
- `private`
- `virtual` 

# abstract có thể dùng trong mọi class phải không?
hầu hết là thế
# abstract k thể dùng trong class nào?
sealed và static class
# tại sao abstract không được dùng trong static class?
vì abstract class được dùng cho mục đích kế thừa, còn static class thì lại k cho kế thừa -> mâu thuẫn mục đích
# abstract có thể dùng cho mọi member có phải không?
Không. 
# abstract dùng được cho những member nào?
Chỉ dùng được cho method, property, indexer, event. 
# member nào k thể dùng abstract ?
field, constructor, hay member `private`/`static`.

# nếu cha dùng abstract member mà con k triển khai thì sao?
Compile error. 
# rule của kế thừa?
Class con bắt buộc `override` mọi abstract member của cha, trừ khi class con cũng được khai báo là `abstract`.
# chỉ có thể kế thừa từ abstract class phải không?
Không. 
# những class nào không thể kế thừa ?
sealed class
# ta có thể dùng member của abstract class trực tiếp mà k kế thừa không?
Chỉ dùng được `static` member trực tiếp qua tên class. Member instance bắt buộc phải qua instance, mà abstract class lại không `new` được, nên buộc phải kế thừa rồi tạo instance class con.

# rule of thumb là gì? có nghĩa gì?
là quy tắc kinh nghiệm 
— đúng trong đa số trường hợp nhưng không tuyệt đối. Dùng làm điểm xuất phát, gặp ngoại lệ thì điều chỉnh.