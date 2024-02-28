using Prism.Mvvm;
using Prism.Navigation;
using PrismBugs.ViewModels;
using PrismBugs.Views;
using PrismBugs.Views.Controls;
using R3.Maui;

namespace PrismBugs
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UsePrism(DryIocContainerExtension.DefaultRules.WithUseInterpretation(), prism =>
                {
                    prism.RegisterTypes(containerRegistry =>
                    {
                        containerRegistry.Register<INavigationService, PageNavigationService>();

                        containerRegistry
                            .Register<BaseNavigationPage>(() => new BaseNavigationPage())
                            .RegisterInstance(new ViewRegistration
                            {
                                Name = nameof(BaseNavigationPage),
                                View = typeof(BaseNavigationPage),
                                Type = ViewType.Page
                            });

                        containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
                        containerRegistry.RegisterForNavigation<MainTabbedPage, MainTabbedPageViewModel>();
                        containerRegistry.RegisterForNavigation<TabbedPage1, TabbedPage1ViewModel>();
                        containerRegistry.RegisterForNavigation<TabbedPage11, TabbedPage11ViewModel>();
                        containerRegistry.RegisterForNavigation<TabbedPage2, TabbedPage2ViewModel>();
                    })
                    .CreateWindow(async (container, navigationService) =>
                    {
                        // If Login
                        await navigationService
                            .CreateBuilder()
                            .AddSegment(nameof(BaseNavigationPage))
                            .AddTabbedSegment(nameof(MainTabbedPage), s => s.SelectedTab(nameof(TabbedPage1)))
                            .NavigateAsync();

                        // If not Login
                        //await navigationService
                        //    .CreateBuilder()
                        //    .AddSegment(nameof(BaseNavigationPage))
                        //    .AddSegment(nameof(LoginPage))
                        //    .NavigateAsync();
                    });
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseR3();

#if DEBUG
            //builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
