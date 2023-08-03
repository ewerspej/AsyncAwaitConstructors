using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AsyncAwaitConstructors.Examples.DiscardedTask;

public partial class DiscardedTaskViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<string> _productList;

    public DiscardedTaskViewModel()
    {
        // The constructor will finish before LoadAsync() has finished, ProductList will not be initialized right after construction
        _ = LoadAsync();

        // This won't work, because loading hasn't finished yet
        AddProduct("Flour");
        AddProduct("Salt");
    }

    // This is bad design, because invoking an asynchronous method in the constructor of the ViewModel hides the fact that something is being loaded asynchronously.
    // We may be inclined to use an async Task instead of async void because async void should be avoided whenever possible, 
    // however in this case it doesn't really make a difference to the caller as the asynchronous work is not being awaited in either case.
    private async Task LoadAsync()
    {
        await Task.Delay(TimeSpan.FromSeconds(2));

        ProductList = new ObservableCollection<string>
        {
            "Sugar", "Milk", "Honey"
        };
    }

    [RelayCommand]
    public void AddProduct(string product)
    {
        ProductList?.Add(product);
    }
}