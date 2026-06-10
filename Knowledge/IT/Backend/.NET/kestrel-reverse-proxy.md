# Kestrel là gì?
là HTTP server mặc định của ASP.NET Core, được Microsoft viết tối ưu cho .NET.

# ý nghĩa tên kestrel?
# Kestrel nhanh vì sao?
- Dùng asynchronous I/O — thread không bị block khi chờ network
- Không phụ thuộc IIS
- Memory allocation tối ưu
- Viết tối ưu cho HTTP workload
- Built on high-performance networking library (libuv / System.Net.Sockets)

# So sánh Kestrel, Nginx, Apache, IIS?
- Kestrel: HTTP server của .NET, dùng trong process, nhanh, không có reverse proxy feature
- Nginx/Apache: HTTP server + reverse proxy, thường đứng trước Kestrel để handle SSL termination, load balancing, serve static file
- IIS: Windows-only, tích hợp với Windows Server, cũ hơn

# Reverse Proxy là gì?
là server đứng trước application server để nhận request từ Internet, rồi forward vào app server (Kestrel). Xử lý SSL, load balancing, caching, logging.
