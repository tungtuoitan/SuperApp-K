---
id: 324
name: "memory-resources"
---

# IDisposable và using statement dùng để làm gì? [id:2845 order:1]
`IDisposable` là interface để giải phóng tài nguyên unmanaged (file, connection, socket). `using` block tự gọi `Dispose()` khi ra khỏi scope.

# tài nguyên unmanaged nghĩa là gì? [id:2846 order:2]
là tài nguyên do OS quản lý chứ không phải CLR — file handle, network socket, DB connection. GC không tự dọn được, phải `Dispose()`.

# tài nguyên process k quản lí thì phải dispose mới dọn được phải không? [id:2847 order:3]
Đúng. Tài nguyên unmanaged (file handle, socket, DB connection) do OS giữ — CLR không tự thu hồi, phải gọi `Dispose()` để OS giải phóng.

# toàn bộ tài nguyên của process là do CLR quản lí à? [id:2848 order:4]
Không. CLR chỉ quản managed memory (object trên heap). Tài nguyên unmanaged như file/socket do OS giữ, CLR không động vào.

# tài nguyên của process gồm những gì? [id:2849 order:5]
- Memory (heap, stack)
- File handle, socket, DB connection
- Thread, timer
- Lock, mutex, semaphore
- Environment variables, working dir

# heap là tài nguyên của runtime à? [id:2850 order:6]
Đúng (managed heap). CLR cấp phát và quản managed heap, dùng để chứa object. GC quét heap này để dọn rác.

# heap chỉ là 1 phần của tài nguyên process phải k? [id:2851 order:7]
Đúng. Process có nhiều tài nguyên (file, socket, thread, ...), heap chỉ là vùng memory để chứa object.

# dispose là gì? [id:2852 order:8]
là giải phóng tài nguyên unmanaged. Class implement `IDisposable` phải có `Dispose()` để cleanup.