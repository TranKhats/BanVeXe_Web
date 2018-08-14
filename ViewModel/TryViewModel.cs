using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BanVeXe_Web.ViewModel
{
    public class TryViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Class { get; set; }
    }

    public class AppDTO
    {
        [Key]
        public string Name { get; set; }
        public int Role { get; set; }
    }
    public class RoleEum
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
