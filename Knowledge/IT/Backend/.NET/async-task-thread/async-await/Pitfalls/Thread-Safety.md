---
name: "Thread-Safety"
---

# có vấn đề gì?
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

# thread-safe là gì?
là khả năng nhiều thread truy cập cùng một dữ liệu/đối tượng cùng lúc mà không gây sai kết quả hay lỗi.

# khi nhiều thread truy cập 1 thứ thread-unsafe thì sao?
Nó báo lỗi hoặc âm thầm sai dữ liệu (race condition) mà không có exception nào.

# tại sao dbContext là thread-unsafe?
vì `DbContext` cần state nội bộ riêng cho từng request

# dbContext thì thread-unsafe à?
Đúng. 
`DbContext` không thread-safe — không được dùng đồng thời bởi nhiều thread.

# từ ngược lại với thread-safe là gì?
Có — thread-unsafe (hoặc non-thread-safe).

# khi dùng lock, thì các request phải đợi nhau để chạy đoạn lock đó à?
Đúng. 
`lock` chỉ cho 1 thread vào critical section tại một thời điểm, thread khác phải chờ → giảm song song. 

# tại sao k được await trong lock nhỉ?
Vì code phía sau `await` sẽ chạy trên thread khác, trong khi `lock` (Monitor) phải được release bởi thread chiếm quyền

# monitor có mấy nghĩa ?
Trong .NET có 2 nghĩa thường gặp: 
(1) `Monitor` — lớp khóa nền của `lock`; 
(2) theo dõi / giám sát (logging, metrics)

# acquire là gì?
là giành / chiếm được khóa (lock). Thread acquire lock thì mới vào critical section; xong thì release để thread khác vào.

# acquire phát âm?
/əˈkwaɪər/ (ơ-KWAI-ơ).

# field readonly thì luôn thread-safe à? vì sao?
Không hẳn. 
nó chỉ đảm bảo k bị gán lại, nhưng value bên trong object thì có thể thay đổi

# những thứ thread-safe và thread-unsafe phổ biến trong asp.net core?
- Thread-safe: `ConcurrentDictionary`, `Interlocked`, `ILogger`, `HttpClient` (gọi song song), object immutable.
- Thread-unsafe: `DbContext`, `List<T>` / `Dictionary<T>`, `HttpContext`, nhiều thread trong 1 request dùng chung 1 scoped service (vd: WhenAll + gọi dbContext)

# thread-unsafe là nguyên nhân gây race-condition phải không?
Đúng phần lớn. 
Dùng đối tượng thread-unsafe từ nhiều thread mà không đồng bộ → race condition. Nhưng race condition cũng có thể đến từ logic sai dù dùng đồ thread-safe.

# có vấn đề gì?
```cs
var list = new List<int>();
await Task.WhenAll(Enumerable.Range(0, 100).Select(async i =>
{
    list.Add(await GetAsync(i));
}));
return list;
```
`List<T>` không thread-safe và nhiều task đang add cùng lúc → corrupt list

# corrupt nghĩa là gì?
là hỏng / sai lệch dữ liệu
— cấu trúc bên trong bị ghi đè lộn xộn nên không còn đúng/đọc được.

# mặc định là thread-unsafe phải không? vì sao?
đúng
vì vậy mới nhanh

# có vấn đề gì? 
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

# atomic nghĩa là gì?
là thao tác chạy trọn vẹn 1 nhịp, không bị thread khác xen vào giữa chừng. 
`_counter++` không atomic vì gồm 3 bước đọc - cộng - ghi.

# trong này _counter luôn = 0 mỗi khi request đến, vì controller là scoped có phải không? 
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

# Interlocked có phổ biến trong asp.net core không? 
Khá phổ biến cho counter / flag dùng chung. 

# Interlocked giải quyết vấn đề gì?
Giải quyết: tăng / giảm / swap giá trị atomic không cần `lock`, tránh race condition trên biến số.

# dùng lock thay cho interlocked có được không?
Được. 
`lock` quanh `count++` cũng đúng. Nhưng `Interlocked` nhanh hơn (không cần khóa OS) cho thao tác đơn giản như tăng/giảm/swap. Thao tác phức tạp hơn thì dùng `lock`.

# khi nào dùng lock, khi nào dùng interlocked?
- Interlocked: thao tác đơn trên 1 biến số (tăng/giảm/swap/compare-exchange).
- lock: khi cần bảo vệ nhiều dòng / nhiều biến cùng lúc (critical section phức tạp).

# có vấn đề gì? giải pháp?
```cs
// đăng ký Singleton
public class CacheService
{
    private readonly List<string> _items = new();
    public void Add(string x) => _items.Add(x);
}
```
nhiều request cùng add cache song song thì sẽ bị corrupt list

# mọi Collection đều là thread-unsafe phải không?
Không. 
có 2 loại: 
- Collection thường: (`List`, `Dictionary`, `HashSet`) -> thread-unsafe; 
- concurrent collections: `ConcurrentDictionary`, `ConcurrentBag`, `ConcurrentQueue`. -> thread-sadfe

# Immutable collections là gì?
là collection không thể sửa CẤU TRÚC sau khi tạo — mọi thao tác "sửa" trả về collection mới. Vd `ImmutableList<T>`, `ImmutableDictionary<T>`. 

# lí do Immutable collections tồn tại?
- Để an toàn khi share giữa nhiều thread (không ai sửa được → khỏi khóa)
- để code dễ suy luận hơn (giá trị không đổi sau khi tạo).

# có vấn đề gì?
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

# nhiều thread cùng đọc 1 object thì có sao k?
k sao, an toàn

# có vấn đề gì?
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

# tại sao người ta k thiết kế để mọi thứ đều thread-safe nhỉ?
Vì thread-safe phải khóa + đồng bộ → chậm hơn và tốn bộ nhớ 
.NET cho bạn chọn: mặc định nhanh (unsafe), cần thì dùng bản thread-safe.

# đa số code chạy đơn luồng à? tại sao?
Đúng với phần lớn logic trong 1 request — chạy tuần tự trên 1 thread. V
ì đa số nghiệp vụ không cần song song, viết đơn luồng đơn giản và không lo race. Song song chỉ dùng khi cần tăng tốc.

# thread-unsafe chỉ xuẩt hiện khi đa luồng phải không?
Đúng. 
Vấn đề thread-safety chỉ phát sinh khi có ≥2 thread truy cập đồng thời. Code đơn luồng thuần thì không bao giờ gặp.

# đơn luồng, đa luồng là gì?
- Đơn luồng: code chạy tuần tự trên 1 thread
- Đa luồng: nhiều thread chạy đồng thời 
  - (vd `Parallel.ForEach`, `Task.WhenAll` nhiều `Task.Run`, hoặc nhiều request cùng lúc).

# lí do đa luồng tồn tại?
để code chạy nhanh hơn?

# khi nào thì cần đa luồng?
khi muốn code chạy nhanh hơn

# các trường hợp phổ biến cần đa luồng?
- CPU-bound nặng: xử lý ảnh/video, tính toán lớn
- Gọi nhiều I/O độc lập song song 
- Background job chạy song song với request.
- Server tự xử lý nhiều request đồng thời.

# có vấn đề gì?
```cs
int total = 0;
await Task.WhenAll(items.Select(async x =>
{
    total += await GetAsync(x);
}));
return total;
```
`total +=` không atomic, cho nên khi += cùng lúc thì bị sai hoặc lỗi
