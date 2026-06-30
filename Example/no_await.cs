// att-id:4
// Chung minh: request thread duoc giai phong khi gap await I/O dau tien

using System;
using System.Threading;
using System.Threading.Tasks;

Console.WriteLine($"[Main] ThreadId={Thread.CurrentThread.ManagedThreadId}");

var t1 = HandleRequest("Req-A");
var t2 = HandleRequest("Req-B");
var t3 = HandleRequest("Req-C");

await Task.WhenAll(t1, t2, t3);
Console.WriteLine($"[Main] Done. ThreadId={Thread.CurrentThread.ManagedThreadId}");

async static Task HandleRequest(string name)
{
    var tid1 = Thread.CurrentThread.ManagedThreadId;
    Console.WriteLine($"[{name}] BEFORE await  => thread={tid1}");

     Task.Delay(500); // BÀI HỌC: THREAD K ĐƯỢC GIẢI PHÓNG, DO K CÓ AWAIT

    var tid2 = Thread.CurrentThread.ManagedThreadId;
    Console.WriteLine($"[{name}] AFTER  await  => thread={tid2}  (same={tid1 == tid2})");
}
