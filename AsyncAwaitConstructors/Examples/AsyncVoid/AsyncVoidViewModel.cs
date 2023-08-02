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
        // The constructor will finish before LoadData() has finished, ProductList will not be initialized right after construction
        LoadData();
    }

    private async void LoadData()
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