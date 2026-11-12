using System;
using System.Collections.Generic;

namespace t11.Domain.Entities;

public partial class NguyenLieu
{
    public string MaNguyenLieu { get; set; } = null!;

    public string TenNguyenLieu { get; set; } = null!;

    public string LoaiNguyenLieu { get; set; } = null!;

    public string? MaSanPham { get; set; }

    public decimal? ChieuDaiThanh { get; set; }

    public string? MaNhaCungCap { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<BanThanhPham> BanThanhPhams { get; set; } = new List<BanThanhPham>();

    public virtual ICollection<DanhMucVatTu> DanhMucVatTus { get; set; } = new List<DanhMucVatTu>();

    public virtual DoiTac? MaNhaCungCapNavigation { get; set; }

    public virtual SanPham? MaSanPhamNavigation { get; set; }
}
