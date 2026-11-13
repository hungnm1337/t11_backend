using System.ComponentModel.DataAnnotations;

namespace t11.Application.Dtos.Kho;

public sealed record KhoRequest(
    [property: Required(ErrorMessage = "Mã kho là bắt buộc.")]
    [property: StringLength(20, ErrorMessage = "Mã kho không được vượt quá 20 ký tự.")]
    string MaKho,
    [property: Required(ErrorMessage = "Tên kho là bắt buộc.")]
    [property: StringLength(200, ErrorMessage = "Tên kho không được vượt quá 200 ký tự.")]
    string TenKho,
    [property: Required(ErrorMessage = "Loại kho là bắt buộc.")]
    [property: StringLength(30, ErrorMessage = "Loại kho không được vượt quá 30 ký tự.")]
    string LoaiKho,
    [property: StringLength(300, ErrorMessage = "Địa chỉ không được vượt quá 300 ký tự.")]
    string? DiaChi,
    [property: StringLength(20, ErrorMessage = "Mã đối tác phụ trách không được vượt quá 20 ký tự.")]
    string? MaDoiTacPhuTrach,
    [property: StringLength(500, ErrorMessage = "Ghi chú không được vượt quá 500 ký tự.")]
    string? GhiChu);

public sealed record KhoResponse(
    string MaKho,
    string TenKho,
    string LoaiKho,
    string? DiaChi,
    string? MaDoiTacPhuTrach,
    string? GhiChu,
    string? MaDoiTacPhuTrachNavigationTenDoiTac);
