using System.ComponentModel.DataAnnotations;

namespace BlogProject.Areas.Admin.Models
{
    public class GetRoleViewModel
    {
        [Required(ErrorMessage = "Lütfen rol başlığını giriniz")]
        public string Name { get; set; }
    }
}
