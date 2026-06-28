---
name: "LINQ-Lazy"
---

# có vấn đề gì?
```cs
var results = items.Select(async i => await ProcessAsync(i));
await Task.WhenAll(results);
return results.Select(r => r.Result);
```
ProcessAsync bị chạy 2 lần
`Select` lazy → `results` bị enumerate 2 lần (1 ở `WhenAll`, 1 ở `return`) → `ProcessAsync` chạy 2 lần, và tập task được await khác tập đọc `.Result`. Sửa: `.ToList()` ngay sau `Select` để materialize 1 lần.

# WhenAll cũng duyệt qua Select lazy à?
Đúng. 
`Task.WhenAll(tasks)` phải enumerate qua `tasks` để gom các Task → nếu `tasks` là `Select` lazy thì việc duyệt này chính là lần chạy lambda.

# enumerate là gì?
là duyệt qua từng phần tử của một collection (`IEnumerable`).

# enumerate và interate là 1 à?
Gần như giống nhau. 
Thường dùng thay thế nhau.

# lazy method trong LINQ nghĩa là gì?
là method chỉ tạo "kế hoạch" chứ chưa chạy, chỉ chạy khi enumerate

# sự khác nhau giữa C# Select() và JS.map?
`. Khác: `Select` lazy (deferred), còn `map` chạy ngay và trả mảng mới luôn.

# deferred là gì?
là trì hoãn — không làm ngay mà để dành tới khi thực sự cần. Trong LINQ, deferred execution = query chỉ chạy khi enumerate.

# deferred phát âm?
/dɪˈfɜːrd/ (đi-FƠD).

# tại sao lại thiết kế Select lazy?
Để tiết kiệm
cho phép chain nhiều LINQ mà chỉ duyệt 1 lần

# cho ví dụ để thấy lazy tiết kiệm hơn là JS đi?
C# dừng ngay ở phần tử đầu, JS tính cả mảng:
```cs
var first = list.Select(Expensive).First(); // C#: gọi Expensive 1 lần
```
```js
const first = list.map(Expensive)[0]; // JS: gọi Expensive cho TẤT CẢ rồi mới lấy [0]
```

# các method lazy trong LINQ?
`Select`, `Where`, `Take`

# các method chạy ngay trong LINQ?
`ToList`, `Count`, `First`, `Sum`, `Any`.
