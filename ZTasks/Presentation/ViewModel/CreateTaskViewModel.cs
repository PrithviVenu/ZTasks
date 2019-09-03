using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using ZTasks.Models;
using ZTasks.Domain.Usecase;
using ZTasks.Presentation.PresenterCallBackHandler;
using Windows.ApplicationModel.Core;
using System;


namespace ZTasks.Presentation.ViewModel
{

    public class CreateTaskViewModel : INotifyPropertyChanged, ICreateTaskPresenterCallback
    {
        private ObservableCollection<ZTask> ZTaskCollection { get; set; }
        UseCaseBase usecase;
        public delegate void Refresh();
        public event Refresh RefreshData;
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
            RemoveEmptyListElements();
            usecase = new CreateTaskUseCase(Ztasks.ToList<ZTask>(), parentZtask, this);
            usecase.Execute();

        }

        public void RemoveEmptyListElements()
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
                if (string.IsNullOrEmpty(Ztasks[i].TaskDetails.TaskTitle))
                    Ztasks.RemoveAt(i);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void OnSuccess(bool success)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                Debug.WriteLine("success");
                RefreshData?.Invoke();
            });

        }
    }
}
