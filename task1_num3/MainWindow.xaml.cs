using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task_1
{
    public partial class MainWindow : Window
    {
        public ViewModel<string> StackViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            StackViewModel = new ViewModel<string>();
            DataContext = StackViewModel;
        }

        private void PushButton_Click(object sender, RoutedEventArgs e)
        {
            string newItem = InputTextBox.Text;
            StackViewModel.Push(newItem);
            InputTextBox.Clear();
        }

        private void PopButton_Click(object sender, RoutedEventArgs e)
        {
            string poppedItem = StackViewModel.Pop();
            StackViewModel.PoppedItem = poppedItem;
        }
    }
}
