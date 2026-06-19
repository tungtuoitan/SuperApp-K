# tính kế thừa mặc định diễn ra thế nào?
Class con tự động thừa hưởng mọi member `public`, `protected`, `internal` của cha. Member `private` không kế thừa.

# rule của kế thừa?
Class con bắt buộc `override` mọi abstract member của cha, trừ khi class con cũng được khai báo là `abstract`.

# khi A : B và B : C thì A có liên hệ gì với C không?
Có, C là ông nội của A.

# thông thường có cần quan tâm đến class ông nội không? vì sao?
Không, vì class cha là đã đủ — class cha đã có tất cả member của ông nội rồi.

# khi nào cần quan tâm tới class ông nội?
chỉ khi cần override member do ông nội khai báo.

# tại sao class chỉ kế thừa được 1 class?
Vì C# cấm multiple class inheritance. Quy tắc này áp dụng cho mọi class, không riêng abstract class.

# vì sao c# lại cấm multiple class inheritance?
vì khi 2 cha cùng có method trùng tên, con không biết theo cha nào.

# cho ví dụ về vấn đề của multiple class inheritance?
C++ cho phép: `class C : public A, public B {}` — class `C` kế thừa cả `A` và `B`. Nếu cả `A` và `B` cùng có method `Print()` thì `c.Print()` mơ hồ — đây là diamond problem.

# những class nào không thể kế thừa?
sealed class.

# khi nào thì được override member của cha?
Khi member của cha được đánh dấu `virtual` hoặc `abstract`, và class con dùng `override`.

# override keyword dùng để làm gì?
Để class con thay implementation của member `virtual`/`abstract` trong class cha.

# override chỉ được dùng trong class con phải không?
Đúng. `override` chỉ có ý nghĩa khi thay implementation của member do class cha khai báo `virtual`/`abstract`. Class gốc (không kế thừa) không có gì để override.

# lí do override tồn tại?
- triển khai body cho abstract member
- thay implementation của virtual member

# nếu con cứ viết trùng signature của cha nhưng k dùng override thì sao?
Compiler warning, đề nghị thêm `new` hoặc `override`. Đây là method hiding: behavior phụ thuộc kiểu reference — gọi qua kiểu cha thì chạy method cha, gọi qua kiểu con thì chạy method con.

Ví dụ:
```csharp
class Animal { public void Speak() => Console.WriteLine("animal"); }
class Dog : Animal { public void Speak() => Console.WriteLine("dog"); }

Dog d = new Dog();
Animal a = d;
d.Speak(); // dog  - reference kiểu con
a.Speak(); // animal - reference kiểu cha (cùng instance)
```
Nếu dùng `override` (cha phải `virtual`) thì cả hai đều in `dog` — đó là polymorphism thật sự.

# hầu hết trường hợp, viết trùng signature thì sẽ đi kèm override phải không?
Đúng. Trùng signature mà cố tình không `override` (method hiding) là edge case hiếm — thường để giữ nguyên hành vi cũ khi gọi qua kiểu cha. Code thực tế gần như luôn dùng `override` để có polymorphism.

# overload là loại từ gì? [id:2908 order:25]
vừa là danh từ, vừa là động từ

# overload(n) là gì? [id:2909 order:26]
là hàm trùng tên nhưng khác params

# overide (v) là gì? [id:2911 order:28]
là việc lớp con thay đổi implementation của lớp cha

# keyword gì để overide(v)? [id:2912 order:29]
`override` ở lớp con, 
kết hợp `virtual` hoặc `abstract` ở lớp cha.
