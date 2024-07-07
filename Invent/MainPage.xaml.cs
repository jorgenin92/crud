
using Invent.Data;
using Invent.Model;
using System.Collections.ObjectModel;

namespace Invent
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Inventario> Items { get; set; } = new();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetInventDB();
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            var items = BaseDatos.GetInventario();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Items.Clear();
                foreach (var item in items)
                    Items.Add(item);

            });
        }

        private void OnAddInventClicked(object sender, EventArgs e)
        {
            Inventario product = new Inventario();
            /*
            if (collectionView.SelectedItem is not null)
            {
                var invent = collectionView.SelectedItem as Inventario;
                if (invent is not null)
                {
                    product = invent as Inventario;
                }
            }
            */
            var navigationParams = new Dictionary<string, object>
            {
                { "Item", product }
            };
            Shell.Current.GoToAsync("InventDetails", navigationParams);

            GetInventDB();
        }

        private void OnUpdateInventClicked(object sender, EventArgs e)
        {
            if (collectionView.SelectedItem is null)
                return;

            var invent = collectionView.SelectedItem as Inventario;
            if (invent is null)
                return;

            var navigationParams = new Dictionary<string, object>
            {
                { "Item", invent }
            };
            Shell.Current.GoToAsync("InventDetails", navigationParams);
            GetInventDB();
            collectionView.SelectedItem = null;
        }

        private void OnDeleteInventClicked(object sender, EventArgs e)
        {
            if (collectionView.SelectedItem is null)
                return;

            var invent = collectionView.SelectedItem as Inventario;
            if (invent is null)
                return;

            BaseDatos.DeleteInventario(invent);
            var items = BaseDatos.GetInventario();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Items.Clear();
                foreach (var item in items)
                    Items.Add(item);

            });
        }

        private void GetInventDB()
        {
            //collectionView.ItemsSource = BaseDatos.GetInventario();
        }
    }

}
