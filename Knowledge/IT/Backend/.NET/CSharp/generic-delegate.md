# generic là gì?
là cú pháp viết class/method dùng với nhiều kiểu mà không hard-code — `List<T>`, `Dictionary<K,V>`. Type-safe và không boxing.

# delegate là gì?
là keyword
# ví dụ keyword cùng loại với delegate?
- `event`: pub/sub
- `Action`, `Func`, `Predicate`: delegate built-in
- `Task`: đại diện work async
# khi nào dùng deletegate?
khi cần pass function như 1 tham số

# lambda expression là gì?
là cú pháp viết delegate ngắn — `x => x * 2`. Hay dùng với LINQ: `list.Where(x => x > 5)`.
# lambda chỉ dùng cho delegate và LINQ thôi à?
Không. Lambda dùng được mọi nơi cần delegate hoặc expression tree — event handler, Task callback, EF Core query, ...

# extension method là gì?
là where, select,... trong linQ
