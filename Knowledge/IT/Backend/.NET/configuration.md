---
id: 321
name: "configuration"
---

# appsettings.json dùng để làm gì? [id:2826 order:1]
là file config của ASP.NET Core app

# appsettings có bị overwrite không? [id:2827 order:2]
Có.

# Thứ tự ưu tiên của Configuration trong ASP.NET Core là gì? [id:2828 order:3]
appsettings.json
→ appsettings.{Environment}.json
→ User Secrets (Development)
→ Environment Variables
→ Command-line Arguments