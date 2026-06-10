# IDisposable và using statement dùng để làm gì?
`IDisposable` là interface để giải phóng tài nguyên unmanaged (file, connection, socket). `using` block tự gọi `Dispose()` khi ra khỏi scope.

# tài nguyên unmanaged nghĩa là gì?
là tài nguyên do OS quản lý chứ không phải CLR — file handle, network socket, DB connection. GC không tự dọn được, phải `Dispose()`.

# tài nguyên process k quản lí thì phải dispose mới dọn được phải không?
Đúng. Tài nguyên unmanaged (file handle, socket, DB connection) do OS giữ — CLR không tự thu hồi, phải gọi `Dispose()` để OS giải phóng.

# toàn bộ tài nguyên của process là do CLR quản lí à?
Không. CLR chỉ quản managed memory (object trên heap). Tài nguyên unmanaged như file/socket do OS giữ, CLR không động vào.

# tài nguyên của process gồm những gì?
- Memory (heap, stack)
- File handle, socket, DB connection
- Thread, timer
- Lock, mutex, semaphore
- Environment variables, working dir

# heap là tài nguyên của runtime à?
Đúng (managed heap). CLR cấp phát và quản managed heap, dùng để chứa object. GC quét heap này để dọn rác.

# heap chỉ là 1 phần của tài nguyên process phải k?
Đúng. Process có nhiều tài nguyên (file, socket, thread, ...), heap chỉ là vùng memory để chứa object.

# dispose là gì?
là giải phóng tài nguyên unmanaged. Class implement `IDisposable` phải có `Dispose()` để cleanup.
