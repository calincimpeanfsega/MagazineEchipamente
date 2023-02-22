using MagazineEchipamente.Models;

namespace MagazineEchipamente;

public partial class ListaMagazinePage : ContentPage
{
	public ListaMagazinePage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetMagazinsAsync();
    }
    async void OnMagazinAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MagazinPage
        {
            BindingContext = new Magazin()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new MagazinPage
            {
                BindingContext = e.SelectedItem as Magazin
            });
        }
    }
}