using Questionnaire.Core.Models;
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

namespace Questionnaire.Views
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public ObservableCollection<EQuestionnaire> Questionnaires { get; set; }

        public Page1()
        {
            InitializeComponent();
            LoadDummyData();
        }

        private void LoadDummyData()
        {
            Questionnaires = new ObservableCollection<EQuestionnaire>
            {
                new EQuestionnaire { Id = 1, Title = "Questionnaire 1" },
                new EQuestionnaire { Id = 2, Title = "Questionnaire 2" },
                new EQuestionnaire { Id = 3, Title = "Questionnaire 3" }
            };

            QuestionnairesList.ItemsSource = Questionnaires;
        }

        private void RemoveQuestionnaire_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int questionnaireId)
            {
                var questionnaireToRemove = Questionnaires.FirstOrDefault(q => q.Id == questionnaireId);
                if (questionnaireToRemove != null)
                {
                    Questionnaires.Remove(questionnaireToRemove);
                }
            }
        }

        private void AddQuestionnaire_Click(object sender, RoutedEventArgs e)
        {
            var newQuestionnaire = new EQuestionnaire
            {
                Id = Questionnaires.Count + 1,
                Title = $"New Questionnaire {Questionnaires.Count + 1}"
            };

            Questionnaires.Add(newQuestionnaire);
        }
    }
}
