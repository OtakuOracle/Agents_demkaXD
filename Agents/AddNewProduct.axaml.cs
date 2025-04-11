using Agents.Models;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Linq;

namespace Agents;

public partial class AddNewProduct : MainWindow
{
    public User7Context context = new User7Context();
    public AddNewProduct()
    {
        InitializeComponent();

        AgentsCombobox.ItemsSource = context.Agents.
            Select(e => e.Title)
            .OrderBy(e => e).ToList();
        ProductCombobox.ItemsSource = context.Products.Select(e => e.Title).OrderBy(e => e).ToList();
    }

    private void AddProductClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        string agent = AgentsCombobox.SelectedItem.ToString();
        string product = ProductCombobox.SelectedItem.ToString();
        DateOnly date = DateOnly.Parse(DataBox.Text);
        int count = int.Parse(CountBox.Text);

        int agentId = context.Agents.FirstOrDefault(e => e.Title == agent).Id;
        int productId = context.Products.FirstOrDefault(e => e.Title == product).Id;

        context.Productsales.Add(new  Productsale 
        {
            Id = context.Productsales.Select(e => e.Id).Count() + 1,
            Productid = productId,
            Agentid = agentId,
            Saledate = date,
            Productcount = count
        });
        context.SaveChanges();
        CheckHistory checkHistory = new CheckHistory();
    }
}
