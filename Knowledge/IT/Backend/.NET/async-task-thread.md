---
id: 320
name: "async-task-thread"
---

# khi nào nên dùng async/await? [id:2811 order:1]
Khi method có I/O (DB query, HTTP call, file).

# cứ có IO là luôn nên dùng await phải không? [id:2812 order:2]
Gần như đúng cho server-side. IO async giúp thread không bị block, server xử lý được nhiều request đồng thời. Trừ trường hợp IO rất ngắn hoặc app tool một thread.

# lợi ích của async khi dùng cho IO? [id:2813 order:3]
Thread không bị block khi chờ IO → trả về thread pool để xử lý request khác. Server cùng số thread phục vụ được nhiều request hơn → throughput cao.

# khi nào nên dùng Task.Run? [id:2814 order:4]


# Task type liên quan gì đến async? [id:2815 order:5]
`async` method trong C# trả về Task.

# khi nào nên dùng Thread? [id:2816 order:6]
Hiếm khi. Chỉ khi cần kiểm soát thấp như set priority, dùng `ThreadStatic`, hoặc tích hợp legacy API. Còn lại dùng Task.

# CPU-bound work là gì? [id:2817 order:7]
là công việc tốn CPU để tính toán — encrypt, parse, image processing, machine learning. Đối ngược với IO-bound (chờ DB/network/file).

# bound nghĩa là gì? [id:2818 order:8]

# Task và Thread khác nhau thế nào? [id:2819 order:9]
Thread là đơn vị OS thực sự, tốn tài nguyên. 
Task là abstraction của Thread, Task tốn thread pool.

# "abstraction cao hơn" nghĩa là gì? cho ví dụ phổ biến [id:2820 order:10]
là layer nằm trên, ẩn đi chi tiết của layer bên dưới
Ví dụ: Task ẩn Thread, EF Core ẩn SQL, HttpClient ẩn TCP socket.
# abstraction có những nghĩa nào, là loại từ gì? [id:2821 order:11]

# đơn vị OS là gì? [id:2822 order:12]
là tài nguyên thực do OS cấp phát và quản lý
# tài nguyên OS là gì?
 — process, thread, file handle, socket.
# abstraction nghĩa là gì? [id:2823 order:13]
là che giấu chi tiết phức tạp bên dưới, chỉ phơi ra interface đơn giản. Task abstract Thread, ORM abstract SQL.

# (task abstract thread) nghĩa là (Task là 1 abstract của thread) à ? [id:2824 order:14]
Đúng. Task là lớp abstraction nằm trên Thread — bạn xài Task, runtime tự lo phân Thread bên dưới.

# compose là gì? [id:2825 order:15]
là ghép nhiều thành phần nhỏ lại thành thành phần lớn hơn. Trong .NET, compose Task là chain `await` nhiều operation, hoặc dùng `Task.WhenAll`.

# Task<ResultOptions> Error(LogDto log); trong này Task có nghĩa gì? [id:2951 order:16]
nghĩa là method này async — trả về `Task<ResultOptions>` thay vì trả thẳng `ResultOptions`. Caller phải `await` để lấy giá trị thật.

# result type Task có nghĩa là chưa có kq, đang đợi có phải không? [id:2952 order:17]
Đúng.
`Task<T>` là 1 promise — đại diện cho công việc đang chạy/sắp chạy. Khi xong, kết quả `T` mới có. Caller dùng `await` hoặc `.Result` để lấy.

# khi nào dùng private? [id:2953 order:18]
khi member chỉ dùng nội bộ trong class.

# mặc định thì member là private hay public? [id:2954 order:19]
Mặc định là `private` cho mọi member trong class/struct (không khai báo modifier).
Riêng interface member mặc định `public`.

# các keyword ngược lại với private? [id:2955 order:20]
- `public`: mọi nơi truy cập được
- `protected`: chỉ class kế thừa truy cập được
- `internal`: chỉ trong cùng assembly truy cập được
- `protected internal`: kết hợp 2 cái trên

# string dạng này gọi là gì? $"{x}-abc"; [id:2956 order:21]
là string interpolation

# các modifier phổ biến? [id:2957 order:22]

# async/await dùng để làm gì? [id:2897 order:14]
để tránh lãng phí thread

# await dùng với CPU-bound task có phổ biến không? cho ví dụ

# hoạt động IO là gì?
là thao tác đọc/ghi dữ liệu ngoài CPU

# làm sao để biết được dùng await có lợi hơn là không dùng? vì dùng await thì phải tốn tài nguyên cho context switch
Rule of thumb: nếu await > vài chục micro giây thì đáng dùng await.

# mỗi process có 1 thread pool phải không? [id:2899 order:16]
Đúng.
.NET runtime tạo 1 `ThreadPool` mặc định cho mỗi process — share cho tất cả Task, async/await, `Task.Run`.

# chức năng của Task.Run?
 đẩy 1 đoạn code chạy trên thread pool
 , trả về `Task` để await. Dùng khi muốn offload CPU-bound work khỏi thread hiện tại.

# ví dụ phổ biến dùng Task.Run?

# thread nào chạy main code?
Main thread
# khi nào main thread exist?

# khi nào pool.thread được dùng?
khi gọi `Task.Run`, `await`, ...

# task.run tạo task mới à?
Đúng.

`Task.Run(...)` tạo 1 Task mới, schedule nó lên thread pool và return Task object để caller có thể await hoặc chờ kết quả.
# khi await IO trả về Task type nhưng thật sự nó đâu tạo ra Task trong queue đâu nhỉ?

# await nghĩa là gì?


# thread A chạy hàm a, trong a có await Task b thì b được chạy bởi thread nào?
Tùy task b.
Nếu b là `Task.Run(...)` → 1 pool thread khác (không phải A). Nếu b là I/O async (`HttpGet`, `DbQuery`) → không thread nào chạy cả, chỉ kernel I/O xử lý; khi xong, runtime mới lấy 1 pool thread (có thể chính là A) để resume hàm a sau `await`.

# Kernel là gì? nó là phần mềm à?

# ý nghĩa của tên Kernel?
"Kernel" tiếng Anh nghĩa là "hạt nhân", "lõi" — như nhân của hạt quả. 
Đặt tên vậy vì nó là phần lõi cốt yếu của OS, mọi thứ khác (shell, app, driver) bao quanh và phụ thuộc vào nó.

# Kernel xử lí toàn bộ hoạt động I/O phải không?
Đúng.
App gọi I/O (đọc file, gửi packet) → syscall → kernel giao việc cho driver/hardware. Trong khi hardware xử lý, app thread không cần đợi (với async I/O), kernel sẽ notify khi xong.
# I/O có tạo task không?
Có 
`File.ReadAllTextAsync` trả về 1 `Task<string>`, nhưng task này KHÔNG chiếm thread — nó chỉ là cái "phiếu chờ" runtime tạo ra. Khi kernel báo I/O xong, runtime mới complete task và resume code sau await.
# I/O Task có tốn thread không?

# mọi I/O đều tạo ra Task nhưng k tốn thread phải không?
Đúng 
Task chỉ là "phiếu chờ", kernel + driver xử lý ngầm bằng IOCP/epoll. I/O sync (vd `File.ReadAllText`) thì khác — block thread cho tới khi xong, không tạo task.

# hàm async luôn tạo ra Task mới à?
Đúng.
Compiler tự wrap body hàm `async` thành state machine và return về `Task`/`Task<T>`. Caller dùng task đó để await hoặc chờ kết quả.
# task.run giống gì trong js?
Gần giống `Promise` 
kết hợp với offload sang Web Worker. JS không có thread pool sẵn nên không có analog 1-1 — `setTimeout(fn, 0)` chỉ defer chứ không chạy thread khác.

# sự khác nhau của task.run và promise trong js?

# offload là gì?
là chuyển công việc từ chỗ hiện tại sang chỗ khác 
Trong .NET: offload = đẩy code từ thread đang chạy (vd UI thread, request thread) sang thread khác (thường là pool).
# mục đích offload ?
# cho ví dụ offload (kèm code)

# chỉ offload được khi không await phải không? vì khi có await thì phải đợi xong thì thread mới chạy tiếp được
Ngược lại. Chính `await` mới là offload — `await` không block thread, nó trả thread về pool, đợi xong mới lấy thread khác chạy tiếp. Nếu KHÔNG await mà gọi blocking → thread bị giữ suốt thời gian chờ, không offload được.
# dùng await tức là offload phải không?
# offload là loại từ gì? cho ví dụ câu phổ biến?

# khi ta offload sang 1 thread b thì giải phóng thread a nhưng lại tốn b, thì nó có lợi hơn chỗ nào nhỉ?
Lợi khi:
1. a là thread đặc biệt (UI thread, request thread) còn b là pool thread thường. 
UI thread block thì app freeze, request thread block thì nghẽn server. Pool thread block thì pool tự co giãn — ít hại hơn. 
2. hoạt động là I/O async: không cần thread b nào cả, chỉ kernel xử lý.
# request thread chính là thread trong pool phải không?
Đúng trong ASP.NET Core.
Kestrel nhận request → đẩy vào thread pool, 1 pool thread bốc lên chạy handler. Không có pool riêng cho request — chung pool với mọi Task khác.
# dùng await chính là offload phải không?
Gần đúng.
`await` offload theo nghĩa "trả thread hiện tại về pool". Còn task được await thì chạy ở đâu (pool thread, kernel I/O) là việc của runtime/task đó.
# mỗi khi await thì thread hiện tại luôn được giải phóng có phải không?
# mỗi request đến server tương ứng 1 task à?
Đúng trong ASP.NET Core.
Mỗi HTTP request → 1 task chạy trên 1 pool thread. Khi handler `await`, thread được trả về pool, đến khi await xong runtime lấy thread khác (có thể cùng) chạy tiếp.


# Thread .NET có liên hệ gì với OS thread? [id:2900 order:23]
Quan trọng với UI app. WPF/WinForms chỉ cho update UI từ UI thread — nếu await xong nhảy sang thread khác, code update UI sẽ throw exception. ASP.NET Core và console app không có ràng buộc này nên chạy thread nào cũng được, lợi cho throughput.
1 thread .NET tương ứng với 1 OS thread

# Task khác Thread như thế nào? [id:2901 order:24]
Task:
    dùng cho short running
    chạy trên thread pool
Thread:
    dùng cho long running
    là OS thread

# 1 Thread trong thread pool có tương ứng với 1 OS thread không? [id:2902 order:25]
Có. Mỗi worker thread trong thread pool là 1 OS thread thật. Pool chỉ tái sử dụng — không tạo/dọn liên tục để tiết kiệm overhead.

<!--# lí do thread pool tồn tại là để tiết kiệm overhead do bỏ qua việc tạo/dọn phải không? [id:3087 order:26]
Đúng.
Tạo OS thread mới tốn ~1ms và 1MB stack — pool giữ sẵn 1 nhóm thread, tái sử dụng cho nhiều task ngắn. Tránh tạo/dọn liên tục. -->

# tạo 1 OS thread mới thì tốn gì? [id:3088 order:27]
~1ms và 1MB stack

# liên hệ giữa stack và pool.thread? [id:3089 order:28]
Mỗi pool thread có 1 stack riêng
(~1MB) cấp khi thread tạo ra.

# khi nào stack được reset? [id:3090 order:29]
khi 1 task kết thúc

# thread chạy 1 task tại 1 thời điểm à? [id:3091 order:30]
Đúng.
1 thread chỉ chạy 1 task tại 1 thời điểm — đó là bản chất của thread (đơn vị thực thi tuần tự). Muốn chạy nhiều task song song thì cần nhiều thread.

# pool.thread khác .NET Thread ở chỗ pool.thread luôn sống có phải không? [id:3092 order:31]
Đúng.
Pool thread sống suốt vòng đời process (idle thì sleep), nhận task khác sau khi xong.

# Task liên hệ gì với thread pool? [id:2904 order:32]
Task mặc định schedule lên thread pool — `Task.Run(() => ...)` lấy 1 worker thread từ pool để chạy. Task không tự sở hữu thread riêng.

# hoạt động của scheduler, queue, thread pool? [id:3093 order:33]
khi có thread rảnh, scheduler bốc task trong queue ra cho thread chạy

# scheduler, queue, thread pool đều thuộc runtime phải không? [id:3094 order:34]
Đúng.
Cả 3 đều là component của .NET runtime (CLR). Process khởi động → runtime tạo sẵn pool + scheduler + queue. App code chỉ submit task, không quản lý 3 cái đó.

<!--# mọi hoạt động trong .net đều dùng pool.thread trừ khi dùng .NET thread phải không [id:3095 order:35]
Gần đúng.
`Task`, `async/await`, `Parallel.For`, ASP.NET request handler đều chạy trên pool. Chỉ khi `new Thread()` mới tạo thread riêng. Main thread của app cũng không thuộc pool. -->

# mỗi process có 1 main thread để chạy app à? [id:3096 order:36]
Đúng.
OS tạo main thread khi process start, chạy `Main()` đầu tiên.

# main thread có thuộc pool không? [id:3097 order:37]
không

<!--# mỗi process đều có 1 main thread à? [id:3098 order:38]
Đúng.
OS yêu cầu mọi process phải có 1 thread khởi đầu để chạy entry point. Process không có thread nào thì không tồn tại. -->

<!--# main thread khác gì pool thread? [id:3099 order:39]
- Main thread: tạo bởi OS khi process start,     chạy `Main()`
- Pool thread: tạo bởi CLR, sống lâu trong pool, chạy task từ queue -->

<!--# chỉ CLR dùng pool thôi phải không? [id:3100 order:40]
Không.
Pool là khái niệm chung của OS/runtime. CLR có thread pool riêng, JVM cũng có, Node.js có libuv thread pool, IIS có request thread pool. Mỗi runtime tự quản pool của mình. -->

# worker và thread là 1 à? [id:3101 order:41]
đúng
Trong context thread pool: worker = thread.
"Worker" nhấn mạnh vai trò (thread chuyên nhận task), còn "thread" là khái niệm kỹ thuật (đơn vị thực thi của OS).

# công việc của pool.thread chỉ là xử lí task từ queue phải không? [id:3102 order:42]
Đúng.
Pool thread khi tạo ra → vào loop: lấy task từ queue, chạy, xong rồi quay lại lấy task tiếp. Idle quá lâu thì OS đưa vào sleep. Không làm việc gì khác.

<!--# khi async được thực thi thì nó tạo ra Task phải không? [id:3134 order:43]
Đúng.
`async` method trả về `Task` (hoặc `Task<T>`) — đại diện cho một operation bất đồng bộ, không phải là thread. -->

# khi gặp I/O bound task thì diễn biến thế nào? [id:3135 order:44]
khi method `await` 1 I/O operation, thread đang chạy được trả về thread pool. OS dùng I/O completion port để chờ kết quả. Khi I/O xong, runtime lấy 1 thread bất kỳ từ pool để continue method.

<!--# I/O bound task thì nằm trong queue không? [id:3136 order:45]
Có. Khi I/O xong, callback được đưa vào queue của thread pool, chờ thread pick up để continue. -->

<!--# hoạt động IO có được đưa vào queue không? [id:3137 order:46]
không
OS xử lý I/O ngay và không bỏ vào queue chờ. -->

<!--# có sự liên hệ giữa task và dòng lệnh/hàm không? [id:3138 order:47]
Có. Task đại diện cho công việc 1 method async đang làm — bao gồm các dòng lệnh sau `await`. Khi await, task pause method tại đó; khi I/O xong, task resume từ đúng dòng tiếp theo. -->

# những task nào mà pool.thread k xử lí? [id:3139 order:48]
I/O-bound task:
HTTP call, file read/write, DB query. Những task này dùng I/O completion port của OS — không cần thread pool thread ngồi chờ, thread được trả về ngay khi đang chờ I/O.

<!--# worker liên hệ gì với pool.thread? [id:3103 order:49]
Worker thread CHÍNH LÀ thread trong pool. Số worker = số thread trong pool. Khi nói "worker" trong context thread pool là nói tới các thread đang chờ task. -->