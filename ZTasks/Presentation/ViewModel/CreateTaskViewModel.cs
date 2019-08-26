using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Domain.Models;
using ZTasks.Domain.Usecase;

namespace ZTasks.Presentation.ViewModel
{

    public class CreateTaskViewModel : INotifyPropertyChanged
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
        public CreateTaskViewModel()
        {
            ZTaskCollection = new ObservableCollection<ZTask>();
            ZTaskCollection.CollectionChanged += Task_CollectionChanged;
        }
        void Task_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine(Ztasks.Count);
        }

        public void AddTask(ZTask parentZtask)
        {
            removeEmptyListElements();
            usecase = new CreateTaskUseCase(Ztasks, parentZtask);
            usecase.Execute();

        }

        public void removeEmptyListElements()
        {
            //foreach (ZTask item in Ztasks)
            //{
            //    if (string.IsNullOrWhiteSpace(item.TaskTitle))
            //    {

            //        Ztasks.Remove(item);
            //    }
            //}
            for (int i = Ztasks.Count - 1; i >= 0; i--)
            {
                if (string.IsNullOrEmpty(Ztasks[i].TaskTitle))
                    Ztasks.RemoveAt(i);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
