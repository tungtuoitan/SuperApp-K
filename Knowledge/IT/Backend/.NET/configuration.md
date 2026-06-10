# appsettings.json dùng để làm gì?
là file config của ASP.NET Core app

# appsettings có bị overwrite không?
Có.

# Thứ tự ưu tiên của Configuration trong ASP.NET Core là gì?
appsettings.json
→ appsettings.{Environment}.json
→ User Secrets (Development)
→ Environment Variables
→ Command-line Arguments
