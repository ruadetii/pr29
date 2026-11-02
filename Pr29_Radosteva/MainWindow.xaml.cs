using System.Windows;
using Pr29_Radosteva.ViewModels;

namespace Pr29_Radosteva
{
    public partial class MainWindow : Window
    {
        public static MainWindow init;
        public MainWindow()
        {
            InitializeComponent();
            init = this;
            DataContext = new VM_Pages();
        }
    }
}
