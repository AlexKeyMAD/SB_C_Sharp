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

namespace Task._Permutation_of_words_in_a_sentence_v2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Revers(object sender, RoutedEventArgs e)
        {
            var words = this.Sentence.Text.Split(' ');

            string str = string.Empty;

            for (int i = words.Length - 1; i >= 0; --i)
            {
                str += words[i] + ' ';
            }

            this.ReversSentence.Content = str;
        }

        private void Button_Click_Split(object sender, RoutedEventArgs e)
        {
            var words = this.Sentence.Text.Split(' ');

            this.Words.ItemsSource = words;
        }
    }
}
