using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AsyncAwaitConstructors.Examples.DiscardedTask;

public partial class DiscardedTaskViewModel : ObservableObject
{
    [ObservableProperty]
    private List<string> _productList;

    public DiscardedTaskViewModel()
    {
        _ = LoadDataAsync();
    }

    private async Task LoadDataAsync()
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