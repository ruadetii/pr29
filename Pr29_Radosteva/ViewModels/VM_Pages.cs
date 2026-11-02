using Pr29_Radosteva.Classes;

namespace Pr29_Radosteva.ViewModels
{
    public class VM_Pages : Notification
    {
        public RealyCommand OnClose
        {
            get {
                return new RealyCommand(obj => {
                    MainWindow.init.Close();
                });
            }
        }
    }
}
