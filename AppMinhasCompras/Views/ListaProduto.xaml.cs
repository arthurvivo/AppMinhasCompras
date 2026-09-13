namespace AppMinhasCompras.Views;
using AppMinhasCompras.Models;
using System.Collections.ObjectModel;

public partial class ListaProduto : ContentPage
{
    ObservableCollection<Produto> lista = new ObservableCollection<Produto>();
	public ListaProduto()
	{

		InitializeComponent();
        listView.ItemsSource = lista;
	}

    protected async override void OnAppearing()
    {
        try
        {
            lista.Clear();
            List<Produto> tmp = await App.Db.getAllProdutos();

            tmp.ForEach(i => lista.Add(i));

        }
        catch (Exception ex)
        {
           await DisplayAlert("Erro", ex.Message, "OK");
        }
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            double soma = lista.Sum(i => i.Total);

            string msg = $"O total é {soma:C}";


        }
        catch (Exception ex)
        {
            DisplayAlert("Erro", ex.Message, "OK");
        }

    } 

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new Views.NovoProduto());
        }
        catch (Exception ex)
        {
            DisplayAlert("Erro", ex.Message, "OK");
        }
    }

    private async void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            string q = e.NewTextValue;

            lista.Clear();

            List<Produto> tmp = await App.Db.SearchProduto(q);


            tmp.ForEach(i => lista.Add(i));

        }
        catch (Exception ex)
        {
             await DisplayAlert("Erro", ex.Message, "OK");
        }
    }


    private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            Produto p = e.SelectedItem as Produto;
            Navigation.PushAsync(new Views.EditarProduto
            {
                BindingContext = p
            });
        }
        catch (Exception ex)
        {
            DisplayAlert("Erro", ex.Message, "OK");
        }
    }

    private async void MenuItem_Clicked_1(object sender, EventArgs e)
    {
        try
        {

            MenuItem menuItem = sender as MenuItem;
            Produto p = menuItem.CommandParameter as Produto;

            bool confirm = await DisplayAlert(
                "Confirmar",
                $"Deseja realmente remover {p.Descricao}?",
                "Sim",
                "Não"
            );
            if (confirm)
            {

                await App.Db.DeleteProduto(p.Id);
                lista.Remove(p);
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Erro", ex.Message, "OK");
        }
    }

    private async void listView_Refreshing(object sender, EventArgs e)
    {
        try
        {
            lista.Clear();
            List<Produto> tmp = await App.Db.getAllProdutos();

            tmp.ForEach(i => lista.Add(i));

        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }

    private void ToolbarItem_Clicked_2(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new Views.Relatorio());
        }
        catch (Exception ex)
        {
            DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}