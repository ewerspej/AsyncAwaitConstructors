using AsyncAwaitConstructors.Examples.AsyncInitializer;
using AsyncAwaitConstructors.Examples.AsyncVoid;
using AsyncAwaitConstructors.Examples.DiscardedTask;

namespace AsyncAwaitConstructors;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(AsyncVoidPage), typeof(AsyncVoidPage));
        Routing.RegisterRoute(nameof(DiscardedTaskPage), typeof(DiscardedTaskPage));
        Routing.RegisterRoute(nameof(AsyncInitializerPage), typeof(AsyncInitializerPage));
    }
}