using AsyncAwaitConstructors.Examples1.AsyncInitializer;
using AsyncAwaitConstructors.Examples1.AsyncVoid;
using AsyncAwaitConstructors.Examples1.DiscardedTask;
using Microsoft.Extensions.Logging;

namespace AsyncAwaitConstructors;

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

#if DEBUG
        builder.Logging.AddDebug();
#endif

        // strictly not necessary
        builder.Services.AddTransient<AsyncVoidPage>();
        builder.Services.AddTransient<DiscardedTaskPage>();

        // required for Shell's automatic dependency injection
        builder.Services.AddTransient(x =>
        {
            var vm = new AsyncInitializerViewModel();

            // here, factory methods cannot be asynchronous, so we cannot await the loading task
            // this is not ideal, because it hides the fact that some data is being loaded asynchronously
            _ = vm.LoadAsync();

            return vm;
        });
        builder.Services.AddTransient<AsyncInitializerPage2>();

        return builder.Build();
    }
}