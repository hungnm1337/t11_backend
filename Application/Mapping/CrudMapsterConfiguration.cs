using Mapster;
using t11.Application.Dtos.BanThanhPham;
using t11.Application.Dtos.DanhMucVatTu;
using t11.Application.Dtos.DoiTac;
using t11.Application.Dtos.KhachHang;
using t11.Application.Dtos.Kho;
using t11.Application.Dtos.NguyenLieu;
using t11.Application.Dtos.SanPham;
using t11.Domain.Entities;

namespace t11.Application.Mapping;

public static class CrudMapsterConfiguration
{
    public static void Register(TypeAdapterConfig config)
    {
        // Map tường minh navigation sang trường phẳng để ProjectToType tạo projection đúng.
        config.NewConfig<Kho, KhoResponse>()
            .Map(d => d.MaDoiTacPhuTrachNavigationTenDoiTac,
                s => s.MaDoiTacPhuTrachNavigation == null ? null : s.MaDoiTacPhuTrachNavigation.TenDoiTac);

        config.NewConfig<SanPham, SanPhamResponse>()
            .Map(d => d.MaKhachHangNavigationTenKhachHang,
                s => s.MaKhachHangNavigation == null ? null : s.MaKhachHangNavigation.TenKhachHang);

        config.NewConfig<NguyenLieu, NguyenLieuResponse>()
            .Map(d => d.MaSanPhamNavigationTenSanPham,
                s => s.MaSanPhamNavigation == null ? null : s.MaSanPhamNavigation.TenSanPham)
            .Map(d => d.MaNhaCungCapNavigationTenDoiTac,
                s => s.MaNhaCungCapNavigation == null ? null : s.MaNhaCungCapNavigation.TenDoiTac);

        config.NewConfig<BanThanhPham, BanThanhPhamResponse>()
            .Map(d => d.MaSanPhamNavigationTenSanPham,
                s => s.MaSanPhamNavigation == null ? null : s.MaSanPhamNavigation.TenSanPham)
            .Map(d => d.MaNguyenLieuGocNavigationTenNguyenLieu,
                s => s.MaNguyenLieuGocNavigation == null ? null : s.MaNguyenLieuGocNavigation.TenNguyenLieu)
            .Map(d => d.MaDonViGiaCongNavigationTenDoiTac,
                s => s.MaDonViGiaCongNavigation == null ? null : s.MaDonViGiaCongNavigation.TenDoiTac);

        config.NewConfig<DanhMucVatTu, DanhMucVatTuResponse>()
            .Map(d => d.MaSanPhamNavigationTenSanPham,
                s => s.MaSanPhamNavigation == null ? null : s.MaSanPhamNavigation.TenSanPham)
            .Map(d => d.MaNguyenLieuNavigationTenNguyenLieu,
                s => s.MaNguyenLieuNavigation == null ? null : s.MaNguyenLieuNavigation.TenNguyenLieu)
            .Map(d => d.MaBanThanhPhamNavigationTenBanThanhPham,
                s => s.MaBanThanhPhamNavigation == null ? null : s.MaBanThanhPhamNavigation.TenBanThanhPham);

        config.NewConfig<KhachHang, KhachHangResponse>();
        config.NewConfig<DoiTac, DoiTacResponse>();
    }
}
