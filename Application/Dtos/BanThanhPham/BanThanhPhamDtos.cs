using System.ComponentModel.DataAnnotations;

namespace t11.Application.Dtos.BanThanhPham;

public sealed record BanThanhPhamRequest(
    [property: Required(ErrorMessage = "Mã bán thành phẩm là bắt buộc.")]
    [property: StringLength(50, ErrorMessage = "Mã bán thành phẩm không được vượt quá 50 ký tự.")]
    string MaBanThanhPham,
    [property: Required(ErrorMessage = "Tên bán thành phẩm là bắt buộc.")]
    [property: StringLength(300, ErrorMessage = "Tên bán thành phẩm không được vượt quá 300 ký tự.")]
    string TenBanThanhPham,
    [property: StringLength(30, ErrorMessage = "Mã sản phẩm không được vượt quá 30 ký tự.")]
    string? MaSanPham,
    [property: StringLength(50, ErrorMessage = "Mã nguyên liệu gốc không được vượt quá 50 ký tự.")]
    string? MaNguyenLieuGoc,
    decimal? ChieuDaiBanThanhPham,
    decimal? HeSoQuyDoi,
    [property: StringLength(200, ErrorMessage = "Công đoạn gia công không được vượt quá 200 ký tự.")]
    string? CongDoanGiaCong,
    [property: StringLength(50, ErrorMessage = "Loại gia công không được vượt quá 50 ký tự.")]
    string? LoaiGiaCong,
    [property: StringLength(100, ErrorMessage = "Xử lý bề mặt không được vượt quá 100 ký tự.")]
    string? XuLyBeMat,
    [property: StringLength(20, ErrorMessage = "Mã đơn vị gia công không được vượt quá 20 ký tự.")]
    string? MaDonViGiaCong,
    decimal? DonGiaGiaCong,
    [property: Required(ErrorMessage = "Trạng thái là bắt buộc.")]
    [property: StringLength(20, ErrorMessage = "Trạng thái không được vượt quá 20 ký tự.")]
    string TrangThai,
    [property: StringLength(500, ErrorMessage = "Ghi chú không được vượt quá 500 ký tự.")]
    string? GhiChu);

public sealed record BanThanhPhamResponse(
    string MaBanThanhPham,
    string TenBanThanhPham,
    string? MaSanPham,
    string? MaNguyenLieuGoc,
    decimal? ChieuDaiBanThanhPham,
    decimal? HeSoQuyDoi,
    string? CongDoanGiaCong,
    string? LoaiGiaCong,
    string? XuLyBeMat,
    string? MaDonViGiaCong,
    decimal? DonGiaGiaCong,
    string TrangThai,
    string? GhiChu,
    string? MaSanPhamNavigationTenSanPham,
    string? MaNguyenLieuGocNavigationTenNguyenLieu,
    string? MaDonViGiaCongNavigationTenDoiTac);
