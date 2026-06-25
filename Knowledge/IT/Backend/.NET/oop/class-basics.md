---
id: 330
name: "class-basics"
---

# literal là gì? [id:3016 order:1]
là giá trị viết trực tiếp trong code, không thông qua biến hay constructor.
Ví dụ: `5`, `"hello"`, `true`, `3.14`, `null`.

# cách khai báo array? [id:3017 order:2]
`new int[] {1,2,3}`

# Array trong c# kế thừa Icollection à? [id:3018 order:3]
Đúng.
Array implement `ICollection`, `IList`, `IEnumerable`. Nhưng `Add`/`Remove` throw `NotSupportedException` vì size cố định.

# array khác gì collection? [id:3019 order:4]
Array là 1 loại collection cụ thể.

# trước mỗi object mới thì phải luôn có new à? [id:3020 order:5]
Có với reference type (class, array, delegate) — `new` cấp phát memory trên heap. Value type (struct, int, bool) không cần `new`, gán literal trực tiếp được.

# nếu k dùng new cho object mới thì sao? [id:3021 order:6]
bị Compile error.

# khi gọi new thì điều gì diễn ra? [id:3022 order:7]
- cấp phát memory
- chạy constructor
- trả về reference

# object nào cũng có constructor à? [id:3024 order:8]
Đúng.

# lí do constructor tồn tại? [id:3025 order:9]
khởi tạo value cho các field và DI.

# có bắt buộc phải có constructor không? [id:3026 order:10]
Không.

# nếu class k có constructor thì sao? [id:3027 order:11]
compiler tự sinh ra default constructor.

# cách phân biệt constructor và method thông thường? [id:3028 order:12]
Constructor:
- tên trùng tên class
- không có return type
- gọi qua `new`

# constructor bắt buộc k return và k có return type à? [id:3029 order:13]
Đúng.

# nếu viết constructor mà có return và return type thì sao? [id:3030 order:14]
Compile error. Constructor mà có return type sẽ bị compiler coi là method bình thường — và nếu tên trùng tên class thì compiler báo lỗi vì class không được phép có method trùng tên class.

# param của constructor đến từ đâu? [id:3031 order:15]
Từ params khi gọi `new X(...)`.

# this luôn có nghĩa là tham chiếu instance phải không? [id:3032 order:16]
Đúng.

# trong constructor thì khi nào cần dùng this? [id:3033 order:17]
Chỉ cần dùng khi field và tham số trùng tên. Nếu tên khác (ví dụ tham số là `birds`, field là `birdsPerDay`) thì compiler tự phân biệt được, không cần `this`.

# vai trò lớn nhất của this trong thực tế? [id:3034 order:18]
Phân biệt field với tham số trùng tên trong constructor.

# this được dùng và không được dùng ở đâu? [id:3036 order:19]
`this` dùng được ở mọi instance method/property. Không dùng được trong `static` method.

# vì sao this không được dùng trong static method? [id:3037 order:20]
vì static không thuộc instance nào.

# quá trình khởi tạo 1 instance? [id:3039 order:21]
4 bước theo thứ tự:
- Cấp phát memory trên heap
- Set field về default (`0`, `null`, `false`)
- Chạy field initializer (ví dụ `int x = 5;` ở chỗ khai báo field)
- Chạy constructor body

# khi instance khởi tạo, constructor sẽ chạy trước hay sẽ khởi tạo field trước? [id:3040 order:22]
khởi tạo field trước.

# class có nằm trong class được không? [id:3041 order:23]
Được. Gọi là nested class — class khai báo bên trong class khác.

# phân biệt field, property trong object? [id:3125 order:24]
- Field: biến trực tiếp lưu data trong object
- Property: cặp getter/setter wrap quanh field, cho phép validate, lazy load, computed value

# rule of thumb khi chọn property/field? vì sao? [id:3126 order:25]
mặc định dùng property, chỉ dùng field cho biến nội bộ private
vì dùng property thì sau này thay đổi hook vẫn k break code

# sự khác nhau chính giữa field và property? [id:3127 order:26]
Property cho phép chèn hook (validate, log, computed). Field thì không — chỉ là ô nhớ thuần.

# property có phổ biến không? [id:3128 order:27]
Cực phổ biến.
Mọi DTO, entity, ViewModel trong .NET hầu hết toàn là property. Tỉ lệ field public ở code .NET hiện đại gần như bằng 0.

# ví dụ phổ biến cần dùng property? [id:3129 order:28]
- Computed property: `FullName => FirstName + " " + LastName`

# so sánh property và computed state ở FE ? [id:3130 order:29]
giống: đều có thể computed value,
khác: state có cache, còn property k có cache (luôn tính toán mỗi lần gọi)

# khi nào setter được thực thi nhỉ? [id:3131 order:30]
Mỗi khi gán giá trị: `user.Name = "abc"`
→ setter chạy. Đọc property (`var x = user.Name`) thì gọi getter, không gọi setter.

# property có lưu giá trị không? vì sao? [id:3132 order:31]
không lưu, vì bản chất nó là hàm

# const là gì? [id:2913 order:32]
là gán giá trị ngay lúc khai báo, không đổi được.

# var là gì? [id:2914 order:33]
là keyword cho phép compiler tự suy luận type từ giá trị bên phải.