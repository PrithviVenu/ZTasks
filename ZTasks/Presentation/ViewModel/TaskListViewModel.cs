﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using ZTasks.Models;
using ZTasks.Domain.Usecase;
using ZTasks.Presentation.PresenterCallBackHandler;
using Windows.ApplicationModel.Core;
using System.Runtime.CompilerServices;

namespace ZTasks.Presentation.ViewModel
{
    public class TaskListViewModel : INotifyPropertyChanged, IGetTaskPresenterCallBack
    {

        private ObservableCollection<ZTask> ZTaskCollection { get; set; }

        UseCaseBase usecase;
        private ObservableCollection<ZTask> _Ztasks;
        public ObservableCollection<ZTask> Ztasks { get { return _Ztasks; } set { _Ztasks = value; NotifyPropertyChanged(); } }
        public TaskListViewModel()
        {
            ZTaskCollection = new ObservableCollection<ZTask>();
            Ztasks = new ObservableCollection<ZTask>();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
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
                ZTaskCollection.Add(task);
                if (task.TaskDetails.ParentTaskId == null)
                {
                    Ztasks.Add(task);
                }
            }
        }
    }
}
