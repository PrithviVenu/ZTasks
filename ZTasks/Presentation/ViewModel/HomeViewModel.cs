using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Domain.Models;
using ZTasks.Domain.Usecase;

namespace ZTasks.Presentation.ViewModel
{

    class HomeViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ZTask> ZTaskCollection { get; set; }
        UseCaseBase usecase;

        public ObservableCollection<ZTask> Ztasks
        {
            get { return ZTaskCollection; }
            set
            {
                ZTaskCollection = value;
                OnPropertyChanged("Ztasks");
            }
        }
        public HomeViewModel()
        {
            usecase = new AddTaskUseCase(this.Ztasks);
        }

        public void AddTask()
        {
            usecase.Execute();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
