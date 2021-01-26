using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfTest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            treeView1.ItemsSource = CategoryLab.GetCreatorList();
            //foreach (Button button in grid1.Children.OfType<Button>())
            //    button.Click += (s, a) => { Process.Start("notepad"); };

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string noomber = "4.1, 4.2" ;

            Window1 taskWindow;
            for (int i = 0; i < CategoryLab.GetCreatorList().Count; i++)
                for (int f = 0; f < CategoryLab.GetCreatorList()[i].Graf.Count; f++)
                    if ((string)((Button)sender).Content == CategoryLab.GetCreatorList()[i].Graf[f].TrafficDescription) //
                        if (0 <= noomber.IndexOf(CategoryLab.GetCreatorList()[i].Graf[f].TrafficDescription)) 
                        {
                            taskWindow = new Window1(CategoryLab.GetCreatorList()[i].Graf[f].TrafficDescription,
                            CategoryLab.GetCreatorList()[i].Graf[f].formText);
                            taskWindow.ShowDialog();
                        }
                        else
                        {
                            taskWindow = new Window1(CategoryLab.GetCreatorList()[i].Graf[f].TrafficDescription,
                            CategoryLab.GetCreatorList()[i].Graf[f].comment,
                            CategoryLab.GetCreatorList()[i].Graf[f].param,
                            CategoryLab.GetCreatorList()[i].Graf[f].lens);
                            taskWindow.ShowDialog();
                        }

        }
    }
}
