using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver.Commands
{
    public class QuestionDTO
    {
        [Key]
        public int Id { get; }
        public string Question { get; set; }
        [Column("Option 1")]
        public string Option1 { get; set; }
        [Column("Answer 1")]
        public bool Answer1 { get; set; }
        [Column("Option 2")]
        public string Option2 { get; set; }
        [Column("Answer 2")]
        public bool Answer2 { get; set; }
        [Column("Option 3")]
        public string Option3 { get; set; }
        [Column("Answer 3")]
        public bool Answer3 { get; set; }
        [Column("Option 4")]
        public string Option4 { get; set; }
        [Column("Answer 4")]
        public bool Answer4 { get; set; }
    }
}
