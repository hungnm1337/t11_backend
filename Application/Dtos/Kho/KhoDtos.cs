using System.ComponentModel.DataAnnotations;

namespace t11.Application.Dtos.Kho;

public sealed record KhoRequest(
    [param: Required(ErrorMessage = "Mã kho là bắt buộc.")]
    [param: StringLength(20, ErrorMessage = "Mã kho không được vượt quá 20 ký tự.")]
    string MaKho,
    [param: Required(ErrorMessage = "Tên kho là bắt buộc.")]
    [param: StringLength(200, ErrorMessage = "Tên kho không được vượt quá 200 ký tự.")]
    string TenKho,
    [param: Required(ErrorMessage = "Loại kho là bắt buộc.")]
    [param: StringLength(30, ErrorMessage = "Loại kho không được vượt quá 30 ký tự.")]
    string LoaiKho,
    [param: StringLength(300, ErrorMessage = "Địa chỉ không được vượt quá 300 ký tự.")]
    string? DiaChi,
    [param: StringLength(20, ErrorMessage = "Mã đối tác phụ trách không được vượt quá 20 ký tự.")]
    string? MaDoiTacPhuTrach,
    [param: StringLength(500, ErrorMessage = "Ghi chú không được vượt quá 500 ký tự.")]
    string? GhiChu);

public sealed record KhoResponse(
    string MaKho,
    string TenKho,
    string LoaiKho,
    string? DiaChi,
    string? MaDoiTacPhuTrach,
    string? GhiChu,
    string? MaDoiTacPhuTrachNavigationTenDoiTac);
