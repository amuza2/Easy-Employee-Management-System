using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EEMS.BusinessLogic.DTOs;
using EEMS.BusinessLogic.Interfaces;
using EEMS.Models.Models;
using EEMS.UI.Views.Account;
using EEMS.UI.Views.Shared.MessageBoxes;
using EEMS.UI.Views.Shared.WindowService;
using System.Windows;

namespace EEMS.UI.ViewModels;

public partial class LoginWindowViewModel : ObservableValidator
{
    private readonly IWindowService _windowService;
    private readonly IAuthService _authService;
    [ObservableProperty] private LoginDto? _account = new();

    public LoginWindowViewModel(IWindowService windowService, IAuthService accountService)
    {
        _windowService = windowService;
        _authService = accountService;
    }

    [RelayCommand]
    private async Task Login()
    {
        if (!string.IsNullOrEmpty(Account?.Username) && !string.IsNullOrEmpty(Account.Password))
        {
            // Perform login logic here
            await DialogService.ShowSingleButtonMessageBoxAsync(
                "You have successfully logged in.",
                "Login",
                "Ok");
        }
        else
        {
            await DialogService.ShowSingleButtonMessageBoxAsync(
                "Please Enter your account details",
                "Login",
                "Ok");
        }

        var result = await _authService.LoginAsync(Account);
    }

    [RelayCommand]
    private void CreateAccount()
    {
        var currentWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
        if(currentWindow != null)
        {
            _windowService.SwitchWindow<SignUpWindow>(currentWindow);
        }
    }
}
