using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using MVVMC;
using Serilog;

namespace PracticalDebuggingDemos
{
    public class MainViewModel : MVVMC.BaseViewModel
    { 
        public ObservableCollection<DemoBase> Demos { get;  } = new ObservableCollection<DemoBase>();
        public ListCollectionView _allDemos;

        public ListCollectionView AllDemos
        {
            get { return _allDemos; }
            set
            {
                _allDemos = value;
                OnPropertyChanged();
            }
        }



        public MainViewModel()
        {
            Log.Information("Starting MainViewModel");
            PopulateComboBox();
        }

        DemoBase _selectedDemo;
        public DemoBase SelectedDemo
        {
            get { return _selectedDemo; }
            set
            {
                _selectedDemo = value;
                OnPropertyChanged();
            }
        }
        DemoBase _activeDemo;
        public DemoBase ActiveDemo
        {
            get { return _activeDemo; }
            set
            {
                _activeDemo = value;
                OnPropertyChanged();
            }
        }

        //public object _content;
        //public object Content
        //{
        //    get { return _content; }
        //    set { _content = value; OnPropertyChanged(); }
        //}

        public ICommand _goCommand;
        public ICommand GoCommand
        {
            get
            {
                if (_goCommand == null)
                {
                    _goCommand = new DelegateCommand(() =>
                    {
                        SelectedDemo.ClearContent();
                        SelectedDemo.Start();
                        ActiveDemo = SelectedDemo;
                    });
                }
                return _goCommand;
            }
        }

        private void PopulateComboBox()
        {
            var demos = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.BaseType == typeof(DemoBase))
                .ToList();
            foreach (var demo in demos)
            {
                Demos.Add(Activator.CreateInstance(demo) as DemoBase);
            }

            AllDemos = new ListCollectionView(Demos);
            AllDemos.GroupDescriptions.Add(new PropertyGroupDescription(nameof(DemoBase.Category)));
        }

    }
}
