using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace Labb3.Models
{
    public class Game
    {
        public static List<Question> listOfAllQuestions { get; set; } = new List<Question>();
        public static List<Quiz> listOfQuizes { get; set; } = new List<Quiz>();
        public static List<string> selectedCategories { get; set; } = new List<string>();
        





        public static void AddQuiz(Quiz quiz)
        {
            listOfQuizes.Add(quiz);
        }
        public static bool CheckIfQuizExists(string title)
        {
            foreach(var quiz in listOfQuizes)
            {
                if(quiz.Title == title)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CheckIfQuestionExist(string statement)
        {
            foreach(var question in listOfAllQuestions)
            {
                if(question.Statement == statement)
                {
                    return true;
                }
            }
            return false;
        }
        public static async void LoadAllQuestions()
        {
            string directoryName = @".\\QuizGame";
            string fileName = "questions.json";
            string directoryFilePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + directoryName;
            

            string filepath = Path.Combine(directoryFilePath, fileName);

            List<Question> questions = new List<Question>();

            try
            {
                if (File.Exists(filepath))
                {
                    string json =  await File.ReadAllTextAsync(filepath);
                    questions = JsonConvert.DeserializeObject<List<Question>>(json);
                    Game.listOfAllQuestions = questions;
                }
                else
                {
                    MessageBox.Show("File does not exist");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occured" + ex.Message);
            }
        }
        public async void LoadAllQuizes()
        {

        }

    }
}
