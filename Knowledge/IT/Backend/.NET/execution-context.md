---
id: 346
name: "execution-context"
---

# ExecutionContext là gì? [id:3258 order:1]
là container lưu "ambient state" của một logical flow
— gồm `AsyncLocal` values, `SecurityContext`, `CultureInfo`. Runtime tự capture và flow nó khi queue work item hoặc gặp `await`.

# AsyncLocal là gì? [id:3259 order:2]
là biến trong mỗi logical flow of execution,
không phải mỗi thread. Giá trị tự flow theo `await` và `Task.Run` nhờ `ExecutionContext`.

# AsyncLocal được dùng mặc định trong await, task.Run à? [id:3260 order:3]
Đúng.
.NET runtime tự động capture và flow `ExecutionContext` (chứa `AsyncLocal` values) khi gọi `await` hoặc `Task.Run` — không cần làm gì thêm.

# logical flow of execution là logical work à ? [id:3261 order:4]
Đúng, cùng nghĩa.

# ambient nghĩa là gì? [id:3262 order:5]
là "xung quanh, có sẵn trong môi trường".
 Trong lập trình: ambient state = state không cần truyền tường minh, code ở bất cứ đâu cũng đọc được mà không cần parameter.

# phát âm ambient? [id:3263 order:6]
/ˈæmbiənt/ — "AM-bi-ənt". Nhấn âm đầu.

# lí do ExecutionContext, AsyncLocal tồn tại? [id:3264 order:7]
để mang state của caller theo khi công việc chạy qua nhiều thread khác nhau.

# Thread-Local Storage là gì? [id:3265 order:8]
là kỹ thuật: mỗi thread lưu bản riêng của một biến
 — thread A và thread B cùng tên biến nhưng không đụng nhau. `[ThreadStatic]` là cách .NET implement TLS.

# lí do Thread-Local Storage tồn tại? [id:3266 order:9]
để tránh race condition

# race condition là gì? [id:3267 order:10]
là lỗi xảy ra khi 2+ thread đọc/ghi cùng 1 biến đồng thời
kết quả phụ thuộc vào thứ tự chạy (race), không đoán trước được.

# race có nghĩa là gì? [id:3268 order:11]
là "cuộc đua".
Race condition = các thread "đua nhau" để đọc/ghi biến — ai thắng (chạy trước) thì quyết định kết quả, không kiểm soát được.

# có cần học ThreadStatic không? vì sao? [id:3269 order:12]
không cần đào sâu — chỉ cần biết tồn tại.
Vì code modern hầu hết async
, mà `[ThreadStatic]` không flow qua `await` → dev nên dùng `AsyncLocal` thay thế.

# ThreadStatic k được dùng phổ biến phải k? [id:3270 order:13]
Đúng.
Hiếm dùng trực tiếp vì không flow qua `await`. Code async nên dùng `AsyncLocal` thay thế. `[ThreadStatic]` chỉ hợp lý khi code synchronous và chắc chắn không cross thread.

# lí do ThreadStatic tồn tại? [id:3271 order:14]
để implement TLS trong .NET

# logical work là gì? [id:3272 order:15]
là một đơn vị công việc từ góc nhìn lập trình viên
— ví dụ 1 HTTP request, 1 background job.
Nó có thể chạy qua nhiều thread (do `await`) nhưng vẫn là "cùng 1 công việc".

# work item và Task là 1 phải không? [id:3273 order:16]
Gần đúng
"Work item" là thuật ngữ chung (đơn vị công việc đưa vào queue),
Task là implementation cụ thể của .NET.
 Mọi Task là work item, nhưng work item không nhất thiết là Task (ví dụ `ThreadPool.QueueUserWorkItem` nhận `Action`, không phải Task).

# flow context nghĩa là gì? [id:3274 order:17]
là việc `ExecutionContext` được tự động copy từ nơi tạo work item sang nơi chạy nó. Worker thread nhận task sẽ thấy đúng ambient state của caller.

# "flow" trong flow context nghĩa là gì? [id:3275 order:18]
là ĐI THEO — context ĐI THEO logical work qua các thread

# invoke là gì? [id:3276 order:19]
là gọi/thực thi một hàm

# invoke có mấy nghĩa ? [id:3277 order:20]
1 nghĩa là gọi/thực thi hàm

# logical flow of execution là gì? [id:3278 order:21]
đồng nghĩa logical work

# cơ chế AsyncLocal? [id:3279 order:22]
lưu giá trị bên trong `ExecutionContext`.
Mỗi lần set `Value`, runtime tạo `ExecutionContext` mới (copy-on-write) chứa giá trị mới rồi gắn vào thread hiện tại. Khi context được capture và flow, worker thấy đúng giá trị.

# "hàm capture context/snapshot", câu này có đúng không? [id:3280 order:23]
Không.
Runtime capture context, không phải hàm. Nói đúng hơn: "runtime capture `ExecutionContext` khi tạo Task/work item" — hàm chỉ chạy trong context đó, không tự capture.

# trong mỗi Task,ExecutionContext luôn giữ context của caller à? [id:3281 order:24]
Đúng.
Khi tạo Task (`Task.Run`, `await`), runtime tự capture `ExecutionContext` của caller và gắn vào task — worker thread chạy task trong context đó.

# muốn flow theo logical work thì bắt buộc phải dùng AsyncLocal phải không? [id:3282 order:25]
Đúng.
`AsyncLocal<T>` là cơ chế duy nhất trong .NET để value tự flow theo logical work qua thread boundary. Muốn flow thứ gì thì lưu vào `AsyncLocal`.

# copy-on-write là gì? [id:3283 order:26]
là kỹ thuật chỉ tạo bản copy khi có thay đổi.
Khi set `AsyncLocal.Value`, runtime tạo context mới chỉ cho nhánh này thay vì sửa context gốc — nhánh khác không bị ảnh hưởng.

# static field, ThreadStatic, AsyncLocal gọi chung là gì? [id:3284 order:27]
là các cơ chế lưu trữ ambient state — state không truyền tường minh qua parameter mà "có sẵn" tại bất cứ đâu trong scope nhất định.

# 'flow qua await' nghĩa là gì? [id:3285 order:28]
là context vẫn ở đó cho dù await làm thread thay đổi
là giá trị vẫn còn sau khi `await` — dù continuation chạy ở thread khác, đọc lại vẫn thấy đúng giá trị. `AsyncLocal` làm được điều này, `[ThreadStatic]` thì không.

# AsyncLocal có được dùng phổ biến không? [id:3286 order:29]
Có, nhưng thường gián tiếp.
`Activity.Current` (distributed tracing), `IHttpContextAccessor` (ASP.NET Core), ambient transaction đều dùng `AsyncLocal` bên trong.

# vì sao mỗi thread nên có context của riêng nó? [id:3287 order:30]
để tránh race condition

# giải thích đầy đủ lí do ExecutionContext ra đời? [id:3288 order:31]
mỗi thread nên có context của riêng nó, và kĩ thuật TLS được triển khai để đạt được điều đó, Nhưng khi logical work được nhiều thread xử lí thì context của logical work k được giữ xuyên suốt, cho nên AsyncLocal + ExecutionContext ra đời để giúp context flow logical work.

# nếu k có TLS thì chuyện gì xảy ra? [id:3289 order:32]
thì sẽ bị race-condition

# tại sao ThreadStatic gắn cứng với 1 thread vật lí? [id:3290 order:33]
Vì `[ThreadStatic]` lưu giá trị trong slot của OS thread

# allocation có mấy nghĩa, là danh từ hay động từ ? [id:3291 order:34]
Danh từ: "sự cấp phát"/ 1 lần cấp phát
Động từ:  "allocate". : cấp phát

# allocation là gì? [id:3292 order:35]
là cấp phát bộ nhớ trên heap cho 1 object mới. GC sau đó phải dọn dẹp — nhiều allocation → GC chạy nhiều → tốn CPU.

# closure là gì? [id:3293 order:36]
là [hàm + snapshot] các biến từ scope bên ngoài

# closure allocation là gì? [id:3294 order:37]
là việc object ẩn được tạo ra tự động
 để giữ snapshot của biến ngoài khi lambda dùng biến bên ngoài