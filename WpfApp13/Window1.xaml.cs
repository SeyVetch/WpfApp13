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
using System.IO;

namespace WpfApp13
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        List<Person> people;
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader("data.txt"))
            {
                people = new List<Person>();
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    Person p = new Person();
                    p.Id = i + 1;
                    string[] data = line.Split(';');
                    p.LastName = data[0];
                    p.FirstName = data[1];
                    p.Age = int.Parse(data[2]);
                    people.Add(p);
                    line = sr.ReadLine();
                    i++;
                }
                DataGridUsers.ItemsSource = people;
            }
        }
    }
}
