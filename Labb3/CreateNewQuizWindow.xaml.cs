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
using System.Windows.Shapes;

namespace Labb3
{
    /// <summary>
    /// Interaction logic for CreateNewQuizWindow.xaml
    /// </summary>
    public partial class CreateNewQuizWindow : Window
    {
        //KOLLA PÅ DETTA!
        Quiz tempQuiz = new Quiz();
        public CreateNewQuizWindow()
        {
            InitializeComponent();
            
        }

        private void btnSaveQuestion_Click(object sender, RoutedEventArgs e)
        {
            
            int correctAnswer = -1;

            if (string.IsNullOrEmpty(QuizName.Text))
            {
                MessageBox.Show("Please input a Quizname!");
                return;
            }
            else if(Game.CheckIfQuizExists(QuizName.Text))
            {
                MessageBox.Show("That Quiz name is already used!, please choose another title");
                return;
            }

            tempQuiz = new Quiz(QuizName.Text, CategoryName.Text);
            

            if(string.IsNullOrEmpty(CategoryName.Text) || string.IsNullOrEmpty(QuestionStatement.Text) || string.IsNullOrEmpty(Answer1.Text) || string.IsNullOrEmpty(Answer2.Text) || string.IsNullOrEmpty(Answer3.Text))
            {
                MessageBox.Show("Please input category, statement, answers and check in the correct answer!");
            }
            else
            {
                if(Checkbox1.IsChecked == true && Checkbox2.IsChecked == false && Checkbox3.IsChecked == false)
                {
                    correctAnswer = 0;
                }
                else if (Checkbox2.IsChecked == true && Checkbox1.IsChecked == false && Checkbox3.IsChecked == false)
                {
                    correctAnswer = 1;
                } 
                else if (Checkbox3.IsChecked == true && Checkbox1.IsChecked == false && Checkbox2.IsChecked == false)
                {
                    correctAnswer = 2;
                }
                else if(Checkbox1.IsChecked == false && Checkbox2.IsChecked == false && Checkbox3.IsChecked == false)
                {
                    MessageBox.Show("Check in the correct answer (You can only check in one box!)");
                    return;
                }

                Question tempQuestion = new Question(CategoryName.Text, QuestionStatement.Text, new string[3] { Answer1.Text, Answer2.Text, Answer3.Text }, correctAnswer);

                tempQuiz.AddQuestion(tempQuestion);
                MessageBox.Show("Question was created!");

                TextBlockQuizName.Text = "QUIZ NAME:";
                CategoryName.Text = string.Empty;
                QuestionStatement.Text = string.Empty;
                Answer1.Text = string.Empty;
                Answer2.Text = string.Empty;
                Answer3.Text = string.Empty;
                Checkbox1.IsChecked = false;
                Checkbox2.IsChecked = false;
                Checkbox3.IsChecked = false;



            }
            //while (isRunning)
            //{
            //    if(QuizName.Text == "")
            //    {
            //        MessageBox.Show("Please input a Quizname!");
            //        break;
            //    }else if (Game.CheckIfQuizExists(QuizName.Text))
            //    {
            //        MessageBox.Show("That Quiz name is already used!");
            //        QuizName.Text = "";
            //    }
            //    else if(CategoryName.Text == "")
            //    {
            //        MessageBox.Show("Please input a Category!");
            //        break;
            //    }else if(QuestionStatement.Text == "")
            //    {
            //        MessageBox.Show("Please input your Question!");
            //        break;
            //    }else if(Answer1.Text == "")
            //    {
            //        MessageBox.Show("Please input Answer1");
            //        break;
            //    }
            //    else if (Answer2.Text == "")
            //    {
            //        MessageBox.Show("Please input Answer2");
            //        break;
            //    }
            //    else if (Answer3.Text == "")
            //    {
            //        MessageBox.Show("Please input Answer3");
            //        break;
            //    }else if (Checkbox1.IsChecked != true && Checkbox2.IsChecked != true && Checkbox3.IsChecked != true)
            //    {
            //        MessageBox.Show("Please check in the right answer!");
            //        break;
            //    }
            //    else
            //    {
            //        Quiz tempQuiz = new Quiz(QuizName.Text, CategoryName.Text);
            //        string[] tempAnswers = new string[3] { Answer1.Text, Answer2.Text, Answer3.Text };
            //        if (Checkbox2.IsChecked == true && Checkbox1.IsChecked == false && Checkbox3.IsChecked == false)
            //        {
            //            correctAnswer = 1;
            //        } 
            //        else if (Checkbox3.IsChecked == true && Checkbox1.IsChecked == false && Checkbox2.IsChecked == false)
            //        {
            //            correctAnswer = 2;
            //        }

            //        tempQuiz.AddQuestion(QuestionStatement.Text, correctAnswer, tempAnswers);
            //        activeQuiz = tempQuiz;
            //        MessageBox.Show("Question created!");

            //        foreach (UIElement element in CreateNewQuizGrid.Children)
            //        {
            //            if (element is TextBox)
            //            {
            //                ((TextBox)element).Text = string.Empty;
            //            }
            //        }
            //        isRunning = false;
            //        break;
            //    }

            //}



            //tempQuiz.AddQuestion(QuestionStatement.Text, )
        }

        private void btnSaveQuiz_Click(object sender, RoutedEventArgs e)
        {
            
            Game.listOfQuizes.Add(tempQuiz);
            MessageBox.Show($"Quiz {tempQuiz.Title} Created!");
            QuizName.Text = string.Empty;
            // KOLLA PÅ DETTA
            //activeQuiz = new Quiz(QuizName.Text, CategoryName.Text);

            //if (Game.listOfQuizes.Contains(activeQuiz))
            //{
            //    MessageBox.Show("A quiz with that name already exist, please choose another name!");
            //}
            //else
            //{
            //    Game.listOfQuizes.Add(activeQuiz);
            //    MessageBox.Show("Quiz created!");
            //}
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
