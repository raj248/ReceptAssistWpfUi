using Wpf.Ui.Common.Interfaces;

namespace UiDesktopApp1.Views.Pages;
/// <summary>
/// Interaction logic for DashboardPage.xaml
/// </summary>
public partial class HomePage : INavigableView<ViewModels.HomeViewModel>
{
    public ViewModels.HomeViewModel ViewModel
    {
        get;
    }

    public HomePage(ViewModels.HomeViewModel viewModel)
    {
        ViewModel = viewModel;

        InitializeComponent();
    }
}