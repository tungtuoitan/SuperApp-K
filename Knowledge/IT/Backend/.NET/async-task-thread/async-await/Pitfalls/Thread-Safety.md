---
id: 363
name: "Thread-Safety"
---

# có vấn đề gì? [id:3578 order:1]
```cs
public async Task<IActionResult> Get()
{
    var t1 = _db.Users.ToListAsync();
    var t2 = _db.Orders.ToListAsync();
    await Task.WhenAll(t1, t2);
    return Ok();
}
```

Chạy 2 query song song trên CÙNG một `DbContext` → không thread-safe,

# thread-safe là gì? [id:3579 order:2]
là khả năng nhiều thread truy cập cùng một dữ liệu/đối tượng cùng lúc mà không gây sai kết quả hay lỗi.

# khi nhiều thread truy cập 1 thứ thread-unsafe thì sao? [id:3580 order:3]
Nó báo lỗi hoặc âm thầm sai dữ liệu (race condition) mà không có exception nào.

# tại sao dbContext là thread-unsafe? [id:3581 order:4]
vì `DbContext` cần state nội bộ riêng cho từng request

# dbContext thì thread-unsafe à? [id:3582 order:5]
Đúng.
`DbContext` không thread-safe — không được dùng đồng thời bởi nhiều thread.

# từ ngược lại với thread-safe là gì? [id:3583 order:6]
Có — thread-unsafe (hoặc non-thread-safe).

# khi dùng lock, thì các request phải đợi nhau để chạy đoạn lock đó à? [id:3584 order:7]
Đúng.
`lock` chỉ cho 1 thread vào critical section tại một thời điểm, thread khác phải chờ → giảm song song.

# tại sao k được await trong lock nhỉ? [id:3585 order:8]
Vì code phía sau `await` sẽ chạy trên thread khác, trong khi `lock` (Monitor) phải được release bởi thread chiếm quyền

# monitor có mấy nghĩa ? [id:3586 order:9]
Trong .NET có 2 nghĩa thường gặp:
(1) `Monitor` — lớp khóa nền của `lock`;
(2) theo dõi / giám sát (logging, metrics)

# acquire là gì? [id:3587 order:10]
là giành / chiếm được khóa (lock). Thread acquire lock thì mới vào critical section; xong thì release để thread khác vào.

# acquire phát âm? [id:3588 order:11]
/əˈkwaɪər/ (ơ-KWAI-ơ).

# field readonly thì luôn thread-safe à? vì sao? [id:3589 order:12]
Không hẳn.
nó chỉ đảm bảo k bị gán lại, nhưng value bên trong object thì có thể thay đổi

# những thứ thread-safe và thread-unsafe phổ biến trong asp.net core? [id:3590 order:13]
- Thread-safe: `ConcurrentDictionary`, `Interlocked`, `ILogger`, `HttpClient` (gọi song song), object immutable.
- Thread-unsafe: `DbContext`, `List<T>` / `Dictionary<T>`, `HttpContext`, nhiều thread trong 1 request dùng chung 1 scoped service (vd: WhenAll + gọi dbContext)

# thread-unsafe là nguyên nhân gây race-condition phải không? [id:3591 order:14]
Đúng phần lớn.
Dùng đối tượng thread-unsafe từ nhiều thread mà không đồng bộ → race condition. Nhưng race condition cũng có thể đến từ logic sai dù dùng đồ thread-safe.

# có vấn đề gì? [id:3592 order:15]
```cs
var list = new List<int>();
await Task.WhenAll(Enumerable.Range(0, 100).Select(async i =>
{
    list.Add(await GetAsync(i));
}));
return list;
```

`List<T>` không thread-safe và nhiều task đang add cùng lúc → corrupt list

# corrupt nghĩa là gì? [id:3593 order:16]
là hỏng / sai lệch dữ liệu
— cấu trúc bên trong bị ghi đè lộn xộn nên không còn đúng/đọc được.

# mặc định là thread-unsafe phải không? vì sao? [id:3594 order:17]
đúng
vì vậy mới nhanh

# có vấn đề gì? [id:3595 order:18]
```cs
public class HomeController : ControllerBase
{
    private static int _counter = 0;
    public IActionResult Get()
    {
        _counter++;
        return Ok(_counter);
    }
}
```

kết quả sẽ k đúng khi có nhiều request cùng lúc, vì _counter++ không atomic

# atomic nghĩa là gì? [id:3596 order:19]
là thao tác chạy trọn vẹn 1 nhịp, không bị thread khác xen vào giữa chừng.
`_counter++` không atomic vì gồm 3 bước đọc - cộng - ghi.

# trong này _counter luôn = 0 mỗi khi request đến, vì controller là scoped có phải không? [id:3597 order:20]
```cs
public class HomeController : ControllerBase
{
    private static int _counter = 0;
    public IActionResult Get()
    {
        //...
    }
}
```

Không. `_counter` là `static` — thuộc class chứ không thuộc instance, nên KHÔNG reset mỗi request dù controller scoped. Mọi request dùng chung 1 `_counter`. (Bỏ `static` thì mới reset mỗi request.)

# Interlocked có phổ biến trong asp.net core không? [id:3598 order:21]
Khá phổ biến cho counter / flag dùng chung.

# Interlocked giải quyết vấn đề gì? [id:3599 order:22]
Giải quyết: tăng / giảm / swap giá trị atomic không cần `lock`, tránh race condition trên biến số.

# dùng lock thay cho interlocked có được không? [id:3600 order:23]
Được.
`lock` quanh `count++` cũng đúng. Nhưng `Interlocked` nhanh hơn (không cần khóa OS) cho thao tác đơn giản như tăng/giảm/swap. Thao tác phức tạp hơn thì dùng `lock`.

# khi nào dùng lock, khi nào dùng interlocked? [id:3601 order:24]
- Interlocked: thao tác đơn trên 1 biến số (tăng/giảm/swap/compare-exchange).
- lock: khi cần bảo vệ nhiều dòng / nhiều biến cùng lúc (critical section phức tạp).

# có vấn đề gì? giải pháp? [id:3602 order:25]
```cs
// đăng ký Singleton
public class CacheService
{
    private readonly List<string> _items = new();
    public void Add(string x) => _items.Add(x);
}
```

nhiều request cùng add cache song song thì sẽ bị corrupt list

# mọi Collection đều là thread-unsafe phải không? [id:3603 order:26]
Không.
có 2 loại:
- Collection thường: (`List`, `Dictionary`, `HashSet`) -> thread-unsafe;
- concurrent collections: `ConcurrentDictionary`, `ConcurrentBag`, `ConcurrentQueue`. -> thread-sadfe

# Immutable collections là gì? [id:3604 order:27]
là collection không thể sửa CẤU TRÚC sau khi tạo — mọi thao tác "sửa" trả về collection mới. Vd `ImmutableList<T>`, `ImmutableDictionary<T>`.

# lí do Immutable collections tồn tại? [id:3605 order:28]
- Để an toàn khi share giữa nhiều thread (không ai sửa được → khỏi khóa)
- để code dễ suy luận hơn (giá trị không đổi sau khi tạo).

# có vấn đề gì? [id:3606 order:29]
```cs
private static readonly Dictionary<string, string> _cache = new();
public string Get(string key)
{
    if (!_cache.ContainsKey(key))
        _cache[key] = Load(key);
    return _cache[key];
}
```

`Dictionary` không thread-safe — nhiều request đọc/ghi `_cache` song song có thể lỗi/corrupt

# nhiều thread cùng đọc 1 object thì có sao k? [id:3607 order:30]
k sao, an toàn

# có vấn đề gì? [id:3608 order:31]
```cs
private static Config _config;
public Config Get()
{
    if (_config == null)
        _config = Load();
    return _config;
}
```

trường hợp nhiều thread cùng Get khi config null thì sẽ Load nhiều lần, -> thread-unsafe

# tại sao người ta k thiết kế để mọi thứ đều thread-safe nhỉ? [id:3609 order:32]
Vì thread-safe phải khóa + đồng bộ → chậm hơn và tốn bộ nhớ
.NET cho bạn chọn: mặc định nhanh (unsafe), cần thì dùng bản thread-safe.

# đa số code chạy đơn luồng à? tại sao? [id:3610 order:33]
Đúng với phần lớn logic trong 1 request — chạy tuần tự trên 1 thread. V
ì đa số nghiệp vụ không cần song song, viết đơn luồng đơn giản và không lo race. Song song chỉ dùng khi cần tăng tốc.

# thread-unsafe chỉ xuẩt hiện khi đa luồng phải không? [id:3611 order:34]
Đúng.
Vấn đề thread-safety chỉ phát sinh khi có ≥2 thread truy cập đồng thời. Code đơn luồng thuần thì không bao giờ gặp.

# đơn luồng, đa luồng là gì? [id:3612 order:35]
- Đơn luồng: code chạy tuần tự trên 1 thread
- Đa luồng: nhiều thread chạy đồng thời
  - (vd `Parallel.ForEach`, `Task.WhenAll` nhiều `Task.Run`, hoặc nhiều request cùng lúc).

# lí do đa luồng tồn tại? [id:3613 order:36]
để code chạy nhanh hơn?

# khi nào thì cần đa luồng? [id:3614 order:37]
khi muốn code chạy nhanh hơn

# các trường hợp phổ biến cần đa luồng? [id:3615 order:38]
- CPU-bound nặng: xử lý ảnh/video, tính toán lớn
- Gọi nhiều I/O độc lập song song
- Background job chạy song song với request.
- Server tự xử lý nhiều request đồng thời.

# có vấn đề gì? [id:3616 order:39]
```cs
int total = 0;
await Task.WhenAll(items.Select(async x =>
{
    total += await GetAsync(x);
}));
return total;
```

`total +=` không atomic, cho nên khi += cùng lúc thì bị sai hoặc lỗi