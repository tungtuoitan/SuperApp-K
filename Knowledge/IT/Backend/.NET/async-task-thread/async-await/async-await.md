---
id: 347
name: "async-await"
---

# xxx [id:3405 order:1]
yyy

# async/await dùng để làm gì? [id:3328 order:2]
để tránh lãng phí thread

# lí do await tồn tại ? [id:3329 order:3]
để giải phóng thread trong khi chờ I/O
— thay vì thread ngồi chờ không làm gì, `await` trả thread về Thread Pool để xử lý request khác. Khi I/O xong, task tiếp tục trên thread được cấp lại.

# await nghĩa là gì? [id:3330 order:4]
là "chờ Task này xong rồi tiếp tục".
Cụ thể: trả thread hiện tại về pool, đăng ký callback, khi Task hoàn thành runtime lấy thread từ pool để chạy tiếp phần code sau `await`.

# await dùng với CPU-bound task có phổ biến không? vì sao? [id:3331 order:5]
Không
vì `await` chỉ giải phóng thread khi thread chờ I/O. còn với CPU-bound task thì thread vẫn bận suốt -> k cần giải phóng.

# làm sao để biết được dùng await có lợi hơn là không dùng? vì dùng await thì phải tốn tài nguyên cho context switch [id:3332 order:6]
Rule of thumb: nếu await > vài chục micro giây thì đáng dùng await.

# khi có await thì phần code sau nó đi đâu? [id:3333 order:7]
sẽ là callback gắn vào Task đang chờ.
Khi Task hoàn thành, runtime schedule continuation lên pool thread để chạy tiếp.

<!--# khi nào thread được trả về pool? [id:3341 order:8]
Khi gặp `await` một Task chưa complete.
Lúc đó thread không có việc làm → trả về pool ngay, không chờ. -->

# mỗi khi await thì thread hiện tại luôn được trả về pool có phải không? vì sao? [id:3343 order:9]
Không hoàn toàn.
Nếu Task complete trước khi `await` yield -> thread chạy tiếp mà k cần trả về pool
Chỉ khi Task chưa complete thì `await` mới trả thread về pool.

# các trường hợp phổ biến Task.completed trước khi await yield? [id:3344 order:10]
cache hit trả về `Task.FromResult(value)`,
hoặc I/O cực nhanh xong ngay.

# khi Task hoàn thành trước khi await yield thì sao? [id:3345 order:11]
thread chạy tiếp mà k cần trả về pool

<!--# khi chạy await async() thì khi nào thread thực sự được giải phóng? [id:3412 order:12]
khi chạy đến await đầu tiên trong async() -->

# yield là gì? [id:3413 order:13]
là trả thread về pool

# khi nào thread yield? [id:3414 order:14]
Khi `await` một Task chưa complete

# khi nào thread k kịp yield ? [id:3415 order:15]
khi task complete quá nhanh

# các trường hợp làm task complete nhanh đến nỗi thread k kịp yield? [id:3416 order:16]
Khi Task đã done trước khi `await` được evaluated"
- cache hit,
- I/O xong ngay trong cùng time slice.
- trong async k có await thật

# hầu hết IO-bound sẽ kịp yield phải không? [id:3417 order:17]
đúng

# ta có thể biết chính xác được cái nào chạy trước hết phải không? task complete vs thread yield [id:3418 order:18]
Không.
Lúc viết code không biết trước — phụ thuộc runtime: cache hit hay miss, network nhanh hay chậm, OS schedule thế nào.

# thứ tự task complete/thread yield có ảnh hưởng kq không? vì sao? [id:3419 order:19]
k ảnh hưởng, vì Kết quả cuối luôn giống nhau
— `await` đảm bảo code sau nó chỉ chạy khi Task xong.
Chỉ khác về performance: complete trước thì tiết kiệm 1 lần context switch, yield trước thì giải phóng thread cho request khác.

# không kịp yield nghĩa là gì? [id:3420 order:20]
`await` kiểm tra Task — nếu đã complete rồi thì chạy tiếp luôn trên thread hiện tại chứ k giải phóng thread

# khi nói thread gốc, main thread có nghĩa là thread nào? [id:3421 order:21]
request thread hoặc UI thread tùy ngữ cảnh

# batch nghĩa là gì? [id:3400 order:22]
lô / nhóm
là xử lý một lượng lớn item cùng một lúc thay vì từng cái một.
Ngược với stream (xử lý ngay khi có).
Ví dụ: đọc 1000 rows từ DB rồi trả về List → batch. Đọc từng row yield return → stream.

# stream nghĩa là gì? [id:3402 order:23]
là Dòng chảy liên tục của dữ liệu
— xử lý từng phần khi có, không cần chờ toàn bộ.
Ngược với batch (lấy hết rồi xử lý một lần).
Trong .NET: `Stream` (byte), `IEnumerable<T>` (sync), `IAsyncEnumerable<T>` (async) đều là stream theo nghĩa này.

<!--# IAsyncEnumerable có phổ biến k [id:3403 order:24]
Khá phổ biến -->

# khi nào dùng IAsyncEnumerable? [id:3404 order:25]
khi cần stream dữ liệu lớn mà không muốn load hết vào memory.