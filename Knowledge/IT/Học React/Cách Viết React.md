---
id: 13
name: "Cách Viết React"
---

# vì sao nên dùng function component thay vì class component? [id:141 order:1]
vì function component ít boiler code

# Khi nào helper funciton có thể nằm trong component? [id:142 order:2]
- khi function nhỏ
- hoặc component nhỏ
- k tái sử dụng

# markup là gì? [id:117 order:3]
- là html

# Tại sao lại nên dùng configuration object để viết repeat markup? [id:143 order:4]
code dễ đọc, dễ sửa hơn do tuân thủ DRY và data-driven

# 4 nguyên tắc viết component? [id:118 order:5]
- chỉ nên làm 1 việc
- logic nhiều thì viết thành hook
- max 5 props
- tránh nest

# vai trò của error-boundary? [id:144 order:6]
tránh crash app toàn bộ

# Cách dùng react-error-boundary? [id:120 order:7]
- bọc chúng ở component dễ gây bug

# dấu hiệu của 1 component đang làm quá nhiều việc? [id:121 order:8]
- nhiều props

# component nhận nhiều props thì sao? [id:122 order:9]
- dễ bị re-render

# vì sao props.A, props.B ít được sử dụng? [id:145 order:10]
vì nó làm boiler code

# destructure là gì? [id:126 order:11]
là dùng thuộc tính trực tiếp thay vì object

# primitives là gì? [id:127 order:12]
- kiểu dữ liệu nguyên thuỷ (string, number,...)

# khi nào thì nên tạo component riêng cho List? khi nào không nên ? [id:128 order:13]
hầu hết là nên tách,
k nên tách khi component chính đơn giản

# vấn đề khi KHÔNG tách List ra khỏi markup? [id:129 order:14]
Khó scan code
Khó reuse list

# explicit public API" pattern là gì? [id:155 order:15]
là chủ động định nghĩa rõ những gì public trong 1 module, thay vì để lộ "tất cả" 1 cách mặc định

# So sánh Featured-base và Layout-based structure? [id:211 order:16]
featured-base dễ mở rộng, phù hợp với app vừa và lớn, còn layout-based thì phù hợp với app nhỏ

# Làm sao tránh cross-feature import [id:156 order:17]
tạo rule trong eslint để báo lỗi khi có cross feature

<!--# Nguyên tắc dùng state? [id:158 order:18]
đặt gần nơi sử dụng nhất có thể
- bắt đầu đặt state ở component, sau đó nâng level lên dần khi cần thiết -->

# Vì sao state đặt gần thì performance càng tốt? [id:159 order:19]
vì state càng trên cao, nó càng dễ trigger re-render lan rộng, gây ra bad performance

# Khi nào thì nên cache server state? [id:160 order:20]
- khi data nặng và ít thay đổi

# phân biệt Server state và UI state? [id:161 order:21]
server state là data từ server
còn UI state là data mà user đang edit ở client

# Form state là gì ? [id:162 order:22]
là toàn bộ trạng thái của 1 form,
ví dụ: value, isTouched, error,...

# Khi nào dùng Form state? [id:163 order:23]
khi nào cần thì dùng, hiện tại tự dùng là đủ rồi,
việc này tương tự việc dùng fetch thủ công thay vì Axios

# 4 nguyên tắc viết FE? [id:165 order:24]
- public api
- Layered Architecture
- Interceptor
- Shared

# Khi nào thì nên move local state lên trên? [id:167 order:25]
- khi cần share với các component khác
- khi nó bị props drilling

# lợi ích của state ở gần nơi sử dụng ? [id:168 order:26]
- code dễ hiểu
- performance tốt

# props drilling là gì? [id:169 order:27]
là việc prop bị truyền qua quá nhiều tầng component

# Interceptor là gì? có chức năng gì? [id:170 order:28]
à lớp đứng giữa app và server,
có chức năng xử lí mọi lỗi trước khi app thấy chúng

# Cách abstract UI component đúng cách? [id:171 order:29]
- không abstract ngay
- quan sát pattern lặp lại của chúng
- khi đủ 3 usecase giống nhau thì hãy abstract

# 2 extension nên dùng trong FE? [id:187 order:30]
- ESLint
- Prettier

# Nguyên tắc viết code? [id:188 order:31]
- code nên ở gần nơi sử dụng

# layer-based structure là gì? [id:273 order:32]
là mỗi loại file có 1 folder lớn tương ứng

# Layer Architecture là gì? [id:189 order:33]
là kiến trúc phân tầng: app > feature > shared
flow đi theo chiều từ trên xuống

# Feature-based architecture là gì? [id:274 order:34]
là mỗi feature có 1 folder tương ứng

# public api là gì? [id:190 order:35]
là việc import/export giữa các feature thông qua file index

# public api có liên hệ gì với abstract không? [id:2802 order:36]
Có. Public API là 1 dạng abstraction — chỉ phơi ra những gì cần dùng (qua `index.ts`), giấu chi tiết bên trong feature. Code ngoài chỉ thấy interface, không biết implementation.

# tradeoff của caching là gì? [id:225 order:37]
dữ liệu có thể bị cũ

# code bị nest thì sao? [id:232 order:38]
thì khó scan, khó đọc