using System.ComponentModel.DataAnnotations;

namespace t11.Application.Dtos.PhieuDieuChuyen;

public sealed record PhieuDieuChuyenResponse(
    string MaGiaoDich,
    DateOnly? NgayChungTu,
    string? MaKhachHang,
    string? NguoiThucHien,
    string MaKhoXuat,
    string MaKhoNhap,
    string? DienGiai);

public sealed record ChiTietDieuChuyenCrudRequest(
    [param: StringLength(30, ErrorMessage = "Đơn hàng không được vượt quá 30 ký tự.")]
    string? DonHang,
    [param: Required(ErrorMessage = "Mã vật tư là bắt buộc.")]
    [param: StringLength(50, ErrorMessage = "Mã vật tư không được vượt quá 50 ký tự.")]
    string MaVatTu,
    [param: StringLength(30, ErrorMessage = "Mã giao dịch không được vượt quá 30 ký tự.")]
    string MaGiaoDich,
    [param: StringLength(20, ErrorMessage = "Đơn vị tính không được vượt quá 20 ký tự.")]
    string? Dvt,
    decimal? TonKho,
    decimal SoLuong,
    [param: StringLength(20, ErrorMessage = "Đơn vị tính 2 không được vượt quá 20 ký tự.")]
    string? Dvt2,
    decimal? SoLuong2,
    decimal? Gia,
    decimal? Tien,
    decimal? GiaDinhDanh,
    [param: StringLength(20, ErrorMessage = "Mã tài khoản nợ không được vượt quá 20 ký tự.")]
    string? MaNxTkNo,
    [param: StringLength(20, ErrorMessage = "Tài khoản vật tư có không được vượt quá 20 ký tự.")]
    string? TkVatTuTkCo,
    [param: StringLength(30, ErrorMessage = "Phiếu yêu cầu nguyên vật liệu không được vượt quá 30 ký tự.")]
    string? PhieuYeuCauNvl,
    [param: StringLength(500, ErrorMessage = "Ghi chú không được vượt quá 500 ký tự.")]
    string? GhiChu);

public sealed record ChiTietDieuChuyenCrudResponse(
    int Id,
    string? DonHang,
    string MaGiaoDich,
    string MaVatTu,
    string? Dvt,
    decimal? TonKho,
    decimal SoLuong,
    string? Dvt2,
    decimal? SoLuong2,
    decimal? Gia,
    decimal? Tien,
    decimal? GiaDinhDanh,
    string? MaNxTkNo,
    string? TkVatTuTkCo,
    string? PhieuYeuCauNvl,
    string? GhiChu);
