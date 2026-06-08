---
id: 20
name: "Học React"
---

# khi nào thì cleanUp trong useEffect chạy ? [id:194 order:0]
cleanup chạy khi:

effect sắp chạy lại (deps đổi)
component unmount

# Nguyên tắc dùng useEffect? [id:175 order:32]
nếu k làm việc với external system (vd: server,...) thì ta k nên dùng useEffect