using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EEMS.BusinessLogic.DTOs;
using EEMS.BusinessLogic.Interfaces;
using EEMS.Models.Models;
using EEMS.UI.Views.Account;
using EEMS.UI.Views.Shared.MessageBoxes;
using EEMS.UI.Views.Shared.WindowService;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace EEMS.UI.ViewModels;

public partial class SignUpWindowViewModel : ObservableValidator
{
    private readonly IWindowService _windowService;
    private readonly IAuthService _authService;
    [ObservableProperty] [Required] private RegisterDto _account = new();

    public SignUpWindowViewModel(IWindowService windowService, IAuthService authService)
    {
        _windowService = windowService;
        _authService = authService;
    }

    [RelayCommand]
    private async Task SignUp()
    {
        if (!string.IsNullOrEmpty(Account.Username) && !string.IsNullOrEmpty(Account.Email)
            && !string.IsNullOrEmpty(Account.Password) && !string.IsNullOrEmpty(Account.ConfirmPassword)
            && string.Equals(Account.Password, Account.ConfirmPassword, StringComparison.Ordinal))
        {
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
    }


    [RelayCommand]
    private void NavigateToLogin()
    {
        var currentWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
        if(currentWindow != null)
        {
            _windowService.SwitchWindow<LoginWindow>(currentWindow);
        }
    }
}
