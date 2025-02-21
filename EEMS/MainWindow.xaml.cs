using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EEMS;

/// <summary>
    /// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
public MainWindow()
{
InitializeComponent();
        var converter = new BrushConverter();
        ObservableCollection<Member> members = new ObservableCollection<Member>();

        members.Add(new Member { Number = "1", Character="J", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "John Doe", Position = "Couch", Email = "JohnDeo@gmail.com", Phone = "123456" });
        members.Add(new Member { Number = "2", Character="R", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Amine Bota", Position = "Teacher", Email = "Aminebota@gmail.com", Phone = "54561231" });
        members.Add(new Member { Number = "3", Character="B", BgColor = (Brush)converter.ConvertFromString("#ff8f00"), Name = "Reza Alavi", Position = "Administration", Email = "Fati@gmail.com", Phone = "1548215" });
        members.Add(new Member { Number = "4", Character="C", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Babriel cox", Position = "Accountant", Email = "foo@gmail.com", Phone = "231560548" });
        members.Add(new Member { Number = "5", Character="E", BgColor = (Brush)converter.ConvertFromString("#6741d9"), Name = "Sarah Vox", Position = "Manager", Email = "dance@gmail.com", Phone = "12341564" });
        members.Add(new Member { Number = "6", Character="U", BgColor = (Brush)converter.ConvertFromString("#ff6f00"), Name = "Lie Area", Position = "Programmer", Email = "read@gmail.com", Phone = "23154860" });
        members.Add(new Member { Number = "7", Character="L", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Sarah Flower", Position = "Desiger", Email = "smart@gmail.com", Phone = "20200245" });
        members.Add(new Member { Number = "8", Character="N", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Marry Cary", Position = "Tester", Email = "small@gmail.com", Phone = "23415610" });
        members.Add(new Member { Number = "9", Character="X", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Tim Corey", Position = "Staff", Email = "balance@gmail.com", Phone = "02414560" });
        members.Add(new Member { Number = "10", Character="P", BgColor =(Brush)converter.ConvertFromString("#0ca678"), Name = "Sweet Cake", Position = "Youtuber", Email = "sweet@gmail.com", Phone = "024346029" });


        members.Add(new Member { Number = "1", Character = "J", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "John Doe", Position = "Couch", Email = "JohnDeo@gmail.com", Phone = "123456" });
        members.Add(new Member { Number = "2", Character = "R", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Amine Bota", Position = "Teacher", Email = "Aminebota@gmail.com", Phone = "54561231" });
        members.Add(new Member { Number = "3", Character = "B", BgColor = (Brush)converter.ConvertFromString("#ff8f00"), Name = "Reza Alavi", Position = "Administration", Email = "Fati@gmail.com", Phone = "1548215" });
        members.Add(new Member { Number = "4", Character = "C", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Babriel cox", Position = "Accountant", Email = "foo@gmail.com", Phone = "231560548" });
        members.Add(new Member { Number = "5", Character = "E", BgColor = (Brush)converter.ConvertFromString("#6741d9"), Name = "Sarah Vox", Position = "Manager", Email = "dance@gmail.com", Phone = "12341564" });
        members.Add(new Member { Number = "6", Character = "U", BgColor = (Brush)converter.ConvertFromString("#ff6f00"), Name = "Lie Area", Position = "Programmer", Email = "read@gmail.com", Phone = "23154860" });
        members.Add(new Member { Number = "7", Character = "L", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Sarah Flower", Position = "Desiger", Email = "smart@gmail.com", Phone = "20200245" });
        members.Add(new Member { Number = "8", Character = "N", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Marry Cary", Position = "Tester", Email = "small@gmail.com", Phone = "23415610" });
        members.Add(new Member { Number = "9", Character = "X", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Tim Corey", Position = "Staff", Email = "balance@gmail.com", Phone = "02414560" });
        members.Add(new Member { Number = "10", Character = "P", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Sweet Cake", Position = "Youtuber", Email = "sweet@gmail.com", Phone = "024346029" });

        members.Add(new Member { Number = "1", Character = "J", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "John Doe", Position = "Couch", Email = "JohnDeo@gmail.com", Phone = "123456" });
        members.Add(new Member { Number = "2", Character = "R", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Amine Bota", Position = "Teacher", Email = "Aminebota@gmail.com", Phone = "54561231" });
        members.Add(new Member { Number = "3", Character = "B", BgColor = (Brush)converter.ConvertFromString("#ff8f00"), Name = "Reza Alavi", Position = "Administration", Email = "Fati@gmail.com", Phone = "1548215" });
        members.Add(new Member { Number = "4", Character = "C", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Babriel cox", Position = "Accountant", Email = "foo@gmail.com", Phone = "231560548" });
        members.Add(new Member { Number = "5", Character = "E", BgColor = (Brush)converter.ConvertFromString("#6741d9"), Name = "Sarah Vox", Position = "Manager", Email = "dance@gmail.com", Phone = "12341564" });
        members.Add(new Member { Number = "6", Character = "U", BgColor = (Brush)converter.ConvertFromString("#ff6f00"), Name = "Lie Area", Position = "Programmer", Email = "read@gmail.com", Phone = "23154860" });
        members.Add(new Member { Number = "7", Character = "L", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Sarah Flower", Position = "Desiger", Email = "smart@gmail.com", Phone = "20200245" });
        members.Add(new Member { Number = "8", Character = "N", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Marry Cary", Position = "Tester", Email = "small@gmail.com", Phone = "23415610" });
        members.Add(new Member { Number = "9", Character = "X", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Tim Corey", Position = "Staff", Email = "balance@gmail.com", Phone = "02414560" });
        members.Add(new Member { Number = "10", Character = "P", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Sweet Cake", Position = "Youtuber", Email = "sweet@gmail.com", Phone = "024346029" });

        members.Add(new Member { Number = "1", Character = "J", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "John Doe", Position = "Couch", Email = "JohnDeo@gmail.com", Phone = "123456" });
        members.Add(new Member { Number = "2", Character = "R", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Amine Bota", Position = "Teacher", Email = "Aminebota@gmail.com", Phone = "54561231" });
        members.Add(new Member { Number = "3", Character = "B", BgColor = (Brush)converter.ConvertFromString("#ff8f00"), Name = "Reza Alavi", Position = "Administration", Email = "Fati@gmail.com", Phone = "1548215" });
        members.Add(new Member { Number = "4", Character = "C", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Babriel cox", Position = "Accountant", Email = "foo@gmail.com", Phone = "231560548" });
        members.Add(new Member { Number = "5", Character = "E", BgColor = (Brush)converter.ConvertFromString("#6741d9"), Name = "Sarah Vox", Position = "Manager", Email = "dance@gmail.com", Phone = "12341564" });
        members.Add(new Member { Number = "6", Character = "U", BgColor = (Brush)converter.ConvertFromString("#ff6f00"), Name = "Lie Area", Position = "Programmer", Email = "read@gmail.com", Phone = "23154860" });
        members.Add(new Member { Number = "7", Character = "L", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Sarah Flower", Position = "Desiger", Email = "smart@gmail.com", Phone = "20200245" });
        members.Add(new Member { Number = "8", Character = "N", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Marry Cary", Position = "Tester", Email = "small@gmail.com", Phone = "23415610" });
        members.Add(new Member { Number = "9", Character = "X", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Tim Corey", Position = "Staff", Email = "balance@gmail.com", Phone = "02414560" });
        members.Add(new Member { Number = "10", Character = "P", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Sweet Cake", Position = "Youtuber", Email = "sweet@gmail.com", Phone = "024346029" });

        membersDataGrid.ItemsSource = members;


    }






    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left) this.DragMove();
    }

    private bool IsMaximized = false;
    private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ClickCount == 2)
        {
            if (IsMaximized)
            {
                this.WindowState = WindowState.Normal;
                Width = 1600;
                Height = 900;

                IsMaximized = false;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }
    }

    private void CheckBox_Checked(object sender, RoutedEventArgs e)
    {

    }
}

public class Member
{
    public string Character { get; set; }
    public string Number { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Brush BgColor { get; set; }
}