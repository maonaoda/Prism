using Prism.Navigation;
using PrismBugs.Views;
using PrismBugs.Views.Controls;
using R3;

namespace PrismBugs.ViewModels
{
    public class LoginPageViewModel : IDestructible
    {
        public readonly INavigationService _navigationService;

        public ReactiveCommand<Unit> LoginCommand { get; set; }

        public LoginPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            LoginCommand = new ReactiveCommand<Unit>();
            LoginCommand.SubscribeAwait(async (_, ct) =>
            {
                var result = await navigationService
                    .CreateBuilder()
                    .UseAbsoluteNavigation()
                    .AddSegment(nameof(BaseNavigationPage))
                    .AddTabbedSegment(nameof(MainTabbedPage), s => s.SelectedTab(nameof(TabbedPage1)))
                    .NavigateAsync();
            }, AwaitOperation.Drop);
        }

        public void Destroy()
        {
            Disposable.Dispose(LoginCommand);
        }
    }
}
