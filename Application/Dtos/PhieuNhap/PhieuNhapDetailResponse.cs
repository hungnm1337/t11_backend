namespace t11.Application.Dtos.PhieuNhap;

public sealed record PhieuNhapInfoResponse(
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
    string? TrangThaiPhieu,
    DoiTacInfoResponse? NhaCungCap,
    KhoInfoResponse? KhoHang,
    KhoInfoResponse? KhoXuat,
    IReadOnlyList<ChiTietPhieuNhapInfoResponse> ChiTietPhieuNhaps);

public sealed record DoiTacInfoResponse(
    string MaDoiTac,
    string TenDoiTac,
    string LoaiDoiTac,
    string? DiaChi,
    string? SoDienThoai,
    string? MaSoThue,
    string? NguoiLienHe);

public sealed record KhoInfoResponse(
    string MaKho,
    string TenKho,
    string LoaiKho,
    string? DiaChi,
    string? MaDoiTacPhuTrach,
    string? GhiChu);

public sealed record ChiTietPhieuNhapInfoResponse(
    int Id,
    string SoPhieuNhap,
    string MaHang,
    string? TenHang,
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
