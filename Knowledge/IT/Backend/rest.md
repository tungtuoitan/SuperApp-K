# REST là gì?
là 1 kiểu thiết kế API dựa trên HTTP, dùng resource + HTTP method để mô tả operation.

# Ý tưởng của REST là gì?
xem mọi thứ là tài nguyên (user, product, order) và dùng HTTP method (GET, POST, PUT, DELETE) để thao tác CRUD với tài nguyên đó.

# Vai trò của REST là gì?
tạo ra rule chung, thống nhất để viết API — giúp client và server độc lập với nhau, dễ tích hợp.

# Các quy định của REST là gì?
- Tách biệt client và server (client lo UI, server lo logic)
- Stateless: mỗi request chứa đủ thông tin, server không lưu session
- Cacheable: response có thể cache
- Uniform interface: dùng resource URL + HTTP method nhất quán
- Layered system: client không biết mình đang nói chuyện với server thật hay proxy

# Điểm mạnh của REST mà các kiểu khác không có?
- Cache HTTP tự nhiên
- HTTP Status rõ ràng (200, 404, 500...)
- Tooling sẵn có (Swagger, Postman, curl)
- Endpoint dễ đọc, dễ debug
- Stateless
- Loose coupling tự nhiên
- Phổ biến nhất — dễ tìm dev

# Điểm yếu của REST là gì?
- Không tốt cho realtime (cần WebSocket/SSE)
- Over-fetching hoặc under-fetching data (không linh hoạt như GraphQL)
- Không tốt cho streaming/long connection

# Khi nào nên dùng REST?
REST là default option — 70% app thông thường phù hợp với REST. Dùng REST trước, chuyển sang gRPC/GraphQL/WebSocket khi có nhu cầu cụ thể.

# Khi nào không nên dùng REST?
Khi app cần: realtime, query phức tạp, performance cực cao, streaming hoặc long connection.
