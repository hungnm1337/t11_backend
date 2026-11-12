using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using t11.Domain.Entities;

namespace t11.Infrastructure.Persistence;

public partial class KhoDbContext : DbContext
{
    public KhoDbContext(DbContextOptions<KhoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BanThanhPham> BanThanhPhams { get; set; }

    public virtual DbSet<ChiTietDieuChuyen> ChiTietDieuChuyens { get; set; }

    public virtual DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }

    public virtual DbSet<DanhMucVatTu> DanhMucVatTus { get; set; }

    public virtual DbSet<DoiTac> DoiTacs { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<Kho> Khos { get; set; }

    public virtual DbSet<NguyenLieu> NguyenLieus { get; set; }

    public virtual DbSet<PhieuDieuChuyen> PhieuDieuChuyens { get; set; }

    public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("auth", "aal_level", new[] { "aal1", "aal2", "aal3" })
            .HasPostgresEnum("auth", "code_challenge_method", new[] { "s256", "plain" })
            .HasPostgresEnum("auth", "factor_status", new[] { "unverified", "verified" })
            .HasPostgresEnum("auth", "factor_type", new[] { "totp", "webauthn", "phone", "recovery_code" })
            .HasPostgresEnum("auth", "oauth_authorization_status", new[] { "pending", "approved", "denied", "expired" })
            .HasPostgresEnum("auth", "oauth_client_type", new[] { "public", "confidential" })
            .HasPostgresEnum("auth", "oauth_registration_type", new[] { "dynamic", "manual" })
            .HasPostgresEnum("auth", "oauth_response_type", new[] { "code" })
            .HasPostgresEnum("auth", "one_time_token_type", new[] { "confirmation_token", "reauthentication_token", "recovery_token", "email_change_token_new", "email_change_token_current", "phone_change_token" })
            .HasPostgresEnum("realtime", "action", new[] { "INSERT", "UPDATE", "DELETE", "TRUNCATE", "ERROR" })
            .HasPostgresEnum("realtime", "equality_op", new[] { "eq", "neq", "lt", "lte", "gt", "gte", "in", "like", "ilike", "is", "match", "imatch", "isdistinct" })
            .HasPostgresEnum("storage", "buckettype", new[] { "STANDARD", "ANALYTICS", "VECTOR" })
          ;

        modelBuilder.Entity<BanThanhPham>(entity =>
        {
            entity.HasKey(e => e.MaBanThanhPham).HasName("pk_ban_thanh_pham");

            entity.ToTable("ban_thanh_pham");

            entity.Property(e => e.MaBanThanhPham)
                .HasMaxLength(50)
                .HasColumnName("ma_ban_thanh_pham");
            entity.Property(e => e.ChieuDaiBanThanhPham)
                .HasPrecision(10, 5)
                .HasColumnName("chieu_dai_ban_thanh_pham");
            entity.Property(e => e.CongDoanGiaCong)
                .HasMaxLength(200)
                .HasColumnName("cong_doan_gia_cong");
            entity.Property(e => e.DonGiaGiaCong)
                .HasPrecision(18, 2)
                .HasColumnName("don_gia_gia_cong");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(500)
                .HasColumnName("ghi_chu");
            entity.Property(e => e.HeSoQuyDoi)
                .HasPrecision(10, 3)
                .HasColumnName("he_so_quy_doi");
            entity.Property(e => e.LoaiGiaCong)
                .HasMaxLength(50)
                .HasColumnName("loai_gia_cong");
            entity.Property(e => e.MaDonViGiaCong)
                .HasMaxLength(20)
                .HasColumnName("ma_don_vi_gia_cong");
            entity.Property(e => e.MaNguyenLieuGoc)
                .HasMaxLength(50)
                .HasColumnName("ma_nguyen_lieu_goc");
            entity.Property(e => e.MaSanPham)
                .HasMaxLength(30)
                .HasColumnName("ma_san_pham");
            entity.Property(e => e.TenBanThanhPham)
                .HasMaxLength(300)
                .HasColumnName("ten_ban_thanh_pham");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Đang dùng'::character varying")
                .HasColumnName("trang_thai");
            entity.Property(e => e.XuLyBeMat)
                .HasMaxLength(100)
                .HasColumnName("xu_ly_be_mat");

            entity.HasOne(d => d.MaDonViGiaCongNavigation).WithMany(p => p.BanThanhPhams)
                .HasForeignKey(d => d.MaDonViGiaCong)
                .HasConstraintName("fk_btp_doi_tac");

            entity.HasOne(d => d.MaNguyenLieuGocNavigation).WithMany(p => p.BanThanhPhams)
                .HasForeignKey(d => d.MaNguyenLieuGoc)
                .HasConstraintName("fk_btp_nguyen_lieu");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.BanThanhPhams)
                .HasForeignKey(d => d.MaSanPham)
                .HasConstraintName("fk_btp_san_pham");
        });

        modelBuilder.Entity<ChiTietDieuChuyen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_chi_tiet_dieu_chuyen");

            entity.ToTable("chi_tiet_dieu_chuyen");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.DonHang)
                .HasMaxLength(30)
                .HasColumnName("don_hang");
            entity.Property(e => e.Dvt)
                .HasMaxLength(20)
                .HasColumnName("dvt");
            entity.Property(e => e.Dvt2)
                .HasMaxLength(20)
                .HasColumnName("dvt_2");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(500)
                .HasColumnName("ghi_chu");
            entity.Property(e => e.Gia)
                .HasPrecision(18, 2)
                .HasColumnName("gia");
            entity.Property(e => e.GiaDinhDanh)
                .HasPrecision(18, 2)
                .HasColumnName("gia_dinh_danh");
            entity.Property(e => e.MaGiaoDich)
                .HasMaxLength(30)
                .HasColumnName("ma_giao_dich");
            entity.Property(e => e.MaNxTkNo)
                .HasMaxLength(20)
                .HasColumnName("ma_nx_tk_no");
            entity.Property(e => e.MaVatTu)
                .HasMaxLength(50)
                .HasColumnName("ma_vat_tu");
            entity.Property(e => e.PhieuYeuCauNvl)
                .HasMaxLength(30)
                .HasColumnName("phieu_yeu_cau_nvl");
            entity.Property(e => e.SoLuong)
                .HasPrecision(18, 3)
                .HasColumnName("so_luong");
            entity.Property(e => e.SoLuong2)
                .HasPrecision(18, 3)
                .HasColumnName("so_luong_2");
            entity.Property(e => e.Tien)
                .HasPrecision(18, 2)
                .HasColumnName("tien");
            entity.Property(e => e.TkVatTuTkCo)
                .HasMaxLength(20)
                .HasColumnName("tk_vat_tu_tk_co");
            entity.Property(e => e.TonKho)
                .HasPrecision(18, 3)
                .HasColumnName("ton_kho");

            entity.HasOne(d => d.MaGiaoDichNavigation).WithMany(p => p.ChiTietDieuChuyens)
                .HasForeignKey(d => d.MaGiaoDich)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ctdc_phieu");

            entity.HasOne(d => d.MaVatTuNavigation).WithMany(p => p.ChiTietDieuChuyens)
                .HasForeignKey(d => d.MaVatTu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ctdc_vat_tu");
        });

        modelBuilder.Entity<ChiTietPhieuNhap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_chi_tiet_phieu_nhap");

            entity.ToTable("chi_tiet_phieu_nhap");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CaSanXuat)
                .HasMaxLength(20)
                .HasColumnName("ca_san_xuat");
            entity.Property(e => e.DonHangGc)
                .HasMaxLength(30)
                .HasColumnName("don_hang_gc");
            entity.Property(e => e.DonTrongThietKe)
                .HasPrecision(18, 5)
                .HasColumnName("don_trong_thiet_ke");
            entity.Property(e => e.Dvt)
                .HasMaxLength(20)
                .HasColumnName("dvt");
            entity.Property(e => e.GiaGc)
                .HasPrecision(18, 2)
                .HasColumnName("gia_gc");
            entity.Property(e => e.MaCdgtVt)
                .HasMaxLength(30)
                .HasColumnName("ma_cdgt_vt");
            entity.Property(e => e.MaHang)
                .HasMaxLength(50)
                .HasColumnName("ma_hang");
            entity.Property(e => e.MaLoi)
                .HasMaxLength(20)
                .HasColumnName("ma_loi");
            entity.Property(e => e.MaPhi)
                .HasMaxLength(20)
                .HasColumnName("ma_phi");
            entity.Property(e => e.MaySanXuat)
                .HasMaxLength(50)
                .HasColumnName("may_san_xuat");
            entity.Property(e => e.SoLenhSx)
                .HasMaxLength(30)
                .HasColumnName("so_lenh_sx");
            entity.Property(e => e.SoLuong)
                .HasPrecision(18, 3)
                .HasColumnName("so_luong");
            entity.Property(e => e.SoPhieuNhap)
                .HasMaxLength(30)
                .HasColumnName("so_phieu_nhap");
            entity.Property(e => e.TenLoi)
                .HasMaxLength(200)
                .HasColumnName("ten_loi");
            entity.Property(e => e.TienGc)
                .HasPrecision(18, 2)
                .HasColumnName("tien_gc");
            entity.Property(e => e.TkCo)
                .HasMaxLength(20)
                .HasColumnName("tk_co");
            entity.Property(e => e.TkNo)
                .HasMaxLength(20)
                .HasColumnName("tk_no");
            entity.Property(e => e.TyLeDonTrongThucTeThietKe)
                .HasPrecision(10, 4)
                .HasColumnName("ty_le_don_trong_thuc_te_thiet_ke");

            entity.HasOne(d => d.MaHangNavigation).WithMany(p => p.ChiTietPhieuNhaps)
                .HasForeignKey(d => d.MaHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ctpn_vat_tu");

            entity.HasOne(d => d.SoPhieuNhapNavigation).WithMany(p => p.ChiTietPhieuNhaps)
                .HasForeignKey(d => d.SoPhieuNhap)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ctpn_phieu_nhap");
        });

        modelBuilder.Entity<DanhMucVatTu>(entity =>
        {
            entity.HasKey(e => e.MaVatTu).HasName("pk_danh_muc_vat_tu");

            entity.ToTable("danh_muc_vat_tu");

            entity.Property(e => e.MaVatTu)
                .HasMaxLength(50)
                .HasColumnName("ma_vat_tu");
            entity.Property(e => e.ChieuDaiSanPham)
                .HasPrecision(10, 5)
                .HasColumnName("chieu_dai_san_pham");
            entity.Property(e => e.DonViTinh)
                .HasMaxLength(20)
                .HasColumnName("don_vi_tinh");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(500)
                .HasColumnName("ghi_chu");
            entity.Property(e => e.HeSoQuyDoiTuThanhDai)
                .HasPrecision(10, 3)
                .HasColumnName("he_so_quy_doi_tu_thanh_dai");
            entity.Property(e => e.LoaiVatTu)
                .HasMaxLength(30)
                .HasColumnName("loai_vat_tu");
            entity.Property(e => e.MaBanThanhPham)
                .HasMaxLength(50)
                .HasColumnName("ma_ban_thanh_pham");
            entity.Property(e => e.MaNguyenLieu)
                .HasMaxLength(50)
                .HasColumnName("ma_nguyen_lieu");
            entity.Property(e => e.MaSanPham)
                .HasMaxLength(30)
                .HasColumnName("ma_san_pham");
            entity.Property(e => e.NhomVatTu1)
                .HasMaxLength(20)
                .HasColumnName("nhom_vat_tu_1");
            entity.Property(e => e.NhomVatTu2)
                .HasMaxLength(20)
                .HasColumnName("nhom_vat_tu_2");
            entity.Property(e => e.TenVatTu)
                .HasMaxLength(300)
                .HasColumnName("ten_vat_tu");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Đang dùng'::character varying")
                .HasColumnName("trang_thai");

            entity.HasOne(d => d.MaBanThanhPhamNavigation).WithMany(p => p.DanhMucVatTus)
                .HasForeignKey(d => d.MaBanThanhPham)
                .HasConstraintName("fk_dmvt_ban_thanh_pham");

            entity.HasOne(d => d.MaNguyenLieuNavigation).WithMany(p => p.DanhMucVatTus)
                .HasForeignKey(d => d.MaNguyenLieu)
                .HasConstraintName("fk_dmvt_nguyen_lieu");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.DanhMucVatTus)
                .HasForeignKey(d => d.MaSanPham)
                .HasConstraintName("fk_dmvt_san_pham");
        });

        modelBuilder.Entity<DoiTac>(entity =>
        {
            entity.HasKey(e => e.MaDoiTac).HasName("pk_doi_tac");

            entity.ToTable("doi_tac");

            entity.Property(e => e.MaDoiTac)
                .HasMaxLength(20)
                .HasColumnName("ma_doi_tac");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(300)
                .HasColumnName("dia_chi");
            entity.Property(e => e.LoaiDoiTac)
                .HasMaxLength(30)
                .HasColumnName("loai_doi_tac");
            entity.Property(e => e.MaSoThue)
                .HasMaxLength(20)
                .HasColumnName("ma_so_thue");
            entity.Property(e => e.NguoiLienHe)
                .HasMaxLength(100)
                .HasColumnName("nguoi_lien_he");
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(20)
                .HasColumnName("so_dien_thoai");
            entity.Property(e => e.TenDoiTac)
                .HasMaxLength(200)
                .HasColumnName("ten_doi_tac");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("pk_khach_hang");

            entity.ToTable("khach_hang");

            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(20)
                .HasColumnName("ma_khach_hang");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(300)
                .HasColumnName("dia_chi");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(500)
                .HasColumnName("ghi_chu");
            entity.Property(e => e.MaSoThue)
                .HasMaxLength(20)
                .HasColumnName("ma_so_thue");
            entity.Property(e => e.NguoiLienHe)
                .HasMaxLength(100)
                .HasColumnName("nguoi_lien_he");
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(20)
                .HasColumnName("so_dien_thoai");
            entity.Property(e => e.TenKhachHang)
                .HasMaxLength(200)
                .HasColumnName("ten_khach_hang");
        });

        modelBuilder.Entity<Kho>(entity =>
        {
            entity.HasKey(e => e.MaKho).HasName("pk_kho");

            entity.ToTable("kho");

            entity.Property(e => e.MaKho)
                .HasMaxLength(20)
                .HasColumnName("ma_kho");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(300)
                .HasColumnName("dia_chi");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(500)
                .HasColumnName("ghi_chu");
            entity.Property(e => e.LoaiKho)
                .HasMaxLength(30)
                .HasColumnName("loai_kho");
            entity.Property(e => e.MaDoiTacPhuTrach)
                .HasMaxLength(20)
                .HasColumnName("ma_doi_tac_phu_trach");
            entity.Property(e => e.TenKho)
                .HasMaxLength(200)
                .HasColumnName("ten_kho");

            entity.HasOne(d => d.MaDoiTacPhuTrachNavigation).WithMany(p => p.Khos)
                .HasForeignKey(d => d.MaDoiTacPhuTrach)
                .HasConstraintName("fk_kho_doi_tac");
        });

        modelBuilder.Entity<NguyenLieu>(entity =>
        {
            entity.HasKey(e => e.MaNguyenLieu).HasName("pk_nguyen_lieu");

            entity.ToTable("nguyen_lieu");

            entity.Property(e => e.MaNguyenLieu)
                .HasMaxLength(50)
                .HasColumnName("ma_nguyen_lieu");
            entity.Property(e => e.ChieuDaiThanh)
                .HasPrecision(8, 3)
                .HasColumnName("chieu_dai_thanh");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(500)
                .HasColumnName("ghi_chu");
            entity.Property(e => e.LoaiNguyenLieu)
                .HasMaxLength(30)
                .HasColumnName("loai_nguyen_lieu");
            entity.Property(e => e.MaNhaCungCap)
                .HasMaxLength(20)
                .HasColumnName("ma_nha_cung_cap");
            entity.Property(e => e.MaSanPham)
                .HasMaxLength(30)
                .HasColumnName("ma_san_pham");
            entity.Property(e => e.TenNguyenLieu)
                .HasMaxLength(300)
                .HasColumnName("ten_nguyen_lieu");

            entity.HasOne(d => d.MaNhaCungCapNavigation).WithMany(p => p.NguyenLieus)
                .HasForeignKey(d => d.MaNhaCungCap)
                .HasConstraintName("fk_nguyen_lieu_doi_tac");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.NguyenLieus)
                .HasForeignKey(d => d.MaSanPham)
                .HasConstraintName("fk_nguyen_lieu_san_pham");
        });

        modelBuilder.Entity<PhieuDieuChuyen>(entity =>
        {
            entity.HasKey(e => e.MaGiaoDich).HasName("pk_phieu_dieu_chuyen");

            entity.ToTable("phieu_dieu_chuyen");

            entity.Property(e => e.MaGiaoDich)
                .HasMaxLength(30)
                .HasColumnName("ma_giao_dich");
            entity.Property(e => e.DienGiai)
                .HasMaxLength(500)
                .HasColumnName("dien_giai");
            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(20)
                .HasColumnName("ma_khach_hang");
            entity.Property(e => e.MaKhoNhap)
                .HasMaxLength(20)
                .HasColumnName("ma_kho_nhap");
            entity.Property(e => e.MaKhoXuat)
                .HasMaxLength(20)
                .HasColumnName("ma_kho_xuat");
            entity.Property(e => e.NgayChungTu).HasColumnName("ngay_chung_tu");
            entity.Property(e => e.NguoiThucHien)
                .HasMaxLength(100)
                .HasColumnName("nguoi_thuc_hien");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.PhieuDieuChuyens)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("fk_pdc_khach_hang");

            entity.HasOne(d => d.MaKhoNhapNavigation).WithMany(p => p.PhieuDieuChuyenMaKhoNhapNavigations)
                .HasForeignKey(d => d.MaKhoNhap)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pdc_kho_nhap");

            entity.HasOne(d => d.MaKhoXuatNavigation).WithMany(p => p.PhieuDieuChuyenMaKhoXuatNavigations)
                .HasForeignKey(d => d.MaKhoXuat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pdc_kho_xuat");
        });

        modelBuilder.Entity<PhieuNhap>(entity =>
        {
            entity.HasKey(e => e.SoPhieuNhap).HasName("pk_phieu_nhap");

            entity.ToTable("phieu_nhap");

            entity.Property(e => e.SoPhieuNhap)
                .HasMaxLength(30)
                .HasColumnName("so_phieu_nhap");
            entity.Property(e => e.MaBoPhan)
                .HasMaxLength(20)
                .HasColumnName("ma_bo_phan");
            entity.Property(e => e.MaCdgtPhieu)
                .HasMaxLength(30)
                .HasColumnName("ma_cdgt_phieu");
            entity.Property(e => e.MaChungTu)
                .HasMaxLength(20)
                .HasColumnName("ma_chung_tu");
            entity.Property(e => e.MaGiaoDich)
                .HasMaxLength(30)
                .HasColumnName("ma_giao_dich");
            entity.Property(e => e.MaHopDong)
                .HasMaxLength(30)
                .HasColumnName("ma_hop_dong");
            entity.Property(e => e.MaKhoHang)
                .HasMaxLength(20)
                .HasColumnName("ma_kho_hang");
            entity.Property(e => e.MaKhoXuat)
                .HasMaxLength(20)
                .HasColumnName("ma_kho_xuat");
            entity.Property(e => e.MaNcc)
                .HasMaxLength(20)
                .HasColumnName("ma_ncc");
            entity.Property(e => e.NgayNhap).HasColumnName("ngay_nhap");
            entity.Property(e => e.NguoiLapPhieu)
                .HasMaxLength(100)
                .HasColumnName("nguoi_lap_phieu");
            entity.Property(e => e.PhieuYeuCau)
                .HasMaxLength(30)
                .HasColumnName("phieu_yeu_cau");
            entity.Property(e => e.SoDonHang)
                .HasMaxLength(30)
                .HasColumnName("so_don_hang");
            entity.Property(e => e.SoHoaDon)
                .HasMaxLength(30)
                .HasColumnName("so_hoa_don");
            entity.Property(e => e.TenBoPhan)
                .HasMaxLength(100)
                .HasColumnName("ten_bo_phan");
            entity.Property(e => e.TenPhanXuong)
                .HasMaxLength(100)
                .HasColumnName("ten_phan_xuong");
            entity.Property(e => e.TrangThaiPhieu)
                .HasMaxLength(30)
                .HasColumnName("trang_thai_phieu");
            entity.Property(e => e.UserTaoPo)
                .HasMaxLength(100)
                .HasColumnName("user_tao_po");

            entity.HasOne(d => d.MaGiaoDichNavigation).WithMany(p => p.PhieuNhaps)
                .HasForeignKey(d => d.MaGiaoDich)
                .HasConstraintName("fk_pn_giao_dich");

            entity.HasOne(d => d.MaKhoHangNavigation).WithMany(p => p.PhieuNhapMaKhoHangNavigations)
                .HasForeignKey(d => d.MaKhoHang)
                .HasConstraintName("fk_pn_kho_hang");

            entity.HasOne(d => d.MaKhoXuatNavigation).WithMany(p => p.PhieuNhapMaKhoXuatNavigations)
                .HasForeignKey(d => d.MaKhoXuat)
                .HasConstraintName("fk_pn_kho_xuat");

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.PhieuNhaps)
                .HasForeignKey(d => d.MaNcc)
                .HasConstraintName("fk_pn_doi_tac");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSanPham).HasName("pk_san_pham");

            entity.ToTable("san_pham");

            entity.Property(e => e.MaSanPham)
                .HasMaxLength(30)
                .HasColumnName("ma_san_pham");
            entity.Property(e => e.ChieuDaiSanPham)
                .HasPrecision(10, 5)
                .HasColumnName("chieu_dai_san_pham");
            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(20)
                .HasColumnName("ma_khach_hang");
            entity.Property(e => e.MoTa)
                .HasMaxLength(500)
                .HasColumnName("mo_ta");
            entity.Property(e => e.TenSanPham)
                .HasMaxLength(200)
                .HasColumnName("ten_san_pham");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Đang dùng'::character varying")
                .HasColumnName("trang_thai");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("fk_san_pham_khach_hang");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
