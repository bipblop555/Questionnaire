using System.Windows.Navigation;

namespace Questionnaire.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Source = new Uri("Page1.xaml", System.UriKind.Relative);
        }
    }
}