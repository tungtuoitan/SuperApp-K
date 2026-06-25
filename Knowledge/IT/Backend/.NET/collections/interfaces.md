---
id: 336
name: "interfaces"
---

# IEnumerable và IQueryable khác nhau thế nào? [id:3177 order:1]
`IEnumerable`: query chạy in-memory (client-side, load hết data về rồi filter). `IQueryable`: query được translate sang SQL và chạy ở database.

# IEnumerable dùng làm gì? [id:3178 order:2]
cho phép forEach và LINQ

# các interface phổ biến? [id:3179 order:3]
IList, ICollection, IEnumerable, IDictionary

# IList là con cháu của ICollection à? [id:3180 order:4]
Đúng. `IList<T>` kế thừa từ `ICollection<T>`, nên IList có mọi thứ ICollection có (Add, Remove, Count) cộng thêm index access (`list[i]`).

# A kế thừa từ B thì A gọi là gì? [id:3181 order:5]
A là derived class (con), B là base class (cha). Hoặc gọi A là subclass, B là superclass.

# ICollection khác gì IDictionary? [id:3182 order:6]
`ICollection<T>`: item có 1 value
IDictionary: item có 2 value (key - value)

# so sánh ICollection và IDictionary ? [id:3183 order:7]
`ICollection`: interate nhanh
`IDictionary`: lookup nhanh, tốn memory nhiều

# các hành động phổ biến với data: lookup,duyệt,...? [id:3184 order:8]
- lookup: tìm 1 item theo key/index
- duyệt (iterate): đi qua từng item
- add/remove: thêm/xóa item
- filter: lọc items theo điều kiện
- sort: sắp xếp
- count: đếm số lượng

# trong ICollection item luôn có thứ tự à? vì sao? [id:3185 order:9]
Không. `ICollection<T>` chỉ define có Count, Add, Remove — không bắt buộc có thứ tự. Thứ tự phụ thuộc implementation: `List<T>` có thứ tự theo insertion, `HashSet<T>` thì không.

# ví dụ phổ biến dùng IEnumerable? [id:3186 order:10]
khi muốn loop mà k muốn dùng type cụ thể

# IEnumerable có được dùng phổ biến k? [id:3187 order:11]
Có, rất phổ biến. Dùng làm return type khi muốn cho phép caller iterate/LINQ mà không expose collection cụ thể. Nhiều method LINQ trả về `IEnumerable<T>`.

# lí do IEnumerable tồn tại? [id:3188 order:12]
dùng để duyệt qua 1 collection