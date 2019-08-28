using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using ZTasks.Models;
using ZTasks.Domain.Usecase;
using ZTasks.Presentation.PresenterCallBackHandler;
using Windows.ApplicationModel.Core;

namespace ZTasks.Presentation.ViewModel
{
    public class TaskListViewModel : INotifyPropertyChanged, IGetTaskPresenterCallBack
    {

        private ObservableCollection<ZTask> ZTaskCollection { get; set; }

        UseCaseBase usecase;

        public ObservableCollection<ZTask> Ztasks
        {
            get { return ZTaskCollection; }
            set
            {
                ZTaskCollection = value;
               // OnPropertyChanged("Ztasks");
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
            usecase = new GetTaskUseCase(this);

            usecase.Execute();

        }

        public async void OnTasksFetchedSuccessfully(List<ZTask> ZtaskList)
        {
            //var v =System.Windows.Application.Current.Dispatcher;
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                Debug.WriteLine(ZtaskList.Count, "msdmsdm");
                Ztasks.Clear();
                AddElementsToCollection(ZtaskList);
            });
        
            //Ztasks = new ObservableCollection<ZTask>(ZtaskList);

        }

        public void AddElementsToCollection(List<ZTask> ZtaskList)
        {
            foreach (ZTask task in ZtaskList)
            {
                Ztasks.Add(task);
            }
        }
    }
}
