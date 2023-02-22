using MagazineEchipamente.Models;

namespace MagazineEchipamente;

public partial class EchipamentPage : ContentPage
{
    Magazin sl;
    public EchipamentPage(Magazin slist)
    {
        InitializeComponent();
        sl = slist;

    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var Echipament = (Echipament)BindingContext;
        await App.Database.SaveEchipamentAsync(Echipament);
        listView.ItemsSource = await App.Database.GetEchipamentsAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var Echipament = (Echipament)BindingContext;
        await App.Database.DeleteEchipamentAsync(Echipament);
        listView.ItemsSource = await App.Database.GetEchipamentsAsync();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetEchipamentsAsync();
    }

    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Echipament p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Echipament;
            var lp = new ListaMagazine()
            {
                MagazinID = sl.ID,
                EchipamentID = p.ID
            };
            await App.Database.SaveListaMagazineAsync(lp);
            p.ListaMagazines = new List<ListaMagazine> { lp };
            await Navigation.PopAsync();
        }
    }


       
}
