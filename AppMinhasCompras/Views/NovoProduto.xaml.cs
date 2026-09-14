using AppMinhasCompras.Models;

namespace AppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
    public NovoProduto()
    {
        InitializeComponent();
        dt_dataCadastro.Date = DateTime.Now;
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Produto p = new Produto
            {
                Descricao = txt_descricao.Text,
                Preco = Convert.ToDouble(txt_preço.Text),
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                DataCadastro = dt_dataCadastro.Date.GetValueOrDefault(DateTime.Now)

            };

            await App.Db.InsertProduto(p);
            await DisplayAlert("Foi", "Registro Inserido", "Ok");
            await Navigation.PopAsync();

        }
        catch (Exception ex)
        {
            await DisplayAlert("Naes", ex.Message, "Okay");
        }
    }
}