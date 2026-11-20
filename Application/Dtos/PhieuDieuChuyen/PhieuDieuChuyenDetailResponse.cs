namespace t11.Application.Dtos.PhieuDieuChuyen;

public sealed record PhieuDieuChuyenInfoResponse(
    string MaGiaoDich,
    DateOnly? NgayChungTu,
    string? MaKhachHang,
    string? NguoiThucHien,
    string MaKhoXuat,
    string MaKhoNhap,
    string? DienGiai,
    KhachHangInfoResponse? KhachHang,
    KhoInfoResponse KhoXuat,
    KhoInfoResponse KhoNhap,
    IReadOnlyList<ChiTietDieuChuyenInfoResponse> ChiTietDieuChuyens);

public sealed record KhachHangInfoResponse(
    string MaKhachHang,
    string TenKhachHang,
    string? DiaChi,
    string? SoDienThoai,
    string? Email,
    string? MaSoThue,
    string? NguoiLienHe,
    string? GhiChu);

public sealed record KhoInfoResponse(
    string MaKho,
    string TenKho,
    string LoaiKho,
    string? DiaChi,
    string? MaDoiTacPhuTrach,
    string? GhiChu);

public sealed record ChiTietDieuChuyenInfoResponse(
    int Id,
    string MaGiaoDich,
    string? DonHang,
    string MaVatTu,
    string? TenVatTu,
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
