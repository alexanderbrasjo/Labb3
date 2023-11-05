using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Labb3.Models
{
    public class Question
    {
        public string Category { get; }
        public string Statement { get; }
        public string[] Answers { get; }
        public int CorrectAnswer { get; }

        [JsonProperty("Image", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string Image { get; } = "\\Images\\quiz.png";

        public Question(string category, string statement, string[] answers, int correctAnswer)
        {
            Category = category;
            Statement = statement;
            CorrectAnswer = correctAnswer;
            Answers = answers;
        }
        [Newtonsoft.Json.JsonConstructor]
        public Question(string category, string statement, string[] answers, int correctAnswer, string image)
        {
            Category = category;
            Statement = statement;
            CorrectAnswer = correctAnswer;
            Answers = answers;
            Image = string.IsNullOrEmpty(image)? "\\Images\\quiz.png": image;
        }
    }
}
