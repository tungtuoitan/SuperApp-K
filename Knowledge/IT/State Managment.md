---
id: 21
name: "State Managment"
---

# trade-off của zustand là gì? [id:204 order:8]
- flexible nên cần có convention để code thống nhất
- middleware, devtool, thư viện ngon nhưng k ngon bằng redux

# trade-off của React context [id:206 order:10]
performance kém
ít tính năng

# dùng react context ở giai đoạn đầu, khi cần thì migrate qua zustand, đây có phải flow tốt không? 
vì sao? [id:207 order:11]
không, 
ta nên dùng zustand ngay từ đầu

# Thư viện quản lí state nào phức tạp nhất? [id:212 order:16]
Redux + Saga

# khi nào dùng Redux saga? [id:213 order:17]
khi cần async phức tạp, hoặc cần realtime

# Tại sao React Context lại k tốt cho hiệu suất? [id:214 order:18]
vì khi 1 state update, mọi component link đến context đều re-render

# Những tính năng mà React context k có ? [id:215 order:19]
- computed state
- middleware
- devtool
- dùng state bên ngoài component tree

# Tại sao zustand có hiệu suất cao hơn React Context? [id:216 order:20]
vì react context sẽ trigger re-render hàng loạt

# React Context là gì?
React có phải state manager không? [id:217 order:21]
nó là kỹ thuật DI, k phải là state manager

# React Context nên dc dùng để làm gì?
nó k nên dùng cho việc gì?
vì sao? [id:218 order:22]
để truyền giá trị ít thay đổi
nó k nên dùng để quản lí state thay đổi nhiều
vì nó có vấn đề re-render

# vì sao Zustand phù hợp với hầu hết các case? [id:219 order:23]
vì nó dễ dùng, hiệu suất khá tốt, khá nhiều tính năng

# cách chọn state manager nhanh? [id:220 order:24]
- mặc định dùng Zustand
- app nhỏ thì dùng Context
- khi team lớn và cần autit trail rõ ràng thì dùng Redux Toolkit

# Các công nghệ phổ biến để quản lí state? [id:222 order:26]
- React
- Zustand
- Redux
- Redux Saga

# ưu điểm của React Context [id:223 order:27]
có sẵn, dễ dùng

# Tanstack Query là gì? [id:250 order:28]
nó là data fetching + caching LAYER

# vì sao Zustand là lựa chọn an toàn và phổ biến? [id:254 order:29]
vì nó phù hợp với hầu hết các case

# vì sao app nhỏ thì nên dùng Context? [id:255 order:30]
vì nó đơn giản, k cần setup

# saga là gì? [id:256 order:31]
là middleware dùng để xử lí side effect trong redux

# Khi nào nên dùng Tanstack Query? [id:258 order:33]
khi cần quản lí server state

# tại sao nên dùng Tanstack Query? [id:259 order:34]
vì Tanstack tiện lợi hơn, mình khỏi cần quản lí server state, loading, cache nữa