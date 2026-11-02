using Schema = System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using System.Windows;
using Pr29_Radosteva.Classes;

namespace Pr29_Radosteva.Models
{
    public class Participants : Notification
    {
        public int Id { get; set; }
        private string fio = "";
        public string FIO
        {
            get { return fio; }
            set
            {
                Match match = Regex.Match(value, "^.{1,100}$");
                if (!match.Success)
                    MessageBox.Show("ФИО не должно быть пустым, и не более 100 символов.",
                        "Не корректный ввод значения.");
                else {
                    fio = value;
                    OnPropertyChanged("FIO");
                }
            }
        }
        private string phone = "";
        public string Phone
        {
            get { return phone; }
            set
            {
                Match match = Regex.Match(value, @"^\+?[0-9]{11}$");
                if (!match.Success)
                    MessageBox.Show("Телефон должен состоять из 11 цифр, допускается знак + в начале.",
                        "Не корректный ввод значения.");
                else {
                    phone = value;
                    OnPropertyChanged("Phone");
                }
            }
        }
        private string email = "";
        public string Email
        {
            get { return email; }
            set
            {
                Match match = Regex.Match(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                if (!match.Success)
                    MessageBox.Show("Email введён не корректно.",
                        "Не корректный ввод значения.");
                else {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        private int idEvent;
        public int IdEvent
        {
            get { return idEvent; }
            set
            {
                idEvent = value;
                OnPropertyChanged("IdEvent");
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
