using Windows.UI.Xaml.Controls;


// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ZTasks.Presentation.Views
{
    public sealed partial class ListTasksControl : UserControl
    {
        public Models.ZTask Tasks { get { return this.DataContext as Models.ZTask; } }

        public ListTasksControl()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s, e) => Bindings.Update();

        }
    }
}
