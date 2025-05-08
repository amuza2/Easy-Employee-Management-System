using EEMS.UI.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace EEMS.UI.Views.Absences;

/// <summary>
/// Interaction logic for Absence.xaml
/// </summary>
public partial class AbsenceWindow : Window
{
    public AbsenceWindow(AbsenceWindowViewModel employeeAbsenceViewModel)
    {
        InitializeComponent();
        DataContext = employeeAbsenceViewModel;
    }

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left) this.DragMove();
    }

    private void btnExit_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}
