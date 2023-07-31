using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AsyncAwaitConstructors.Examples.AsyncVoid;

public partial class AsyncVoidViewModel : ObservableObject
{
    [ObservableProperty]
    private List<string> _productList;

    public AsyncVoidViewModel()
    {
        LoadData();
    }

    private async void LoadData()
    {
        await Task.Delay(TimeSpan.FromSeconds(2));

        ProductList = new List<string>
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