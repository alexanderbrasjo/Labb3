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
    /// Interaction logic for EditQuizWindow.xaml
    /// </summary>
    public partial class EditQuizWindow : Window
    {
        public Quiz selectedQuiz = new Quiz();
        public EditQuizWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            cbbQuizChoose.ItemsSource = Game.listOfMyQuizes;
            
        }

        private void cbbQuizChoose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedQuiz = (Quiz)cbbQuizChoose.SelectedItem;

            if(selectedQuiz == null)
            {
                ListBoxChooseQuestion.ItemsSource = null;
                return;
            }
            if(selectedQuiz.Questions == null)
            {
                ListBoxChooseQuestion.ItemsSource = null;
            }
            else
            {
                ListBoxChooseQuestion.ItemsSource = selectedQuiz.Questions;
            }
        }

        private void ListBoxChooseQuestion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxChooseQuestion.ItemsSource = selectedQuiz.Questions;
            //Game.activeQuiz = (Question)ListBoxChooseQuestion.SelectedItem;
        }

        private void btnDeleteQuestion_Click(object sender, RoutedEventArgs e)
        {
            selectedQuiz.RemoveQuestion((Question)ListBoxChooseQuestion.SelectedItem);
            MessageBox.Show("Deleted Question!");
            cbbQuizChoose.ItemsSource = Game.listOfMyQuizes;
            ListBoxChooseQuestion.ItemsSource = null;
            ListBoxChooseQuestion.ItemsSource = selectedQuiz.Questions;
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDeleteQuiz_Click(object sender, RoutedEventArgs e)
        {
            Game.DeleteQuiz(selectedQuiz);
            MessageBox.Show("Deleted Quiz");
            cbbQuizChoose.ItemsSource = null;
            cbbQuizChoose.ItemsSource = Game.listOfMyQuizes;
            ListBoxChooseQuestion.ItemsSource = null;
        }
    }
}
