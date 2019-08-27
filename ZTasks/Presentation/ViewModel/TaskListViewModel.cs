using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Models;
using ZTasks.Domain.Usecase;
using ZTasks.Presentation.PresenterCallBack;

namespace ZTasks.Presentation.ViewModel
{
    public class TaskListViewModel : INotifyPropertyChanged, IGetTasksCallBack
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
        public TaskListViewModel()
        {
            ZTaskCollection = new ObservableCollection<ZTask>();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void MyTasks()
        {
            usecase = new GetTasksUseCase(this);

            usecase.Execute();

        }

        public void OnTasksFetchedSuccessfully(ObservableCollection<ZTask> ZtaskList)
        {
            Debug.WriteLine(ZtaskList.Count, "msdmsdm");
            Ztasks.Clear();
            AddElementsToCollection(ZtaskList);
        }

        public void AddElementsToCollection(ObservableCollection<ZTask> ZtaskList)
        {
            foreach (ZTask task in ZtaskList)
            {
                Ztasks.Add(task);
            }
        }
    }
}
