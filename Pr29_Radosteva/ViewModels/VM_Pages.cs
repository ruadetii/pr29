using Pr29_Radosteva.Classes;
using Pr29_Radosteva.Context;

namespace Pr29_Radosteva.ViewModels
{
    public class VM_Pages : Notification
    {
        public CalendarContext calendarContext = new CalendarContext();
        public VM_Events vm_events;
        public VM_Participants vm_participants;
        public VM_Pages()
        {
            vm_events = new VM_Events(calendarContext);
            vm_participants = new VM_Participants(calendarContext);
            MainWindow.init.frame.Navigate(new View.Main(vm_events));
        }
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
