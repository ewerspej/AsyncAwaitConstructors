using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AsyncAwaitConstructors.Examples.AsyncVoid;

public partial class AsyncVoidViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<string> _productList;

    public AsyncVoidViewModel()
    {
        // The constructor will finish before Load() has finished, ProductList will not be initialized right after construction
        Load();

        // This won't work, because loading hasn't finished yet
        AddProduct("Flour");
        AddProduct("Salt");
    }

    // This is bad design, because calling an async void method in the constructor of the ViewModel hides the fact that something is being loaded asynchronously
    private async void Load()
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