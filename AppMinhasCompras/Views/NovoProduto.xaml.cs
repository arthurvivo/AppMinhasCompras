using AppMinhasCompras.Models;

namespace AppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Produto p = new Produto
            {
                Descricao = txt_descricao.Text,
                Preco = Convert.ToDouble(txt_preço.Text),
                Quantidade = Convert.ToDouble(txt_quantidade.Text)

            };

            await App.Db.InsertProduto(p);
            await DisplayAlertAsync("Foi", "Registro Inserido", "Ok");
            await Navigation.PopAsync();

        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Naes", ex.Message, "Okay");
        }
    }
}