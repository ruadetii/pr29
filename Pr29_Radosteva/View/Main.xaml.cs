using System.Windows.Controls;

namespace Pr29_Radosteva.View
{
    public partial class Main : Page
    {
        public Main(object Context)
        {
            InitializeComponent();
            DataContext = Context;
        }
    }
}
