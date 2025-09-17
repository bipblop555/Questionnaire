using System.Windows.Controls;
using Questionnaire.ViewModels;
namespace Questionnaire.Views
{
    /// <summary>
    /// Logique d'interaction pour Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            this.DataContext = new Page2ViewModel();
        }
    }
}
