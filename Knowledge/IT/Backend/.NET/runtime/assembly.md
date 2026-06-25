---
id: 319
name: "assembly"
---

# cho tôi vài câu phổ biến có dùng assemply? [id:2807 order:1]
- "load assembly vào memory"

# assembly là 1 ngôn ngữ code phải không? [id:2808 order:2]
Không. Assembly trong .NET là file output (`.dll`/`.exe`). Trùng tên với "Assembly language" (ngôn ngữ cấp thấp) nhưng khác hẳn nhau.

# assembly có mấy nghĩa? [id:2809 order:3]
Trong IT có 2: Assembly trong .NET (file `.dll`/`.exe`), và Assembly language (ngôn ngữ cấp thấp gần machine code).

# ý nghĩa tên assemply? [id:2810 order:4]
"Assembly" nghĩa là "lắp ráp" — assembly trong .NET là sản phẩm đã lắp ráp xong (IL + metadata + resource) sẵn sàng deploy.

# assembly là gì? [id:2798 order:5]
là đơn vị deploy của .NET — thường là file `.dll` hoặc `.exe`, chứa IL và metadata của 1 project hoặc library.

# đơn vị deploy là gì? [id:2799 order:6]
là phần nhỏ nhất mà bạn copy/ship lên server để app chạy. Trong .NET là file `.dll`/`.exe`.

# đơn vị deploy hầu hết là file phải không? [id:2800 order:7]
Đúng, nhưng cũng có thể là folder, container image (Docker), hoặc package (`.nupkg`, `.zip`) tùy cách ship.

# ship là gì? [id:2801 order:8]
là đóng gói và đưa code/sản phẩm lên môi trường thật để user dùng — có thể là deploy server, publish package, push image lên registry.