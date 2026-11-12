using System;
using System.Collections.Generic;

namespace t11.Domain.Entities;

public partial class ChiTietDieuChuyen
{
    public int Id { get; set; }

    public string MaGiaoDich { get; set; } = null!;

    public string? DonHang { get; set; }

    public string MaVatTu { get; set; } = null!;

    public string? Dvt { get; set; }

    public decimal? TonKho { get; set; }

    public decimal SoLuong { get; set; }

    public string? Dvt2 { get; set; }

    public decimal? SoLuong2 { get; set; }

    public decimal? Gia { get; set; }

    public decimal? Tien { get; set; }

    public decimal? GiaDinhDanh { get; set; }

    public string? MaNxTkNo { get; set; }

    public string? TkVatTuTkCo { get; set; }

    public string? PhieuYeuCauNvl { get; set; }

    public string? GhiChu { get; set; }

    public virtual PhieuDieuChuyen MaGiaoDichNavigation { get; set; } = null!;

    public virtual DanhMucVatTu MaVatTuNavigation { get; set; } = null!;
}
