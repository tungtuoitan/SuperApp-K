---
id: 353
name: "Concurrency"
---

# t1,t2,t3 có chạy theo thứ tự k? [id:3391 order:1 atts:2]
```cs
Console.WriteLine("A1");
var t1 = B();
var t2 = B();
var t3 = B();
var results = await Task.WhenAll(t1, t2, t3);
Console.WriteLine("A2");

async static Task B()
{
    Console.WriteLine("B1");
}
```

không.
Cả 3 task start gần như cùng lúc, thứ tự B1 in ra không đảm bảo.
`Task.WhenAll` chỉ đảm bảo A2 chạy sau khi cả 3 xong — không đảm bảo thứ tự giữa t1/t2/t3.

# SemaphoreSlim là gì? Chức năng? [id:3397 order:2]
Là một lock
cho phép tối đa N thread vào critical section cùng lúc (so với `lock` chỉ cho 1).

# SemaphoreSlim là thể loại gì? [id:3398 order:3]
Là cơ chế điều phối truy cập tài nguyên 
dùng chung giữa nhiều thread.

# primitive nghĩa là gì? [id:3399 order:4]
nguyên thủy / cơ bản nhất

# ý nghĩa từ semaphore? [id:3401 order:5]
là biến đếm số process được phép truy cập tài nguyên cùng lúc
Xuất phát từ hệ thống tín hiệu đường sắt — cờ hiệu cho phép hoặc chặn tàu vào đoạn đường.
Trong CS: Edsger Dijkstra đặt tên năm 1965 — một biến đếm kiểm soát số lượng process được phép truy cập tài nguyên cùng lúc.

# deadlock là gì? [id:3430 order:6]
Tình huống 2+ thread chờ nhau vô tận — không ai nhường trước.
Trong .NET: thường xảy ra khi gọi `.Result`/`.Wait()` trên async Task trong sync context — thread block chờ Task xong, nhưng Task cần thread đó để resume → kẹt mãi.

# đâu là caller cao cấp nhất? [id:3431 order:7]
ASP.NET framework

# khi tất cả thread bị block thì request trả về gì? [id:3432 order:8]
lỗi timeout

# hàm main có phải là caller cao nhất k? vì sao? [id:3433 order:9]
không?
caller cao nhất là hàm gọi controller trực tiếp
`Main()` là entry point của process nhưng không gọi controller trực tiếp.
Khi có HTTP request, middleware pipeline của framework mới dispatch đến controller — nên framework là caller của business logic trong request lifecycle, không phải `Main()`.

# control là gì? [id:3434 order:10]
là quyền (n) quyết định thread chạy tiếp cái gì.

# ai nắm control ? [id:3435 order:11]
hàm nào đang được thread thực thi thì hàm đó nắm control.

<!--# việc nắm control có nghĩa gì? [id:3436 order:12]
nghĩa là Thread đang thực thi code của hàm đó
Mất control nghĩa là thread chuyển sang chạy code của thứ khác (caller, scheduler, OS). -->

# khái niệm control (nắm quyền điều khiển) có trong .NET không?
có. 
`control` là khái niệm chung của runtime/CS, không riêng .NET. Trong .NET, ta hay gặp khi nói về:
- `await` → "yield control back to caller"
- exception → "control transfers to catch block"
- `Main()` → entry point "where control starts"

# caller là gì? [id:3437 order:13]
là Method gọi method hiện tại.
Ví dụ: A() gọi B() → A là caller của B. Khi B return hoặc `await`, control trả về A.
