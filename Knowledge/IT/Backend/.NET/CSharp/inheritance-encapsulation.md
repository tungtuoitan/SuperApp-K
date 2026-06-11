# inheritance là gì?
là kế thừa — class con có toàn bộ member của class cha. C# chỉ hỗ trợ single inheritance (1 class cha) nhưng nhiều interface.
# inheritance đọc thế nào?
Đọc là "in-he-ri-tần" (tiếng Anh /ɪnˈher.ɪ.təns/).

<!-- # virtual và override là gì?
- `virtual`: cho phép class con override method
- `override`: class con thay đổi cài đặt method virtual của cha -->

# sealed là gì?
là từ khoá chặn kế thừa

# encapsulation là gì?
là đóng gói để che giấu state bên trong class, chỉ phơi qua property/method. Dùng access modifier (`private`, `public`, `protected`, `internal`).
# public api có phải là encapsulation k?
Không trực tiếp. Public API là phần class phơi ra — encapsulation là nguyên tắc che giấu phần còn lại. Public API là kết quả của việc encapsulate đúng cách.
# encapsulation có phải abstract không?
Khác. Encapsulation che giấu chi tiết của 1 class. Abstraction là che giấu chi tiết qua interface/abstract class — focus vào "what", bỏ qua "how".

# access modifier có những loại nào?
- `public`: ai cũng truy cập được
- `private`: chỉ trong class
- `protected`: trong class + class con
- `internal`: trong cùng assembly
- `protected internal`: kết hợp protected + internal
# modifier có nghĩa là gì?
là "bộ điều chỉnh" — từ khoá thay đổi behavior/quyền truy cập của member. Ví dụ access modifier (`public`/`private`), inheritance modifier (`virtual`/`sealed`), storage modifier (`static`/`readonly`).
