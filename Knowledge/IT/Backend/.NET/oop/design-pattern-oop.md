---
id: 315
name: "design-pattern-oop"
---

# Design Pattern là gì? [id:2755 order:1]
là cách tổ chức nhiều class/object/service để giải quyết vấn đề lớn trong app. Ví dụ: MVC, Observer, Singleton, Microservices, CQRS.

# Vai trò của Design Pattern là gì? [id:2756 order:2]
dùng để giải quyết 1 vấn đề cụ thể: tách code (UI, logic, data), tách Data Access, đảm bảo 1 instance duy nhất cho Logger/DB connection...

# Quan hệ giữa app và Design Pattern là gì? [id:2757 order:3]
1 app thường dùng nhiều design pattern cùng lúc — mỗi pattern giải quyết 1 vấn đề khác nhau trong cùng app.

<!--# Các loại pattern là gì? [id:2758 order:4]
- Architectural/Application pattern (MVC, Microservice, CQRS)
- Creational patterns (Singleton, Factory, Builder)
- Structural patterns (Repository)
- Behavioral patterns
- Frontend/UI patterns (MVVM) -->

# Các Architectural Pattern phổ biến là gì? [id:2759 order:5]
- MVC
- API-first
- CQRS
- Microservice

# Lợi ích của MVC là gì? [id:2760 order:6]
- Server tạo HTML hoàn chỉnh → load page nhanh → SEO tốt
- Tránh lộ API/dữ liệu thô cho client → bảo mật hơn

# Phân biệt Kỹ thuật, Pattern, Framework? [id:2761 order:7]
- Kỹ thuật: cách code giải quyết vấn đề nhỏ, level 1 hàm (async/await, hash password)
- Pattern: cách tổ chức code ở mức thiết kế (MVC, Repository, Singleton)
- Framework: công cụ có sẵn giải quyết 1 vấn đề cụ thể (ASP.NET Core, React, EF Core)

# Phân biệt Class và Object? [id:2762 order:8]
- Class: bản thiết kế, không có sự sống
- Object: thực thể thật được tạo ra từ Class, sống trong bộ nhớ
Ví von: class là bản thiết kế xe, object là chiếc xe thật.

# Domain là gì? [id:2763 order:9]
có 3 nghĩa:
- Business domain: lĩnh vực mà phần mềm giải quyết (Banking, E-commerce, Healthcare)
- Internet domain: tên định danh trên internet (google.com)
- Code domain: nhóm logic nghiệp vụ liên quan trong codebase (HR domain, Finance domain)

# Phân biệt Domain, Module, Component? [id:2764 order:10]
- Domain: lớn hơn feature (HR, Finance)
- Module: là feature (HRListPage, RFDList)
- Component: 1 phần của feature (HRGrid, Filter, Pagination)