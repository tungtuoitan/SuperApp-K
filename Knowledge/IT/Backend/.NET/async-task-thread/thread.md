---
id: 0
name: "thread"
---

# mỗi process có 1 main thread để chạy app à? [id:3096 order:36]
Đúng.
OS tạo main thread khi process start, chạy `Main()` đầu tiên.

# main thread có thuộc pool không? [id:3097 order:37]
không

# mỗi process đều có 1 main thread à? [id:3098 order:38]
Đúng.
OS yêu cầu mọi process phải có 1 thread khởi đầu để chạy entry point. Process không có thread nào thì không tồn tại.

# main thread khác gì pool thread? [id:3099 order:39]
- Main thread: tạo bởi OS, tương ứng với process
- Pool thread: tạo bởi CLR, tương ứng với request

# thread nào chạy main code?
Main thread

# khi nào main thread exist?
Khi `Main()` return (hoặc app gọi `Environment.Exit()`).
Với console app async, main thread chờ `await` hoàn thành rồi mới exit.

# Kernel là gì? nó là phần mềm à?
là phần mềm — lõi của hệ điều hành.
Kernel quản lý hardware (CPU, RAM, disk, network) và cung cấp syscall cho app. Không phải hardware, không phải firmware.

# ý nghĩa của tên Kernel?
"Kernel" tiếng Anh nghĩa là "hạt nhân", "lõi" — như nhân của hạt quả.
Đặt tên vậy vì nó là phần lõi cốt yếu của OS, mọi thứ khác (shell, app, driver) bao quanh và phụ thuộc vào nó.

# Kernel xử lí toàn bộ hoạt động I/O phải không?
Đúng.
App gọi I/O (đọc file, gửi packet) → syscall → kernel giao việc cho driver/hardware. Trong khi hardware xử lý, app thread không cần đợi (với async I/O), kernel sẽ notify khi xong.

# hoạt động IO là gì?
là thao tác đọc/ghi dữ liệu ngoài CPU
