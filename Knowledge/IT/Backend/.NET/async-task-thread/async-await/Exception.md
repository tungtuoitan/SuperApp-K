---
id: 354
name: "Exception"
---

# trong async mà throw thì sao? [id:3438 order:1]
exception được gói vào Task trả về — không throw ngay tại chỗ gọi.
Chỉ được rethrow khi `await` Task đó hoặc gọi `.Result`/`.Wait()`.

# khi nào throw bị nuốt ? [id:3439 order:2]
khi Task không được await (fire-and-forget)
- → exception âm thầm biến mất.

# tại sao throw nhưng k await thì exception bị nuốt ? [id:3440 order:3]
vì exception được gói trong Task trả về. Nếu không ai `await` Task đó → không ai mở Task ra → exception không bao giờ được rethrow → biến mất.

# làm sao để Exception trong async không bị nuốt ? [id:3441 order:4]
chỉ cần dùng: await hoặc `.Wait()`, `.Result`... là k bị nuốt

# await async void có hợp lệ không? vì sao? [id:3395 order:5]
Không. `async void` trả về `void`, không phải `Task` — compiler không cho `await void`.

# propagate là gì? [id:3396 order:6]
lan truyền — exception propagate = exception được chuyển lên caller phía trên qua call stack cho đến khi gặp `catch` xử lý nó.

# trong bất đồng bộ, khi nào lỗi bị nuốt? [id:3394 order:7]
- khi gọi async mà k dùng await,....
- khi dùng whenAll mà k gom hết exception

# WhenAll throw Exception thế nào? [id:3392 order:9]
chỉ rethrow exception **đầu tiên**

# có chạy vào catch không? vì sao? [id:3442 order:9]
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

# khi có await thì ta luôn bắt được exception trong Task à? vì sao? [id:3443 order:10]
đúng
vì `await` "mở Task" ra