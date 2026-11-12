using System;
using System.Collections.Generic;

namespace t11.Domain.Entities;

public partial class PhieuDieuChuyen
{
    public string MaGiaoDich { get; set; } = null!;

    public DateOnly? NgayChungTu { get; set; }

    public string? MaKhachHang { get; set; }

    public string? NguoiThucHien { get; set; }

    public string MaKhoXuat { get; set; } = null!;

    public string MaKhoNhap { get; set; } = null!;

    public string? DienGiai { get; set; }

    public virtual ICollection<ChiTietDieuChuyen> ChiTietDieuChuyens { get; set; } = new List<ChiTietDieuChuyen>();

    public virtual KhachHang? MaKhachHangNavigation { get; set; }

    public virtual Kho MaKhoNhapNavigation { get; set; } = null!;

    public virtual Kho MaKhoXuatNavigation { get; set; } = null!;

    public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; } = new List<PhieuNhap>();
}
