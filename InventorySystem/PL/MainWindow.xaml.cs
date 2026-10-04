using InventorySystem.BLL;
using InventorySystem.DAL;
using InventorySystem.Models;
using InventorySystem.PL.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InventorySystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow( MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;


        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGridItemCodes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}