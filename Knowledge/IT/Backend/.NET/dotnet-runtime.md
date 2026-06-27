---
name: "dotnet-runtime"
---

# .net runtime được tải xuống server khi nào nhỉ?
khi cài .NET sdk
Hoặc khi deploy app dạng **self-contained** — runtime được publish chung với app, không cần server cài sẵn.

# .net sdk chứa gì?
SDK = runtime + tooling để build/dev:
- .NET runtime (chạy app)
- compiler (`csc`, Roslyn)
- CLI (`dotnet build`, `dotnet run`, `dotnet publish`)
- MSBuild, NuGet client
- BCL (Base Class Library)

# deploy self-contained là gì?
là deploy app kèm luôn .NET runtime trong folder publish 
— server không cần cài .NET sẵn vẫn chạy được.

# bundle là gì?
là thư mục publish sau khi build
 chứa exe + dll + runtime + assets, copy lên server là chạy.

# bundle nặng hơn thì có vấn đề gì?
- deploy chậm hơn
- Tốn dung lượng disk nếu chạy nhiều app self-contained

# self-contained có phổ biến không? vì sao?
ít phổ biến
rot: vì chỉ được dùng để ship app cho khách
