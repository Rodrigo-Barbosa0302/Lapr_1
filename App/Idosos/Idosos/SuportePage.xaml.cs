namespace Idosos;

public partial class SuportePage : ContentPage
{
    public SuportePage()
    {
        InitializeComponent();
    }

    async void OnVerTutoriais(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Tutoriais");
    }
}