using System.Collections.ObjectModel;
using Pr29_Radosteva.Classes;
using Pr29_Radosteva.Context;
using Pr29_Radosteva.Models;

namespace Pr29_Radosteva.ViewModels
{
    public class VM_Events : Notification
    {
        public CalendarContext calendarContext;
        public ObservableCollection<Events> Events { get; set; }
        public VM_Events(CalendarContext calendarContext)
        {
            this.calendarContext = calendarContext;
            Events = new ObservableCollection<Events>(calendarContext.Events.OrderBy(x => x.DateEvent));
        }

        public RealyCommand OnAddEvent
        {
            get {
                return new RealyCommand(obj => {
                    Events NewEvent = new Events()
                    {
                        DateEvent = DateTime.Now
                    };
                    Events.Add(NewEvent);
                    calendarContext.Events.Add(NewEvent);
                    calendarContext.SaveChanges();
                });
            }
        }
    }
}
