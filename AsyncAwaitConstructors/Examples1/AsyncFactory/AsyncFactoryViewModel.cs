﻿using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AsyncAwaitConstructors.Examples1.AsyncFactory;

public partial class AsyncFactoryViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<string> _productList;

    // In order to prevent callers from instantiating the ViewModel directly, we change the visibility of the default constructor to private.
    // This forces callers to use the CreateNewAsync() factory method, which already loads the data.
    private AsyncFactoryViewModel() {}

    private async Task LoadAsync()
    {
        await Task.Delay(TimeSpan.FromSeconds(2));

        ProductList = new ObservableCollection<string>
        {
            "Sugar", "Milk", "Honey"
        };
    }

    // This pattern is very useful in order to avoid writing async void methods and calling asynchronous methods in constructors in general.
    // One downside of this approach is that the created object is only available to the caller after the asynchronous loading task finished,
    // which also means that it won't work with Shell's dependency injection, because only synchronous factory methods are possible.
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