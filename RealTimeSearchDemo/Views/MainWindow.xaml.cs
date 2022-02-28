using MaterialDesignExtensions.Controls;
using Microsoft.Toolkit.Mvvm.DependencyInjection;

namespace RealTimeSearchDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MaterialWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = Ioc.Default.GetService<MainViewModel>();
        }
    }
}
