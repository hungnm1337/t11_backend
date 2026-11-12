using System;
using System.Collections.Generic;

namespace t11.Domain.Entities;

public partial class PhieuNhap
{
    public string SoPhieuNhap { get; set; } = null!;

    public DateOnly NgayNhap { get; set; }

    public string? MaChungTu { get; set; }

    public string? SoDonHang { get; set; }

    public string? SoHoaDon { get; set; }

    public string? PhieuYeuCau { get; set; }

    public string? MaNcc { get; set; }

    public string? MaHopDong { get; set; }

    public string? MaGiaoDich { get; set; }

    public string? MaKhoHang { get; set; }

    public string? MaKhoXuat { get; set; }

    public string? TenPhanXuong { get; set; }

    public string? MaBoPhan { get; set; }

    public string? TenBoPhan { get; set; }

    public string? UserTaoPo { get; set; }

    public string? NguoiLapPhieu { get; set; }

    public string? MaCdgtPhieu { get; set; }

    public string? TrangThaiPhieu { get; set; }

    public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; } = new List<ChiTietPhieuNhap>();

    public virtual PhieuDieuChuyen? MaGiaoDichNavigation { get; set; }

    public virtual Kho? MaKhoHangNavigation { get; set; }

    public virtual Kho? MaKhoXuatNavigation { get; set; }

    public virtual DoiTac? MaNccNavigation { get; set; }
}
