using System.Windows;

namespace SineGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new MainWindowViewModel();
            DataContext = viewModel;
            Closing += ((o, e) => viewModel.StopCommand.Execute(null));
        }
    }
}
