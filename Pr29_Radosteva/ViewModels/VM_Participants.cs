using System.Collections.ObjectModel;
using Pr29_Radosteva.Classes;
using Pr29_Radosteva.Context;
using Pr29_Radosteva.Models;

namespace Pr29_Radosteva.ViewModels
{
    public class VM_Participants : Notification
    {
        public CalendarContext calendarContext;
        public ObservableCollection<Participants> Participants { get; set; } = new ObservableCollection<Participants>();
        private Events selectedEvent;
        public Events SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                selectedEvent = value;
                Participants.Clear();
                foreach (Participants participant in calendarContext.Participants
                    .Where(x => x.IdEvent == selectedEvent.Id).OrderBy(x => x.FIO))
                    Participants.Add(participant);
                OnPropertyChanged("SelectedEvent");
            }
        }
        public VM_Participants(CalendarContext calendarContext) =>
            this.calendarContext = calendarContext;

        public RealyCommand OnAddParticipant
        {
            get {
                return new RealyCommand(obj => {
                    Participants NewParticipant = new Participants()
                    {
                        IdEvent = SelectedEvent.Id
                    };
                    Participants.Add(NewParticipant);
                    calendarContext.Participants.Add(NewParticipant);
                    calendarContext.SaveChanges();
                });
            }
        }

        public RealyCommand OnBack
        {
            get {
                return new RealyCommand(obj => {
                    MainWindow.init.frame.Navigate(
                        new View.Main((MainWindow.init.DataContext as VM_Pages).vm_events));
                });
            }
        }
    }
}
