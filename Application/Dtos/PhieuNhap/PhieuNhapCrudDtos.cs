using System.ComponentModel.DataAnnotations;

namespace t11.Application.Dtos.PhieuNhap;

public sealed record PhieuNhapResponse(
    string SoPhieuNhap,
    DateOnly NgayNhap,
    string? MaChungTu,
    string? SoDonHang,
    string? SoHoaDon,
    string? PhieuYeuCau,
    string? MaNcc,
    string? MaHopDong,
    string? MaGiaoDich,
    string? MaKhoHang,
    string? MaKhoXuat,
    string? TenPhanXuong,
    string? MaBoPhan,
    string? TenBoPhan,
    string? UserTaoPo,
    string? NguoiLapPhieu,
    string? MaCdgtPhieu,
    string? TrangThaiPhieu);

public sealed record ChiTietPhieuNhapCrudRequest(
    [param: Required(ErrorMessage = "Mã hàng là bắt buộc.")]
    [param: StringLength(50, ErrorMessage = "Mã hàng không được vượt quá 50 ký tự.")]
    string MaHang,
    [param: StringLength(30, ErrorMessage = "Số phiếu nhập không được vượt quá 30 ký tự.")]
    string SoPhieuNhap,
    [param: StringLength(20, ErrorMessage = "Đơn vị tính không được vượt quá 20 ký tự.")]
    string? Dvt,
    decimal SoLuong,
    [param: StringLength(20, ErrorMessage = "Tài khoản nợ không được vượt quá 20 ký tự.")]
    string? TkNo,
    [param: StringLength(20, ErrorMessage = "Tài khoản có không được vượt quá 20 ký tự.")]
    string? TkCo,
    [param: StringLength(20, ErrorMessage = "Mã phí không được vượt quá 20 ký tự.")]
    string? MaPhi,
    decimal? DonTrongThietKe,
    decimal? TyLeDonTrongThucTeThietKe,
    [param: StringLength(20, ErrorMessage = "Ca sản xuất không được vượt quá 20 ký tự.")]
    string? CaSanXuat,
    [param: StringLength(50, ErrorMessage = "Máy sản xuất không được vượt quá 50 ký tự.")]
    string? MaySanXuat,
    [param: StringLength(30, ErrorMessage = "Mã công đoạn vật tư không được vượt quá 30 ký tự.")]
    string? MaCdgtVt,
    [param: StringLength(20, ErrorMessage = "Mã lỗi không được vượt quá 20 ký tự.")]
    string? MaLoi,
    [param: StringLength(200, ErrorMessage = "Tên lỗi không được vượt quá 200 ký tự.")]
    string? TenLoi,
    [param: StringLength(30, ErrorMessage = "Số lệnh sản xuất không được vượt quá 30 ký tự.")]
    string? SoLenhSx,
    [param: StringLength(30, ErrorMessage = "Đơn hàng gia công không được vượt quá 30 ký tự.")]
    string? DonHangGc,
    decimal? GiaGc,
    decimal? TienGc);

public sealed record ChiTietPhieuNhapCrudResponse(
    int Id,
    string MaHang,
    string SoPhieuNhap,
    string? Dvt,
    decimal SoLuong,
    string? TkNo,
    string? TkCo,
    string? MaPhi,
    decimal? DonTrongThietKe,
    decimal? TyLeDonTrongThucTeThietKe,
    string? CaSanXuat,
    string? MaySanXuat,
    string? MaCdgtVt,
    string? MaLoi,
    string? TenLoi,
    string? SoLenhSx,
    string? DonHangGc,
    decimal? GiaGc,
    decimal? TienGc);
