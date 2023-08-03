using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AsyncAwaitConstructors.Examples1.AsyncInitializer;

public partial class AsyncInitializerViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<string> _productList;
    
    // Providing a public method to load the data allows the caller to decide when data is loaded and await the returned Task
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