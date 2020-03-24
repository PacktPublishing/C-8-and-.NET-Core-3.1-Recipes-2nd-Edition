using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDosDesktop.Models;
using ToDosDesktop.Services;

namespace ToDosDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ToDosService _service = new ToDosService();
        public ObservableCollection<ToDo> ToDos { get; set; } = new ObservableCollection<ToDo>()
        {
            new ToDo()
            {
                Id = 1,
                Title = "Git commit",
                Completed = true
            },
            new ToDo()
            {
                Id = 2,
                Title = "Git push",
                Completed = true
            },
            new ToDo()
            {
                Id = 3,
                Title = "Leave building",
                Completed = false
            }
        };

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var todos = await _service.GetToDos();
            foreach (var todo in todos)
            {
                ToDos.Add(todo);
            }
        }
    }
}
