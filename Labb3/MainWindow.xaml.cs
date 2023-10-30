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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Labb3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {

        
        public MainWindow()
        {
            InitializeComponent();
            Quiz quiz = new Quiz();
            quiz.GenerateQuestions();
            Game.LoadAllQuestions();
        }

        private void btnCreateNewQuiz_Click(object sender, RoutedEventArgs e)
        {
            CreateNewQuizWindow createNewQuizWindow = new CreateNewQuizWindow();
            createNewQuizWindow.Show();
        }

        private void btnStartNewQuiz_Click(object sender, RoutedEventArgs e)
        {
            StartNewQuizWindow startNewQuizWindow = new StartNewQuizWindow();
            startNewQuizWindow.Show();
        }

        private void btnExitGame_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
