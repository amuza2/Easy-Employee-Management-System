using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace EEMS.UI.ViewModels;

public partial class SingleButtonMessageBoxViewModel : ObservableObject
{
    [ObservableProperty] private string _message;
    [ObservableProperty] private string _title;
    [ObservableProperty] private string _okButtonText;
    
    public TaskCompletionSource<bool> CloseRequest { get; set; }
    
    [RelayCommand]
    private void Ok()
    {
        CloseRequest?.TrySetResult(true);
    }
}
