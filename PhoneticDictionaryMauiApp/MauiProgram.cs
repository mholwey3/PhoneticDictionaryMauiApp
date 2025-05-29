using Microsoft.Extensions.Logging;
using PhoneticDictionaryMauiApp.Source;
using System.Reflection;

namespace PhoneticDictionaryMauiApp
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<PhoneticDictionaryDatabase>(s));
            builder.Services.AddTransient<MainPage>();

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            using (Stream stream = assembly.GetManifestResourceStream("PhoneticDictionaryMauiApp.Resources.Raw.Database.db"))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);

                    File.WriteAllBytes(PhoneticDictionaryDatabase.DbPath, memoryStream.ToArray());
                }
            }

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
