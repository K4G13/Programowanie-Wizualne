using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PhonesAppMAUI.ViewModels;

namespace PhonesAppMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            string libraryName = System.Configuration.ConfigurationManager.AppSettings["DAOLibraryName"]!;
            BLC.BLC blc = new BLC.BLC(libraryName);

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            //builder.Services.AddSingleton<PhonesCollectionViewModel>();
            builder.Services.AddSingleton<PhonesCollectionViewModel>( provider => new PhonesCollectionViewModel(blc) );
            builder.Services.AddSingleton<PhonesPage>();

            builder.Services.AddSingleton<ProducersCollectionViewModel>(provider => new ProducersCollectionViewModel(blc));
            builder.Services.AddSingleton<ProducersPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
