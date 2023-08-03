using AsyncAwaitConstructors.Examples1.AsyncFactory;
using AsyncAwaitConstructors.Examples1.AsyncInitializer;
using AsyncAwaitConstructors.Examples1.AsyncVoid;
using AsyncAwaitConstructors.Examples1.DiscardedTask;

namespace AsyncAwaitConstructors;

public partial class PagesPage : ContentPage
{
    public PagesPage()
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

    private async void OnAsyncInitializer2ButtonClicked(object sender, EventArgs e)
    {
        var vm = new AsyncInitializerViewModel();
        await vm.LoadAsync();
        var page = new AsyncInitializerPage2(vm);
        await Shell.Current.Navigation.PushAsync(page);
    }

    private async void OnAsyncInitializer3ButtonClicked(object sender, EventArgs e)
    {
        var vm = new AsyncInitializerViewModel();
        var page = new AsyncInitializerPage2(vm);
        await Shell.Current.Navigation.PushAsync(page);

        // awaiting the loading of the ViewModel data after showing the page is useful to provide a smoother user experience
        await vm.LoadAsync();
    }

    private async void OnAsyncInitializer4ButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AsyncInitializerPage2));
    }

    private async void OnAsyncFactoryButtonClicked(object sender, EventArgs e)
    {
        var vm = await AsyncFactoryViewModel.CreateNewAsync();
        var page = new AsyncFactoryPage(vm);
        await Shell.Current.Navigation.PushAsync(page);
    }
}