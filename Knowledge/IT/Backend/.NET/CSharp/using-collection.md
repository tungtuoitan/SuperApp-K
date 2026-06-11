# using directive và using statement khác nhau thế nào?
- using directive dùng để import namespace
- using statment dùng để gọi `Dispose()` khi ra scope

# collection phổ biến trong C#?
- `List<T>`: array tự resize
- `Dictionary<K,V>`: key-value
- `HashSet<T>`: tập hợp unique
- `Queue<T>`, `Stack<T>`: FIFO/LIFO
- `Array`: kích thước cố định
<!--
# IEnumerable, ICollection, IList khác nhau?
- `IEnumerable<T>`: chỉ duyệt qua, không sửa
- `ICollection<T>`: thêm `Count`, `Add`, `Remove`
- `IList<T>`: thêm index access (`list[0]`) -->
<!--
# foreach hoạt động thế nào?
duyệt mọi item của object implement `IEnumerable`. Compiler dịch sang gọi `GetEnumerator()` rồi `MoveNext()` + `Current`. -->

<!-- # yield return là gì?
là cú pháp viết iterator lazy — trả từng item, không cần build list trong memory. Dùng trong method trả về `IEnumerable<T>`. -->
