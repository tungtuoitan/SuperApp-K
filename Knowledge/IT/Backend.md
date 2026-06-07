---
id: 261
name: "Backend"
---

# Backend có mấy tầng [id:2216 order:1]
có 4 tầng:
- hosting
- business logic
- data access
- cross-cutting

# coupling là gì? [id:2217 order:2]
là việc A phụ thuộc vào B

# "tránh coupling" là gì? [id:2218 order:3]
là tránh việc A phụ thuộc CỨNG vào B

# tight coupling là gì? [id:2219 order:4]
là A phụ thuộc  quá chặt vào B

# tầng cross-cutting thường chứa gì? [id:2220 order:5]
chứa các service dùng chung như log, auth, cache service

# tại sao lại gọi là cross-cutting? [id:2221 order:6]
cross cutting nghĩa là cắt ngang,
gọi là cross cutting vì các service này sẽ dùng ở mọi tầng, "cắt ngang" mọi chỗ

# 1 source nên có mấy file appsettings? [id:2222 order:7]
nên dùng 3 file, mỗi file tương ứng với 1 môi trường

# .NET xác định môi trường dựa vào đâu? [id:2223 order:8]
dựa vào biến môi trường: ASPNETCORE_ENVIROMENT

# file appsettings nào được dùng ,đc quyết định bởi cái gì? [id:2224 order:9]
được quyết định bởi môi trường

# so sánh file app.config và appsettings.json? [id:2225 order:10]
giống nhau: đều dùng để lưu key, password, address,...
khác nhau: app.config là file dùng cho .NET cũ, còn appsettings dùng cho .NET hiện đại

# nên dùng app.config hay appsettings? vì sao? [id:2226 order:11]
nên dùng appsettings, vì nó và version mới, và nó linh hoạt, mạnh mẽ hơn

# cross-ting tương ứng với tầng gì ở FE? [id:2227 order:12]
tầng shared

# Tại sao khi deploy BE thì đôi lúc bị lỗi do service hiện tại đang chạy nhỉ? [id:2228 order:13]
nếu deploy lúc app đạng chạy thì sẽ bị lỗi
còn nếu app dang idle thì k sao

# idle là gì? [id:2229 order:14]
là trạng thái app rảnh