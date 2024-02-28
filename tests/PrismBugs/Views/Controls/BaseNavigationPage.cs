using Prism.Common;
using Prism.Controls;

#nullable disable
namespace PrismBugs.Views.Controls
{
    public class BaseNavigationPage : PrismNavigationPage
    {
#if ANDROID
        INavigationPageController NavigationPageController => this;

        public new event EventHandler BackButtonPressed;

        public BaseNavigationPage()
        {
            BackButtonPressed += HandleBackButtonPressed;
            BarTextColor = Colors.White;
        }

        public BaseNavigationPage(Page page)
            : base(page)
        {
            BackButtonPressed += HandleBackButtonPressed;
            BarTextColor = Colors.White;
        }

        private async void HandleBackButtonPressed(object sender, EventArgs args)
        {
            await MvvmHelpers.HandleNavigationPageGoBack(this);
        }
#else
        public BaseNavigationPage()
        {
            BarTextColor = Colors.White;
        }

        public BaseNavigationPage(Page page)
            : base(page)
        {
            BarTextColor = Colors.White;
        }

#endif

        protected override bool OnBackButtonPressed()
        {
#if ANDROID
            if (CurrentPage.SendBackButtonPressed())
                return true;

            if (NavigationPageController.StackDepth > 1)
            {
                BackButtonPressed.Invoke(this, EventArgs.Empty);
                return true;
            }

            return false;
#else
            return base.OnBackButtonPressed();
#endif
        }
    }
}
