using System.ComponentModel.DataAnnotations;

namespace t11.Application.Dtos.KhachHang;

public sealed record KhachHangRequest(
    [property: Required(ErrorMessage = "Mã khách hàng là bắt buộc.")]
    [property: StringLength(20, ErrorMessage = "Mã khách hàng không được vượt quá 20 ký tự.")]
    string MaKhachHang,
    [property: Required(ErrorMessage = "Tên khách hàng là bắt buộc.")]
    [property: StringLength(200, ErrorMessage = "Tên khách hàng không được vượt quá 200 ký tự.")]
    string TenKhachHang,
    [property: StringLength(300, ErrorMessage = "Địa chỉ không được vượt quá 300 ký tự.")]
    string? DiaChi,
    [property: StringLength(20, ErrorMessage = "Số điện thoại không được vượt quá 20 ký tự.")]
    string? SoDienThoai,
    [property: StringLength(100, ErrorMessage = "Email không được vượt quá 100 ký tự.")]
    string? Email,
    [property: StringLength(20, ErrorMessage = "Mã số thuế không được vượt quá 20 ký tự.")]
    string? MaSoThue,
    [property: StringLength(100, ErrorMessage = "Người liên hệ không được vượt quá 100 ký tự.")]
    string? NguoiLienHe,
    [property: StringLength(500, ErrorMessage = "Ghi chú không được vượt quá 500 ký tự.")]
    string? GhiChu);

public sealed record KhachHangResponse(
    string MaKhachHang,
    string TenKhachHang,
    string? DiaChi,
    string? SoDienThoai,
    string? Email,
    string? MaSoThue,
    string? NguoiLienHe,
    string? GhiChu);
