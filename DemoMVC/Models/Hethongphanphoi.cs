using System.ComponentModel.DataAnnotations;
namespace DemoMVC.Models;

public class Hethongphanphoi
{
    [Key]
    public string MaHTPP { get; set; }
    public string TenHTPP { get; set; }
     public ICollection<Daily> Dailys { get; set; } 
}