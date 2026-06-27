---
name: "Exception"
---

# trong async mà throw thì sao?
exception được gói vào Task trả về — không throw ngay tại chỗ gọi.
Chỉ được rethrow khi `await` Task đó hoặc gọi `.Result`/`.Wait()`.

# khi nào throw bị nuốt ?
khi Task không được await (fire-and-forget) 
- → exception âm thầm biến mất.

# tại sao throw nhưng k await thì exception bị nuốt ?
vì exception được gói trong Task trả về. Nếu không ai `await` Task đó → không ai mở Task ra → exception không bao giờ được rethrow → biến mất.

# làm sao để Exception trong async không bị nuốt ?
chỉ cần dùng: await hoặc `.Wait()`, `.Result`... là k bị nuốt

# await async void có hợp lệ không? vì sao? [id:3395 order:24]
Không. `async void` trả về `void`, không phải `Task` — compiler không cho `await void`.

# propagate là gì? [id:3396 order:25]
lan truyền — exception propagate = exception được chuyển lên caller phía trên qua call stack cho đến khi gặp `catch` xử lý nó.

<!--# async void (C): exception khong the catch tu ngoai -> luon tu catch ben trong --> giải thích và cho ví dụ [id:3393 order:22]
`async void` không trả về `Task`, nên caller không có gì để `await` hay `catch`.
Exception bị throw vào `SynchronizationContext` hiện tại → thường crash app, không bắt được. -->

<!--# khi nào thì exception k đi vào catch? vì sao [id:3394 order:23]
khi exception được throw trong `async void`
vì caller không `await` được nên exception bay ra ngoài scope của `try/catch` đó. -->

# WhenAll throw Exception thế nào? [id:3392 order:21]
chỉ rethrow exception **đầu tiên**

# có chạy vào catch không? vì sao?
```csharp
var tasks = new List<Task<string>>();
tasks.Add(B());
var allTask = Task.WhenAll(tasks);

try { await allTask; }
catch
{
    // catch
}

async Task<string> B()
{
    throw new Exception($"");
}
```
Có chạy vào catch.
`Task.WhenAll` được `await` → exception trong Task được rethrow ra ngoài → try/catch bắt được. Khác với fire-and-forget (không await) — ở đây có await nên exception "mở Task" ra được.

# khi có await thì ta luôn bắt được exception trong Task à? vì sao?
đúng 
vì `await` "mở Task" ra
