using System.ComponentModel.DataAnnotations;

namespace t11.Application.Dtos.DanhMucVatTu;

public sealed record DanhMucVatTuRequest(
    [param: Required(ErrorMessage = "Mã vật tư là bắt buộc.")]
    [param: StringLength(50, ErrorMessage = "Mã vật tư không được vượt quá 50 ký tự.")]
    string MaVatTu,
    [param: Required(ErrorMessage = "Tên vật tư là bắt buộc.")]
    [param: StringLength(300, ErrorMessage = "Tên vật tư không được vượt quá 300 ký tự.")]
    string TenVatTu,
    [param: Required(ErrorMessage = "Loại vật tư là bắt buộc.")]
    [param: StringLength(30, ErrorMessage = "Loại vật tư không được vượt quá 30 ký tự.")]
    string LoaiVatTu,
    [param: StringLength(30, ErrorMessage = "Mã sản phẩm không được vượt quá 30 ký tự.")]
    string? MaSanPham,
    decimal? ChieuDaiSanPham,
    [param: StringLength(50, ErrorMessage = "Mã nguyên liệu không được vượt quá 50 ký tự.")]
    string? MaNguyenLieu,
    [param: StringLength(50, ErrorMessage = "Mã bán thành phẩm không được vượt quá 50 ký tự.")]
    string? MaBanThanhPham,
    decimal? HeSoQuyDoiTuThanhDai,
    [param: StringLength(20, ErrorMessage = "Nhóm vật tư 1 không được vượt quá 20 ký tự.")]
    string? NhomVatTu1,
    [param: StringLength(20, ErrorMessage = "Nhóm vật tư 2 không được vượt quá 20 ký tự.")]
    string? NhomVatTu2,
    [param: Required(ErrorMessage = "Đơn vị tính là bắt buộc.")]
    [param: StringLength(20, ErrorMessage = "Đơn vị tính không được vượt quá 20 ký tự.")]
    string DonViTinh,
    [param: Required(ErrorMessage = "Trạng thái là bắt buộc.")]
    [param: StringLength(20, ErrorMessage = "Trạng thái không được vượt quá 20 ký tự.")]
    string TrangThai,
    [param: StringLength(500, ErrorMessage = "Ghi chú không được vượt quá 500 ký tự.")]
    string? GhiChu);

public sealed record DanhMucVatTuResponse(
    string MaVatTu,
    string TenVatTu,
    string LoaiVatTu,
    string? MaSanPham,
    decimal? ChieuDaiSanPham,
    string? MaNguyenLieu,
    string? MaBanThanhPham,
    decimal? HeSoQuyDoiTuThanhDai,
    string? NhomVatTu1,
    string? NhomVatTu2,
    string DonViTinh,
    string TrangThai,
    string? GhiChu,
    string? MaSanPhamNavigationTenSanPham,
    string? MaNguyenLieuNavigationTenNguyenLieu,
    string? MaBanThanhPhamNavigationTenBanThanhPham);
