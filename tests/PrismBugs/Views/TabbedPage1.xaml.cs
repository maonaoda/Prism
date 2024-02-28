using PrismBugs.ViewModels;

namespace PrismBugs.Views
{
    public partial class TabbedPage1 : ContentPage
    {
        public TabbedPage1()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            if (BindingContext is TabbedPage1ViewModel vm)
            {
                vm.Count.Value++;
            }
        }
    }
}
