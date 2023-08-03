namespace AsyncAwaitConstructors.Examples1.DiscardedTask;

public partial class DiscardedTaskPage : ContentPage
{
	public DiscardedTaskPage()
	{
		InitializeComponent();

		var vm = new DiscardedTaskViewModel();

        BindingContext = vm;

		// This will have no effect
		vm.AddProduct("Chocolate ice cream");
    }
}