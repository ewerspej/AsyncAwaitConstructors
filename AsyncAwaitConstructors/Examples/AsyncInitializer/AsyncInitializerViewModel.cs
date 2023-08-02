using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AsyncAwaitConstructors.Examples.AsyncInitializer;

public partial class AsyncInitializerViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<string> _productList = new();

    public AsyncInitializerViewModel() { }

    public async Task LoadAsync()
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