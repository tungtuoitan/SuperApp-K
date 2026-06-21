---
id: 337
name: "iterate-loop"
---

# LINQ là gì? [id:3189 order:1]
là cú pháp query collection tương tự SQL

# LINQ giống sql ở chỗ nào? [id:3190 order:2]
giống ở cú pháp

<!--# interate là gì? có phải loop không? [id:3191 order:3]
là duyệt qua từng phần tử của collection. -->

# loop là 1 chuỗi các interation phải không? [id:3192 order:4]
Đúng. Loop (`for`, `while`) là cơ chế lặp lại. Mỗi lần lặp là 1 iteration. Iterate qua collection = loop qua từng phần tử.

<!--# loop khác gì interate? [id:3193 order:5]
loop là cơ chế (for, while, foreach). iterate là hành động duyệt qua collection. Có thể iterate mà không cần loop tường minh (LINQ, recursion). Loop không nhất thiết phải iterate collection — có thể lặp đếm số (`for i = 0..9`). -->

# cho tôi câu nói ví dụ dùng cả 2 từ đi? [id:3194 order:6]
"Chúng ta dùng loop `foreach` để iterate qua từng phần tử trong list." — loop là cái vòng lặp, iterate là hành động đang làm bên trong.

<!--# duyệt là đi từ 1 đến 9, còn loop là lặp đi lặp lại việc đi từ 1 đến 9 phải không? [id:3195 order:7]
Gần đúng nhưng ngược. Iterate (duyệt) là hành động đi qua từng phần tử — tức là đi từ 1 đến 9 một lần. Loop là cơ chế cho phép lặp lại hành động đó nếu cần. Khi duyệt collection, thường chỉ đi qua mỗi phần tử 1 lần. -->

# ví dụ phổ biến của loop và interate? [id:3196 order:8]
Loop không iterate: `for (int i = 0; i < 10; i++)` — lặp đếm số.
Iterate trong loop: `foreach (var user in users)` — duyệt collection.
Iterate không có loop tường minh: `users.Where(u => u.IsActive)` — LINQ iterate bên trong, không thấy loop.

# phân biệt loop và interate? [id:3197 order:9]
interate là hành động đi qua từng item, còn loop là lặp đi lặp lại 1 hành động cụ thể, hành động có thể là interate hoặc là 1 phép tính

# trong loop k nhất thiết phải là interate phải k? [id:3198 order:10]
Đúng. Ví dụ `while (true) { doWork(); }` là loop nhưng không iterate collection — nó lặp lại một hành động, không duyệt qua phần tử nào.