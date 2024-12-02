using Microsoft.Extensions.Logging;

namespace KCAppP2
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
                    // Fuentes predeterminadas
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                    // Agregar una fuente personalizada con las iniciales KC
                    fonts.AddFont("KCFont-Regular.ttf", "KCFontRegular"); // Reemplaza con tu fuente personalizada
                });

#if DEBUG
            // Configuración de logging para depuración
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
