using System;
using System.Collections.Generic;

namespace t11.Domain.Entities;

public partial class SanPham
{
    public string MaSanPham { get; set; } = null!;

    public string TenSanPham { get; set; } = null!;

    public decimal? ChieuDaiSanPham { get; set; }

    public string? MaKhachHang { get; set; }

    public string? MoTa { get; set; }

    public string TrangThai { get; set; } = null!;

    public virtual ICollection<BanThanhPham> BanThanhPhams { get; set; } = new List<BanThanhPham>();

    public virtual ICollection<DanhMucVatTu> DanhMucVatTus { get; set; } = new List<DanhMucVatTu>();

    public virtual KhachHang? MaKhachHangNavigation { get; set; }

    public virtual ICollection<NguyenLieu> NguyenLieus { get; set; } = new List<NguyenLieu>();
}
