using FlashCardsPc.DbConfiguration;
using FlashCardsPc.Repository;
using FlashCardsPc.Services;
using Microsoft.Extensions.Logging;

namespace FlashCardsPc
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddDbContext<FlashcardContext>();
            builder.Services.AddTransient<ICardsRepository, CardsRepository>();
            builder.Services.AddTransient<ICardsService, CardsService>();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
