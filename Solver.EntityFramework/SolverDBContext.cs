using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Solver.Commands;

namespace Solver.EntityFramework
{
    public class SolverDBContext : DbContext
    {
        public SolverDBContext(DbContextOptions options) : base(options) { }

        public DbSet<QuizDTO> Quiz { get; set; }
        public DbSet<QuestionDTO> Pytanie { get; set; }
    }
}