using Agents.Models;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Numerics;

namespace Agents;

public partial class AddNewAgent : MainWindow
{
    public bool isnew;
    public Agent partner1;
    public int idNewAgent = -1;
    public bool checkUpdate { get; private set; }

    public bool IsButtonVisible { get; set; } = true;

    public AddNewAgent()
    {
        isnew = true;
        InitializeComponent();
        checkUpdate = false;
    }

    public AddNewAgent(Agent partner)
    {
        IsButtonVisible = false;
        using var context = new User7Context();

        isnew = false;
        InitializeComponent();
        gridEdit.DataContext = partner;
        partner1 = partner;

        type.SelectedItem = context.Agenttypes.FirstOrDefault(e => e.Title == partner.Title);
        title.Text = partner.Title;
        inn.Text = partner.Inn;
        phone.Text = partner.Phone;
        mail.Text = partner.Email;
        addres.Text = partner.Address;
        priority.Text = partner.Priority.ToString();
        kpp.Text = partner.Kpp;
        name.Text = partner.Directorname;

        idNewAgent = partner.Id;
        checkUpdate = false;

    }

    private void OkButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        bool check = true;
        using var context = new User7Context();


        if (title.Text.Length == 0)
        {

            var dialog = new Window
            {
                Title = "Ошибка",
                Content = new TextBlock { Text = "Заголовок не может быть пустым" },
                SizeToContent = SizeToContent.WidthAndHeight,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            dialog.ShowDialog(this);
        }

        if (inn.Text.Length == 0)
        {
            var dialog = new Window
            {
                Title = "Ошибка",
                Content = new TextBlock { Text = "Инн не заполнен" },
                SizeToContent = SizeToContent.WidthAndHeight,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            dialog.ShowDialog(this);
        }


        if (phone.Text.Length == 0)
        {
            var dialog = new Window
            {
                Title = "Ошибка",
                Content = new TextBlock { Text = "Номер телефона не заполнен" },
                SizeToContent = SizeToContent.WidthAndHeight,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            dialog.ShowDialog(this);
        }

        if (mail.Text.Length == 0)
        {
            var dialog = new Window
            {
                Title = "Ошибка",
                Content = new TextBlock { Text = "Почта не заполнена" },
                SizeToContent = SizeToContent.WidthAndHeight,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            dialog.ShowDialog(this);
        }

        if (addres.Text.Length == 0)
        {
            var dialog = new Window
            {
                Title = "Ошибка",
                Content = new TextBlock { Text = "Адрес не заполнен" },
                SizeToContent = SizeToContent.WidthAndHeight,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            dialog.ShowDialog(this);
        }


        if (priority.Text.Length == 0)
        {
            var dialog = new Window
            {
                Title = "Ошибка",
                Content = new TextBlock { Text = "Приоритет не заполнен" },
                SizeToContent = SizeToContent.WidthAndHeight,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            dialog.ShowDialog(this);
        }

        if (kpp.Text.Length == 0)
        {
            var dialog = new Window
            {
                Title = "Ошибка",
                Content = new TextBlock { Text = "Кпп не заполнен" },
                SizeToContent = SizeToContent.WidthAndHeight,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            dialog.ShowDialog(this);
        }

        if (name.Text.Length == 0)
        {
            var dialog = new Window
            {
                Title = "Ошибка",
                Content = new TextBlock { Text = "Поле имя не заполнено" },
                SizeToContent = SizeToContent.WidthAndHeight,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            dialog.ShowDialog(this);
        }


        if (isnew)
        {
            var newAgent = new Agent
            {
                Title = title.Text,
                Inn = inn.Text,
                Phone = phone.Text,
                Email = mail.Text,
                Address = addres.Text,
                Priority = int.Parse(priority.Text),
                Kpp = kpp.Text,
                Directorname = name.Text,
                Agenttypeid = (type.SelectedItem as Agenttype)?.Id ?? 1
            };

            idNewAgent = newAgent.Id;

            context.Agents.Add(newAgent);
        }
        else
        {
            var existingAgent = context.Agents.FirstOrDefault(e => e.Id == idNewAgent);
            if (existingAgent == null)
            {
                ShowError("Агент не найден");
                return;
            }

            existingAgent.Title = title.Text;
            existingAgent.Inn = inn.Text;
            existingAgent.Phone = phone.Text;
            existingAgent.Email = mail.Text;
            existingAgent.Address = addres.Text;
            existingAgent.Priority = int.Parse(priority.Text);
            existingAgent.Kpp = kpp.Text;
            existingAgent.Directorname = name.Text;
            existingAgent.Agenttypeid = (type.SelectedItem as Agenttype)?.Id ?? existingAgent.Agenttypeid;

            context.Update(existingAgent);
        }

        context.SaveChanges();
        checkUpdate = true;
        Close(this);
        MainWindow mainWindow = new MainWindow();
    }

    private void ShowError(string message)
    {
        var dialog = new Window
        {
            Title = "Ошибка",
            Content = new TextBlock { Text = message },
            SizeToContent = SizeToContent.WidthAndHeight,
            WindowStartupLocation = WindowStartupLocation.CenterScreen
        };
        dialog.ShowDialog(this);
    }

    private void Exit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show(this);
        Close(this);
    }
    private void Hisory_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        CheckHistory checkHistory = new CheckHistory(idNewAgent);
        checkHistory.Show();
    }

}
