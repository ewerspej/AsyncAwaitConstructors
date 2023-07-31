namespace AsyncAwaitConstructors.Examples.AsyncVoid;

public partial class AsyncVoidPage : ContentPage
{
	public AsyncVoidPage()
	{
		InitializeComponent();

		var vm = new AsyncVoidViewModel();

        BindingContext = vm;

		// This will have no effect
		vm.AddProduct("Vanilla ice cream");
    }
}