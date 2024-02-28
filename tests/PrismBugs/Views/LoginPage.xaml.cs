using PrismBugs.ViewModels;

namespace PrismBugs.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
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
