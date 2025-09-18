using Questionnaire.ViewModels;
using System.Windows.Controls;

namespace Questionnaire.Views
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {

        public Page1()
        {
            InitializeComponent();
            this.DataContext = new QuestionnaireViewModel();
        }

        private void TextBox_IsKeyboardFocusedChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
