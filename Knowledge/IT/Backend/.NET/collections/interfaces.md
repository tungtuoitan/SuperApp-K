---
name: "interfaces"
---

# IEnumerable và IQueryable khác nhau thế nào?
`IEnumerable`: query chạy in-memory (client-side, load hết data về rồi filter). `IQueryable`: query được translate sang SQL và chạy ở database.

# IEnumerable dùng làm gì?
cho phép forEach và LINQ

# các interface phổ biến?
IList, ICollection, IEnumerable, IDictionary

# IList là con cháu của ICollection à?
Đúng. `IList<T>` kế thừa từ `ICollection<T>`, nên IList có mọi thứ ICollection có (Add, Remove, Count) cộng thêm index access (`list[i]`).

# A kế thừa từ B thì A gọi là gì?
A là derived class (con), B là base class (cha). Hoặc gọi A là subclass, B là superclass.

# ICollection khác gì IDictionary?
`ICollection<T>`: item có 1 value
IDictionary: item có 2 value (key - value)

# lợi và hại của 2 cái trên?
`ICollection`: đơn giản, thứ tự rõ ràng, duyệt nhanh. Không lookup theo key được.
`IDictionary`: lookup O(1) theo key, nhưng tốn memory hơn (lưu cả key lẫn value), không có thứ tự mặc định.

# các hành động phổ biến với data: lookup,duyệt,...?
- lookup: tìm 1 item theo key/index
- duyệt (iterate): đi qua từng item
- add/remove: thêm/xóa item
- filter: lọc items theo điều kiện
- sort: sắp xếp
- count: đếm số lượng

# trong ICollection item luôn có thứ tự à? vì sao?
Không. `ICollection<T>` chỉ define có Count, Add, Remove — không bắt buộc có thứ tự. Thứ tự phụ thuộc implementation: `List<T>` có thứ tự theo insertion, `HashSet<T>` thì không.

# ví dụ phổ biến dùng IEnumerable?
khi muốn loop mà k muốn dùng type cụ thể

# IEnumerable có được dùng phổ biến k?
Có, rất phổ biến. Dùng làm return type khi muốn cho phép caller iterate/LINQ mà không expose collection cụ thể. Nhiều method LINQ trả về `IEnumerable<T>`.

# lí do IEnumerable tồn tại?
dùng để duyệt qua 1 collection
