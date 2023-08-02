namespace AsyncAwaitConstructors.Examples.AsyncInitializer;

public partial class AsyncInitializerPage2 : ContentPage
{
	public AsyncInitializerPage2(AsyncInitializerViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;

        // may or may not work, depends on whether the ViewModel was fully initialized already or not
        viewModel.AddProduct("Pistachio ice cream");
    }
}