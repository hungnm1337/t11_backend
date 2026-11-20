# Hướng dẫn tích hợp API cho Frontend

Tài liệu này hướng dẫn frontend tích hợp các API danh mục, phiếu nhập và phiếu điều chuyển.

## 1. Cấu hình API client

### Local

```ts
export const API_BASE_URL = "https://localhost:7017";
```

Nếu chạy backend bằng profile HTTP:

```ts
export const API_BASE_URL = "http://localhost:5154";
```

Tất cả request gửi JSON cần có header:

```ts
{
  "Content-Type": "application/json"
}
```

Frontend local `http://localhost:3000` đã được backend cho phép CORS.

## 2. Response phân trang

Các API GET danh sách trả về:

```ts
interface PagedResult<T> {
  items: T[];
  total: number;
  page: number;
  size: number;
}
```

Gọi danh sách:

```http
GET /api/<resource>?page=1&size=20
```

- `page` bắt đầu từ `1`.
- `size` từ `1` đến `200`.
- Không có filter theo mã trong API generic hiện tại.

Ví dụ TypeScript:

```ts
const response = await fetch(
  `${API_BASE_URL}/api/DoiTac?page=1&size=20`
);

const data: PagedResult<DoiTac> = await response.json();
```

## 3. API danh mục

Các resource sau đều có CRUD:

```text
/api/BanThanhPham
/api/DanhMucVatTu
/api/DoiTac
/api/KhachHang
/api/Kho
/api/NguyenLieu
/api/SanPham
```

Mỗi resource hỗ trợ:

```http
GET    /api/<resource>?page=1&size=20
GET    /api/<resource>/<id>
POST   /api/<resource>
PUT    /api/<resource>/<id>
DELETE /api/<resource>/<id>
```

### Tạo mới

```ts
const response = await fetch(`${API_BASE_URL}/api/DoiTac`, {
  method: "POST",
  headers: { "Content-Type": "application/json" },
  body: JSON.stringify({
	maDoiTac: "NCC001",
	tenDoiTac: "Nhà cung cấp A",
	loaiDoiTac: "NhaCungCap",
	diaChi: "Hà Nội",
	soDienThoai: "0900000000",
	maSoThue: "0123456789",
	nguoiLienHe: "Nguyễn Văn A"
  })
});
```

### Cập nhật

`PUT` cần gửi đầy đủ request model:

```ts
await fetch(`${API_BASE_URL}/api/DoiTac/NCC001`, {
  method: "PUT",
  headers: { "Content-Type": "application/json" },
  body: JSON.stringify({
	maDoiTac: "NCC001",
	tenDoiTac: "Nhà cung cấp A - Updated",
	loaiDoiTac: "NhaCungCap",
	diaChi: "Hà Nội",
	soDienThoai: "0900000000",
	maSoThue: "0123456789",
	nguoiLienHe: "Nguyễn Văn B"
  })
});
```

### Xóa

```ts
const response = await fetch(`${API_BASE_URL}/api/DoiTac/NCC001`, {
  method: "DELETE"
});

// Thành công: HTTP 204, không có response body.
```

## 4. Phiếu nhập

Có hai cách tạo phiếu nhập.

### 4.1 Tạo phiếu nhập cùng chi tiết - khuyến nghị

Dùng transaction API:

```http
POST /api/PhieuNhap
```

Request:

```ts
interface PhieuNhapTransactionRequest {
  phieuNhap: {
	soPhieuNhap: string;
	ngayNhap: string; // YYYY-MM-DD
	maChungTu?: string | null;
	soDonHang?: string | null;
	soHoaDon?: string | null;
	phieuYeuCau?: string | null;
	maNcc?: string | null;
	maHopDong?: string | null;
	maGiaoDich?: string | null;
	maKhoHang?: string | null;
	maKhoXuat?: string | null;
	tenPhanXuong?: string | null;
	maBoPhan?: string | null;
	tenBoPhan?: string | null;
	userTaoPo?: string | null;
	nguoiLapPhieu?: string | null;
	maCdgtPhieu?: string | null;
	trangThaiPhieu?: string | null;
  };
  chiTietPhieuNhaps: Array<{
	maHang: string;
	dvt?: string | null;
	soLuong: number;
	tkNo?: string | null;
	tkCo?: string | null;
	maPhi?: string | null;
	donTrongThietKe?: number | null;
	tyLeDonTrongThucTeThietKe?: number | null;
	caSanXuat?: string | null;
	maySanXuat?: string | null;
	maCdgtVt?: string | null;
	maLoi?: string | null;
	tenLoi?: string | null;
	soLenhSx?: string | null;
	donHangGc?: string | null;
	giaGc?: number | null;
	tienGc?: number | null;
  }>;
}
```

Ví dụ:

```ts
const response = await fetch(`${API_BASE_URL}/api/PhieuNhap`, {
  method: "POST",
  headers: { "Content-Type": "application/json" },
  body: JSON.stringify({
	phieuNhap: {
	  soPhieuNhap: "PN001",
	  ngayNhap: "2026-01-31",
	  maNcc: "NCC001",
	  maKhoHang: "KHO001",
	  trangThaiPhieu: "Nhap"
	},
	chiTietPhieuNhaps: [
	  {
		maHang: "VT001",
		dvt: "kg",
		soLuong: 100
	  }
	]
  })
});

const result = await response.json();
// { soPhieuNhap: "PN001", chiTietIds: [1] }
```

Header bắt buộc:

- `soPhieuNhap`
- `ngayNhap`

Detail bắt buộc:

- `maHang`
- `soLuong`

Header và detail được lưu trong cùng transaction. Nếu một detail lỗi, toàn bộ request rollback.

### 4.2 CRUD riêng phiếu nhập

Header:

```text
/api/PhieuNhapCrud
```

```http
GET    /api/PhieuNhapCrud?page=1&size=20
GET    /api/PhieuNhapCrud/PN001
POST   /api/PhieuNhapCrud
PUT    /api/PhieuNhapCrud/PN001
DELETE /api/PhieuNhapCrud/PN001
```

Detail:

```text
/api/ChiTietPhieuNhap
```

```http
GET    /api/ChiTietPhieuNhap?page=1&size=20
GET    /api/ChiTietPhieuNhap/1
POST   /api/ChiTietPhieuNhap
PUT    /api/ChiTietPhieuNhap/1
DELETE /api/ChiTietPhieuNhap/1
```

Khi tạo detail riêng, phải gửi `soPhieuNhap` trỏ tới phiếu đã tồn tại:

```json
{
  "soPhieuNhap": "PN001",
  "maHang": "VT001",
  "dvt": "kg",
  "soLuong": 50
}
```

Detail response có thêm `id` do database tự sinh.

## 5. Phiếu điều chuyển

### 5.1 Tạo phiếu cùng chi tiết - khuyến nghị

```http
POST /api/PhieuDieuChuyen
```

Ví dụ request:

```json
{
  "phieuDieuChuyen": {
	"maGiaoDich": "GD001",
	"ngayChungTu": "2026-01-31",
	"maKhachHang": "KH001",
	"nguoiThucHien": "admin",
	"maKhoXuat": "KHO001",
	"maKhoNhap": "KHO002",
	"dienGiai": "Điều chuyển nguyên liệu"
  },
  "chiTietDieuChuyens": [
	{
	  "maVatTu": "VT001",
	  "dvt": "kg",
	  "soLuong": 20,
	  "ghiChu": "Chuyển kho"
	}
  ]
}
```

Header bắt buộc:

- `maGiaoDich`
- `maKhoXuat`
- `maKhoNhap`

Detail bắt buộc:

- `maVatTu`
- `soLuong`

`maKhoXuat` phải khác `maKhoNhap`.

Response:

```json
{
  "maGiaoDich": "GD001",
  "chiTietIds": [1]
}
```

### 5.2 CRUD riêng phiếu điều chuyển

Header:

```text
/api/PhieuDieuChuyenCrud
```

```http
GET    /api/PhieuDieuChuyenCrud?page=1&size=20
GET    /api/PhieuDieuChuyenCrud/GD001
POST   /api/PhieuDieuChuyenCrud
PUT    /api/PhieuDieuChuyenCrud/GD001
DELETE /api/PhieuDieuChuyenCrud/GD001
```

Detail:

```text
/api/ChiTietDieuChuyen
```

```http
GET    /api/ChiTietDieuChuyen?page=1&size=20
GET    /api/ChiTietDieuChuyen/1
POST   /api/ChiTietDieuChuyen
PUT    /api/ChiTietDieuChuyen/1
DELETE /api/ChiTietDieuChuyen/1
```

Khi tạo detail riêng:

```json
{
  "maGiaoDich": "GD001",
  "maVatTu": "VT001",
  "dvt": "kg",
  "soLuong": 20
}
```

## 6. Lấy phiếu và danh sách detail

Frontend có thể lấy toàn bộ phiếu và detail trong một request bằng các API aggregate:

```http
GET /api/PhieuNhap/{soPhieuNhap}
GET /api/PhieuDieuChuyen/{maGiaoDich}
```

Ví dụ lấy phiếu nhập:

```ts
interface PhieuNhapInfoResponse {
  soPhieuNhap: string;
  ngayNhap: string;
  soDonHang?: string | null;
  maNcc?: string | null;
  maKhoHang?: string | null;
  nhaCungCap?: DoiTacInfo | null;
  khoHang?: KhoInfo | null;
  khoXuat?: KhoInfo | null;
  chiTietPhieuNhaps: ChiTietPhieuNhapInfo[];
}

const phieu = await fetch(
  `${API_BASE_URL}/api/PhieuNhap/PN001`
).then(response => parseApiResponse<PhieuNhapInfoResponse>(response));

console.log(phieu.chiTietPhieuNhaps);
```

Ví dụ lấy phiếu điều chuyển:

```ts
interface PhieuDieuChuyenInfoResponse {
  maGiaoDich: string;
  ngayChungTu?: string | null;
  maKhoXuat: string;
  maKhoNhap: string;
  khachHang?: KhachHangInfo | null;
  khoXuat: KhoInfo;
  khoNhap: KhoInfo;
  chiTietDieuChuyens: ChiTietDieuChuyenInfo[];
}

const phieu = await fetch(
  `${API_BASE_URL}/api/PhieuDieuChuyen/GD001`
).then(response => parseApiResponse<PhieuDieuChuyenInfoResponse>(response));

console.log(phieu.chiTietDieuChuyens);
```

Detail đã được trả trực tiếp trong response nên không cần gọi thêm API detail cho màn hình xem chi tiết.

Các endpoint CRUD detail riêng vẫn có thể dùng khi cần chỉnh sửa từng dòng:

```ts
await fetch(`${API_BASE_URL}/api/ChiTietPhieuNhap/1`, {
  method: "DELETE"
});
```

## 7. Xử lý lỗi phía frontend

```ts
async function parseApiResponse<T>(response: Response): Promise<T> {
  if (response.ok) {
	if (response.status === 204) {
	  return undefined as T;
	}

	return response.json();
  }

  const problem = await response.json().catch(() => null);
  throw new Error(
	problem?.detail ?? `API error: ${response.status}`
  );
}
```

Các status cần xử lý:

| Status | Frontend nên xử lý |
|---|---|
| `400` | Hiển thị lỗi validation cho form |
| `404` | Thông báo bản ghi không tồn tại |
| `409` | Thông báo mã đã tồn tại hoặc dữ liệu đang được tham chiếu |
| `500` | Hiển thị lỗi hệ thống và ghi log request |

## 8. Quy trình khuyến nghị

### Tạo phiếu mới

1. Kiểm tra các mã liên quan đã tồn tại: nhà cung cấp, kho, vật tư.
2. Gọi transaction POST `/api/PhieuNhap` hoặc `/api/PhieuDieuChuyen`.
3. Lưu mã phiếu và `chiTietIds` từ response.
4. Sau khi tạo thành công, gọi GET detail nếu cần hiển thị lại dữ liệu.

### Chỉnh sửa phiếu

1. Gọi `GET` header.
2. Gọi `GET` danh sách detail tương ứng.
3. Cập nhật header bằng `PUT` header CRUD.
4. Cập nhật từng detail bằng `PUT /{id}`.
5. Xóa detail không còn sử dụng bằng `DELETE /{id}`.

### Xóa phiếu

1. Xóa các detail trước.
2. Xóa header sau.
3. Nếu database trả `409`, kiểm tra các bản ghi khác đang tham chiếu tới phiếu.
