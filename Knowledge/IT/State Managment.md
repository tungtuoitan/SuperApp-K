---
id: 268
name: "State Managment"
---

# trade-off của zustand là gì? [id:2245 order:1]
- flexible nên cần có convention để code thống nhất
- middleware, devtool, thư viện ngon nhưng k ngon bằng redux

# trade-off của React context [id:2246 order:2]
performance kém
ít tính năng

# dùng react context ở giai đoạn đầu, khi cần thì migrate qua zustand, đây có phải flow tốt không? [id:2247 order:3]
vì sao? [id:207 order:11]
không,
ta nên dùng zustand ngay từ đầu

# Thư viện quản lí state nào phức tạp nhất? [id:2248 order:4]
Redux + Saga

# khi nào dùng Redux saga? [id:2249 order:5]
khi cần async phức tạp, hoặc cần realtime

# Tại sao React Context lại k tốt cho hiệu suất? [id:2250 order:6]
vì khi 1 state update, mọi component link đến context đều re-render

# Những tính năng mà React context k có ? [id:2251 order:7]
- computed state
- middleware
- devtool
- dùng state bên ngoài component tree

# Tại sao zustand có hiệu suất cao hơn React Context? [id:2252 order:8]
vì react context sẽ trigger re-render hàng loạt

# React Context là gì? [id:2253 order:9]
React có phải state manager không? [id:217 order:21]
nó là kỹ thuật DI, k phải là state manager

# React Context nên dc dùng để làm gì? [id:2254 order:10]
nó k nên dùng cho việc gì?
vì sao? [id:218 order:22]
để truyền giá trị ít thay đổi
nó k nên dùng để quản lí state thay đổi nhiều
vì nó có vấn đề re-render

# vì sao Zustand phù hợp với hầu hết các case? [id:2255 order:11]
vì nó dễ dùng, hiệu suất khá tốt, khá nhiều tính năng

# cách chọn state manager nhanh? [id:2256 order:12]
- mặc định dùng Zustand
- app nhỏ thì dùng Context
- khi team lớn và cần autit trail rõ ràng thì dùng Redux Toolkit

# Các công nghệ phổ biến để quản lí state? [id:2257 order:13]
- React
- Zustand
- Redux
- Redux Saga

# ưu điểm của React Context [id:2258 order:14]
có sẵn, dễ dùng

# Tanstack Query là gì? [id:2259 order:15]
nó là data fetching + caching LAYER

# vì sao Zustand là lựa chọn an toàn và phổ biến? [id:2260 order:16]
vì nó phù hợp với hầu hết các case

# vì sao app nhỏ thì nên dùng Context? [id:2261 order:17]
vì nó đơn giản, k cần setup

# saga là gì? [id:2262 order:18]
là middleware dùng để xử lí side effect trong redux

# Khi nào nên dùng Tanstack Query? [id:2263 order:19]
khi cần quản lí server state

# tại sao nên dùng Tanstack Query? [id:2264 order:20]
vì Tanstack tiện lợi hơn, mình khỏi cần quản lí server state, loading, cache nữa