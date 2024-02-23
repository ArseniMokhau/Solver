using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver.Model
{
    public class Question
    {
        public int Id { get; }
        public string QuestionText { get; }
        public List<string> Options { get; }
        public List<bool> Answers { get; }

        public Question(int id, string questionText, List<string> options, List<bool> answers)
        {
            Id = id;
            QuestionText = questionText;
            Options = options;
            Answers = answers;
        }
    }
}
