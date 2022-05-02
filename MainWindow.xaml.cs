using System.Windows;
using Practice_3.Views;

namespace Practice_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GoToData();
        }

        public void GoToCreatePerson()
        {
            Content = new CreatePersonControl(GoToData);

        }

        public void GoToFilter()
        {
            Content = new FilterControl(GoToData);

        }

        public void GoToData()
        {
            Content=new DataControl(GoToCreatePerson,GoToFilter);
        }
    }
}
