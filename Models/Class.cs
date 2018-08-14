using System;
using System.Collections.Generic;

namespace BanVeXe_Web.Models
{
    public partial class Class
    {
        public Class()
        {
            DeatailClass = new HashSet<DeatailClass>();
        }

        public string IdType { get; set; }
        public string TypeName { get; set; }

        public ICollection<DeatailClass> DeatailClass { get; set; }
    }
}
