﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver.Commands
{
    public class QuizDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IdPyt { get; set; }
    }
}
