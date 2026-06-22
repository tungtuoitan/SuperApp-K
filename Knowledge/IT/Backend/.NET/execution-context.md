# ExecutionContext là gì?
là container lưu "ambient state" của một logical flow 
— gồm `AsyncLocal` values, `SecurityContext`, `CultureInfo`. Runtime tự capture và flow nó khi queue work item hoặc gặp `await`.

# AsyncLocal là gì?
là biến trong mỗi logical flow of execution, 
không phải mỗi thread. Giá trị tự flow theo `await` và `Task.Run` nhờ `ExecutionContext`.

# AsyncLocal được dùng mặc định trong await, task.Run à?
Đúng. 
.NET runtime tự động capture và flow `ExecutionContext` (chứa `AsyncLocal` values) khi gọi `await` hoặc `Task.Run` — không cần làm gì thêm.

# logical flow of execution là logical work à ?
Đúng, cùng nghĩa.

# ambient nghĩa là gì?
là "xung quanh, có sẵn trong môi trường".
 Trong lập trình: ambient state = state không cần truyền tường minh, code ở bất cứ đâu cũng đọc được mà không cần parameter.

# phát âm ambient?
/ˈæmbiənt/ — "AM-bi-ənt". Nhấn âm đầu.

# lí do ExecutionContext, AsyncLocal tồn tại?
để mang state của caller theo khi công việc chạy qua nhiều thread khác nhau.

# Thread-Local Storage là gì?
là kỹ thuật: mỗi thread lưu bản riêng của một biến
 — thread A và thread B cùng tên biến nhưng không đụng nhau. `[ThreadStatic]` là cách .NET implement TLS.

# lí do Thread-Local Storage tồn tại?
để tránh race condition

# race condition là gì?
là lỗi xảy ra khi 2+ thread đọc/ghi cùng 1 biến đồng thời
kết quả phụ thuộc vào thứ tự chạy (race), không đoán trước được.

# race có nghĩa là gì?
là "cuộc đua". 
Race condition = các thread "đua nhau" để đọc/ghi biến — ai thắng (chạy trước) thì quyết định kết quả, không kiểm soát được.

# ThreadStatic là gì?
là attribute dùng cho field: mỗi thread đọc/ghi bản riêng của field đó, không đụng nhau.

# ThreadStatic k được dùng phổ biến phải k?
Đúng. 
Hiếm dùng trực tiếp vì không flow qua `await`. Code async nên dùng `AsyncLocal` thay thế. `[ThreadStatic]` chỉ hợp lý khi code synchronous và chắc chắn không cross thread.

# lí do ThreadStatic tồn tại?
để implement TLS trong .NET 

# logical work là gì?
là một đơn vị công việc từ góc nhìn lập trình viên 
— ví dụ 1 HTTP request, 1 background job. 
Nó có thể chạy qua nhiều thread (do `await`) nhưng vẫn là "cùng 1 công việc".

# work item và Task là 1 phải không?
Gần đúng
"Work item" là thuật ngữ chung (đơn vị công việc đưa vào queue), 
Task là implementation cụ thể của .NET.
 Mọi Task là work item, nhưng work item không nhất thiết là Task (ví dụ `ThreadPool.QueueUserWorkItem` nhận `Action`, không phải Task).

# flow context nghĩa là gì?
là việc `ExecutionContext` được tự động copy từ nơi tạo work item sang nơi chạy nó. Worker thread nhận task sẽ thấy đúng ambient state của caller.

# "flow" trong flow context nghĩa là gì?
là ĐI THEO — context ĐI THEO logical work qua các thread

# invoke là gì?
là gọi/thực thi một hàm

# invoke có mấy nghĩa ?
1 nghĩa là gọi/thực thi hàm

# logical flow of execution là gì?
đồng nghĩa logical work

# cơ chế AsyncLocal?
lưu giá trị bên trong `ExecutionContext`. 
Mỗi lần set `Value`, runtime tạo `ExecutionContext` mới (copy-on-write) chứa giá trị mới rồi gắn vào thread hiện tại. Khi context được capture và flow, worker thấy đúng giá trị.

# "hàm capture context/snapshot", câu này có đúng không?
Không. 
Runtime capture context, không phải hàm. Nói đúng hơn: "runtime capture `ExecutionContext` khi tạo Task/work item" — hàm chỉ chạy trong context đó, không tự capture.

# trong mỗi Task,ExecutionContext luôn giữ context của caller à?
Đúng. 
Khi tạo Task (`Task.Run`, `await`), runtime tự capture `ExecutionContext` của caller và gắn vào task — worker thread chạy task trong context đó.

# muốn flow theo logical work thì bắt buộc phải dùng AsyncLocal phải không?
Đúng. 
`AsyncLocal<T>` là cơ chế duy nhất trong .NET để value tự flow theo logical work qua thread boundary. Muốn flow thứ gì thì lưu vào `AsyncLocal`.

# copy-on-write là gì?
là kỹ thuật chỉ tạo bản copy khi có thay đổi. 
Khi set `AsyncLocal.Value`, runtime tạo context mới chỉ cho nhánh này thay vì sửa context gốc — nhánh khác không bị ảnh hưởng.

# static field, ThreadStatic, AsyncLocal gọi chung là gì?
là các cơ chế lưu trữ ambient state — state không truyền tường minh qua parameter mà "có sẵn" tại bất cứ đâu trong scope nhất định.

# 'flow qua await' nghĩa là gì?
là context vẫn ở đó cho dù await làm thread thay đổi
là giá trị vẫn còn sau khi `await` — dù continuation chạy ở thread khác, đọc lại vẫn thấy đúng giá trị. `AsyncLocal` làm được điều này, `[ThreadStatic]` thì không.

# AsyncLocal có được dùng phổ biến không?
Có, nhưng thường gián tiếp. 
`Activity.Current` (distributed tracing), `IHttpContextAccessor` (ASP.NET Core), ambient transaction đều dùng `AsyncLocal` bên trong.

# vì sao mỗi thread nên có context của riêng nó?
để tránh race condition

# giải thích đầy đủ lí do ExecutionContext ra đời?
mỗi thread nên có context của riêng nó, và kĩ thuật TLS được triển khai để đạt được điều đó, Nhưng khi logical work được nhiều thread xử lí thì context của logical work k được giữ xuyên suốt, cho nên AsyncLocal + ExecutionContext ra đời để giúp context flow logical work.

# nếu k có TLS thì chuyện gì xảy ra?
thì sẽ bị race-condition

# tại sao ThreadStatic gắn cứng với 1 thread vật lí?
Vì `[ThreadStatic]` lưu giá trị trong slot của OS thread

# allocation có mấy nghĩa, là danh từ hay động từ ?
Danh từ: "sự cấp phát"/ 1 lần cấp phát
Động từ:  "allocate". : cấp phát

# allocation là gì?
là cấp phát bộ nhớ trên heap cho 1 object mới. GC sau đó phải dọn dẹp — nhiều allocation → GC chạy nhiều → tốn CPU.

# closure là gì?
là [hàm + snapshot] các biến từ scope bên ngoài

# closure allocation là gì?
là object chứa tất cả biến mà 1 hàm capture
