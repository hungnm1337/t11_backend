using System.ComponentModel.DataAnnotations;

namespace t11.Application.Dtos.SanPham;

public sealed record SanPhamRequest(
    [property: Required(ErrorMessage = "Mã sản phẩm là bắt buộc.")]
    [property: StringLength(30, ErrorMessage = "Mã sản phẩm không được vượt quá 30 ký tự.")]
    string MaSanPham,
    [property: Required(ErrorMessage = "Tên sản phẩm là bắt buộc.")]
    [property: StringLength(200, ErrorMessage = "Tên sản phẩm không được vượt quá 200 ký tự.")]
    string TenSanPham,
    decimal? ChieuDaiSanPham,
    [property: StringLength(20, ErrorMessage = "Mã khách hàng không được vượt quá 20 ký tự.")]
    string? MaKhachHang,
    [property: StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự.")]
    string? MoTa,
    [property: Required(ErrorMessage = "Trạng thái là bắt buộc.")]
    [property: StringLength(20, ErrorMessage = "Trạng thái không được vượt quá 20 ký tự.")]
    string TrangThai);

public sealed record SanPhamResponse(
    string MaSanPham,
    string TenSanPham,
    decimal? ChieuDaiSanPham,
    string? MaKhachHang,
    string? MoTa,
    string TrangThai,
    string? MaKhachHangNavigationTenKhachHang);
