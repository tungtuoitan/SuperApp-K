---
id: 25
name: "Token-based"
---

# Token-based phù hợp với hệ thống nào? [id:62 order:1]
phù hợp với hầu hết các hệ thống

# Token-based không phù hợp với hệ thống nào? [id:228 order:2]
web server side rendering
hệ thống cần revoke quyền ngay lập tức
hệ thống tài chính/ ngân hàng

# tại sao token-based k phù hợp với hệ thống ngân hàng? [id:229 order:3]
vì ngân hàng cần bảo mật cao, cần ban user NGAY LẬP TỨC, và token k thể làm điều đó

# tại sao session phù hợp với SSR web, còn token thì không phù hợp? [id:230 order:4]
vì ta k thể gắn token vào page request

# lí do cốt lõi mà SSR k thể dùng token là gì? [id:3065 order:5]
do ta k thể gắn token vào page request

# sự khác nhau giữa SPA và SSR khi thao tác với DOM? [id:3066 order:6]
- SSR: mỗi khi có page mới thì browser dựng lại toàn bộ DOM
- SPA: js sẽ CRUD với DOM trực tiếp

# Flow navigation của SSR? [id:3067 order:7]
navigation → page request > server render HTML → browser nhận HTML → browser reload page.

# ta k thể gắn token vào page request phải k? vì sao? [id:3068 order:8]
Đúng.
vì page request được thiết kế như vậy

# request trong SSR gọi là gì? [id:3069 order:9]
**Page request** (hoặc **document request**, **navigation request**).
Là HTTP request browser tự tạo khi navigation, server trả về HTML đầy đủ. Khác với **API call** (request trả về JSON cho JS xử lý).

# page request khác gì so với api thông thường? [id:3070 order:10]
- Page request: browser tự tạo khi navigate, server trả HTML đầy đủ để browser dựng page.
- API call: JS chủ động fetch, server trả JSON cho JS xử lý, không reload page.

# trong SSR, hầu hết api là page request phải không? [id:3071 order:11]
đúng.

# trong SSR có api call không? chúng dùng để làm gì? [id:3072 order:12]
Có.
Dùng cho các tương tác phụ nhỏ: search auto-complete, vote/like button...

# browser navigation là gì? [id:3073 order:13]
là gõ URL, F5, click thẻ `<a href>`, submit `<form>`): browser TỰ tạo HTTP request

# SSR bắt buộc gắn liền với browser navigation à? [id:3074 order:14]
Đúng.

# tại sao browser navigation lại gọi page request? [id:3075 order:15]
Vì khi navigation, browser tạo request mặc định `Accept: text/html' để reload page

# sự khác biệt giữa SSR và hybrid? [id:3076 order:16]
- SSR thuần: server render toàn bộ HTML
- Hybrid: browser navigation đầu tiên lấy full html, sau đó thì work như SPA.

# lí do hybrid web tồn tại? [id:3077 order:17]
Để có cả SEO/first-paint nhanh của SSR lẫn UX mượt của SPA. Server render page đầu cho crawler đọc được + user thấy nội dung ngay, sau đó JS hydrate để các navigation tiếp theo chạy như SPA, không reload.

# Cách nhận biêt SSR và SPA? [id:3078 order:18]
SPA
- request trả về html rỗng
- api call phổ biến
SSR
- trả về html full
- hầu hết api là page request

# trong SPA thì mọi request đến server sau public/index.html request sẽ phải cần token phải không? [id:3079 order:19]
Đúng.
Request 1 chỉ tải HTML rỗng + bundle JS (chưa có token). Sau khi JS chạy, mọi request tiếp theo (API call) mới gắn token vào header `Authorization`.

# cách nhận biết source là SPA? [id:3080 order:20]
- trong HTML file chỉ có 1 `<div id="root">` (hoặc `#app`) + thẻ `<script>`.
- trong Network tab chỉ có 1 request HTML duy nhất

# cách nhận biết source là SSR [id:3081 order:21]
- file html có đầy đủ UI
- tắt js trong browser web vẫn ok
- mỗi lần navigate đều có page request

# tắt js trong browser nghĩa là gì? [id:3082 order:22]
là vào setting browser disable thực thi JavaScript, mọi file `.js` tải về sẽ không chạy. Dùng để test xem page có còn dùng được không khi không có JS — SSR thật sẽ vẫn render UI, SPA sẽ chỉ thấy `<div id="root">` rỗng.

# trong web, request đầu tiên luôn là page request phải không? [id:3083 order:23]
Đúng.
Khi user gõ URL/click link, browser luôn tạo page request (`Accept: text/html`) để load HTML đầu. Sau đó JS mới có thể tạo API call. Không có cách nào để API call đứng trước page request đầu tiên.

# tại sao trong network chỉ tải về index.html và js nhưng web lại có login btn UI? [id:3084 order:24]
vì file js tạo ra UI
Khi bundle chạy, React gọi `createElement` + `ReactDOM.render` để chèn DOM nodes (button, input...) vào `<div id="root">`. HTML file không chứa UI — JS sinh ra UI tại runtime trong DOM.

# trong spa, file js chứa hầu hết mọi thứ à? [id:3085 order:25]
Đúng.
Bundle JS chứa toàn bộ UI components, routing, state management, và code gọi API. HTML chỉ là khung rỗng (`<div id="root">`). CSS có thể nằm trong JS (CSS-in-JS) hoặc tách file riêng. Data động fetch từ API server lúc runtime.

# flow của SPA? [id:3086 order:26]
- browser gõ URL → tải HTML rỗng + bundle JS → JS chạy → render UI