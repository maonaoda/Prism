using PrismBugs.ViewModels;

namespace PrismBugs.Views
{
    public partial class TabbedPage2 : ContentPage
    {
        public TabbedPage2()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            if (BindingContext is TabbedPage2ViewModel vm)
            {
                vm.Count.Value++;
            }
        }
    }
}
