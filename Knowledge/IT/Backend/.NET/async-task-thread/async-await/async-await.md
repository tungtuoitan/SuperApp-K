---
id: 347
name: "async-await"
---

# xxx [id:3405 order:1]
yyy

# async/await dùng để làm gì? [id:3328 order:2]
để tránh lãng phí thread

# lí do await tồn tại ? [id:3329 order:3]
để giải phóng thread trong khi chờ I/O
— thay vì thread ngồi chờ không làm gì, `await` trả thread về Thread Pool để xử lý request khác. Khi I/O xong, task tiếp tục trên thread được cấp lại.

# await nghĩa là gì? [id:3330 order:4]
là "chờ Task này xong rồi tiếp tục".
Cụ thể: trả thread hiện tại về pool, đăng ký callback, khi Task hoàn thành runtime lấy thread từ pool để chạy tiếp phần code sau `await`.

# await dùng với CPU-bound task có phổ biến không? vì sao? [id:3331 order:5]
Không
vì `await` chỉ giải phóng thread khi thread chờ I/O. còn với CPU-bound task thì thread vẫn bận suốt -> k cần giải phóng.

# làm sao để biết được dùng await có lợi hơn là không dùng? vì dùng await thì phải tốn tài nguyên cho context switch [id:3332 order:6]
Rule of thumb: nếu await > vài chục micro giây thì đáng dùng await.

# khi có await thì phần code sau nó đi đâu? [id:3333 order:7]
sẽ là callback gắn vào Task đang chờ.
Khi Task hoàn thành, runtime schedule continuation lên pool thread để chạy tiếp.

<!--# khi nào thread được trả về pool? [id:3341 order:8]
Khi gặp `await` một Task chưa complete.
Lúc đó thread không có việc làm → trả về pool ngay, không chờ. -->

# mỗi khi await thì thread hiện tại luôn được trả về pool có phải không? vì sao? [id:3343 order:9]
Không hoàn toàn.
Nếu Task complete trước khi `await` yield -> thread chạy tiếp mà k cần trả về pool
Chỉ khi Task chưa complete thì `await` mới trả thread về pool.

# các trường hợp phổ biến Task.completed trước khi await yield? [id:3344 order:10]
cache hit trả về `Task.FromResult(value)`,
hoặc I/O cực nhanh xong ngay.

# khi Task hoàn thành trước khi await yield thì sao? [id:3345 order:11]
thread chạy tiếp mà k cần trả về pool

<!--# khi chạy await async() thì khi nào thread thực sự được giải phóng? [id:3412 order:12]
khi chạy đến await đầu tiên trong async() -->

<!--# yield là gì? [id:3413 order:13]
là trả thread về pool -->

<!--# khi nào thread yield? [id:3414 order:14]
Khi `await` một Task chưa complete -->

# khi nào thread k kịp yield ? [id:3415 order:15]
khi task complete quá nhanh

# các trường hợp làm task complete nhanh đến nỗi thread k kịp yield? [id:3416 order:16]
Khi Task đã done trước khi `await` được evaluated"
- cache hit,
- I/O xong ngay trong cùng time slice.
- trong async k có await thật

# hầu hết IO-bound sẽ kịp yield phải không? [id:3417 order:17]
đúng

# ta có thể biết chính xác được cái nào chạy trước hết phải không? task complete vs thread yield [id:3418 order:18]
Không.
Lúc viết code không biết trước — phụ thuộc runtime: cache hit hay miss, network nhanh hay chậm, OS schedule thế nào.

# thứ tự task complete/thread yield có ảnh hưởng kq không? vì sao? [id:3419 order:19]
k ảnh hưởng, vì Kết quả cuối luôn giống nhau
— `await` đảm bảo code sau nó chỉ chạy khi Task xong.
Chỉ khác về performance: complete trước thì tiết kiệm 1 lần context switch, yield trước thì giải phóng thread cho request khác.

<!--# không kịp yield nghĩa là gì? [id:3420 order:20]
`await` kiểm tra Task — nếu đã complete rồi thì chạy tiếp luôn trên thread hiện tại chứ k giải phóng thread -->

<!--# khi nói thread gốc, main thread có nghĩa là thread nào? [id:3421 order:21]
request thread hoặc UI thread tùy ngữ cảnh -->

# batch nghĩa là gì? [id:3400 order:22]
lô / nhóm
là xử lý một lượng lớn item cùng một lúc thay vì từng cái một.
Ngược với stream (xử lý ngay khi có).
Ví dụ: đọc 1000 rows từ DB rồi trả về List → batch. Đọc từng row yield return → stream.

# stream nghĩa là gì? [id:3402 order:23]
là Dòng chảy liên tục của dữ liệu
— xử lý từng phần khi có, không cần chờ toàn bộ.
Ngược với batch (lấy hết rồi xử lý một lần).
Trong .NET: `Stream` (byte), `IEnumerable<T>` (sync), `IAsyncEnumerable<T>` (async) đều là stream theo nghĩa này.

<!--# IAsyncEnumerable có phổ biến k [id:3403 order:24]
Khá phổ biến -->

# khi nào dùng IAsyncEnumerable? [id:3404 order:25]
khi cần stream dữ liệu lớn mà không muốn load hết vào memory.


# có nên dùng async void không? vì sao?
Không. 
vì k trả về Task thì k thể xử lí tiếp được, do đó k thể await và exception bị nuốt

# có cần quan tâm SynchronizationContext không? vì sao?
không
vì Trong ASP.NET Core: **không có** `SynchronizationContext` 
— sau `await`, continuation chạy trên pool thread bất kỳ. 

# việc capture thì tốn tài nguyên à?
Có tốn một chút (allocation + indirection), nhưng overhead nhỏ, không đủ để lo trong app code. Chỉ đáng tối ưu trong hot-path của library.

# trong ASP.NET Core hiện đại,,khi nào thì cần dùng ConfigureAwait(false) ?
k cần dùng,
vì ASP.NET Core không có `SynchronizationContext`. 

# trong ASP.NET Core hiện đại, các lỗi sai thường gặp đi dùng async await?
- `async void` thay vì `async Task` — exception bị nuốt
- `Parallel.ForEach` với `async` lambda — không await được, kết thúc sớm
- fire-and-forget trong controller — dùng disposed DI object, mất exception
- `Task.WhenAll` + `catch (Exception)` — chỉ lấy exception đầu tiên
- `Task.Run(async () => ...)` trả `Task<Task>`, quên `Unwrap()`
- `await` trong `lock` — compile error

# code này có vấn đề gì?
```cs
Parallel.ForEach(items, async item =>
{
    await ProcessAsync(item);
});
```
`Parallel.ForEach` không hiểu `async` lambda: chạy mỗi item như `async void`, không chờ kết quả — `ForEach` kết thúc ngay dù các task chưa xong. Dùng `await Task.WhenAll(items.Select(ProcessAsync))` thay thế.

# parallel.ForEach là gì? có phổ biến không? khi nào dùng? khác gì ForEach thông thường?
Chạy iterations song song trên nhiều thread (CPU-bound parallelism). 
Khá phổ biến cho CPU-bound work. 
Khác `foreach` thường: iterations chạy đồng thời trên nhiều thread thay vì tuần tự. 
Không hợp với `async` lambda — dùng `Task.WhenAll` cho I/O-bound.

# k nên dùng async await bên trong  parallel.ForEach phải không? vì sao?
Đúng. 
`Parallel.ForEach` không hiểu `async` lambda — chạy như `async void`, không await được.

# tại sao có Task.WhenAll() rồi mà vẫn cần parallel.ForEach?
Mục đích khác nhau: `Task.WhenAll` dành cho I/O-bound (nhiều task chờ async, không cần thêm thread); `Parallel.ForEach` dành cho CPU-bound (phân công work trên nhiều thread vật lý để tận dụng đa nhân).

# Task.WhenAll() hoạt động thế nào? 
khi tất cả Task complete mới trả về. 

# có dùng số thread = số task không?
Số thread phụ thuộc vào Task bên trong: I/O-bound có thể không cần thread nào lúc chờ.

# Task.WhenAll(multiple Task.Run( CPU-bound work)) có tương tự Parallel.ForEach không?
Tương tự nhưng không giống hệt. `Task.WhenAll(Task.Run(...))` tạo N task trên pool, không kiểm soát degree of parallelism. `Parallel.ForEach` tự điều tiết số thread song song dựa trên CPU core và `MaxDegreeOfParallelism`.

# tại sao parallel.foreach() k hợp với async await?
`Parallel.ForEach` expect delegate trả `void` — khi truyền `async` lambda thực ra trả `void` (fire-and-forget). `ForEach` không có cách nào chờ các task async hoàn thành.

# có vấn đề gì? vì sao?
```cs
try
{
    await Task.WhenAll(task1, task2, task3);
}
catch (Exception ex){
    Console.log(ex)
}
```
bỏ sót các exception 2,3,4
vì `ex` chỉ chứa exception ĐẦU TIÊN. 

# semaphoreslim có gì khó dùng không?
Có. Nếu quên `Release()` khi exception xảy ra thì semaphore bị leak — thread sau không vào được mãi. Phải wrap `Release()` trong `finally`.

# cách dùng semaphoreslim?
```cs
var sem = new SemaphoreSlim(1, 1);
await sem.WaitAsync();
try { /* critical section */ }
finally { sem.Release(); }
```
Dùng `WaitAsync()` thay `Wait()` để không block thread.

# lưu ý khi dùng semaphoreslim?
- Luôn `Release()` trong `finally`

# nếu quên release() trong semaphoreslim thì sao?
Semaphore bị leak: count không tăng lại, các thread đang chờ `WaitAsync()` block mãi mãi → deadlock/hang toàn bộ code đi qua semaphore đó.

# Semaphore luôn hoạt động nhờ count à?
Đúng. `SemaphoreSlim(initialCount, maxCount)`: `initialCount` = số lần có thể `WaitAsync()` ngay; mỗi `Release()` tăng count 1; khi count = 0, thread tiếp theo phải chờ.

# dispose là gì?
là giải phóng tài nguyên không quản lý (file handle, DB connection, socket) khi object không còn dùng. Thực hiện qua `IDisposable.Dispose()` hoặc `await using` với `IAsyncDisposable`.

# có vấn đề gì?
```cs
public async Task<IActionResult> Post([FromBody] Dto dto)
{
    _ = Task.Run(async () =>
    {
        await Task.Delay(100);
        await _dbContext.SaveAsync(dto); // ObjectDisposedException!
    });
    return Ok();
}
```
Fire-and-forget: `Post()` return ngay, `_dbContext` bị dispose, nhưng task nền vẫn chạy và gọi `SaveAsync` → `ObjectDisposedException`. Exception bị nuốt, không có error handling.

# trong ASP.NET Core hiện đại, .Result và .Wait có được dùng phổ biến không? vì sao?
Không. 
vì chúng Vẫn block thread > gây lãng phí thread pool.

# vấn đề gì?
```cs
Task<Task> outer = Task.Run(async () =>
{
    await Task.Delay(1000);
});
await outer;
```
`Task.Run(async () => ...)` trả `Task<Task>`. `await outer` chỉ await outer task (xong khi lambda bắt đầu chạy), không chờ inner task (`Delay`). Dùng `await outer.Unwrap()` hoặc `await await outer`.

# vấn đề gì?
```cs
private int _count = 0;

lock (_locker)
{
    await DoSomethingAsync(); 
}
```
`await` trong `lock` là compile error

# tại sao await trong lock lại bị compile error?
Vì sau `await` continuation có thể chạy trên thread khác, trong khi `lock` yêu cầu được release bởi đúng thread đã acquire. C# compiler cấm để tránh race condition và invalid lock release.

# dùng `await foreach` được à?
Được. Dùng với `IAsyncEnumerable<T>`.

# khi nào cần dùng await foreach?
Khi consume `IAsyncEnumerable<T>` — dữ liệu được produce bất đồng bộ từng phần (DB streaming, real-time feed, file lớn không muốn load hết vào memory).

# lí do await foreach tồn tại là cho phép xử lí dữ liệu từng phần theo cách bất đồng bộ, để không block thread  phải k?
Đúng.

# await foreach hoạt động thế nào?
Mỗi iteration gọi `MoveNextAsync()` trên enumerator — `await` chờ phần tử tiếp theo sẵn sàng rồi tiếp tục. 

# await foreach khác foreach thông thường ở chỗ hoạt động load item sẽ k block thread nữa , có phải không?
Đúng. 
`foreach` gọi `MoveNext()` đồng bộ (block nếu cần chờ); `await foreach` gọi `MoveNextAsync()` — thread trả về pool trong lúc chờ item tiếp theo.

# `await foreach` thường dùng làm gì?
- stream data từ DB, API, file lớn.

# pitfall là gì?
là cạm bẫy — lỗi dễ mắc phải nhưng khó nhận ra khi mới nhìn vào code.

