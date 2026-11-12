using System;
using System.Collections.Generic;

namespace t11.Domain.Entities;

public partial class DanhMucVatTu
{
    public string MaVatTu { get; set; } = null!;

    public string TenVatTu { get; set; } = null!;

    public string LoaiVatTu { get; set; } = null!;

    public string? MaSanPham { get; set; }

    public decimal? ChieuDaiSanPham { get; set; }

    public string? MaNguyenLieu { get; set; }

    public string? MaBanThanhPham { get; set; }

    public decimal? HeSoQuyDoiTuThanhDai { get; set; }

    public string? NhomVatTu1 { get; set; }

    public string? NhomVatTu2 { get; set; }

    public string DonViTinh { get; set; } = null!;

    public string TrangThai { get; set; } = null!;

    public string? GhiChu { get; set; }

    public virtual ICollection<ChiTietDieuChuyen> ChiTietDieuChuyens { get; set; } = new List<ChiTietDieuChuyen>();

    public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; } = new List<ChiTietPhieuNhap>();

    public virtual BanThanhPham? MaBanThanhPhamNavigation { get; set; }

    public virtual NguyenLieu? MaNguyenLieuNavigation { get; set; }

    public virtual SanPham? MaSanPhamNavigation { get; set; }
}
