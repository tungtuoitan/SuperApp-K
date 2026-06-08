---
id: 62
name: "webpack-hmr"
---

# webpack là gì? [id:484 order:0]
Công cụ "module bundler" — đọc tất cả file JS/TS/CSS/assets của project, xử lý (compile TypeScript, transpile ES6+, minify), rồi đóng gói thành các file output mà browser hiểu.

# Bundler làm gì? [id:485 order:1]
Chuyển source code hiện đại (TypeScript, SCSS, ES modules) thành HTML/CSS/JS thuần mà browser đọc được. Browser chỉ hiểu HTML/CSS/JS — bundler làm cầu nối.

# HMR là gì? [id:486 order:2]
Hot Module Replacement — tính năng của webpack cho phép cập nhật code trong browser mà không cần reload toàn trang. Khi bạn sửa file, chỉ module đó được thay thế, state của app giữ nguyên.

# webpack-dev-server là gì? [id:487 order:3]
HTTP server nhỏ chạy trong development — serve file FE và hỗ trợ HMR. Khi chạy `npm start`, thực chất là chạy webpack-dev-server trên port 3000.

# webpack-dev-server có nằm trong webpack không? [id:488 order:4]
Không. Đây là package riêng (`webpack-dev-server`), chạy kết hợp với webpack. webpack làm build, webpack-dev-server làm serve và watch.

# WebSocket là gì? [id:489 order:5]
Giao thức (RFC 6455) kết nối 2 chiều liên tục, chạy trên TCP. Bắt đầu bằng HTTP handshake rồi upgrade lên WebSocket protocol. URL dùng `ws://` hoặc `wss://` (encrypted).

# Module trong webpack là gì? [id:490 order:6]
Thường là 1 file source (1 `.ts` hoặc `.tsx`). Webpack bundle nhiều module thành ít file JS output. HMR "module X thay đổi" = đúng 1 file source đó, không phải toàn bộ bundle.

# Công việc của webpack-dev-server? [id:491 order:7]
1. Serve `index.html` + JS bundle cho mọi route (SPA)
2. Watch file changes → trigger webpack recompile
3. Duy trì WebSocket để push HMR updates xuống browser
4. Proxy API requests nếu có cấu hình

# HMR dùng giao thức gì để nhận thông báo từ server? [id:492 order:8]
WebSocket — kết nối 2 chiều liên tục giữa browser và webpack-dev-server. Khi code thay đổi, server push thông báo qua WebSocket, browser tự fetch module mới.

<!--# `WDS_SOCKET_HOST` và `WDS_SOCKET_PORT` là gì? [id:493 order:9]
Biến env cho webpack-dev-server biết HMR WebSocket nên kết nối tới host và port nào. -->

# WebSocket hoạt động thế nào? [id:494 order:10]
Khác HTTP (gửi → nhận → đóng), WebSocket là kết nối 2 chiều liên tục:
1. Client gửi HTTP request đặc biệt: `Upgrade: websocket`
2. Server đồng ý → connection được "upgrade", không đóng nữa
3. Cả 2 bên gửi message bất cứ lúc nào, không cần request/response

# WebSocket nhanh vì connection luôn mở? [id:495 order:11]
Đúng. HTTP phải tạo connection mới cho mỗi request (overhead: TCP handshake + HTTP headers). WebSocket giữ connection → không overhead → latency thấp hơn, phù hợp cho real-time (chat, HMR, game).

# Khi vào `localhost:3000`, browser lấy HTML/CSS/JS thế nào? [id:496 order:12]
Browser gửi `GET /` đến webpack-dev-server → server trả `index.html` → browser parse HTML, thấy thẻ `<script>` → gửi thêm request lấy JS bundle → JS chạy → React render UI.

# Khi chạy `localhost:3000`, request có IP nguồn là gì? [id:497 order:13]
`127.0.0.1`. Browser gửi từ loopback → webpack-dev-server nhận thấy IP nguồn là loopback → firewall không apply inbound rules → request đi thẳng vào.

# Khi code thay đổi, chuyện gì xảy ra? [id:498 order:14]
1. File được save → webpack file watcher detect thay đổi
2. webpack compile lại module đó (chỉ module đó, không phải toàn bộ)
3. webpack-dev-server push thông báo qua WebSocket: "module X đã thay đổi"
4. Browser nhận → fetch module mới từ server
5. React HMR swap module cũ bằng module mới — không reload trang, state giữ nguyên

# craco.config.js liên quan gì đến debug mobile? [id:499 order:15]
craco cho phép override cấu hình webpack-dev-server của CRA. Để debug mobile qua IP, cần:
- `host: "0.0.0.0"` — dev server lắng nghe trên mọi interfaces
- `allowedHosts: "all"` — cho phép request từ bất kỳ host nào
- `client.webSocketURL: "auto://0.0.0.0:0/ws"` — HMR WebSocket tự kết nối về host mà page được load từ đó

# Tại sao cần `host: "0.0.0.0"` trong craco? [id:500 order:16]
Mặc định webpack-dev-server bind `localhost` (127.0.0.1) — chỉ nhận request từ chính máy. Đổi sang `0.0.0.0` thì phone mới gửi request vào được qua WiFi.

# Tại sao HMR lỗi khi dùng USB debug mà không config? [id:501 order:17]
WebSocket của HMR kết nối về `localhost:3000`. Trên phone, `localhost` là chính phone, không phải laptop → WebSocket fail → HMR không hoạt động sau khi reload.

<!--# `auto://0.0.0.0:0/ws` nghĩa là gì? [id:502 order:18]
`auto` = WebSocket tự lấy host từ URL mà page đang được load. Phone mở `http://192.168.2.26:3000` → WebSocket tự kết nối `ws://192.168.2.26:3000/ws`. Không cần hardcode IP. -->

# Phone gửi request vào webpack-dev-server thế nào? [id:503 order:19]
Phone mở Chrome → gõ `http://192.168.2.26:3000` → Chrome gửi HTTP GET tới IP đó port 3000 → packet đi qua WiFi → đến WiFi adapter laptop → webpack-dev-server đang listen `0.0.0.0:3000` nhận request → trả `index.html` → browser load JS bundle → React app chạy.