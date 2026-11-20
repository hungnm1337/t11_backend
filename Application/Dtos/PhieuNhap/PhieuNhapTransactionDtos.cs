using System.ComponentModel.DataAnnotations;

namespace t11.Application.Dtos.PhieuNhap;

public sealed record PhieuNhapHeaderRequest(
    [param: Required(ErrorMessage = "Số phiếu nhập là bắt buộc.")]
    [param: StringLength(30, ErrorMessage = "Số phiếu nhập không được vượt quá 30 ký tự.")]
    string SoPhieuNhap,
    DateOnly NgayNhap,
    [param: StringLength(20, ErrorMessage = "Mã chứng từ không được vượt quá 20 ký tự.")]
    string? MaChungTu,
    [param: StringLength(30, ErrorMessage = "Số đơn hàng không được vượt quá 30 ký tự.")]
    string? SoDonHang,
    [param: StringLength(30, ErrorMessage = "Số hóa đơn không được vượt quá 30 ký tự.")]
    string? SoHoaDon,
    [param: StringLength(30, ErrorMessage = "Phiếu yêu cầu không được vượt quá 30 ký tự.")]
    string? PhieuYeuCau,
    [param: StringLength(20, ErrorMessage = "Mã nhà cung cấp không được vượt quá 20 ký tự.")]
    string? MaNcc,
    [param: StringLength(30, ErrorMessage = "Mã hợp đồng không được vượt quá 30 ký tự.")]
    string? MaHopDong,
    [param: StringLength(30, ErrorMessage = "Mã giao dịch không được vượt quá 30 ký tự.")]
    string? MaGiaoDich,
    [param: StringLength(20, ErrorMessage = "Mã kho hàng không được vượt quá 20 ký tự.")]
    string? MaKhoHang,
    [param: StringLength(20, ErrorMessage = "Mã kho xuất không được vượt quá 20 ký tự.")]
    string? MaKhoXuat,
    [param: StringLength(100, ErrorMessage = "Tên phân xưởng không được vượt quá 100 ký tự.")]
    string? TenPhanXuong,
    [param: StringLength(20, ErrorMessage = "Mã bộ phận không được vượt quá 20 ký tự.")]
    string? MaBoPhan,
    [param: StringLength(100, ErrorMessage = "Tên bộ phận không được vượt quá 100 ký tự.")]
    string? TenBoPhan,
    [param: StringLength(100, ErrorMessage = "User tạo PO không được vượt quá 100 ký tự.")]
    string? UserTaoPo,
    [param: StringLength(100, ErrorMessage = "Người lập phiếu không được vượt quá 100 ký tự.")]
    string? NguoiLapPhieu,
    [param: StringLength(30, ErrorMessage = "Mã công đoạn phiếu không được vượt quá 30 ký tự.")]
    string? MaCdgtPhieu,
    [param: StringLength(30, ErrorMessage = "Trạng thái phiếu không được vượt quá 30 ký tự.")]
    string? TrangThaiPhieu);

public sealed record ChiTietPhieuNhapRequest(
    [param: Required(ErrorMessage = "Mã hàng là bắt buộc.")]
    [param: StringLength(50, ErrorMessage = "Mã hàng không được vượt quá 50 ký tự.")]
    string MaHang,
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

public sealed record PhieuNhapTransactionRequest(
    PhieuNhapHeaderRequest PhieuNhap,
    IReadOnlyList<ChiTietPhieuNhapRequest> ChiTietPhieuNhaps);

public sealed record PhieuNhapTransactionResponse(string SoPhieuNhap, IReadOnlyList<int> ChiTietIds);
