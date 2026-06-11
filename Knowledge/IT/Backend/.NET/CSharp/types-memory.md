# value type và reference type khác nhau thế nào?
- Value type: lưu trên stack
- Reference type: lưu trên heap
# stack là gì?
là vùng memory dạng LIFO, dùng cho biến local và call frame của hàm. Cấp phát/giải phóng tự động khi vào/ra scope.
# heap là gì?
là vùng memory dùng cho object động (`new`). Object sống đến khi không còn reference, GC dọn rác.
# vai trò của stack?
- Lưu local variable, parameter, return address
- Tự động dọn khi hàm return
- Truy cập rất nhanh
# vai trò của heap?
- Lưu object có lifetime dài hơn scope hàm
- Cho phép share object qua reference
- Cần GC quản lý

# string trong C# là value hay reference type?
Reference type.
# điểm đặc biệt của string ?
là reference type nhưng behavior giống value type: immutable — sửa string là tạo string mới.
# nullable type là gì?
là kiểu cho phép giá trị `null`.
