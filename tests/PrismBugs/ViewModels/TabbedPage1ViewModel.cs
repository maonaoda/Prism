using Prism.Navigation;
using PrismBugs.Views;
using PrismBugs.Views.Controls;
using R3;

namespace PrismBugs.ViewModels
{
    public class TabbedPage1ViewModel : IDestructible
    {
        public BindableReactiveProperty<int> Count { get; }
        public BindableReactiveProperty<string> CounterBtnText { get; }

        public ReactiveCommand<Unit> NextCommand { get; set; }
        public ReactiveCommand<Unit> LogoutCommand { get; set; }

        public TabbedPage1ViewModel(INavigationService navigationService)
        {
            Count = new BindableReactiveProperty<int>();
            CounterBtnText = Count.Select(x => $"Clicked {x} times on TabbedPage1").ToBindableReactiveProperty("");

            LogoutCommand = new ReactiveCommand<Unit>();
            LogoutCommand.SubscribeAwait(async (_, ct) =>
            {
                await navigationService
                    .CreateBuilder()
                    .UseAbsoluteNavigation()
                    .AddSegment(nameof(BaseNavigationPage))
                    .AddSegment(nameof(LoginPage))
                    .NavigateAsync();
            }, AwaitOperation.Drop);

            NextCommand = new ReactiveCommand<Unit>();
            NextCommand.SubscribeAwait(async (_, ct) =>
            {
                await navigationService
                    .CreateBuilder()
                    .AddSegment(nameof(TabbedPage11))
                    .NavigateAsync();
            }, AwaitOperation.Drop);
        }

        public void Destroy()
        {
            Disposable.Dispose(Count, CounterBtnText);
        }
    }
}