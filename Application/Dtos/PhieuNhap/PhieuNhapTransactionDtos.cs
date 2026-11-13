using System.ComponentModel.DataAnnotations;

namespace t11.Application.Dtos.PhieuNhap;

public sealed record PhieuNhapHeaderRequest(
    [property: Required(ErrorMessage = "Số phiếu nhập là bắt buộc.")]
    [property: StringLength(30, ErrorMessage = "Số phiếu nhập không được vượt quá 30 ký tự.")]
    string SoPhieuNhap,
    DateOnly NgayNhap,
    [property: StringLength(20, ErrorMessage = "Mã chứng từ không được vượt quá 20 ký tự.")]
    string? MaChungTu,
    [property: StringLength(30, ErrorMessage = "Số đơn hàng không được vượt quá 30 ký tự.")]
    string? SoDonHang,
    [property: StringLength(30, ErrorMessage = "Số hóa đơn không được vượt quá 30 ký tự.")]
    string? SoHoaDon,
    [property: StringLength(30, ErrorMessage = "Phiếu yêu cầu không được vượt quá 30 ký tự.")]
    string? PhieuYeuCau,
    [property: StringLength(20, ErrorMessage = "Mã nhà cung cấp không được vượt quá 20 ký tự.")]
    string? MaNcc,
    [property: StringLength(30, ErrorMessage = "Mã hợp đồng không được vượt quá 30 ký tự.")]
    string? MaHopDong,
    [property: StringLength(30, ErrorMessage = "Mã giao dịch không được vượt quá 30 ký tự.")]
    string? MaGiaoDich,
    [property: StringLength(20, ErrorMessage = "Mã kho hàng không được vượt quá 20 ký tự.")]
    string? MaKhoHang,
    [property: StringLength(20, ErrorMessage = "Mã kho xuất không được vượt quá 20 ký tự.")]
    string? MaKhoXuat,
    [property: StringLength(100, ErrorMessage = "Tên phân xưởng không được vượt quá 100 ký tự.")]
    string? TenPhanXuong,
    [property: StringLength(20, ErrorMessage = "Mã bộ phận không được vượt quá 20 ký tự.")]
    string? MaBoPhan,
    [property: StringLength(100, ErrorMessage = "Tên bộ phận không được vượt quá 100 ký tự.")]
    string? TenBoPhan,
    [property: StringLength(100, ErrorMessage = "User tạo PO không được vượt quá 100 ký tự.")]
    string? UserTaoPo,
    [property: StringLength(100, ErrorMessage = "Người lập phiếu không được vượt quá 100 ký tự.")]
    string? NguoiLapPhieu,
    [property: StringLength(30, ErrorMessage = "Mã công đoạn phiếu không được vượt quá 30 ký tự.")]
    string? MaCdgtPhieu,
    [property: StringLength(30, ErrorMessage = "Trạng thái phiếu không được vượt quá 30 ký tự.")]
    string? TrangThaiPhieu);

public sealed record ChiTietPhieuNhapRequest(
    [property: Required(ErrorMessage = "Mã hàng là bắt buộc.")]
    [property: StringLength(50, ErrorMessage = "Mã hàng không được vượt quá 50 ký tự.")]
    string MaHang,
    [property: StringLength(20, ErrorMessage = "Đơn vị tính không được vượt quá 20 ký tự.")]
    string? Dvt,
    decimal SoLuong,
    [property: StringLength(20, ErrorMessage = "Tài khoản nợ không được vượt quá 20 ký tự.")]
    string? TkNo,
    [property: StringLength(20, ErrorMessage = "Tài khoản có không được vượt quá 20 ký tự.")]
    string? TkCo,
    [property: StringLength(20, ErrorMessage = "Mã phí không được vượt quá 20 ký tự.")]
    string? MaPhi,
    decimal? DonTrongThietKe,
    decimal? TyLeDonTrongThucTeThietKe,
    [property: StringLength(20, ErrorMessage = "Ca sản xuất không được vượt quá 20 ký tự.")]
    string? CaSanXuat,
    [property: StringLength(50, ErrorMessage = "Máy sản xuất không được vượt quá 50 ký tự.")]
    string? MaySanXuat,
    [property: StringLength(30, ErrorMessage = "Mã công đoạn vật tư không được vượt quá 30 ký tự.")]
    string? MaCdgtVt,
    [property: StringLength(20, ErrorMessage = "Mã lỗi không được vượt quá 20 ký tự.")]
    string? MaLoi,
    [property: StringLength(200, ErrorMessage = "Tên lỗi không được vượt quá 200 ký tự.")]
    string? TenLoi,
    [property: StringLength(30, ErrorMessage = "Số lệnh sản xuất không được vượt quá 30 ký tự.")]
    string? SoLenhSx,
    [property: StringLength(30, ErrorMessage = "Đơn hàng gia công không được vượt quá 30 ký tự.")]
    string? DonHangGc,
    decimal? GiaGc,
    decimal? TienGc);

public sealed record PhieuNhapTransactionRequest(
    PhieuNhapHeaderRequest PhieuNhap,
    IReadOnlyList<ChiTietPhieuNhapRequest> ChiTietPhieuNhaps);

public sealed record PhieuNhapTransactionResponse(string SoPhieuNhap, IReadOnlyList<int> ChiTietIds);
