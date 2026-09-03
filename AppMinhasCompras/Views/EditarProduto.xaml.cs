<ContentPage x:Class="AppMinhasCompras.Views.EditarProduto"
             xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml">
  <StackLayout>
    <Entry x:Name="txt_descricao"   Text="{Binding Descricao}"     Placeholder="Descrição" />
    <Entry x:Name="txt_preco"       Text="{Binding Preco}"         Keyboard="Numeric" Placeholder="Preço" />
    <Entry x:Name="txt_quantidade"  Text="{Binding Quantidade}"    Keyboard="Numeric" Placeholder="Quantidade" />
  </StackLayout>
</ContentPage>