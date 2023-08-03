using AsyncAwaitConstructors.Examples1.AsyncInitializer;
using AsyncAwaitConstructors.Examples1.AsyncVoid;
using AsyncAwaitConstructors.Examples1.DiscardedTask;

namespace AsyncAwaitConstructors;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(AsyncVoidPage), typeof(AsyncVoidPage));
        Routing.RegisterRoute(nameof(DiscardedTaskPage), typeof(DiscardedTaskPage));
        Routing.RegisterRoute(nameof(AsyncInitializerPage), typeof(AsyncInitializerPage));
        Routing.RegisterRoute(nameof(AsyncInitializerPage2), typeof(AsyncInitializerPage2));
    }
}