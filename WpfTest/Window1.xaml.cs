using System.Collections.Generic;
using System.Windows;
using MainModel;

namespace WpfTest
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1(string trafficDescription, string formText)
        {
            InitializeComponent();

            pv1.Visibility = Visibility.Hidden;

            lab1.Content = trafficDescription;

            lab2.Content = $"Ответ : {formText}";
        }

        public Window1(string trafficDescription, string[] comment, List<double[]> param, bool lens)
        {
            InitializeComponent();

            DataContext = new MainViewModel(trafficDescription,  comment,  param, lens);

            lab1.Visibility = Visibility.Hidden;

            lab2.Visibility = Visibility.Hidden;
        }

    }
}
