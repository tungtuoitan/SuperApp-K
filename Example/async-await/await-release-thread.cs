// Chay: dotnet script async_thread_release.cs
// Chung minh: request thread duoc giai phong khi gap await I/O dau tien

using System;
using System.Threading;
using System.Threading.Tasks;

Console.WriteLine($"[Main] ThreadId={Thread.CurrentThread.ManagedThreadId}");

var t1 = HandleRequest("Req-1");
var t2 = HandleRequest("Req-2");
var t3 = HandleRequest("Req-3");

await Task.WhenAll(t1, t2, t3);
Console.WriteLine($"[Main] Done. ThreadId={Thread.CurrentThread.ManagedThreadId}");

// Mô phỏng một async controller action
async static Task HandleRequest(string name)
{
    var tid1 = Thread.CurrentThread.ManagedThreadId;
    Console.WriteLine($"[{name}] BEFORE await  => thread={tid1}");

    // === Đây là I/O thật: thread được giải phóng TẠI ĐÂY ===
    await Task.Delay(500); // mô phỏng DB / HTTP call // BÀI HỌC: THREAD ĐƯỢC GIẢI PHÓNG, NHỜ AWAIT

    var tid2 = Thread.CurrentThread.ManagedThreadId;
    Console.WriteLine($"[{name}] AFTER  await  => thread={tid2}  (same={tid1 == tid2})");
}

/*
OUTPUT (thread id thay đổi mỗi lần chạy, nhưng pattern luôn giống nhau):

[Main] ThreadId=1
[Req-1] BEFORE await  => thread=1       <- cả 3 request bắt đầu trên thread 1
[Req-2] BEFORE await  => thread=1       <- thread 1 chưa bị block, nó lần lượt
[Req-3] BEFORE await  => thread=1       <- khởi động cả 3 trước khi await WhenAll
[Req-3] AFTER  await  => thread=4  (same=False)
[Req-1] AFTER  await  => thread=6  (same=False)
[Req-2] AFTER  await  => thread=5  (same=False)
[Main] Done. ThreadId=6

KEY POINTS - chứng minh 3 điều:

1. THREAD ĐƯỢC GIẢI PHÓNG TẠI await:
   - "BEFORE await" của cả 3 request đều in LIÊN TỤC trên thread=1
   - Thread 1 không bị chặn, nó lần lượt khởi động Req-1, Req-2, Req-3
     rồi trả về ngay sau mỗi lần gặp await Task.Delay(500)
   - Nếu thread 1 bị block tại Req-1, thì Req-2 và Req-3 sẽ không bắt đầu được

2. KHÔNG CÓ THREAD NÀO BỊ CHIẾM TRONG LÚC CHỜ I/O:
   - Trong 500ms chờ Task.Delay, thread 1 đã về pool và đang phục vụ việc khác
   - Không có thread nào ngồi "ngủ" 500ms - đây là "There Is No Thread"

3. SAU await, CONTINUATION CHẠY TRÊN THREAD POOL THREAD KHÁC:
   - "AFTER await" in thread=4, 5, 6 - hoàn toàn khác thread=1
   - same=False vì ASP.NET Core không có SynchronizationContext
   - Đây là bình thường và đúng thiết kế

ĐIỀU GÌ XẢY RA Ở TẦNG OS:
   await Task.Delay / HttpClient / DB query
   └─ Thread 1 trả về pool
   └─ OS timer/IO completion port đếm ngầm (không cần thread)
   └─ Khi xong → OS báo qua interrupt
   └─ Thread pool lấy 1 thread rảnh để chạy tiếp continuation

SO SÁNH VỚI Task.Run:
   await Task.Run(() => CpuWork())
   └─ Thread 1 trả về pool (giải phóng thật)
   └─ NHƯNG thread pool thread B BỊ CHIẾM để đốt CPU
   └─ Net = vẫn tốn 1 thread, thêm overhead schedule
*/
