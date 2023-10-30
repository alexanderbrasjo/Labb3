using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace Labb3.Models
{
    public class Quiz
    {
        private List<Question>? Questions { get; set; }
        //private IEnumerable<Question>? _questions;
        private string? _title = string.Empty;
        //public IEnumerable<Question> Questions => _questions;
        private string? _category = string.Empty;
        public string? Title => _title;
        public string? Category => _category;

        
        public Quiz(string title, string category)
        {
            _title = title;
            _category = category;
            Questions = new List<Question>();
        }
        public Quiz()
        {
            Questions = new List<Question>();
        }
        public Question GetRandomQuestion()
        {
            if(Questions.Count > 0)
            {
                Random random = new Random();
                int randomIndex = random.Next(0, Questions.Count);
                return Questions[randomIndex]; 
            }
            else
            {
                return new Question("","Congratulations, you answered all questions correct! Press STOP QUIZ to return to Main Menu", new string[3] { "Very", "Good", "Job" }, 0);
            }
            //throw new NotImplementedException("A random Question needs to be returned here!");
        }

        public void AddQuestion(Question question)
        {
            Question tempQuestion = new Question(question.Category, question.Statement, question.Answers, question.CorrectAnswer);
            Questions.Add(tempQuestion);
            //throw new NotImplementedException("Question need to be instantiated and added to list of questions here!");
        }

        public void RemoveQuestion(int index)
        {
            //KOLLA PÅ DETTA!!!
            if(Questions.Count > 0)
            {
                Questions.RemoveAt(index);
            }
            else
            {

            }
            //throw new NotImplementedException("Question at requested index need to be removed here!");
        }

        public async void GenerateQuestions()
        {
            AddQuestion(new Question("Sport", " In which sport do players use a shuttlecock?", new string[3] { "Tennis", "Badminton", "Squash" }, 1));
            AddQuestion(new Question("Sport", " Who holds the record for the most home runs in a single MLB season?", new string[3] { "Babe Ruth", "Barry Bonds", "Sammy Sosa" }, 1));
            AddQuestion(new Question("Sport", " What is the maximum number of players a standard soccer team can have on the field during a match?", new string[3] { "9", "10", "11" }, 2));
            AddQuestion(new Question("Sport", " Which sport is known as the \"king of sports\" and is often called football in most countries?", new string[3] { "Soccer", "American Football", "Rugby" }, 0));
            AddQuestion(new Question("Sport", " Who is considered the greatest basketball player of all time?", new string[3] { "LeBron James", "Kobe Bryant", "Michael Jordan" }, 2));
            AddQuestion(new Question("Sport", " In golf, what is it called when a player completes a hole in one stroke under par?", new string[3] { "Birdie", "Eagle", "Bogey" }, 0));
            AddQuestion(new Question("Sport", " What is the diameter of a standard basketball hoop in inches?", new string[3] { "16 inches", "18 inches", "20 inches" }, 1));
            AddQuestion(new Question("Sport", " What is the official ball used in a game of table tennis?", new string[3] { "Tennis ball", "Ping pong ball", "Golf ball" }, 1));
            AddQuestion(new Question("Sport", " Which sport is often called the \"gentleman's game\"?", new string[3] { "Cricket", "Wrestling", "Formula 1 racing" }, 0));
            AddQuestion(new Question("Sport", " Which country is known for inventing the sport of cricket?", new string[3] { "England", "Australia", "India" }, 1));

            AddQuestion(new Question("Math", "What is the result of 2 + 2?", new string[3] { "3", "4", "5" }, 1));
            AddQuestion(new Question("Math", "Solve for x: 3x - 8 = 16", new string[3] { "4", "6", "8" }, 2));
            AddQuestion(new Question("Math", "What is the square root of 25?", new string[3] { "3", "4", "5" }, 2));
            AddQuestion(new Question("Math", "What is the area of a rectangle with length 6 and width 8?", new string[3] { "12", "24", "48" }, 1));
            AddQuestion(new Question("Math", "Simplify: 2/3 + 1/4", new string[3] { "5/12", "3/7", "1/2" }, 0));
            AddQuestion(new Question("Math", "What is 3 squared (3^2)?", new string[3] { "6", "9", "12" }, 1));
            AddQuestion(new Question("Math", "If a = 4 and b = 7, what is the value of a + b?", new string[3] { "9", "11", "12" }, 2));
            AddQuestion(new Question("Math", "What is the product of 5 and 8?", new string[3] { "13", "35", "40" }, 2));
            AddQuestion(new Question("Math", "If x = 10 and y = 3, what is the value of 2x - 5y?", new string[3] { "16", "17", "18" }, 0));
            AddQuestion(new Question("Math", "What is the result of 7 divided by 0?", new string[3] { "Undefined", "0", "7" }, 0));

            AddQuestion(new Question("Geography", "Which country is known as the Land of the Rising Sun?", new string[3] { "China", "Japan", "South Korea" }, 1));
            AddQuestion(new Question("Geography", "What is the capital of France?", new string[3] { "Berlin", "Madrid", "Paris" }, 2));
            AddQuestion(new Question("Geography", "Which river is the longest in the world?", new string[3] { "Nile", "Amazon", "Mississippi" }, 0));
            AddQuestion(new Question("Geography", "In which continent is the Sahara Desert located?", new string[3] { "Asia", "Africa", "South America" }, 1));
            AddQuestion(new Question("Geography", "What is the largest country by land area?", new string[3] { "Russia", "Canada", "United States" }, 0));
            AddQuestion(new Question("Geography", "Which mountain range spans the border between the United States and Canada?", new string[3] { "Rocky Mountains", "Andes", "Himalayas" }, 0));
            AddQuestion(new Question("Geography", "What is the capital of Australia?", new string[3] { "Sydney", "Melbourne", "Canberra" }, 2));
            AddQuestion(new Question("Geography", "Which European city is known as the City of Canals?", new string[3] { "Venice", "Amsterdam", "Prague" }, 0));
            AddQuestion(new Question("Geography", "In which ocean would you find the Galapagos Islands?", new string[3] { "Atlantic Ocean", "Indian Ocean", "Pacific Ocean" }, 2));
            AddQuestion(new Question("Geography", "What is the highest mountain in the world?", new string[3] { "K2", "Mount Everest", "Kilimanjaro" }, 1));

            AddQuestion(new Question("Entertainment", "Who played the character of Jack Dawson in the movie 'Titanic'?", new string[3] { "Leonardo DiCaprio", "Brad Pitt", "Tom Cruise" }, 0));
            AddQuestion(new Question("Entertainment", "Which animated film features a young lion named Simba?", new string[3] { "Toy Story", "Aladdin", "The Lion King" }, 2));
            AddQuestion(new Question("Entertainment", "Which actress portrayed Hermione Granger in the 'Harry Potter' film series?", new string[3] { "Emma Watson", "Kristen Stewart", "Dakota Fanning" }, 0));
            AddQuestion(new Question("Entertainment", "In 'Star Wars,' what is the real name of the character known as Darth Vader?", new string[3] { "Anakin Skywalker", "Obi-Wan Kenobi", "Luke Skywalker" }, 0));
            AddQuestion(new Question("Entertainment", "Who is the lead vocalist of the band Queen?", new string[3] { "Paul McCartney", "Elton John", "Freddie Mercury" }, 2));
            AddQuestion(new Question("Entertainment", "Which film won the Academy Award for Best Picture in 2020?", new string[3] { "Parasite", "1917", "Joker" }, 0));
            AddQuestion(new Question("Entertainment", "Which famous director directed 'Pulp Fiction' and 'Kill Bill'?", new string[3] { "Christopher Nolan", "Steven Spielberg", "Quentin Tarantino" }, 2));
            AddQuestion(new Question("Entertainment", "What is the name of the fictional wizarding school in the 'Harry Potter' series?", new string[3] { "Hogwarts", "Durmstrang", "Beauxbatons" }, 0));
            AddQuestion(new Question("Entertainment", "In the 'Lord of the Rings' film trilogy, what is the name of the one ring?", new string[3] { "Excalibur", "Sauron's Ring", "The One Ring" }, 2));
            AddQuestion(new Question("Entertainment", "Which actor portrayed James Bond in the film 'Casino Royale'?", new string[3] { "Daniel Craig", "Pierce Brosnan", "Sean Connery" }, 0));

            AddQuestion(new Question("History", "Who was the first President of the United States?", new string[3] { "John Adams", "George Washington", "Thomas Jefferson" }, 1));
            AddQuestion(new Question("History", "In what year did Christopher Columbus reach the Americas?", new string[3] { "1492", "1512", "1522" }, 0));
            AddQuestion(new Question("History", "Which ancient civilization built the pyramids of Giza?", new string[3] { "Greeks", "Romans", "Egyptians" }, 2));
            AddQuestion(new Question("History", "What event marked the start of World War I in 1914?", new string[3] { "Assassination of Archduke Franz Ferdinand", "Sinking of the Lusitania", "Bombing of Pearl Harbor" }, 0));
            AddQuestion(new Question("History", "Who was the leader of the Soviet Union during the Cuban Missile Crisis?", new string[3] { "Vladimir Putin", "Joseph Stalin", "Nikita Khrushchev" }, 2));
            AddQuestion(new Question("History", "In which year did the Berlin Wall fall, leading to the reunification of Germany?", new string[3] { "1985", "1990", "2000" }, 1));
            AddQuestion(new Question("History", "Which queen is known for her reign in the United Kingdom during the Victorian era?", new string[3] { "Queen Mary", "Queen Anne", "Queen Victoria" }, 2));
            AddQuestion(new Question("History", "What was the main document that influenced the formation of the United States?", new string[3] { "Declaration of Independence", "Bill of Rights", "Emancipation Proclamation" }, 0));
            AddQuestion(new Question("History", "Who was the famous civil rights leader known for his 'I Have a Dream' speech?", new string[3] { "Malcolm X", "Nelson Mandela", "Martin Luther King Jr." }, 2));
            AddQuestion(new Question("History", "Which explorer is credited with circumnavigating the globe?", new string[3] { "Amerigo Vespucci", "Ferdinand Magellan", "Vasco da Gama" }, 1));




            
            string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string directoryName = "QuizGame";

            string fileName = "questions.json";

            string directoryFilePath = Path.Combine(directoryPath, directoryName);
            string filePath = Path.Combine(directoryFilePath, fileName);

            string json = JsonConvert.SerializeObject(Game.listOfAllQuestions, Newtonsoft.Json.Formatting.Indented);
            
            try
            {
                Directory.CreateDirectory(directoryFilePath);
                await File.WriteAllTextAsync(filePath, json);
            }
            catch (IOException e)
            {
                MessageBox.Show("An error occurred: " + e.Message);
            }

            
        }

        public static Quiz CreateRandomQuiz()
        {
            Quiz tempQuiz = new Quiz("Random1", "None");
            Random rand = new Random();
            List<int> usedIndices = new List<int>(); // To keep track of used question indices

            for (int i = 0; i < 10; i++)
            {
                int randomIndex;

                do
                {
                    randomIndex = rand.Next(0, Game.listOfAllQuestions.Count);
                } while (usedIndices.Contains(randomIndex)); // Continue until an unused index is found

                tempQuiz.Questions.Add(Game.listOfAllQuestions[randomIndex]);
                usedIndices.Add(randomIndex); // Mark the index as used
            }
            Game.listOfQuizes.Add(tempQuiz);
            return tempQuiz;
        }

        //public static void CreateRandomQuiz()
        //{
        //    Quiz tempQuiz = new Quiz("Random1", "None");
        //    Random rand = new Random();

        //    for(int i = 0; i < 10; i++)
        //    {
        //        int randomIndex = rand.Next(0, Game.listOfAllQuestions.Count);
        //        tempQuiz.Questions.Add(Game.listOfAllQuestions[randomIndex]);
        //    }
        //    Game.listOfQuizes.Add(tempQuiz);
        //}
    }
}
