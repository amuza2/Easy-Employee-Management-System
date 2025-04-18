using EEMS.UI.Enums;
using EEMS.UI.ViewModels;
using System.Windows;

namespace EEMS.UI.Views.Shared;

public class DialogService
{
    public static async Task<bool> ShowSingleButtonMessageBoxAsync(string message, string title = "Message", string okButtonText = "OK")
    {
        var vm = new SingleButtonMessageBoxViewModel
        {
            Message = message,
            Title = title,
            OkButtonText = okButtonText,
            CloseRequest = new TaskCompletionSource<bool>()
        };

        var window = new SingleButtonMessageBox
        {
            DataContext = vm,
            Owner = Application.Current.MainWindow
        };

        vm.CloseRequest.Task.ContinueWith(_ =>
        {
            window.Dispatcher.Invoke(window.Close);
        });

        window.ShowDialog();

        return await vm.CloseRequest.Task;

        //var tcs = new TaskCompletionSource<bool>();
        //vm.CloseRequest = tcs;
        //return await tcs.Task;
    }

    public static async Task<CustomMessageBoxResult> ShowTwoButtonMessageBoxAsync(string message, string title = "Confirm", string confirmButtonText = "Yes", string cancelButtonText = "No")
    {
        var vm = new TwoButtonMessageBoxViewModel
        {
            Message = message,
            Title = title,
            ConfirmButtonText = confirmButtonText,
            CancelButtonText = cancelButtonText,
            CloseRequest = new TaskCompletionSource<CustomMessageBoxResult>()
        };

        var window = new TowButtonMessageBox
        {
            DataContext = vm,
            Owner = Application.Current.MainWindow
        };

        // Subscribe to close on result
        vm.CloseRequest.Task.ContinueWith(_ =>
        {
            window.Dispatcher.Invoke(window.Close);
        });

        window.ShowDialog();

        return await vm.CloseRequest.Task;

        //var tcs = new TaskCompletionSource<CustomMessageBoxResult>();
        //vm.CloseRequest = tcs;


        //return await tcs.Task;
    }
}
