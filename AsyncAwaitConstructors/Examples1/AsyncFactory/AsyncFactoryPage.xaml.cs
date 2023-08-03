namespace AsyncAwaitConstructors.Examples1.AsyncFactory;

public partial class AsyncFactoryPage : ContentPage
{
    public AsyncFactoryPage(AsyncFactoryViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

        // this works, because the ViewModel is already initialized
        viewModel.AddProduct("Cookie dough ice cream");
    }
}