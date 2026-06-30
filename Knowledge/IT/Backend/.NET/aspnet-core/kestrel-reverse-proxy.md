---
id: 317
name: "kestrel-reverse-proxy"
---

# Kestrel là gì? [id:2770 order:1]
là HTTP server mặc định của ASP.NET Core, được Microsoft viết tối ưu cho .NET.

# ý nghĩa tên kestrel? [id:2843 order:2]
là tên 1 loài chim cắt nhỏ, bay nhanh và linh hoạt — Microsoft đặt để gợi ý tới tốc độ và sự nhẹ nhàng của HTTP server này.

# Kestrel nhanh vì sao? [id:2844 order:3]
- Dùng asynchronous I/O — thread không bị block khi chờ network
- Không phụ thuộc IIS
- Memory allocation tối ưu
- Viết tối ưu cho HTTP workload
- Built on high-performance networking library (libuv / System.Net.Sockets)

# So sánh Kestrel và IIS? [id:2773 order:4]
- `Kestrel`: cross-platform, nhẹ, nhanh, dùng trong ASP.NET Core;
- `IIS`: Windows-only, nặng hơn, dùng làm reverse proxy trước Kestrel

# Reverse Proxy là gì? [id:2774 order:5]
là server đứng trước application server
để nhận request từ Internet, rồi forward vào app server (Kestrel). Xử lý SSL, load balancing, caching, logging.

# api server và app server có phải là 1 không?? [id:3624 order:6]
gần như là 1.
`app server` có nghĩa rộng
`api server` là app server chỉ phục vụ HTTP API
