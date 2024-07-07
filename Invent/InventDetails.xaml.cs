using Invent.Data;
using Invent.Model;

namespace Invent;

[QueryProperty("Item", "Item")]
public partial class InventDetails : ContentPage
{
    protected Inventario item;
    public Inventario Item
    {
        get => BindingContext as Inventario;
        set => BindingContext = value;
    }

    public InventDetails()
	{
		InitializeComponent();
    }

    async void OnSaveClicked(object sender, EventArgs e)
    {
        if (Item.id_prod < 1)
        {
            await DisplayAlert("Invent", "Ingresa un Id valido.", "OK");
            return;
        }
        if (string.IsNullOrWhiteSpace(Item.descripcion))
        {
            await DisplayAlert("Invent", "Ingresa la descripción.", "OK");
            return;
        }

        if (Item.id_unico == 0)
        {
            BaseDatos.InsertInventario(Item);
        }
        else
        {
            BaseDatos.DeleteInventario(Item);
        }

        await Shell.Current.GoToAsync("..");
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (Item.id_unico == 0)
            return;

        BaseDatos.DeleteInventario(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}