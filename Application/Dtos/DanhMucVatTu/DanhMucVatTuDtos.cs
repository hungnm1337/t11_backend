using System.ComponentModel.DataAnnotations;

namespace t11.Application.Dtos.DanhMucVatTu;

public sealed record DanhMucVatTuRequest(
    [property: Required(ErrorMessage = "Mã vật tư là bắt buộc.")]
    [property: StringLength(50, ErrorMessage = "Mã vật tư không được vượt quá 50 ký tự.")]
    string MaVatTu,
    [property: Required(ErrorMessage = "Tên vật tư là bắt buộc.")]
    [property: StringLength(300, ErrorMessage = "Tên vật tư không được vượt quá 300 ký tự.")]
    string TenVatTu,
    [property: Required(ErrorMessage = "Loại vật tư là bắt buộc.")]
    [property: StringLength(30, ErrorMessage = "Loại vật tư không được vượt quá 30 ký tự.")]
    string LoaiVatTu,
    [property: StringLength(30, ErrorMessage = "Mã sản phẩm không được vượt quá 30 ký tự.")]
    string? MaSanPham,
    decimal? ChieuDaiSanPham,
    [property: StringLength(50, ErrorMessage = "Mã nguyên liệu không được vượt quá 50 ký tự.")]
    string? MaNguyenLieu,
    [property: StringLength(50, ErrorMessage = "Mã bán thành phẩm không được vượt quá 50 ký tự.")]
    string? MaBanThanhPham,
    decimal? HeSoQuyDoiTuThanhDai,
    [property: StringLength(20, ErrorMessage = "Nhóm vật tư 1 không được vượt quá 20 ký tự.")]
    string? NhomVatTu1,
    [property: StringLength(20, ErrorMessage = "Nhóm vật tư 2 không được vượt quá 20 ký tự.")]
    string? NhomVatTu2,
    [property: Required(ErrorMessage = "Đơn vị tính là bắt buộc.")]
    [property: StringLength(20, ErrorMessage = "Đơn vị tính không được vượt quá 20 ký tự.")]
    string DonViTinh,
    [property: Required(ErrorMessage = "Trạng thái là bắt buộc.")]
    [property: StringLength(20, ErrorMessage = "Trạng thái không được vượt quá 20 ký tự.")]
    string TrangThai,
    [property: StringLength(500, ErrorMessage = "Ghi chú không được vượt quá 500 ký tự.")]
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
