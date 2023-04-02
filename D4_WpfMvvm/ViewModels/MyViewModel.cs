using D4_WpfMvvm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace D4_WpfMvvm.ViewModels
{
    internal class MyViewModel : INotifyPropertyChanged
    {
        private User user;
        public string FirstName
        {
            get => user.FirstName;
            set
            {
                if (user.FirstName != value)
                {
                    user.FirstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }
        public string LastName
        {
            get => user.LastName;
            set
            {
                if (user.FirstName != value)
                {
                    user.LastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }
        public MyViewModel() 
        { 
            user = new User() { FirstName = "Zenon", LastName = "Martyniuk"};
            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    FirstName = "Elon";
                    LastName = "Martyniuk";
                    Thread.Sleep(1000);
                    FirstName = "Zenon";
                    LastName = "Musk";
                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
