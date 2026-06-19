---
id: 324
name: "memory-resources"
---

# value type và reference type khác nhau gì? [id:2890 order:1]
Value type lưu giá trị ở stack hoặc inline trong object.
Reference type lưu địa chỉ trỏ đến object trên heap

# stack là gì? [id:3104 order:2]
là vùng nhớ của thread

# quan hệ giữa stack và thread? [id:3105 order:3]
- stack luôn được cấp khi thread được tạo

# mỗi thread có mấy stack, mỗi stack có mấy thread? [id:3106 order:4]
luôn luôn là 1 1

# stack chỉ lưu value type và reference phải không? [id:3107 order:5]
Đúng.
Stack chứa local variable kiểu value type (`int`, `struct`) và reference (con trỏ tới object trên heap). Bản thân object reference type vẫn nằm trên heap, chỉ con trỏ ở stack.

# con trỏ là gì? [id:3108 order:6]
là 1 ô nhớ chứa địa chỉ của 1 object.
Trong .NET ẩn đi dưới dạng "reference" — bạn không thấy địa chỉ trực tiếp.

<!--# reference là gì? [id:3109 order:7]
là con trỏ
Reference trong .NET là 1 con trỏ tới object trên heap, nhưng được runtime quản lý — không cho phép arithmetic như C/C++. -->

# trong văn nói, con trỏ, reference, địa chỉ là 1 phải không? [id:3110 order:8]
Gần như vậy.
Trong giao tiếp hằng ngày 3 từ thường được hoán đổi để chỉ "thứ trỏ tới object". Chính xác hơn: "địa chỉ" là giá trị (số ô nhớ), "con trỏ"/"reference" là biến chứa địa chỉ đó. C/C++ tách bạch hơn, .NET thì gộp lại gọi là "reference".

# heap là gì? [id:3111 order:9]
là vùng nhớ dùng chung trong process, lưu object có lifetime dài hơn scope của hàm tạo ra nó. Trong .NET do GC quản lý.

# lí do stack tồn tại? [id:3112 order:10]
dùng để quản lí lifetime của data theo scope HÀM
sinh ra khi vào hàm, mất đi khi ra khỏi hàm

# lí do heap tồn tại? [id:3113 order:11]
Để chứa data chính

# hầu hết data được lưu trong heap phải k? [id:3114 order:12]
Đúng.
Object class, array, string, collection... đều ở heap. Stack chỉ giữ local value type và reference (con trỏ tới heap). Trong app thật, tổng dung lượng data ở heap lớn hơn stack rất nhiều lần.

# khai báo local là khai báo trong 1 hàm à? [id:3115 order:13]
Đúng.
Local variable là biến khai báo trong body của 1 method/function, sống trong scope của hàm đó, hết scope thì biến mất.

# static field sẽ được lưu ở đâu? [id:3116 order:14]
Trong 1 vùng riêng của heap
trong 1 vùng riêng gọi là "high frequency heap" hoặc "loader heap" của AppDomain. Sống suốt vòng đời process, không bị GC dọn theo cách object thường.

<!--# khi nào stack lưu reference type? [id:3117 order:15]
Khi reference đó là local variable: bản thân con trỏ ở stack, object thật vẫn ở heap. -->

# con trỏ được lưu ở đâu? [id:3118 order:16]
lưu trong stack/heap Tùy ngữ cảnh.
Nếu là local reference variable → lưu ở stack.
Nếu là field reference của 1 object → lưu inline trong object đó trên heap.

# khi biến local là refernece type, thì biến được lưu trực tiếp trong stack k cần con trỏ luôn à? [id:3119 order:17]
Không.
object vẫn ở heap, stack chỉ chứa con trỏ trỏ tới nó.

# reference type luôn luôn được lưu trong heap phải không? [id:3120 order:18]
Hầu hết là vậy
Object class luôn nằm trên heap, kể cả khi reference được khai báo local. Trừ khi dùng `Span<T>`, `ref struct` — đó là các trường hợp đặc biệt không phải reference type thông thường.

# khi nào heap lưu value type? [id:3121 order:19]
Khi value type là field của 1 class

# stack và heap khác nhau gì? [id:2891 order:20]
Stack:
    chứa value type.
    lifetime ngắn, theo hàm
    dung lượng 1mb
Heap:
    chứa reference type
    sống lâu dài
    dung lượng nhiều

# mỗi process 1 heap à? [id:3122 order:21]
Đúng.
Mỗi process .NET có 1 managed heap riêng do GC quản lý. Process khác không truy cập được heap của nhau.

# độ lớn giữa stack và heap? [id:2892 order:22]
Stack nhỏ — mặc định 1MB/thread trên Windows. Heap lớn — gần như giới hạn bằng RAM của process.

# boxing và unboxing là gì? [id:2895 order:23]
Boxing: convert value type → object (wrap vào heap). Unboxing: ngược lại, lấy value type ra khỏi object.

# boxing, unboxing k phổ biến phải không? [id:2896 order:24]
Đúng.
Code hiện đại dùng generic (`List<T>`, `Dictionary<K,V>`) nên không cần wrap value type vào `object`. Boxing chỉ còn xuất hiện khi gán value type vào `object` hoặc interface non-generic.

# dung lượng mặc định của stack? [id:3123 order:25]
Stack: 1MB/thread trên Windows, 8MB trên Linux.

# dung lượng mặc định của Heap? [id:3124 order:26]
khoảng vài GB
gần bằng RAM ảo của process

# IDisposable và using statement dùng để làm gì? [id:2845 order:27]
`IDisposable` là interface để giải phóng tài nguyên unmanaged (file, connection, socket). `using` block tự gọi `Dispose()` khi ra khỏi scope.

# tài nguyên unmanaged nghĩa là gì? [id:2846 order:28]
là tài nguyên do OS quản lý chứ không phải CLR — file handle, network socket, DB connection. GC không tự dọn được, phải `Dispose()`.

# tài nguyên process k quản lí thì phải dispose mới dọn được phải không? [id:2847 order:29]
Đúng. Tài nguyên unmanaged (file handle, socket, DB connection) do OS giữ — CLR không tự thu hồi, phải gọi `Dispose()` để OS giải phóng.

<!--# toàn bộ tài nguyên của process là do CLR quản lí à? [id:2848 order:30]
Không. CLR chỉ quản managed memory (object trên heap). Tài nguyên unmanaged như file/socket do OS giữ, CLR không động vào. -->

<!--# tài nguyên của process gồm những gì? [id:2849 order:31]
- Memory (heap, stack)
- File handle, socket, DB connection
- Thread, timer
- Lock, mutex, semaphore
- Environment variables, working dir -->

# heap là tài nguyên của runtime à? [id:2850 order:32]
Đúng (managed heap). CLR cấp phát và quản managed heap, dùng để chứa object. GC quét heap này để dọn rác.

# heap chỉ là 1 phần của tài nguyên process phải k? [id:2851 order:33]
Đúng. Process có nhiều tài nguyên (file, socket, thread, ...), heap chỉ là vùng memory để chứa object.

# dispose là gì? [id:2852 order:34]
là giải phóng tài nguyên unmanaged. Class implement `IDisposable` phải có `Dispose()` để cleanup.

# idisposable và using luôn đi cùng nhau phải không? [id:2923 order:35]
Không bắt buộc. `IDisposable` chỉ định contract `Dispose()`, có thể gọi tay. Nhưng `using` chỉ chạy được với object implement `IDisposable` — nên khi gặp `using` thì luôn có `IDisposable`.

# khi dùng using thì k cần gọi dispose à? tại sao? [id:2924 order:36]
Đúng. Compiler tự sinh `try/finally { obj.Dispose(); }` quanh block `using` — nên `Dispose()` luôn được gọi khi thoát scope, kể cả khi exception.

# trường hợp nào cần dùng dispose? [id:2925 order:37]
Khi object giữ unmanaged resource: file handle, DB connection, socket, stream, timer. GC không tự dọn được resource ngoài managed heap.

# IDisposable và using dùng để làm gì? [id:2926 order:38]
`IDisposable` interface cho object nắm giữ resource cần dọn (file, connection, DB). `using` tự gọi `Dispose()` khi thoát scope, kể cả khi có exception.