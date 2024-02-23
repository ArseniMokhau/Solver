using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver.Services
{
    public class QuizEvaluator
    {
        public static int Evaluate(List<bool> radioButtonValues, List<bool> answers)
        {
            if (radioButtonValues == null || answers == null)
            {
                throw new ArgumentNullException("The radioButtonValues and answers lists must not be null.");
            }

            if (radioButtonValues.Count != answers.Count)
            {
                throw new ArgumentException("The radioButtonValues and answers lists must have the same number of elements.");
            }

            for (int i = 0; i < radioButtonValues.Count; i++)
            {
                if (radioButtonValues[i] != answers[i])
                {
                    return 0; // At least one answer is incorrect
                }
            }

            return 1; // All answers are correct
        }
    }
}