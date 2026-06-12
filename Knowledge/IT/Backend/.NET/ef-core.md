---
id: 323
name: "ef-core"
---

<!--# Entity Framework Core là gì? [id:2837 order:1]
là ORM của .NET -->

<!--# ORM là gì? [id:2838 order:2]
là Object-Relational Mapping — mapping table DB thành class C#, row thành object. Dev thao tác object thay vì viết SQL trực tiếp. -->

<!--# LINQ là gì? [id:2839 order:3]
là Language Integrated Query — cú pháp query data ngay trong C#, dùng được cho collection, DB (qua EF Core), XML. -->

# query là gì? [id:2840 order:4]
là lệnh yêu cầu lấy/lọc data — thường viết bằng SQL (DB) hoặc LINQ (C#).

# query là script phải không? [id:2841 order:5]
Không. Query là biểu thức/lệnh, script là file gồm nhiều lệnh.

# script có những nghĩa nào? [id:2842 order:6]
- File chứa nhiều lệnh chạy tuần tự (`.sh`, `.ps1`, `.sql`)
- Code viết bằng scripting language (JS, Python) — không cần compile riêng
- Tệp tự động hóa: build script, deploy script, migration script