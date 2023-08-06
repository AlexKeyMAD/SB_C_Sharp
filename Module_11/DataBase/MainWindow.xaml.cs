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

namespace TaskDataBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataBase db = new DataBase();
            db.Initialosation();

            UserIdentification UI = new UserIdentification();

            IUser CurentUser = null;

            while (CurentUser == null)
            {
                if (UI.ShowDialog() == true)
                {
                    if (UI.User.Text != "")
                    {
                        CurentUser = db.Identification(UI.User.Text);
                    }
                    else
                    {
                        MessageBox.Show("Что-то пошло не так");
                    }
                }
            }
        }
    }
}
