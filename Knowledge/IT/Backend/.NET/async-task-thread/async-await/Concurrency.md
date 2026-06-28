---
id: 353
name: "Concurrency"
---

# 1 2 3 có chạy theo thứ tự k? vì sao?[id:3391 order:1 atts:2 open-context]
```cs
var t1 = B(1);
var t2 = B(2);
var t3 = B(3);
var results = await Task.WhenAll(t1, t2, t3);
async static Task B(int id)
{
    Console.WriteLine(id);
}
```

Có — in tuần tự `1 → 2 → 3` đúng thứ tự.
Vì `B()` không có `await` nào bên trong → chạy **đồng bộ** hoàn toàn, trả về Task đã complete sẵn. 

# nếu trong B có awaitTask.Delay(2000) thì thứ tự in có còn đảm bảo không?[id:3391 order:1 close-context]
không còn đảm bảo

# SemaphoreSlim là gì? Chức năng? [id:3397 order:2]
Là một lock
cho phép tối đa N thread vào critical section cùng lúc (so với `lock` chỉ cho 1).

<!--# SemaphoreSlim và lock là cơ chế hay gì? [id:3398 order:3]
Là synchronization primitive — cơ chế điều phối truy cập vào tài nguyên dùng chung giữa nhiều thread. -->

# primitive nghĩa là gì? [id:3399 order:4]
nguyên thủy / cơ bản nhất

<!--# ý nghĩa từ semaphore? [id:3401 order:5]
Tiếng Latin: "semaphore" = "signal bearer" (người mang tín hiệu).
Xuất phát từ hệ thống tín hiệu đường sắt — cờ hiệu cho phép hoặc chặn tàu vào đoạn đường.
Trong CS: Edsger Dijkstra đặt tên năm 1965 — một biến đếm kiểm soát số lượng process được phép truy cập tài nguyên cùng lúc. -->

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

# caller là gì? [id:3437 order:13]
là Method gọi method hiện tại.
Ví dụ: A() gọi B() → A là caller của B. Khi B return hoặc `await`, control trả về A.
