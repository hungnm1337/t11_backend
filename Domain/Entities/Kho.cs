using System;
using System.Collections.Generic;

namespace t11.Domain.Entities;

public partial class Kho
{
    public string MaKho { get; set; } = null!;

    public string TenKho { get; set; } = null!;

    public string LoaiKho { get; set; } = null!;

    public string? DiaChi { get; set; }

    public string? MaDoiTacPhuTrach { get; set; }

    public string? GhiChu { get; set; }

    public virtual DoiTac? MaDoiTacPhuTrachNavigation { get; set; }

    public virtual ICollection<PhieuDieuChuyen> PhieuDieuChuyenMaKhoNhapNavigations { get; set; } = new List<PhieuDieuChuyen>();

    public virtual ICollection<PhieuDieuChuyen> PhieuDieuChuyenMaKhoXuatNavigations { get; set; } = new List<PhieuDieuChuyen>();

    public virtual ICollection<PhieuNhap> PhieuNhapMaKhoHangNavigations { get; set; } = new List<PhieuNhap>();

    public virtual ICollection<PhieuNhap> PhieuNhapMaKhoXuatNavigations { get; set; } = new List<PhieuNhap>();
}
