using Labb3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace Labb3
{
    /// <summary>
    /// Interaction logic for PlayWindow.xaml
    /// </summary>
    public partial class PlayWindow : Window
    {
        public static Quiz activeQuiz = new Quiz();
        public static Question currentQuestion;
        public int correctAnswers { get; set; } = 0;
        public int questionIndex { get; set; } = 0;
        public string quizStatus { get; set; } = string.Empty;
        //KOLLA PÅ CORRECTANSWERS OCH PROCENTEN

        
        
        public PlayWindow()
        {
            InitializeComponent();
            currentQuestion = activeQuiz.GetRandomQuestion();
            this.DataContext = currentQuestion;
            quizStatus = QuizStatus();

        }

        private void btnStopPlaying_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAnswer1_Click(object sender, RoutedEventArgs e)
        {
            if(currentQuestion.CorrectAnswer == 0)
            {
                MessageBox.Show("Correct!");
                correctAnswers++;
                ProgressBar.Value += 10;
            }
            else
            {
                MessageBox.Show("Sorry, that was not the right answer!");
            }
            activeQuiz.RemoveQuestion(0);
            currentQuestion = activeQuiz.GetRandomQuestion();
            questionIndex++;
            this.DataContext = currentQuestion;
            quizStatus = QuizStatus();
        }

        private void btnAnswer2_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestion.CorrectAnswer == 1)
            {
                MessageBox.Show("Correct!");
                correctAnswers++;
                ProgressBar.Value += 10;
            }
            else
            {
                MessageBox.Show("Sorry, that was not the right answer!");
            }
            activeQuiz.RemoveQuestion(0);
            currentQuestion = activeQuiz.GetRandomQuestion();
            questionIndex++;
            this.DataContext = currentQuestion;
            quizStatus = QuizStatus();
        }

        private void btnAnswer3_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestion.CorrectAnswer == 2)
            {
                MessageBox.Show("Correct!");
                correctAnswers++;
                ProgressBar.Value += 10;
            }
            else
            {
                MessageBox.Show("Sorry, that was not the right answer!");
            }
            activeQuiz.RemoveQuestion(0);
            currentQuestion = activeQuiz.GetRandomQuestion();
            questionIndex++;
            this.DataContext = currentQuestion;
            quizStatus = QuizStatus();
        }
        private string QuizStatus()
        {
            return $"Correct answers: {correctAnswers} / {questionIndex}";
        }
    }
}
