---
name: "IO-CPU-bound"
---

# I/O bound là gì?
là Tác vụ mà thời gian chờ chủ yếu là chờ thiết bị ngoài (disk, network, DB)
 — CPU nhàn rỗi trong lúc chờ. Ngược với CPU-bound (CPU bận suốt).

# các hoạt động I/O phổ biến?
- Đọc/ghi file, DB query, HTTP request
- Blob upload/download
- `await stream.CopyToAsync()`, `await File.ReadAllBytesAsync()`

# những hoạt động phổ biến là CPU/blocking
- `stream.CopyTo()`, `File.ReadAllBytes()` — sync file I/O
- JSON serialize/deserialize lớn
- BCrypt/SHA hash
- Resize ảnh, xử lý video
- `Thread.Sleep()`, `.Result`, `.Wait()` — blocking wait

# các hoạt động với stream đều là CPU-bound à?
Không. disk/network stream đều là I/O-bound. 
Nhưng API sync như `stream.CopyTo()` block thread trong khi chờ — thread bị giữ như CPU-bound. Dùng `CopyToAsync()` để thread không bị block.

# stream chỉ có 2 loại: từ network và từ disk phải không?
Không. 
Còn nhiều loại: memory stream (`MemoryStream`), pipe stream, crypto stream, compression stream... Disk và network chỉ là 2 loại phổ biến nhất.

# có stream từ memory không?
Có — `MemoryStream` đọc/ghi trực tiếp trên buffer trong RAM. Không có I/O wait → CPU-bound, rất nhanh.

# đọc file từ ổ cứng, memory có phải CPU-bound không? vì sao?
- Từ ổ cứng thì là I/O-bound — vì phải chờ disk, CPU nhàn trong lúc đó.
- Từ memory/RAM (đã cache) thì là CPU-bound

# ghi file trong ổ cứng cũng là I/O à?
Có — ghi disk là I/O-bound, CPU chờ disk controller ghi xong. 
Dùng `await File.WriteAllBytesAsync()` thay vì sync để không block thread.
