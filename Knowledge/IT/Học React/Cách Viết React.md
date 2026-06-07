---
id: 285
name: "Cách Viết React"
---

# vì sao nên dùng function component thay vì class component? [id:2357 order:1]
vì function component ít boiler code

# Khi nào helper funciton có thể nằm trong component? [id:2358 order:2]
- khi function nhỏ
- hoặc component nhỏ
- k tái sử dụng

# markup là gì? [id:2359 order:3]
- là html

# Tại sao lại nên dùng  configuration object để viết repeat markup? [id:2360 order:4]
code dễ đọc, dễ sửa hơn do tuân thủ DRY và data-driven

# 4 nguyên tắc viết component? [id:2361 order:5]
- chỉ nên làm 1 việc
- logic nhiều thì viết thành hook
- max 5 props
- tránh nest

# vai trò của error-boundary? [id:2362 order:6]
tránh crash app toàn bộ

# Cách dùng react-error-boundary? [id:2363 order:7]
- bọc chúng ở component dễ gây bug

# dấu hiệu của 1 component đang làm quá nhiều việc? [id:2364 order:8]
- nhiều props

# component nhận nhiều props thì sao? [id:2365 order:9]
- dễ bị re-render

# vì sao props.A, props.B ít được sử dụng? [id:2366 order:10]
vì nó làm boiler code

# destructure là gì? [id:2367 order:11]
là dùng thuộc tính trực tiếp thay vì object

# primitives là gì? [id:2368 order:12]
- kiểu dữ liệu nguyên thuỷ (string, number,...)

# khi nào thì nên tạo  component riêng cho List? [id:2369 order:13]
khi nào không nên ? [id:128 order:13]
hầu hết là nên tách,
k nên tách khi component chính đơn giản

# vấn đề khi KHÔNG tách List ra khỏi markup? [id:2370 order:14]
Khó scan code
Khó reuse list

# explicit public API" pattern là gì? [id:2371 order:15]
là chủ động định nghĩa rõ những gì public trong 1 module, thay vì để lộ "tất cả" 1 cách mặc định

# So sánh Featured-base và Layout-based structure? [id:2372 order:16]
featured-base dễ mở rộng, phù hợp với app vừa và lớn, còn layout-based thì phù hợp với app nhỏ

# Làm sao tránh cross-feature import [id:2373 order:17]
tạo rule trong eslint để báo lỗi khi có cross feature

# Vì sao state đặt gần thì performance càng tốt? [id:2374 order:18]
vì state càng trên cao, nó càng dễ trigger re-render lan rộng, gây ra bad performance

# Khi nào thì nên cache server state? [id:2375 order:19]
- khi data nặng và ít thay đổi

# phân biệt Server state và UI state? [id:2376 order:20]
server state là data từ server
còn UI state là data mà user đang edit ở client

# Form state là gì ? [id:2377 order:21]
là toàn bộ trạng thái của 1 form,
ví dụ: value, isTouched, error,...

# Khi nào dùng Form state? [id:2378 order:22]
khi nào cần thì dùng, hiện tại tự dùng là đủ rồi,
việc này tương tự việc dùng fetch thủ công thay vì Axios

# 4 nguyên tắc viết FE? [id:2379 order:23]
- public api
- Layered Architecture
- Interceptor
- Shared

# Khi nào thì nên move local state lên trên? [id:2380 order:24]
- khi cần share với các component khác
- khi nó bị props drilling

# lợi ích của state ở gần nơi sử dụng ? [id:2381 order:25]
- code dễ hiểu
- performance tốt

# props drilling là gì? [id:2382 order:26]
là việc prop bị truyền qua quá nhiều tầng component

# Interceptor là gì? [id:2383 order:27]
có chức năng gì? [id:170 order:30]
à lớp đứng giữa app và server,
có chức năng xử lí mọi lỗi trước khi app thấy chúng

# Cách abstract UI component đúng cách? [id:2384 order:28]
- không abstract ngay
- quan sát pattern lặp lại của chúng
- khi đủ 3 usecase giống nhau thì hãy abstract

# 2 extension nên dùng trong FE? [id:2385 order:29]
- ESLint
- Prettier

# Nguyên tắc viết code? [id:2386 order:30]
- code nên ở gần nơi sử dụng

# layer-based structure là gì? [id:2387 order:31]
là mỗi loại file có 1 folder lớn tương ứng

# Layer Architecture là gì? [id:2388 order:32]
là kiến trúc phân tầng: app > feature > shared
flow đi theo chiều từ trên xuống

# Feature-based architecture là gì? [id:2389 order:33]
là mỗi feature có 1 folder tương ứng

# public api là gì? [id:2390 order:34]
là việc import/export giữa các feature thông qua file index

# tradeoff của caching là gì? [id:2391 order:35]
dữ liệu có thể bị cũ

# code bị nest thì sao? [id:2392 order:36]
thì khó scan, khó đọc