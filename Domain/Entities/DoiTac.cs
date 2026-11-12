using System;
using System.Collections.Generic;

namespace t11.Domain.Entities;

public partial class DoiTac
{
    public string MaDoiTac { get; set; } = null!;

    public string TenDoiTac { get; set; } = null!;

    public string LoaiDoiTac { get; set; } = null!;

    public string? DiaChi { get; set; }

    public string? SoDienThoai { get; set; }

    public string? MaSoThue { get; set; }

    public string? NguoiLienHe { get; set; }

    public virtual ICollection<BanThanhPham> BanThanhPhams { get; set; } = new List<BanThanhPham>();

    public virtual ICollection<Kho> Khos { get; set; } = new List<Kho>();

    public virtual ICollection<NguyenLieu> NguyenLieus { get; set; } = new List<NguyenLieu>();

    public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; } = new List<PhieuNhap>();
}
