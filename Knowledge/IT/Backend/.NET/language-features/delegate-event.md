---
id: 340
name: "delegate-event"
---

# phát âm delegate? [id:3213 order:1]
"DEL-uh-ghết" (nhấn âm đầu).

# event và delegate khác nhau thế nào? [id:3214 order:2]
event là wrapper trên delegate: chỉ class khai báo event mới có thể raise (invoke), bên ngoài chỉ subscribe/unsubscribe. Delegate thì ai cũng invoke được trực tiếp.

# invoke là gì? [id:3215 order:3]
là gọi/thực thi một method hoặc delegate. `myDelegate.Invoke(args)` hoặc viết tắt `myDelegate(args)`.

# delegate có phổ biến trong web api k? [id:3216 order:4]
không

# lamda expenssion tương ứng với gì trong JS? [id:3217 order:5]
tương đương arrow function