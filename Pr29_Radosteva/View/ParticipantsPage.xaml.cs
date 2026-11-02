using System.Windows.Controls;

namespace Pr29_Radosteva.View
{
    public partial class ParticipantsPage : Page
    {
        public ParticipantsPage(object Context)
        {
            InitializeComponent();
            DataContext = Context;
        }
    }
}
