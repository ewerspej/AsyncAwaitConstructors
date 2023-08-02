using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AsyncAwaitConstructors.Examples.AsyncFactory;

public partial class AsyncFactoryViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<string> _productList = new();

    private AsyncFactoryViewModel() {}

    private async Task LoadAsync()
    {
        await Task.Delay(TimeSpan.FromSeconds(2));

        ProductList = new ObservableCollection<string>
        {
            "Sugar", "Milk", "Honey"
        };
    }

    public static async Task<AsyncFactoryViewModel> CreateNewAsync()
    {
        var instance = new AsyncFactoryViewModel();
        await instance.LoadAsync();
        return instance;
    }

    [RelayCommand]
    public void AddProduct(string product)
    {
        ProductList?.Add(product);
    }
}