﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Wpf.Ui.Common.Interfaces;

namespace UiDesktopApp1.ViewModels;

public partial class HomeViewModel : ObservableObject, INavigationAware
{
    [ObservableProperty]
    private int _counter = 0;
    public void OnNavigatedTo()
    {
    }

    public void OnNavigatedFrom()
    {
    }

    [RelayCommand]
    private void OnCounterIncrement()
    {
        Counter++;
    }
}
