using Schema = System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using System.Windows;
using Pr29_Radosteva.Classes;

namespace Pr29_Radosteva.Models
{
    public class Events : Notification
    {
        public int Id { get; set; }
        private string name = "";
        public string Name
        {
            get { return name; }
            set
            {
                Match match = Regex.Match(value, "^.{1,50}$");
                if (!match.Success)
                    MessageBox.Show("Наименование не должно быть пустым, и не более 50 символов.",
                        "Не корректный ввод значения.");
                else {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private DateTime dateEvent;
        public DateTime DateEvent
        {
            get { return dateEvent; }
            set
            {
                if (value.Date < DateTime.Now.Date)
                    MessageBox.Show("Дата события не может быть меньше текущей.",
                        "Не корректный ввод значения.");
                else {
                    dateEvent = value;
                    OnPropertyChanged("DateEvent");
                }
            }
        }
        private string place = "";
        public string Place
        {
            get { return place; }
            set
            {
                Match match = Regex.Match(value, "^.{1,100}$");
                if (!match.Success)
                    MessageBox.Show("Место проведения не должно быть пустым, и не более 100 символов.",
                        "Не корректный ввод значения.");
                else {
                    place = value;
                    OnPropertyChanged("Place");
                }
            }
        }
        private string description = "";
        public string Description
        {
            get { return description; }
            set
            {
                Match match = Regex.Match(value, "^.{1,1000}$");
                if (!match.Success)
                    MessageBox.Show("Описание не должно быть пустым, и не более 1000 символов.",
                        "Не корректный ввод значения.");
                else {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        [Schema.NotMapped]
        private bool isEnable;
        [Schema.NotMapped]
        public bool IsEnable
        {
            get { return isEnable; }
            set
            {
                isEnable = value;
                OnPropertyChanged("IsEnable");
                OnPropertyChanged("IsEnableText");
            }
        }
        [Schema.NotMapped]
        public string IsEnableText
        {
            get
            {
                if (IsEnable) return "Сохранить";
                else return "Изменить";
            }
        }
    }
}
