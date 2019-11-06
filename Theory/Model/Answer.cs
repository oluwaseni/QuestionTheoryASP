using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Theory.Model
{
    public class Answer
    {

        [Key]
        public int Id { get; set; }
        public int Ans { get; set; }
        public int MyQuestionsId { get; set; }
        public int StudentAnswersId { get; set; }
        public string StudentId { get; set; }
    }
}
