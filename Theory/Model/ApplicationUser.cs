using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Theory.Model
{
    public class ApplicationUser: IdentityUser
    {
        [Column(TypeName="nvarchar(20)")]
        public string matric { get; set; }
    }
}
