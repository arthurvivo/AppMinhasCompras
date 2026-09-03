using AppMinhasCompras.Models;

namespace AppMinhasCompras.Views;

public partial class EditarProduto : ContentPage
{
	public EditarProduto()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Produto produto_anexado = BindingContext as Produto

            Produto p = new Produto
            {
                Id = produto_anexado.Id, 
                Descricao = txt_descricao.Text,
                Preco = Convert.ToDouble(txt_preço.Text),
                Quantidade = Convert.ToDouble(txt_quantidade.Text)

            };

            await App.Db.UpdateProduto(p);
            await DisplayAlertAsync("Foi", "Registro Atualizado", "Ok");
            Navigation.PopAsync();

        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Naes", ex.Message, "Okay");
        }
    }
}