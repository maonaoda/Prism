using Prism.Controls;

#nullable disable
namespace PrismBugs.Views.Controls
{
    public class BaseNavigationPage : PrismNavigationPage
    {
        //        INavigationPageController NavigationPageController => this;

        //        public new event EventHandler BackButtonPressed;

        //        public BaseNavigationPage()
        //        {
        //            BackButtonPressed += HandleBackButtonPressed;
        //            BarTextColor = Colors.White;
        //        }

        //        public BaseNavigationPage(Page page)
        //            : base(page)
        //        {
        //            BackButtonPressed += HandleBackButtonPressed;
        //            BarTextColor = Colors.White;
        //        }

        //        protected override bool OnBackButtonPressed()
        //        {
        //#if ANDROID
        //            if (CurrentPage.SendBackButtonPressed())
        //                return true;

        //            if (NavigationPageController.StackDepth > 1)
        //            {
        //                BackButtonPressed.Invoke(this, EventArgs.Empty);
        //                return true;
        //            }

        //            return false;
        //#else
        //            return base.OnBackButtonPressed();
        //#endif
        //        }

        //        private async void HandleBackButtonPressed(object sender, EventArgs args)
        //        {
        //            await MvvmHelpers.HandleNavigationPageGoBack(this);
        //        }
    }
}
