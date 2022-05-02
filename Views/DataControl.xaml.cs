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
using Practice_3.ViewModels;

namespace Practice_3.Views
{
    /// <summary>
    /// Interaction logic for DataControl.xaml
    /// </summary>
    public partial class DataControl : UserControl
    {
        private DataViewModel _viewModel;
        public DataControl(Action goToCreateAction, Action goToFilterAction)
        {
            InitializeComponent();
            DataContext = _viewModel = new DataViewModel(goToCreateAction,goToFilterAction);
        }
    }
}
