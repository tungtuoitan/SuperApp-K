---
id: 357
name: "Task-Run"
---

# offload là gì? [id:3334 order:1]
là chuyển công việc từ chỗ hiện tại sang chỗ khác
Trong .NET: offload = đẩy code từ thread đang chạy (vd UI thread, request thread) sang thread khác (thường là pool).

<!--# mục đích offload ? [id:3335 order:2]
giải phóng thread quan trọng (UI thread, request thread) khỏi công việc nặng/chờ lâu, để thread có thể phục vụ việc khác. -->

# cách offload phổ biến? [id:3336 order:3]
- dùng async cho IO bound > để giải phóng thread
dùng WhenAll cho nhiều hoạt động cùng lúc > để tiết kiệm time

# khi ta offload sang 1 thread b thì giải phóng thread a nhưng lại tốn b, thì nó có lợi hơn chỗ nào nhỉ? [id:3342 order:4]
Lợi khi:
1. a là thread đặc biệt (UI thread, request thread) còn b là pool thread thường.
UI thread block thì app freeze, request thread block thì nghẽn server. Pool thread block thì pool tự co giãn — ít hại hơn.
2. hoạt động là I/O async: không cần thread b nào cả, chỉ kernel xử lý.

# lí do Task.Run() tồn tại? [id:3456 order:5]
Để offload CPU-bound work khỏi thread quan trọng (vd: UI thread)
cho phép xử lí song song cùng lúc nhiều CPU-bound work

# khi nào nên dùng Task.Run() không await? [id:3457 order:6]
Chỉ dùng khi muốn fire-and-forget

# các cách dùng Task.Run() trong ASP.NET Core ? [id:3458 order:7]
- Task.Run() (fire-and-forget)
- await + Task.WhenAll + NHIỀU Task.Run() chạy song song

# await Task.Run(() => async()) và await async() thì khác gì nhau ? [id:3459 order:8]
- `await Task.Run()`:      request thread được giải phóng NGAY
- `await asyncMethod()`:   request thread được giải phóng khi gặp `await` I/O đầu tiên

# Cách dùng await async()? [id:3460 order:9]
- dùng cho IO-bound

# nếu async nhưng có cả CPU-bound và IO-bound thì nên dùng gì? vì sao? [id:3461 order:10]
cứ dùng await
vì trong trường hợp này thôi ta chỉ có thể tối ưu bằng cách giải phóng thread

# mọi await đều giải phóng main thread nếu task chưa completed phải không? [id:3462 order:11]
Đúng
— bất kể loại Task, nếu chưa complete khi gặp `await` thì request thread được trả về pool. Lưu ý: "main thread" ở đây là request thread (pool thread), không phải main thread của process.

# await Task.Run() có giải phóng main thread không? [id:3463 order:12]
Có.
`Task.Run()` trả về Task chưa complete ngay → `await` trả request thread về pool. Pool thread chạy work song song.

<!--# cho tôi flow cụ thể của await Task.Run(() => CpuHeavy()) và Task.Run() đi [id:3464 order:13]
1. request thread gặp `await Task.Run(() => CpuHeavy())` →
2. queue CpuHeavy() lên pool, nhận Task chưa complete
3. phần code sau được gắn vào callback của Task
4. main thread được giải phóng
5. khi Task complete, runtime chạy callback để tiếp tục -->

# khi nào nên dùng await async(), khi nào nên dùng Task.Run() độc lập? [id:3465 order:14]
nếu là I/O-bound thuần túy thì dùng await async()
và k nên dùng Task.Run() độc lập vì nó cũng tương tự await async()

# code thế này có hợp lí không? giải thích? [id:3466 order:15]
```cs
Task<ResultOptions> uploadTask = Task.Run(async () =>
{
    ResultOptions resUpload = await Upload(uploadFile, loggedUser);
    return resUpload;
});
uploadTask = await Upload();

var saveTask = uploadTask.ContinueWith(async (taskInfo) =>
{
    // ...
});
public async Task<ResultOptions> Upload(UploadFile uploadFile, string? loggedUser)
{
    ResultOptions resUpload = await _blobUpload.UploadFile(streamDoc, path, uploadFile.FilenameGuid, uploadFile.Filename);
    ///...
}
```

Không hợp lý.
k cần dùng Task.Run() vì đây là Async đơn lẻ
k cần dùng ContinueWith vì có thể dùng await là đủ