

# log ra gì? giải thích?
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



# kết quả là gì?
```js
function f1()
{
    var N = 0; // N luon duoc khoi tao khoi ham f1 dduowcj thuc thi
    console.log(N);
    function f2() // Ham f2
    {
        N += 1; // cong don cho bien N
        console.log('-->>',N);
    }

    return f2;
}

var result = f1();

result(); // Chay lan 1
result(); // Chay lan 2
result(); // Chay lan 3
```
In ra: `0`, `-->> 1`, `-->> 2`, `-->> 3`.
`f1()` in `0` rồi trả `f2`; `f2` giữ closure biến `N`, mỗi lần gọi `result()` tăng `N` → 1, 2, 3.
