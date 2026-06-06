# SuperApp — Mobile Code (ActivityBar, Tab Restore, Zustand)

## K module có id là gì?
`"K"`.

## `useGlobalInit` là gì?
Hook đăng ký trong `ModuleDefinition` — chạy unconditionally khi app mount, bất kể module nào đang active. Dùng cho logic cần chạy mọi lúc (load data, auto-open tab).

## `mobileExcludedTypes` là gì?
Field trong `TabPersistence` interface — khai báo tab type nào không được restore trên mobile.

## Prop `horizontal` trong ActivityBar là gì?
Signal phân biệt mobile/desktop. `VSCodeLayout.tsx` truyền `<ActivityBar horizontal />` khi mobile, không truyền khi desktop.

## `mobileExcludedTypes` được check ở đâu?
Trong `useTabBarSync.ts`, trước khi gọi `persistence.restoreTab`:
```ts
if (isMobile && persistence.mobileExcludedTypes?.includes(persisted.type)) continue;
```

## Tab `multiProject` còn được lưu vào localStorage trên mobile không?
Có. `mobileExcludedTypes` chỉ skip **restore**, không skip **save**. Tab vẫn được persist để khi quay lại PC thì có.

## Làm sao ẩn tất cả module trừ K trên mobile trong ActivityBar?
Filter `visibleModules` trong `ActivityBar.tsx` dựa vào prop `horizontal`:
```ts
if (horizontal && m.id !== "K") return false;
```

## Tại sao dùng `horizontal` thay vì `isMobile` trong ActivityBar?
`horizontal` đã là signal phân biệt mobile/desktop trong component này — không cần thêm dependency `useDeviceStore`, đơn giản hơn.

## Để thêm module khác hiện trên mobile thì sửa ở đâu?
`ActivityBar.tsx` dòng filter — thêm `|| m.id === "TenModule"` vào điều kiện.

## `useEditorTabBarStore()` trả về gì?
Toàn bộ store snapshot với shallow compare — tất cả fields.

## Tại sao `useShallow` vẫn gây re-render thừa?
`useShallow` so sánh từng field top-level. Nhưng vì return hết tất cả fields, bất kỳ field nào thay đổi cũng trigger re-render — dù component không dùng field đó.

## `useEditorTabBarStoreSlice` khác `useEditorTabBarStore` thế nào?
`useEditorTabBarStore` = convenience hook trả về toàn bộ store.
`useEditorTabBarStoreSlice` = raw Zustand store, dùng với custom selector — chỉ re-render khi đúng field đó thay đổi.

## Để thêm tab type khác không restore trên mobile thì sửa ở đâu?
`tabPersistence.mobileExcludedTypes` trong module tương ứng. Nếu tab type đó cũng có auto-open logic trong `useGlobalInit`, cần thêm `if (isMobile) return` ở đó nữa.

## Tab `multiProject` bị hiện trên mobile qua 2 con đường nào?
1. **localStorage restore**: `useTabBarSync` restore tab đã lưu từ session trước.
2. **Auto-open**: `useGlobalInit` trong `project.module.tsx` gọi `openMultiProjectTab([])` khi mount.

## Tại sao fix `mobileExcludedTypes` vẫn chưa đủ để ẩn tab multiProject?
Vì `useGlobalInit` gọi `openMultiProjectTab([])` khi mount — bypass hoàn toàn localStorage, tab mở dù không có gì trong storage.

## VSEditorArea bị lag trên mobile do đâu?
Subscribe toàn bộ Zustand store khiến component re-render mỗi khi bất kỳ field nào thay đổi — kể cả các field drag (`draggedTabId`, `dragOverTabId`, `dragOverPosition`) thay đổi liên tục khi thao tác trên mobile.

## Cách fix subscribe thừa trong Zustand?
Dùng `useEditorTabBarStoreSlice` với selector chỉ pick đúng field cần:
```ts
const { openTabs, activeTabId } = useEditorTabBarStoreSlice(
    useShallow((s) => ({ openTabs: s.openTabs, activeTabId: s.activeTabId }))
);
```

## Fix `useGlobalInit` auto-open multiProject trên mobile thế nào?
```ts
const { isMobile } = useDeviceStore();
useEffect(() => {
    if (isMobile) return;
    openMultiProjectTab([]);
}, []);
```

## Nếu 1 tab type có cả auto-open lẫn localStorage restore thì cần fix mấy chỗ?
2 chỗ: `mobileExcludedTypes` trong `tabPersistence` (chặn restore từ localStorage) và `if (isMobile) return` trong `useGlobalInit` (chặn auto-open khi mount).
