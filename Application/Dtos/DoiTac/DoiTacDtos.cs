using System.ComponentModel.DataAnnotations;

namespace t11.Application.Dtos.DoiTac;

public sealed record DoiTacRequest(
    [property: Required(ErrorMessage = "Mã đối tác là bắt buộc.")]
    [property: StringLength(20, ErrorMessage = "Mã đối tác không được vượt quá 20 ký tự.")]
    string MaDoiTac,
    [property: Required(ErrorMessage = "Tên đối tác là bắt buộc.")]
    [property: StringLength(200, ErrorMessage = "Tên đối tác không được vượt quá 200 ký tự.")]
    string TenDoiTac,
    [property: Required(ErrorMessage = "Loại đối tác là bắt buộc.")]
    [property: StringLength(30, ErrorMessage = "Loại đối tác không được vượt quá 30 ký tự.")]
    string LoaiDoiTac,
    [property: StringLength(300, ErrorMessage = "Địa chỉ không được vượt quá 300 ký tự.")]
    string? DiaChi,
    [property: StringLength(20, ErrorMessage = "Số điện thoại không được vượt quá 20 ký tự.")]
    string? SoDienThoai,
    [property: StringLength(20, ErrorMessage = "Mã số thuế không được vượt quá 20 ký tự.")]
    string? MaSoThue,
    [property: StringLength(100, ErrorMessage = "Người liên hệ không được vượt quá 100 ký tự.")]
    string? NguoiLienHe);

public sealed record DoiTacResponse(
    string MaDoiTac,
    string TenDoiTac,
    string LoaiDoiTac,
    string? DiaChi,
    string? SoDienThoai,
    string? MaSoThue,
    string? NguoiLienHe);
