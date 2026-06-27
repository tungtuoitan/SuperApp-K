---
id: 356
name: "Task"
---

# async trả về gì? [id:3452 order:1]
`Task`
— wrapper bọc kết quả hoặc exception của một async operation.
- `async Task` → không có giá trị trả về
- `async Task<T>` → trả về T khi xong
- `async void` → không trả về gì, không track được (chỉ dùng cho event handler)

# trong Task chứa gì? [id:3453 order:2]
Trạng thái (status),
kết quả khi complete (cho `Task<T>`),
exception nếu Faulted,
và danh sách continuation (code đăng ký chạy khi Task complete).

# khi nào thì Task.status = Faulted ? [id:3454 order:3]
khi exception xảy ra bên trong async method và không được catch bên trong.

# Task có bao nhiêu status, Các status phổ biến của Task? [id:3455 order:4]
8
`Running`, `RanToCompletion`, `Faulted`, `Canceled`.