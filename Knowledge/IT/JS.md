---
id: 358
name: "JS"
---

# log ra gì? giải thích? [id:3467 order:1]
```js
function Product() {

    var name;

    this.setName = function(value) {
        name = value;
    };

    this.getName = function() {
        return name;
    };
}

var p = new Product();
p.setName("anonystick.com");

console.log(p.name);
console.log(p.getName());
```

In ra: `undefined` rồi `anonystick.com`.
`name` là biến local (private) trong constructor, không gắn vào `this` → `p.name` là `undefined`. `getName()` là closure giữ tham chiếu tới `name` nên trả về giá trị đã set.

<!--# kết quả là gì? [id:3468 order:2]
In ra: `0`, `-->> 1`, `-->> 2`, `-->> 3`.
`f1()` in `0` rồi trả `f2`; `f2` giữ closure biến `N`, mỗi lần gọi `result()` tăng `N` → 1, 2, 3. -->