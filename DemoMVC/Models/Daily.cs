using System.ComponentModel.DataAnnotations;
namespace DemoMVC.Models;

public class Daily
{ 
    [Key]
    public string MaDaiLy { get; set; }
    public string TenDaiLy { get; set; }
    public string DiaChi { get; set; }
    public string NguoiDaiDien { get; set; }
    public string MaHTPP { get; set; }
    public string Dienthoai { get; set; }

      public Hethongphanphoi Hethongphanphoi { get; set; }
}