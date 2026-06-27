---
id: 35
name: "Azure Blob Storage"
---

# Azure Blob Storage là gì? [id:284 order:1]
Dịch vụ lưu trữ file của Microsoft Azure dùng để lưu file nhị phân (ảnh, PDF, video...) trên cloud.

# File trong Azure Blob có public mặc định không? [id:285 order:2]
Không.

# Azure Blob có mấy chế độ truy cập? [id:286 order:3]
Hai chế độ: Public và Private.

# Public và Private khác nhau thế nào? [id:287 order:4]
Public: ai cũng truy cập được. Private: chỉ owner mới truy cập được.

# Azure Blob có CDN sẵn không? [id:288 order:5]
Có.

# Bật CDN thì URL thay đổi như thế nào? [id:289 order:6]
Domain thay đổi từ `blob.core.windows.net` sang `azureedge.net`, path file giữ nguyên.
Ví dụ: `https://mystorage.blob.core.windows.net/files/img.jpg` → `https://mystorage.azureedge.net/files/img.jpg`.