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


# lí do cốt lõi mà SSR k thể dùng token là gì?
do ta k thể gắn token vào page request

# sự khác nhau giữa SPA và SSR khi thao tác với DOM?
- SSR: mỗi khi có page mới thì browser dựng lại toàn bộ DOM
- SPA: js sẽ CRUD với DOM trực tiếp

# Flow navigation của SSR?
navigation → page request > server render HTML → browser nhận HTML → browser reload page. 
# ta k thể gắn token vào page request phải k? vì sao?
Đúng. 
vì page request được thiết kế như vậy

# request trong SSR gọi là gì?
**Page request** (hoặc **document request**, **navigation request**). 
Là HTTP request browser tự tạo khi navigation, server trả về HTML đầy đủ. Khác với **API call** (request trả về JSON cho JS xử lý).
# page request khác gì so với api thông thường?
- Page request: browser tự tạo khi navigate, server trả HTML đầy đủ để browser dựng page.
- API call: JS chủ động fetch, server trả JSON cho JS xử lý, không reload page.

# trong SSR, hầu hết api là page request phải không?
đúng.
# trong SSR có api call không? chúng dùng để làm gì?
Có. 
Dùng cho các tương tác phụ nhỏ: search auto-complete, vote/like button...

# browser navigation là gì?
là gõ URL, F5, click thẻ `<a href>`, submit `<form>`): browser TỰ tạo HTTP request

# SSR bắt buộc gắn liền với browser navigation à?
Đúng. 
# tại sao browser navigation lại gọi page request?
Vì khi navigation, browser tạo request mặc định `Accept: text/html' để reload page

# sự khác biệt giữa SSR và hybrid?
- SSR thuần: server render toàn bộ HTML 
- Hybrid: browser navigation đầu tiên lấy full html, sau đó thì work như SPA.
# lí do hybrid web tồn tại?
Để có cả SEO/first-paint nhanh của SSR lẫn UX mượt của SPA. Server render page đầu cho crawler đọc được + user thấy nội dung ngay, sau đó JS hydrate để các navigation tiếp theo chạy như SPA, không reload.

# Cách nhận biêt SSR và SPA?
SPA
- request trả về html rỗng
- api call phổ biến
SSR
- trả về html full
- hầu hết api là page request

# trong SPA thì mọi request đến server sau public/index.html request sẽ phải cần token phải không?
Đúng. 
Request 1 chỉ tải HTML rỗng + bundle JS (chưa có token). Sau khi JS chạy, mọi request tiếp theo (API call) mới gắn token vào header `Authorization`.
# cách nhận biết source là SPA?
- trong HTML file chỉ có 1 `<div id="root">` (hoặc `#app`) + thẻ `<script>`. 
- trong Network tab chỉ có 1 request HTML duy nhất

# cách nhận biết source là SSR
- file html có đầy đủ UI
- tắt js trong browser web vẫn ok
- mỗi lần navigate đều có page request
# tắt js trong browser nghĩa là gì?
là vào setting browser disable thực thi JavaScript, mọi file `.js` tải về sẽ không chạy. Dùng để test xem page có còn dùng được không khi không có JS — SSR thật sẽ vẫn render UI, SPA sẽ chỉ thấy `<div id="root">` rỗng.

# trong web, request đầu tiên luôn là page request phải không?
Đúng.
Khi user gõ URL/click link, browser luôn tạo page request (`Accept: text/html`) để load HTML đầu. Sau đó JS mới có thể tạo API call. Không có cách nào để API call đứng trước page request đầu tiên.

# tại sao trong network chỉ tải về index.html và js nhưng web lại có login btn UI?
vì file js tạo ra UI
Khi bundle chạy, React gọi `createElement` + `ReactDOM.render` để chèn DOM nodes (button, input...) vào `<div id="root">`. HTML file không chứa UI — JS sinh ra UI tại runtime trong DOM.
# trong spa, file js chứa hầu hết mọi thứ à?
Đúng. 
Bundle JS chứa toàn bộ UI components, routing, state management, và code gọi API. HTML chỉ là khung rỗng (`<div id="root">`). CSS có thể nằm trong JS (CSS-in-JS) hoặc tách file riêng. Data động fetch từ API server lúc runtime.

# flow của SPA?
- browser gõ URL → tải HTML rỗng + bundle JS → JS chạy → render UI