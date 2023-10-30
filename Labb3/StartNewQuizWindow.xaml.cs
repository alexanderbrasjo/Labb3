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
    /// Interaction logic for StartNewQuizWindow.xaml
    /// </summary>
    public partial class StartNewQuizWindow : Window
    {
        public StartNewQuizWindow()
        {
            InitializeComponent();
            Quiz tempQuiz = Quiz.CreateRandomQuiz();
            cbbQuizChoose.ItemsSource = Game.listOfQuizes;
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }
        private void cbbQuizChoose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PlayWindow.activeQuiz = (Quiz)cbbQuizChoose.SelectedItem;
        }

        private void btnStartQuiz_Click(object sender, RoutedEventArgs e)
        {
            //int chosenQuiz = cbbQuizChoose.
            //if (cbbQuizChoose.)

            PlayWindow.activeQuiz = (Quiz)cbbQuizChoose.SelectedItem;
            if(PlayWindow.activeQuiz != null)
            {
                PlayWindow playWindow = new PlayWindow();
                playWindow.Show();

            }
            else
            {
                MessageBox.Show("Please choose a quiz");
            }
        }

    }
}
