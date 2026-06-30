---
id: 349
name: "thread"
---

# mỗi process có 1 main thread để chạy app à? [id:3096 order:1]
Đúng.
OS tạo main thread khi process start, chạy `Main()` đầu tiên.

# mỗi process đều có 1 main thread à? [id:3098 order:3]
Đúng.
OS yêu cầu mọi process phải có 1 thread khởi đầu để chạy entry point. Process không có thread nào thì không tồn tại.

# main thread khác gì pool thread? [id:3099 order:4]
- Main thread: tạo bởi OS, tương ứng với process
- Pool thread: tạo bởi CLR, tương ứng với request

# thread nào chạy main code? [id:3361 order:5]
Main thread

<!--# khi nào main thread exist? [id:3362 order:6]
Khi `Main()` return (hoặc app gọi `Environment.Exit()`).
Với console app async, main thread chờ `await` hoàn thành rồi mới exit. -->

# Kernel là gì? nó là phần mềm à? [id:3363 order:7]
là phần mềm — lõi của hệ điều hành.
Kernel quản lý hardware (CPU, RAM, disk, network) và cung cấp syscall cho app. Không phải hardware, không phải firmware.

# ý nghĩa của tên Kernel? [id:3364 order:8]
"Kernel" tiếng Anh nghĩa là "hạt nhân", "lõi" — như nhân của hạt quả.
Đặt tên vậy vì nó là phần lõi cốt yếu của OS, mọi thứ khác (shell, app, driver) bao quanh và phụ thuộc vào nó.

# Kernel xử lí toàn bộ hoạt động I/O phải không? [id:3365 order:9]
Đúng.
App gọi I/O (đọc file, gửi packet) → syscall → kernel giao việc cho driver/hardware. Trong khi hardware xử lý, app thread không cần đợi (với async I/O), kernel sẽ notify khi xong.

# hoạt động IO là gì? ? [id:3366 order:10]
là phải hoạt động mà CPU phải chờ

# tại sao CPU phải chờ khi làm việc với thiết bị ngoài nhỉ?
vì CPU rất nhanh so với bọn chúng