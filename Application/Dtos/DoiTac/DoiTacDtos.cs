using System.ComponentModel.DataAnnotations;

namespace t11.Application.Dtos.DoiTac;

public sealed record DoiTacRequest(
    [param: Required(ErrorMessage = "Mã đối tác là bắt buộc.")]
    [param: StringLength(20, ErrorMessage = "Mã đối tác không được vượt quá 20 ký tự.")]
    string MaDoiTac,
    [param: Required(ErrorMessage = "Tên đối tác là bắt buộc.")]
    [param: StringLength(200, ErrorMessage = "Tên đối tác không được vượt quá 200 ký tự.")]
    string TenDoiTac,
    [param: Required(ErrorMessage = "Loại đối tác là bắt buộc.")]
    [param: StringLength(30, ErrorMessage = "Loại đối tác không được vượt quá 30 ký tự.")]
    string LoaiDoiTac,
    [param: StringLength(300, ErrorMessage = "Địa chỉ không được vượt quá 300 ký tự.")]
    string? DiaChi,
    [param: StringLength(20, ErrorMessage = "Số điện thoại không được vượt quá 20 ký tự.")]
    string? SoDienThoai,
    [param: StringLength(20, ErrorMessage = "Mã số thuế không được vượt quá 20 ký tự.")]
    string? MaSoThue,
    [param: StringLength(100, ErrorMessage = "Người liên hệ không được vượt quá 100 ký tự.")]
    string? NguoiLienHe);

public sealed record DoiTacResponse(
    string MaDoiTac,
    string TenDoiTac,
    string LoaiDoiTac,
    string? DiaChi,
    string? SoDienThoai,
    string? MaSoThue,
    string? NguoiLienHe);
