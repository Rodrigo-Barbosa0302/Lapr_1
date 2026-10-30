namespace Idosos;

public partial class DefinicoesPage : ContentPage
{
    public DefinicoesPage()
    {
        InitializeComponent();

        SwVoz.IsToggled = Preferences.Get("ler_voz_alta", false);
        SwSom.IsToggled = Preferences.Get("som_videos", true);
        AtualizarLetras(Preferences.Get("letras_grandes", false));
        AtualizarEstados();
    }

    void AtualizarLetras(bool grande)
    {
        var res = Application.Current!.Resources;
        var primaria = (Color)res["Primaria"];
        var texto = (Color)res["Texto"];

        BtnNormal.Text = grande ? "Normal" : "Normal";
        BtnGrande.Text = grande ? "Grande" : "Grande";

        BtnGrande.BackgroundColor = grande ? primaria : Colors.White;
        BtnGrande.TextColor = grande ? Colors.White : texto;
        BtnNormal.BackgroundColor = grande ? Colors.White : primaria;
        BtnNormal.TextColor = grande ? texto : Colors.White;
    }

    void AtualizarEstados()
    {
        var res = Application.Current!.Resources;
        var primaria = (Color)res["Primaria"];
        var suave = (Color)res["TextoSuave"];

        LblVoz.Text = SwVoz.IsToggled ? "Ligado" : "Desligado";
        LblVoz.TextColor = SwVoz.IsToggled ? primaria : suave;
        LblSom.Text = SwSom.IsToggled ? "Ligado" : "Desligado";
        LblSom.TextColor = SwSom.IsToggled ? primaria : suave;
    }

    void OnNormal(object sender, EventArgs e)
    {
        Preferences.Set("letras_grandes", false);
        AtualizarLetras(false);
    }

    void OnGrande(object sender, EventArgs e)
    {
        Preferences.Set("letras_grandes", true);
        AtualizarLetras(true);
    }

    void OnVozToggled(object sender, ToggledEventArgs e)
    {
        Preferences.Set("ler_voz_alta", e.Value);
        AtualizarEstados();
    }

    void OnSomToggled(object sender, ToggledEventArgs e)
    {
        Preferences.Set("som_videos", e.Value);
        AtualizarEstados();
    }
}