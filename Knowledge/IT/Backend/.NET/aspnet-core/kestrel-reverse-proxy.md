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

# So sánh Kestrel, Nginx, Apache, IIS? [id:2773 order:4]
- Kestrel: HTTP server của .NET, dùng trong process, nhanh, không có reverse proxy feature
- Nginx/Apache: HTTP server + reverse proxy, thường đứng trước Kestrel để handle SSL termination, load balancing, serve static file
- IIS: Windows-only, tích hợp với Windows Server, cũ hơn

# Reverse Proxy là gì? [id:2774 order:5]
là server đứng trước application server để nhận request từ Internet, rồi forward vào app server (Kestrel). Xử lý SSL, load balancing, caching, logging.