using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Theory.Model
{
    public class StudentAnswers
    {
        [Key]
        public int id { get; set; }
        public string Matric { get; set; }
        public string Answers { get; set; }
        public int MyQuestionsId { get; set; }
        public int UserId { get; set; }
    }
}
