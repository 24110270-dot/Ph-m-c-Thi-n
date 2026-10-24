using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuanLyThuVien
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entity Framework Core Code First - Quan Ly Thu Vien");
        }
    }

    // Thực thể 1: Thể loại (Bảng 1)
    [Table("TheLoai")]
    public class TheLoai
    {
        [Key]
        [StringLength(20)]
        public string MaTheLoai { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string TenTheLoai { get; set; } = string.Empty;

        [StringLength(255)]
        public string? MoTa { get; set; }

        public virtual ICollection<Sach> Sachs { get; set; } = new List<Sach>();
    }

    // Thực thể 2: Sách (Bảng N)
    [Table("Sach")]
    public class Sach
    {
        [Key]
        [StringLength(20)]
        public string MaSach { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string TenSach { get; set; } = string.Empty;

        [StringLength(100)]
        public string? TacGia { get; set; }

        public int NamXuatBan { get; set; }

        public double GiaBan { get; set; }

        public int SoLuong { get; set; }

        [Required]
        [StringLength(20)]
        public string MaTheLoai { get; set; } = string.Empty;

        [ForeignKey("MaTheLoai")]
        public virtual TheLoai? TheLoai { get; set; }
    }

    // DbContext đúng tên QLTVDBContext theo đề bài
    public class QLTVDBContext : DbContext
    {
        public DbSet<TheLoai> TheLoais { get; set; }
        public DbSet<Sach> Sachs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Chuỗi kết nối SQL Server
                optionsBuilder.UseSqlServer(@"Server=LAPTOP-6SN65NCS\HUECTMDB;Database=QLTVDB;Integrated Security=True;TrustServerCertificate=True;");
            }
        }
    }
}