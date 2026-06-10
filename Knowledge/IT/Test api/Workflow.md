---
id: 49
name: "Workflow"
---

# Workflow chuẩn để chạy load test là gì? [id:395 order:1]
Restore baseline DB → swap .env sang test DB → restart BE → re-prewarm tokens → chạy k6.

# Tại sao phải restore baseline DB trước mỗi lần test? [id:396 order:2]
Để đảm bảo data shape nhất quán, tránh kết quả bị ảnh hưởng bởi data thay đổi từ run trước.

# re-prewarm là gì ? [id:397 order:3]
là bước generate lại JWT tokens cho user trong DB vừa restore, lưu vào `tokens.json` để k6 dùng — tránh test bị 401 do token cũ.

# Tại sao phải re-prewarm tokens sau mỗi lần restore? [id:398 order:4]
Vì restore tạo lại user trong DB, JWT cũ tham chiếu user cũ sẽ không hợp lệ.

# Tại sao phải restart BE sau khi restore DB? [id:399 order:5]
Để EF Core connection pool sạch — pool cũ bám vào DB cũ sẽ trả 401/500.

# Tại sao không dùng `$env:ConnectionStrings__...` để override DB thay vì swap .env? [id:400 order:6]
Vì BE dùng DotNetEnv để load `Timeline\.env`, và DotNetEnv ghi đè env vars set qua `$env:...`.

# Tại sao phải copy tokens.json vào `test-workspace-api/results/` trước khi chạy k6? [id:401 order:7]
Vì k6 v2 resolve `open()` relative to cwd, không phải script path — tokens phải nằm đúng thư mục.