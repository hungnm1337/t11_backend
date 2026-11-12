using System;
using System.Collections.Generic;

namespace t11.Domain.Entities;

public partial class BanThanhPham
{
    public string MaBanThanhPham { get; set; } = null!;

    public string TenBanThanhPham { get; set; } = null!;

    public string? MaSanPham { get; set; }

    public string? MaNguyenLieuGoc { get; set; }

    public decimal? ChieuDaiBanThanhPham { get; set; }

    public decimal? HeSoQuyDoi { get; set; }

    public string? CongDoanGiaCong { get; set; }

    public string? LoaiGiaCong { get; set; }

    public string? XuLyBeMat { get; set; }

    public string? MaDonViGiaCong { get; set; }

    public decimal? DonGiaGiaCong { get; set; }

    public string TrangThai { get; set; } = null!;

    public string? GhiChu { get; set; }

    public virtual ICollection<DanhMucVatTu> DanhMucVatTus { get; set; } = new List<DanhMucVatTu>();

    public virtual DoiTac? MaDonViGiaCongNavigation { get; set; }

    public virtual NguyenLieu? MaNguyenLieuGocNavigation { get; set; }

    public virtual SanPham? MaSanPhamNavigation { get; set; }
}
