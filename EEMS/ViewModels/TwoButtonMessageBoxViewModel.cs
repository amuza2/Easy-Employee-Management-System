using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EEMS.UI.Enums;

namespace EEMS.UI.ViewModels;

public partial class TwoButtonMessageBoxViewModel : ObservableObject
{
    [ObservableProperty] private string _message;

    [ObservableProperty] private string _title;

    [ObservableProperty] private string _confirmButtonText;

    [ObservableProperty] private string _cancelButtonText;

    public TaskCompletionSource<CustomMessageBoxResult> CloseRequest { get; set; }

    [RelayCommand]
    private void Confirm()
    {
        CloseRequest?.TrySetResult(CustomMessageBoxResult.Confirmed);
    }

    [RelayCommand]
    private void Cancel()
    {
        CloseRequest?.TrySetResult(CustomMessageBoxResult.Cancelled);
    }
}
