using Microsoft.Xaml.Behaviors;
using System.Windows.Controls;
using System.Windows.Media;

namespace Questionnaire.Behaviour;

public class RequiredBehavior : Behavior<TextBox>
{
    protected override void OnAttached()
    {
        base.OnAttached();
        var txtBox = this.AssociatedObject as TextBox;

        txtBox.TextChanged += this.OnTextChanged;
        this.SetBorderColor(txtBox);
    }

    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        var txtBox = this.AssociatedObject as TextBox;
        this.SetBorderColor(txtBox);
    }

    private void SetBorderColor(TextBox txtBox)
    {
        if (string.IsNullOrWhiteSpace(txtBox.Text))
        {
            txtBox.BorderBrush = new SolidColorBrush(Colors.Red);
        }
        else
        {
            txtBox.BorderBrush = new SolidColorBrush(Colors.Green);
            txtBox.Foreground = new SolidColorBrush(Colors.Green);
        }
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();
        var txtBox = this.AssociatedObject as TextBox;
        txtBox.TextChanged -= this.OnTextChanged;
    }
}
