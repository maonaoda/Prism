using PrismBugs.ViewModels;

namespace PrismBugs.Views
{
    public partial class TabbedPage11 : ContentPage
    {
        public TabbedPage11()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            if (BindingContext is TabbedPage11ViewModel vm)
            {
                vm.Count.Value++;
            }
        }
    }
}
