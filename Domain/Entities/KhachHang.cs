using System;
using System.Collections.Generic;

namespace t11.Domain.Entities;

public partial class KhachHang
{
    public string MaKhachHang { get; set; } = null!;

    public string TenKhachHang { get; set; } = null!;

    public string? DiaChi { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public string? MaSoThue { get; set; }

    public string? NguoiLienHe { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<PhieuDieuChuyen> PhieuDieuChuyens { get; set; } = new List<PhieuDieuChuyen>();

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
