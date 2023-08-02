﻿using CommunityToolkit.Mvvm.ComponentModel;
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
    }

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