using Agents.Models;
using System.Linq;
using Avalonia.Controls;


namespace Agents
{
    public partial class CheckHistory : MainWindow
    {
        public int agentIdgl;
        public CheckHistory()
        {
            InitializeComponent();
        }
        public CheckHistory(int agentId) : this()
        {
            agentIdgl = agentId;
            LoadData(agentId);
        }

        private void LoadData(int agentId)
        {
            using var context = new User7Context();
            var items = context.Productsales
                .Where(e => e.Agentid == agentId)
                .Select(e => new
                {
                    Title = e.Product.Title,
                    Date = e.Saledate.ToString("dd.MM.yyyy"),
                    Count = e.Productcount
                }).ToList();

            HistoryListBox.ItemsSource = items;
        }

        private async void AddButton_CLick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            AddNewProduct addingNewProduct1 = new AddNewProduct();
            await addingNewProduct1.ShowDialog(this);
            LoadData(agentIdgl);
            this.Close();
        }
    }
}