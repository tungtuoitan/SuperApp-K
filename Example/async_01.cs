// att-id:2
// Chay: dotnet script async_03_sequential_vs_parallel.cs

using System;
using System.Diagnostics;
using System.Threading.Tasks;

Console.WriteLine("A1");
var t1 = B();
var t2 = B();
var t3 = B();
var results = await Task.WhenAll(t1, t2, t3);
Console.WriteLine("A2");

async static Task B()
{
    Console.WriteLine("B1");
}

/*
OUTPUT:
1 - A1
2 - B1  <- 3 cai start cung luc (thu tu co the thay doi)
3 - B1
4 - B1
5 - A2

KEY POINT:
- t1,t2,t3 duoc tao truoc khi await -> tat ca start ngay lap tuc
- Task.WhenAll cho cho den khi ca 3 xong roi moi tiep tuc
- A2 luon o cuoi vi await WhenAll
*/
