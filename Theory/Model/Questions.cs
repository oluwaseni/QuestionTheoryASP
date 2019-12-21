using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Theory.Model
{
    public class Questions
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string Question { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string ExpectedAnswers { get; set; }
    }
}
