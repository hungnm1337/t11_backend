using System;
using System.Collections.Generic;

namespace t11.Domain.Entities;

public partial class ChiTietPhieuNhap
{
    public int Id { get; set; }

    public string SoPhieuNhap { get; set; } = null!;

    public string MaHang { get; set; } = null!;

    public string? Dvt { get; set; }

    public decimal SoLuong { get; set; }

    public string? TkNo { get; set; }

    public string? TkCo { get; set; }

    public string? MaPhi { get; set; }

    public decimal? DonTrongThietKe { get; set; }

    public decimal? TyLeDonTrongThucTeThietKe { get; set; }

    public string? CaSanXuat { get; set; }

    public string? MaySanXuat { get; set; }

    public string? MaCdgtVt { get; set; }

    public string? MaLoi { get; set; }

    public string? TenLoi { get; set; }

    public string? SoLenhSx { get; set; }

    public string? DonHangGc { get; set; }

    public decimal? GiaGc { get; set; }

    public decimal? TienGc { get; set; }

    public virtual DanhMucVatTu MaHangNavigation { get; set; } = null!;

    public virtual PhieuNhap SoPhieuNhapNavigation { get; set; } = null!;
}
