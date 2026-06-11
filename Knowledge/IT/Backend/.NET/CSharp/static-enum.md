# static là gì?
là từ khoá đánh dấu member thuộc về class chứ không thuộc instance — gọi qua class name, không cần `new`.
# x thuộc về class/instance thì khác nhau gì?
- Thuộc class (static): 1 bản chung cho cả class, gọi qua `ClassName.x`
- Thuộc instance: mỗi object có bản riêng, gọi qua `obj.x`

# readonly và const khác nhau thế nào?
- `const`: compile-time constant, phải gán lúc khai báo, implicit static
- `readonly`: runtime constant, gán lúc khai báo hoặc trong constructor

# const có giống const trong js k?
Khác. C# `const` là compile-time, chỉ cho primitive/string. JS `const` là runtime, chỉ chặn rebind biến — vẫn sửa được property của object.
# compile-time và runtime thì khác gì nhỉ, liên quan gì đến biến?
- Compile-time: lúc compiler dịch code → giá trị phải biết trước
- Runtime: lúc app chạy → giá trị có thể tính ra hoặc nhận từ input
`const` cần biết giá trị lúc compile, `readonly` chỉ cần biết khi tạo object.

# enum là gì?
là kiểu liệt kê
# enum dùng khi nào?
khi cần tập hợp hằng số có tên.
# ý nghĩa từ enum?
viết tắt của "enumeration" — liệt kê. Trong toán/lập trình nghĩa là đánh số/đặt tên cho các giá trị rời rạc.
