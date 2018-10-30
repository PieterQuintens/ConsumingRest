using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using TestApp.Models;
using Xamarin.Forms;

namespace TestApp.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public ObservableCollection<TestModel> TestLists { get; set; } = new ObservableCollection<TestModel>
        {
            new TestModel
            {
                Title = "een"
            },
            new TestModel
            {
                Title = "twee"
            }
        };
        private Command NavigateCommand => new Command(OnNavigateClick);

        private async void OnNavigateClick()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Test");
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}
