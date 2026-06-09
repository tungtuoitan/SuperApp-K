---
id: 28
name: "Declarative & imperative"
---

# imperative là gì? [id:233 order:17]
- code nhiều dòng, mỗi dòng là 1 hành động nhỏ

# Declarative là gì? [id:234 order:18]
là code 1 dòng mô tả kết quả

# Liên hệ giữa declarative và imperative? [id:235 order:19]
declarative api là imperative code được đóng gói lại

# React được thiết kế theo kiểu gì? vì sao? [id:238 order:22]
theo kiểu declarative
vì dev chỉ cần mô tả UI, React sẽ lo việc cập nhật DOM

# React có imperative không? ví dụ? [id:239 order:23]
có
ví dụ: useEffect, useRef

# declarative và imperative, cái nào phổ biến hơn? tại sao? [id:241 order:25]
declarative phổ biến hơn

vì declarative giải quyết được 90% công việc, imperative chỉ để giải quyết 10% công việc còn lại mà declarative không làm được

# ví dụ declarative và imperative? [id:242 order:26]
declarative: React, SQL
imperative: useEffect, DOM api,

# vì sao useEffect là imperative? [id:243 order:27]
vì nó luôn chứa chuỗi hành động nhỏ bên trong