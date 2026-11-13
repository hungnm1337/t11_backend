using System.ComponentModel.DataAnnotations;

namespace t11.Application.Dtos.NguyenLieu;

public sealed record NguyenLieuRequest(
    [property: Required(ErrorMessage = "Mã nguyên liệu là bắt buộc.")]
    [property: StringLength(50, ErrorMessage = "Mã nguyên liệu không được vượt quá 50 ký tự.")]
    string MaNguyenLieu,
    [property: Required(ErrorMessage = "Tên nguyên liệu là bắt buộc.")]
    [property: StringLength(300, ErrorMessage = "Tên nguyên liệu không được vượt quá 300 ký tự.")]
    string TenNguyenLieu,
    [property: Required(ErrorMessage = "Loại nguyên liệu là bắt buộc.")]
    [property: StringLength(30, ErrorMessage = "Loại nguyên liệu không được vượt quá 30 ký tự.")]
    string LoaiNguyenLieu,
    [property: StringLength(30, ErrorMessage = "Mã sản phẩm không được vượt quá 30 ký tự.")]
    string? MaSanPham,
    decimal? ChieuDaiThanh,
    [property: StringLength(20, ErrorMessage = "Mã nhà cung cấp không được vượt quá 20 ký tự.")]
    string? MaNhaCungCap,
    [property: StringLength(500, ErrorMessage = "Ghi chú không được vượt quá 500 ký tự.")]
    string? GhiChu);

public sealed record NguyenLieuResponse(
    string MaNguyenLieu,
    string TenNguyenLieu,
    string LoaiNguyenLieu,
    string? MaSanPham,
    decimal? ChieuDaiThanh,
    string? MaNhaCungCap,
    string? GhiChu,
    string? MaSanPhamNavigationTenSanPham,
    string? MaNhaCungCapNavigationTenDoiTac);
