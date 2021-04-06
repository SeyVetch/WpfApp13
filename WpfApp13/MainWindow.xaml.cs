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
using System.IO;

namespace WpfApp13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            string LName = txtLName.Text;
            string FName = txtFName.Text;
            string Age = txtAge.Text;

            if (string.IsNullOrWhiteSpace(LName))
            {
                MessageBox.Show("Введите фамилию");
                return;
            }
            if (string.IsNullOrWhiteSpace(FName))
            {
                MessageBox.Show("Введите имя");
                return;
            }
            if (string.IsNullOrWhiteSpace(Age))
            {
                MessageBox.Show("Введите возраст");
                return;
            }
            uint val;
            if (!uint.TryParse(Age, out val))
            {
                MessageBox.Show("Неверный возраст");
                return;
            }
            using (StreamWriter sw = new StreamWriter("data.txt", true))
            {
                sw.WriteLine($"{LName};{FName};{Age}");
            }
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            Window1 w = new Window1();
            this.Hide();
            w.ShowDialog();
            this.Show();
        }
    }
}
