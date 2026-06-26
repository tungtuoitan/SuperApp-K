---
id: 0
name: "async-await"
---

# async/await dùng để làm gì? [id:2897 order:14]
để tránh lãng phí thread

# lí do await tồn tại ?
để giải phóng thread trong khi chờ I/O
— thay vì thread ngồi chờ không làm gì, `await` trả thread về Thread Pool để xử lý request khác. Khi I/O xong, task tiếp tục trên thread được cấp lại.

# await nghĩa là gì?
là "chờ Task này xong rồi tiếp tục".
Cụ thể: trả thread hiện tại về pool, đăng ký callback, khi Task hoàn thành runtime lấy thread từ pool để chạy tiếp phần code sau `await`.

# await dùng với CPU-bound task có phổ biến không? vì sao?
Không
vì `await` chỉ giải phóng thread khi thread chờ I/O. còn với CPU-bound task thì thread vẫn bận suốt -> k cần giải phóng.

# làm sao để biết được dùng await có lợi hơn là không dùng? vì dùng await thì phải tốn tài nguyên cho context switch
Rule of thumb: nếu await > vài chục micro giây thì đáng dùng await.

# khi có await thì phần code sau nó đi đâu?
sẽ là callback gắn vào Task đang chờ.
Khi Task hoàn thành, runtime schedule continuation lên pool thread để chạy tiếp.

# offload là gì?
là chuyển công việc từ chỗ hiện tại sang chỗ khác
Trong .NET: offload = đẩy code từ thread đang chạy (vd UI thread, request thread) sang thread khác (thường là pool).

# mục đích offload ?
giải phóng thread quan trọng (UI thread, request thread) khỏi công việc nặng/chờ lâu, để thread có thể phục vụ việc khác.

# cách offload phổ biến?
`Task.Run(() => ...)` — đẩy CPU-bound work lên Thread Pool thread để thread chính nhẹ đầu (UI thread hoặc request thread).

# cho ví dụ offload (kèm code)
```csharp
// Offload CPU-bound khỏi request thread
app.MapGet("/hash", async () => {
    var result = await Task.Run(() => BCrypt.HashPassword("secret"));
    return result;
});
```
Request thread được trả về pool ngay khi gặp `await Task.Run`, không bị giữ suốt quá trình hash.

# dùng await chính là offload phải không?
Gần đúng.
`await` offload theo nghĩa "trả thread hiện tại về pool". Còn task được await thì chạy ở đâu (pool thread, kernel I/O) là việc của runtime/task đó.

# offload là loại từ gì? cho ví dụ câu phổ biến?
(v): "We offload the heavy computation to a background thread."
Cũng dùng như noun: "This is an offload to the thread pool."

# chỉ offload được khi không await phải không? vì khi có await thì phải đợi xong thì thread mới chạy tiếp được
Ngược lại. Chính `await` mới là offload — `await` không block thread, nó trả thread về pool, đợi xong mới lấy thread khác chạy tiếp. Nếu KHÔNG await mà gọi blocking → thread bị giữ suốt thời gian chờ, không offload được.

# khi nào thread được trả về pool?
Khi gặp `await` một Task chưa complete.
Lúc đó thread không có việc làm → trả về pool ngay, không chờ.

# khi ta offload sang 1 thread b thì giải phóng thread a nhưng lại tốn b, thì nó có lợi hơn chỗ nào nhỉ?
Lợi khi:
1. a là thread đặc biệt (UI thread, request thread) còn b là pool thread thường.
UI thread block thì app freeze, request thread block thì nghẽn server. Pool thread block thì pool tự co giãn — ít hại hơn.
2. hoạt động là I/O async: không cần thread b nào cả, chỉ kernel xử lý.

# mỗi khi await thì thread hiện tại luôn được trả về pool có phải không? vì sao?
Không hoàn toàn.
Nếu Task complete trước khi `await` yield -> thread chạy tiếp mà k cần trả về pool
Chỉ khi Task chưa complete thì `await` mới trả thread về pool.

# các trường hợp phổ biến Task.completed trước khi await yield?
cache hit trả về `Task.FromResult(value)`,
hoặc I/O cực nhanh xong ngay.

# khi Task hoàn thành trước khi await yield thì sao?
thread chạy tiếp mà k cần trả về pool


# t1,t2,t3 có chạy theo thứ tự k? [atts:async_01]
không. 
Cả 3 task start gần như cùng lúc, thứ tự B1 in ra không đảm bảo.
`Task.WhenAll` chỉ đảm bảo A2 chạy sau khi cả 3 xong — không đảm bảo thứ tự giữa t1/t2/t3.

# WhenAll throw Exception thế nào?
chỉ rethrow exception **đầu tiên** 


# async void (C): exception khong the catch tu ngoai -> luon tu catch ben trong --> giải thích và cho ví dụ
`async void` không trả về `Task`, nên caller không có gì để `await` hay `catch`.
Exception bị throw vào `SynchronizationContext` hiện tại → thường crash app, không bắt được.

# khi nào thì exception k đi vào catch? vì sao
khi exception được throw trong `async void`
vì caller không `await` được nên exception bay ra ngoài scope của `try/catch` đó.

# await async void có hợp lệ không? vì sao?
Không. `async void` trả về `void`, không phải `Task` — compiler không cho `await void`.


# propagate là gì?
lan truyền — exception propagate = exception được chuyển lên caller phía trên qua call stack cho đến khi gặp `catch` xử lý nó.

# SemaphoreSlim là gì? Chức năng?
Là một lock 
cho phép tối đa N thread vào critical section cùng lúc (so với `lock` chỉ cho 1).

# SemaphoreSlim và lock là cơ chế hay gì?
Là synchronization primitive — cơ chế điều phối truy cập vào tài nguyên dùng chung giữa nhiều thread.

# primitive nghĩa là gì?
nguyên thủy / cơ bản nhất

# batch nghĩa là gì?
lô / nhóm
là xử lý một lượng lớn item cùng một lúc thay vì từng cái một.
Ngược với stream (xử lý ngay khi có).
Ví dụ: đọc 1000 rows từ DB rồi trả về List → batch. Đọc từng row yield return → stream.

# ý nghĩa từ semaphore?
Tiếng Latin: "semaphore" = "signal bearer" (người mang tín hiệu).
Xuất phát từ hệ thống tín hiệu đường sắt — cờ hiệu cho phép hoặc chặn tàu vào đoạn đường.
Trong CS: Edsger Dijkstra đặt tên năm 1965 — một biến đếm kiểm soát số lượng process được phép truy cập tài nguyên cùng lúc.

# stream nghĩa là gì?
là Dòng chảy liên tục của dữ liệu 
— xử lý từng phần khi có, không cần chờ toàn bộ.
Ngược với batch (lấy hết rồi xử lý một lần).
Trong .NET: `Stream` (byte), `IEnumerable<T>` (sync), `IAsyncEnumerable<T>` (async) đều là stream theo nghĩa này.

# IAsyncEnumerable có phổ biến k
Khá phổ biến 

# khi nào dùng IAsyncEnumerable?
khi cần stream dữ liệu lớn mà không muốn load hết vào memory.
