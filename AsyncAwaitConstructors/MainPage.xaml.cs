using AsyncAwaitConstructors.Examples.AsyncInitializer;
using AsyncAwaitConstructors.Examples.AsyncVoid;
using AsyncAwaitConstructors.Examples.DiscardedTask;

namespace AsyncAwaitConstructors;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnAsyncVoidButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AsyncVoidPage));
    }

    private async void OnDiscardedTaskButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(DiscardedTaskPage));
    }

    private async void OnAsyncInitializerButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AsyncInitializerPage));
    }
}