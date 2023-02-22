using MagazineEchipamente.Models;
namespace MagazineEchipamente;

public partial class MagazinPage : ContentPage
{
    public MagazinPage()
	{
		InitializeComponent();
	}

    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EchipamentPage((Magazin)
       this.BindingContext)
        {
            BindingContext = new Echipament()
        });

    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Magazin)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveMagazinAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Magazin)BindingContext;
        await App.Database.DeleteMagazinAsync(slist);
        await Navigation.PopAsync();
    }

    async void OnDeleteItemButtonClicked(object sender, EventArgs e)
    {
        Echipament Echipament;
        var Magazin = (Magazin)BindingContext;
        if(listView.SelectedItem != null)
        {
            Echipament = listView.SelectedItem as Echipament;
            var ListaMagazineAll = await App.Database.GetListaMagazines();
            var ListaMagazine = ListaMagazineAll.FindAll(x => x.EchipamentID == Echipament.ID & x.MagazinID == Magazin.ID);
            await App.Database.DeleteListaMagazineAsync(ListaMagazine.FirstOrDefault());
            await Navigation.PopAsync();
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (Magazin)BindingContext;

        listView.ItemsSource = await App.Database.GetListaMagazinesAsync(shopl.ID);
    }

}