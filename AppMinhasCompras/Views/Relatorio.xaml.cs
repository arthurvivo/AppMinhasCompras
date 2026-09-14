using AppMinhasCompras.Models;
using System.Collections.ObjectModel;

namespace AppMinhasCompras.Views;

public partial class Relatorio : ContentPage
{
    ObservableCollection<Produto> listaRelatorio = new ObservableCollection<Produto>();

    public Relatorio()
    {
        InitializeComponent();
        listView.ItemsSource = listaRelatorio;

        dt_inicio.Date = DateTime.Now.AddDays(-7);
        dt_fim.Date = DateTime.Now;
    }

    private async void btn_Filtrar_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (dt_inicio.Date > dt_fim.Date)
            {
                await DisplayAlert("Erro", "A data inicial não pode ser maior que a data final", "OK");
                return;
            }

            listaRelatorio.Clear();

            List<Produto> tmp = await App.Db.GetProdutosPorPeriodo(
                dt_inicio.Date.GetValueOrDefault(DateTime.Now),
                dt_fim.Date.GetValueOrDefault(DateTime.Now)
            );

            tmp.ForEach(i => listaRelatorio.Add(i));

            double soma = tmp.Sum(i => i.Total);
            lbl_total.Text = $"Total no período: {soma:C} ({tmp.Count} produto(s))";
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}