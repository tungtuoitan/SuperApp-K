---
id: 334
name: "array"
---

<!--# C#.Array là gì? [id:3155 order:1]
là cấu trúc để lưu phần tử cùng kiểu liên tiếp 1 cách tối ưu nhất? -->

# C#.Array có phải cấu trúc lưu phần tử cùng kiểu liên tiếp tối ưu nhất không? [id:3156 order:2]
Đúng.
Trong .NET, không có cấu trúc nào lưu phần tử cùng kiểu liên tiếp với overhead thấp hơn array. Mọi collection khác đều build trên array hoặc kém tối ưu hơn.

# lí do C#.Array tồn tại? [id:3157 order:3]
vì cần một cấu trúc base tốt để các collection khác build dựa trên nó.

# vì sao C#.Array có performance tốt? [id:3158 order:4]
- vì:
- fixed size,
- lưu liên tiếp trong memory

# tại sao fixed size và lưu liên tiếp thì performance tốt? [id:3372 order:5]
- Fixed size: CPU tính địa chỉ phần tử bằng index → truy cập O(1), không cần traverse.
- Lưu liên tiếp: CPU cache load theo block 64 byte (cache line) → nhiều phần tử được cache 1 lần, ít cache miss.

# traverse là gì? [id:3373 order:6]
là (v) duyệt qua từng phần tử theo thứ tự. Ví dụ: "traverse the array from index 0 to n."

# traverse phát âm? [id:3374 order:7]
/trəˈvɜːrs/

# traverse khác gì interate? [id:3375 order:8]
trong văn nói là 1

<!--# truy cập tức là đọc phải không? [id:3376 order:9]
Không.
truy cập (access) = đọc hoặc ghi -->

# cấu trúc cấp thấp nghĩa là gì? [id:3159 order:10]
là cấu trúc gần với phần cứng, ít abstraction.
Array map gần như 1-1 với cách CPU/RAM lưu data — không có thêm logic resize, hash, link giữa các node.

# cấu trúc càng gần phần cứng thì performance càng tốt phải k? vì sao? [id:3160 order:11]
Đúng.
Vì càng nhiều abstraction tức là càng nhiều code chạy trung gian -> gây tốn CPU và memory.

# code càng gần phần cứng thì càng ít abstraction phải không? tại sao? [id:3161 order:12]
Đúng.
Vì Càng gần phần cứng, dev càng phải tự xử lý chi tiết — không có lớp che.

# so sánh code bậc cao và code bậc thấp? [id:3377 order:13]
- Bậc thấp: ít abstraction, khó viết,  tự quản lý memory, performance cao.
- Bậc cao : nhiều abstraction, dễ viết, GC, performance thấp hơn.

# tại sao code bậc thấp thì performance tốt hơn? [id:3378 order:14]
- vì ít abstraction hơn thì code ngắn hơn, từ đó chạy nhanh hơn

# abstraction tạo ra overhead phải không? [id:3163 order:15]
Đúng. Mỗi lớp abstraction là code phụ chạy trung gian — tốn CPU cycle và memory. Đổi lại, dev viết code dễ hơn, ít bug hơn, tái sử dụng được nhiều.

# C là ngôn ngữ bậc thấp nhất mà thân thiện con người rồi phải không? [id:3164 order:16]
rot: đúng

# Musk tối ưu huấn luyện AI bằng cách dùng training-stack C để giảm abstraction phải không? [id:3165 order:17]
rot: đúng

# lưu liên tiếp trong memory nghĩa là gì? [id:3166 order:18]
các phần tử nằm sát nhau trong RAM, không bị phân mảnh. Nhờ vậy CPU có thể tính địa chỉ phần tử bằng công thức `base + index * size` và truy cập trong O(1).

# data type nào hay bị phân mảnh? [id:3167 order:19]
class, string, object
— mỗi instance được cấp phát riêng trên heap, địa chỉ rải rác. Linked list, dictionary cũng hay phân mảnh vì node/bucket nằm rời nhau.

# pointer có phải địa chỉ của ô nhớ không? [id:3168 order:20]
Đúng. Pointer là 1 số nguyên đại diện cho địa chỉ ô nhớ trong RAM, dùng để CPU biết phải đi tới đâu để lấy data.

# lợi ích/bất lợi của phân mảnh? [id:3169 order:21]
lợi: thêm/ xoá nhanh
hại: read chậm

# tại sao phân mảnh lại k tận dụng được CPU cache? [id:3170 order:22]
vì CPU cache load data theo block liên tiếp
(cache line, thường 64 byte). Khi data nằm liên tiếp, CPU đọc 1 lần được nhiều phần tử. Khi data phân mảnh, CPU phải đi tới nhiều địa chỉ khác nhau, mỗi lần load 1 cache line mới — tốn thời gian.

# array có phải là base cho hầu hết cấu trúc trong nhiều nền tảng nhiều ngôn ngữ không? [id:3171 order:23]
Đúng.
Hầu hết ngôn ngữ (C, C++, Java, C#, Python, JS) đều dùng array làm cấu trúc nền cho List/ArrayList/Vector/Stack/Queue. Vì array map gần với phần cứng, không thể tối ưu hơn để lưu phần tử liên tiếp.

# O1 có nghĩa là duyệt qua mọi phần tử 1 lần, có phải không? vì sao? [id:3172 order:24]
Không.
vì O(1) nghĩa là thời gian thực thi không phụ thuộc số lượng phần tử
— luôn cố định, không cần duyệt. Ví dụ truy cập `array[5]` là O(1) vì CPU tính địa chỉ trực tiếp, không quan tâm array có 10 hay 1 triệu phần tử. Duyệt qua mọi phần tử 1 lần là O(n).

# overhead là gì? [id:3173 order:25]
là chi phí phụ phát sinh
vd: List có overhead hơn array vì phải lưu thêm capacity, count, logic resize.

# ta k thể thêm/xoá item trong array à? [id:3174 order:26]
Đúng
Array có size cố định lúc khởi tạo, không thể thêm/xoá. Muốn "thêm" phải tạo array mới to hơn rồi copy data sang.