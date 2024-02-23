using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver.EntityFramework
{
    public class SolverDBContextFactory
    {
        public DbContextOptions _options;
        public SolverDBContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public SolverDBContext Create()
        {
            return new SolverDBContext(_options);
        }
    }
}
