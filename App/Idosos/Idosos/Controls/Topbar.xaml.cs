namespace Idosos.Controls;

public partial class TopBar : ContentView
{
    public static readonly BindableProperty ActiveProperty =
        BindableProperty.Create(nameof(Active), typeof(string), typeof(TopBar), "Inicio",
            propertyChanged: (b, o, n) => ((TopBar)b).Refresh());

    public string Active
    {
        get => (string)GetValue(ActiveProperty);
        set => SetValue(ActiveProperty, value);
    }

    public TopBar()
    {
        InitializeComponent();
        Refresh();
    }

    void Refresh()
    {
        Apply(LblInicio, BarInicio, "Inicio");
        Apply(LblTutoriais, BarTutoriais, "Tutoriais");
        Apply(LblSuporte, BarSuporte, "Suporte");
        Apply(LblDefinicoes, BarDefinicoes, "Definicoes");
    }

    void Apply(Label label, BoxView bar, string key)
    {
        bool ativo = Active == key;
        var res = Application.Current!.Resources;
        label.TextColor = (Color)res[ativo ? "Primaria" : "Texto"];
        label.FontAttributes = ativo ? FontAttributes.Bold : FontAttributes.None;
        bar.IsVisible = ativo;
    }

    async void OnTabTapped(object sender, TappedEventArgs e)
    {
        var rota = (string)e.Parameter!;
        if (rota != Active)
            await Shell.Current.GoToAsync($"//{rota}");
    }
}