---
id: 330
name: "class-basics"
---

# literal là gì? [id:3016 order:1]
là giá trị viết trực tiếp trong code, không thông qua biến hay constructor.
Ví dụ: `5`, `"hello"`, `true`, `3.14`, `null`.

# cách khai báo array? [id:3017 order:2]
`new int[] {1,2,3}`

<!--# array trong c# là collection à? [id:3018 order:3]
Có. Array implement `IEnumerable`, `ICollection`, `IList` nên được tính là collection. Khác `List<T>` ở chỗ size cố định. -->

# array khác gì collection? [id:3019 order:4]
Array là 1 loại collection cụ thể.

# trước mỗi object mới thì phải luôn có new à? [id:3020 order:5]
Có với reference type (class, array, delegate) — `new` cấp phát memory trên heap. Value type (struct, int, bool) không cần `new`, gán literal trực tiếp được.

# nếu k dùng new cho object mới thì sao? [id:3021 order:6]
bị Compile error.

# vai trò của new? [id:3022 order:7]
- cấp phát memory
- chạy constructor
- trả về reference đến object mới

<!--# new được dùng với gì? [id:3023 order:8]
Với reference type (class, array, delegate) và value type (struct, int…). -->

# object nào cũng có constructor à? [id:3024 order:9]
Đúng.

# lí do constructor tồn tại? [id:3025 order:10]
khởi tạo value cho các field và DI.

# có bắt buộc phải có constructor không? [id:3026 order:11]
Không.

<!--# nếu k có constructor thì thế nào? [id:3027 order:12]
compiler tự sinh ra default constructor. -->

# cách phân biệt constructor và method thông thường? [id:3028 order:13]
Constructor:
- tên trùng tên class
- không có return type
- gọi qua `new`

# constructor bắt buộc k return và k có return type à? [id:3029 order:14]
Đúng.

# nếu viết constructor mà có return và return type thì sao? [id:3030 order:15]
Compile error. Constructor mà có return type sẽ bị compiler coi là method bình thường — và nếu tên trùng tên class thì compiler báo lỗi vì class không được phép có method trùng tên class.

# param của constructor đến từ đâu? [id:3031 order:16]
Từ params khi gọi `new X(...)`.

# this luôn có nghĩa là tham chiếu instance phải không? [id:3032 order:17]
Đúng.

# trong constructor thì khi nào cần dùng this? [id:3033 order:18]
Chỉ cần dùng khi field và tham số trùng tên. Nếu tên khác (ví dụ tham số là `birds`, field là `birdsPerDay`) thì compiler tự phân biệt được, không cần `this`.

# vai trò lớn nhất của this trong thực tế? [id:3034 order:19]
Phân biệt field với tham số trùng tên trong constructor.

# hầu hết this chỉ được dùng trong constructor phải không? [id:3035 order:20]
Không.

# this được dùng và không được dùng ở đâu? [id:3036 order:21]
`this` dùng được ở mọi instance method/property. Không dùng được trong `static` method.

# vì sao this không được dùng trong static method? [id:3037 order:22]
vì static không thuộc instance nào.

# Các cách dùng this? [id:3038 order:23]
- Phân biệt field với tham số/biến local trùng tên
- Gọi constructor khác trong cùng class (`: this(...)`)
- Pass instance hiện tại ra ngoài (`Foo(this)`)
- Return chính object để chain method (`return this;`)

# quá trình khởi tạo 1 instance? [id:3039 order:24]
4 bước theo thứ tự:
- Cấp phát memory trên heap
- Set field về default (`0`, `null`, `false`)
- Chạy field initializer (ví dụ `int x = 5;` ở chỗ khai báo field)
- Chạy constructor body

# khi instance khởi tạo, constructor sẽ chạy trước hay sẽ khởi tạo field trước? [id:3040 order:25]
khởi tạo field trước.

# class có nằm trong class được không? [id:3041 order:26]
Được. Gọi là nested class — class khai báo bên trong class khác.