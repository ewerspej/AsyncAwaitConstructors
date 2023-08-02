namespace AsyncAwaitConstructors.Examples.AsyncInitializer;

public partial class AsyncInitializerPage : ContentPage
{
    private readonly AsyncInitializerViewModel _viewModel;

	public AsyncInitializerPage()
	{
		InitializeComponent();

		BindingContext = _viewModel = new AsyncInitializerViewModel();

        // will work, but will be overwritten by LoadAsync() call
        _viewModel.AddProduct("Pizza");
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // problem: we load the data every time the page appears on screen, which is not ideal and often not wanted
        await _viewModel.LoadAsync();

        // will work, because it's called after the ViewModel has been initialized
        _viewModel.AddProduct("Strawberry ice cream");
    }
}