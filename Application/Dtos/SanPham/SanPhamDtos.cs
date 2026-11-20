using System.ComponentModel.DataAnnotations;

namespace t11.Application.Dtos.SanPham;

public sealed record SanPhamRequest(
    [param: Required(ErrorMessage = "Mã sản phẩm là bắt buộc.")]
    [param: StringLength(30, ErrorMessage = "Mã sản phẩm không được vượt quá 30 ký tự.")]
    string MaSanPham,
    [param: Required(ErrorMessage = "Tên sản phẩm là bắt buộc.")]
    [param: StringLength(200, ErrorMessage = "Tên sản phẩm không được vượt quá 200 ký tự.")]
    string TenSanPham,
    decimal? ChieuDaiSanPham,
    [param: StringLength(20, ErrorMessage = "Mã khách hàng không được vượt quá 20 ký tự.")]
    string? MaKhachHang,
    [param: StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự.")]
    string? MoTa,
    [param: Required(ErrorMessage = "Trạng thái là bắt buộc.")]
    [param: StringLength(20, ErrorMessage = "Trạng thái không được vượt quá 20 ký tự.")]
    string TrangThai);

public sealed record SanPhamResponse(
    string MaSanPham,
    string TenSanPham,
    decimal? ChieuDaiSanPham,
    string? MaKhachHang,
    string? MoTa,
    string TrangThai,
    string? MaKhachHangNavigationTenKhachHang);
