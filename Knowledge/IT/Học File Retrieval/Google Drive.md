---
id: 36
name: "Google Drive"
---

# Google Drive có CDN không? [id:290 order:1]
Không.

# Tại sao Google Drive không có CDN? [id:291 order:2]
Vì Google Drive không được thiết kế làm storage server.

# Google Drive có cache được không? [id:292 order:3]
Không.

# Tại sao file từ Google Drive không cache được qua reload? [id:358 order:4]
Vì không có Cache-Control header — browser không biết cache đến khi nào.

# Giải pháp tốt nhất để cache khi buộc phải dùng Google Drive là gì? [id:359 order:5]
Dùng Cache API của browser để lưu response vào disk.

# Cache API khác RAM cache ở điểm gì? [id:360 order:6]
RAM cache mất khi reload. Cache API lưu trên disk, tồn tại đến khi clear hoặc hết TTL.

# Cache API có tự expire không? [id:361 order:7]
Không.