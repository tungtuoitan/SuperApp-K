---
id: 352
name: "Code-examples"
---

# code này chạy thế nào? [id:3422 order:1 open-context]
```csharp
var tasks = new List<Task<string>>();

B();

static async Task<string> B()
{
    throw new Exception($"");
}
```

`B()` được gọi
→ Task trả về ở trạng thái Faulted (vì throw ngay, không có await trước).

# code này có giải phóng thread không? vì sao? [id:3423 order:2]
Không.
`B()` throw ngay, không gặp `await` nào → thread không yield về pool. Thread tiếp tục chạy dòng sau bình thường.

# code này chạy có bị lỗi k? vì sao? [id:3424 order:3]
Không.
`B()` throw nhưng Task không được await → exception bị nuốt, chương trình chạy tiếp bình thường, không crash.

# khi chạy đến B thì có giải phóng thread không? vì sao? [id:3425 order:4]
Không.
vì `B()` throw ngay — không có `await` nào được gặp → thread không yield, không trả về pool.
Exception được gói vào Task trả về, thread tiếp tục chạy dòng tiếp theo bình thường.

# nếu thêm delay vào B (trước throw) thì có giải phóng thread không? vì sao? [id:3426 order:5]
Có,
Khi gặp `await Task.Delay` — Task chưa complete → thread yield về pool.

# nếu dùng `await Task.Delay 1ms` thì có giải phóng thread không? vì sao? [id:3427 order:6 close-context]
Thường là có, nhưng không đảm bảo.
`Task.Delay(1)` tạo timer async — hầu hết trường hợp Task chưa complete khi gặp `await` → thread yield.
Tuy nhiên nếu hệ thống xử lý cực nhanh và Task complete trước khi `await` yield, thread chạy thẳng không qua pool.

# Code này chạy thế nào? giải thích? [id:3428 order:7]
```csharp
Console.Write("1");
var r2 = await Task.Run(() => B());
Console.Write("2");
async static Task<string> B()
{
    Console.Write("B");
    await Task.Delay(200);
    Console.Write("B-done");
    return "";
}
```

In ra `1 >B >B-done >2`.
- "1": main thread chạy trước.
- "B": `Task.Run(() => B())` đẩy B sang pool thread, B chạy ngay.
- await Delay(200) → B yield, main vẫn đang await Task.Run.
- "B-done": sau 200ms, continuation chạy tiếp, B return.
- "2": Task.Run hoàn tất, main resume in "2".

# trong này, tại sao B-done k được in ra? [id:3429 order:8]
```csharp
var r2 = Task.Run(() => B());
async static Task<string> B()
{
    await Task.Delay(200);
    Console.Write("B-done");
    return "";
}
```

vì main exit trước khi B-done chạy