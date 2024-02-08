using Microsoft.Extensions.Logging;
using Python.Runtime;

namespace HousePricePredictorUK
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {

            Environment.SetEnvironmentVariable("PYTHONNET_PYDLL", @"C:\Users\ocsio\AppData\Local\Programs\Python\Python311\python311.dll");
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiMaps()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
