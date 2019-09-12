using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMC;

namespace PracticalDebugingDemos
{
    public class MainViewModel : MVVMC.BaseViewModel
    {
        public ObservableCollection<DemoBase> Demos { get;  } = new ObservableCollection<DemoBase>();

        public MainViewModel()
        {
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

        public object _content;
        public object Content
        {
            get { return _content; }
            set { _content = value; OnPropertyChanged(); }
        }

        public ICommand _goCommand;
        public ICommand GoCommand
        {
            get
            {
                if (_goCommand == null)
                {
                    _goCommand = new DelegateCommand(() =>
                    {
                        SelectedDemo.Start();
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
        }
    }
}
