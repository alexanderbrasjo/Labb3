using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3.Models
{
    public class Question
    {
        public string Category { get; }
        public string Statement { get; }
        public string[] Answers { get; }
        public int CorrectAnswer { get; }
        public Question(string category, string statement, string[] answers, int correctAnswer)
        {
            Category = category;
            Statement = statement;
            CorrectAnswer = correctAnswer;
            Answers = answers;
        }
    }
}
