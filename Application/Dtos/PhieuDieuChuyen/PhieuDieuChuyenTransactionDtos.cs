using System.ComponentModel.DataAnnotations;

namespace t11.Application.Dtos.PhieuDieuChuyen;

public sealed record PhieuDieuChuyenHeaderRequest(
    [param: Required(ErrorMessage = "Mã giao dịch là bắt buộc.")]
    [param: StringLength(30, ErrorMessage = "Mã giao dịch không được vượt quá 30 ký tự.")]
    string MaGiaoDich,
    DateOnly? NgayChungTu,
    [param: StringLength(20, ErrorMessage = "Mã khách hàng không được vượt quá 20 ký tự.")]
    string? MaKhachHang,
    [param: StringLength(100, ErrorMessage = "Người thực hiện không được vượt quá 100 ký tự.")]
    string? NguoiThucHien,
    [param: Required(ErrorMessage = "Mã kho xuất là bắt buộc.")]
    [param: StringLength(20, ErrorMessage = "Mã kho xuất không được vượt quá 20 ký tự.")]
    string MaKhoXuat,
    [param: Required(ErrorMessage = "Mã kho nhập là bắt buộc.")]
    [param: StringLength(20, ErrorMessage = "Mã kho nhập không được vượt quá 20 ký tự.")]
    string MaKhoNhap,
    [param: StringLength(500, ErrorMessage = "Diễn giải không được vượt quá 500 ký tự.")]
    string? DienGiai);

public sealed record ChiTietDieuChuyenRequest(
    [param: StringLength(30, ErrorMessage = "Đơn hàng không được vượt quá 30 ký tự.")]
    string? DonHang,
    [param: Required(ErrorMessage = "Mã vật tư là bắt buộc.")]
    [param: StringLength(50, ErrorMessage = "Mã vật tư không được vượt quá 50 ký tự.")]
    string MaVatTu,
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

public sealed record PhieuDieuChuyenTransactionRequest(
    PhieuDieuChuyenHeaderRequest PhieuDieuChuyen,
    IReadOnlyList<ChiTietDieuChuyenRequest> ChiTietDieuChuyens);

public sealed record PhieuDieuChuyenTransactionResponse(string MaGiaoDich, IReadOnlyList<int> ChiTietIds);
