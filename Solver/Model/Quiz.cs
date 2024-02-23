using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver.Model
{
    public class Quiz
    {
        public int Id { get; }
        public string Name { get; }
        public string IdPyt { get; }

        public Quiz(int id, string name, string idPyt)
        {
            Id = id;
            Name = name;
            IdPyt = idPyt;
        }
    }
}
